using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        ShopEntities Entity = new ShopEntities();
        public ObservableCollection<Product> Data { get; set; } = new ObservableCollection<Product>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Entity.Products.Load();
            Data = Entity.Products.Local;
            Entity.Suppliers.Load();
        }

        private string search;
        public string Search
        {
                get => search; 
                set => Set(ref search, value); 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void Set<T>(ref T field, T value, [CallerMemberName]string prop = "")
        {
            field = value;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
            productList.ItemsSource= (Resources[Data] as CollectionViewSource).View;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void txtSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = search;
            Data = new ObservableCollection<Product>(Entity.Products.Local.Where(x => x.ProductName.ToLower().Contains($"{value}".ToLower())).ToList());
            productList.ItemsSource = Data;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow window = new AddEditWindow();
            window.SupplierCollection = new Collection<Supplier>(Entity.Suppliers.Local);
            window.ShowDialog();
            if (window.Product!=null)
            {
                Data.Add(window.Product);
                Entity.SaveChanges();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
           MessageBoxResult choice= MessageBox.Show("Are you sure you want to permanently delete this item?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (choice == MessageBoxResult.Yes)
            {
                var obj = ((Button)sender).DataContext as Product;
                Data.Remove(obj);
                Entity.SaveChanges();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
