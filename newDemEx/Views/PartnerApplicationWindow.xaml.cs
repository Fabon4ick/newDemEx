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
using newDemEx.Helpers;

namespace newDemEx.Views
{
    /// <summary>
    /// Логика взаимодействия для PartnerApplicationWindow.xaml
    /// </summary>
    public partial class PartnerApplicationWindow : Window
    {
        public PartnerApplicationWindow()
        {
            InitializeComponent();
            ApplicationScroll.Content = new PartnerFabric().GetCards();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new MosaicaWindow().Show();
            Close();
        }

        private void AddApplicationButton_Click(object sender, RoutedEventArgs e)
        {
            new AddEditApplicationWindow().ShowDialog();
        }
    }
}
