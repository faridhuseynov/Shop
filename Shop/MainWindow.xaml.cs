using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Prod> prods { get; set; } = new ObservableCollection<Prod>();
        public class Prod
        {
            public string ProductName { get; set; }
            public Nullable<decimal> UnitPrice { get; set; }
            public string Package { get; set; }
            public string Suppl { get; set; }
            public bool IsDiscounted { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            prods.Add(new Prod
            {
                ProductName = "exotic liq",
                UnitPrice = 50,
                Package = "10 boxes",
                Suppl = "Chai",
                IsDiscounted = true
            });
            prods.Add(new Prod
            {
                ProductName = "Coffee",
                UnitPrice = 40,
                Package = "Nescafe light",
                Suppl = "Nescafe",
                IsDiscounted = false
            });
        }


    }
}
