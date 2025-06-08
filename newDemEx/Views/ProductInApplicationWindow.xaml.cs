using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using newDemEx.BaseModel;

namespace newDemEx.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductInApplicationWindow.xaml
    /// </summary>
    public partial class ProductInApplicationWindow : Window
    {
        private readonly sdvgEntities _db = new sdvgEntities().GetContext();
        
        public ProductInApplicationWindow(int partnerId)
        {
            InitializeComponent();
            LoadPartnerProduct(partnerId);
        }

        private void LoadPartnerProduct(int partnerId)
        {
            var partnerProduct = _db.ProductInOrder.Where(p => p.Order.PartnerId == partnerId).ToList();
            MainDataGrid.ItemsSource = partnerProduct;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
