using System.Collections.Generic;
using System.Windows.Controls;
using WPFModernVerticalMenu.Model;
using WPFModernVerticalMenu.Services;
using System.Threading.Tasks;
using System.Windows;
using System;

namespace WPFModernVerticalMenu.Pages
{
    public partial class ProductsPage : Page
    {
        private readonly ApiService apiService = new ApiService();
        private Product selectedProduct;
        private List<Category> categories;

        public ProductsPage()
        {
            InitializeComponent();
            LoadCategoriesAndProducts();
        }

        private async void LoadCategoriesAndProducts()
        {
            await LoadCategories();
            await LoadProducts();
        }

        private async Task LoadCategories()
        {
            categories = await apiService.GetCategories();
            ProductCategoryComboBox.ItemsSource = categories;
        }

        private async Task LoadProducts()
        {
            var products = await apiService.GetProducts();
            foreach (var product in products)
            {
                product.CategoryName = categories?.Find(c => c.Id == product.CategoryId)?.Name;
            }
            DataGridProduits.ItemsSource = products;
        }

        private async void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            string productName = ProductNameTextBox.Text;
            string productPriceText = ProductPriceTextBox.Text;
            Console.WriteLine($"Adding product: Name={productName}, Price={productPriceText}, CategoryId={ProductCategoryComboBox.SelectedValue}");

            if (ProductCategoryComboBox.SelectedValue is int categoryId && !string.IsNullOrWhiteSpace(productName) && decimal.TryParse(productPriceText, out decimal productPrice))
            {
                var product = new Product { Name = productName, Price = productPrice, CategoryId = categoryId };
                await apiService.AddProduct(product);
                await LoadProducts();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Veuillez remplir correctement tous les champs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }






        private async void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct != null)
            {
                string productName = ProductNameTextBox.Text;
                string productPriceText = ProductPriceTextBox.Text;
                Console.WriteLine($"Updating product: Id={selectedProduct.Id}, Name={productName}, Price={productPriceText}, CategoryId={ProductCategoryComboBox.SelectedValue}");

                if (ProductCategoryComboBox.SelectedValue is int categoryId && !string.IsNullOrWhiteSpace(productName) && decimal.TryParse(productPriceText, out decimal productPrice))
                {
                    selectedProduct.Name = productName;
                    selectedProduct.Price = productPrice;
                    selectedProduct.CategoryId = categoryId;
                    await apiService.UpdateProduct(selectedProduct);
                    await LoadProducts();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Veuillez remplir correctement tous les champs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un produit à modifier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private async void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct != null)
            {
                await apiService.DeleteProduct(selectedProduct.Id);
                await LoadProducts();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un produit à supprimer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DataGridProduits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridProduits.SelectedItem is Product product)
            {
                selectedProduct = product;
                ProductNameTextBox.Text = product.Name;
                ProductPriceTextBox.Text = product.Price.ToString();
                ProductCategoryComboBox.SelectedValue = product.CategoryId;
            }
        }

        private void ClearFields()
        {
            selectedProduct = null;
            ProductNameTextBox.Text = string.Empty;
            ProductPriceTextBox.Text = string.Empty;
            ProductCategoryComboBox.SelectedIndex = -1;
        }
    }
}
