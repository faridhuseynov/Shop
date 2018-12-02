using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Shop
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window, INotifyPropertyChanged
    {
        public AddEditWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public ICollection<Supplier> SupplierCollection { get; set; }
        public int MyProperty { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public Product Product;

        private string prodName;
        public string ProdName
        {
            get => prodName;
            set => Set(ref prodName, value);
        }

        private decimal unitPrice;
        public decimal UnitPrice
        {
            get=>unitPrice;
            set => Set(ref unitPrice, value);
        }

        private string package;
        public string Package
        {
            get => package;
            set => Set(ref package, value);
        }



        public void Set<T>(ref T field, T value, [CallerMemberName]string prop = "")
        {
            field = value;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text) || 
                string.IsNullOrWhiteSpace(tbPrice.Text) ||
                string.IsNullOrWhiteSpace(tbPackage.Text))
            {
                MessageBox.Show("Missing information, please fill in all fields", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Product = new Product
                {
                    ProductName = ProdName,
                    UnitPrice = UnitPrice,
                    Package = Package,
                    IsDiscontinued = cbDiscontinued.IsChecked.Value,
                    Supplier = cbSupplier.SelectedValue as Supplier
                };
                Close();
            }
        }
    }
}
