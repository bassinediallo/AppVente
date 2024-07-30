using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFModernVerticalMenu.Pages;

namespace WPFModernVerticalMenu
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        // Start: MenuLeft PopupButton //
        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new ProductsPage());
        }

        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new CategoriesPage());
        }
        private void btnProducts_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Ajoutez ici le code pour gérer l'événement MouseEnter pour le bouton Produits
        }

        private void btnProducts_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Ajoutez ici le code pour gérer l'événement MouseLeave pour le bouton Produits
        }

        private void btnCategories_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Ajoutez ici le code pour gérer l'événement MouseEnter pour le bouton Catégories
        }

        private void btnCategories_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Ajoutez ici le code pour gérer l'événement MouseLeave pour le bouton Catégories
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }






    }


        
}
