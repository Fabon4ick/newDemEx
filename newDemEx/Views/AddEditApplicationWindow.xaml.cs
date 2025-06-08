using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для AddEditApplicationWindow.xaml
    /// </summary>
    public partial class AddEditApplicationWindow : Window
    {
        private readonly sdvgEntities _db = new sdvgEntities().GetContext();
        private readonly bool _isEdit;
        private readonly Partner _partner;

        public AddEditApplicationWindow()
        {
            InitializeComponent();
            _isEdit = false;
            FillField();
        }
        public AddEditApplicationWindow(Partner partner)
        {
            InitializeComponent();
            _partner = partner;
            _isEdit = true;
            FillField();
            FillPartner();
        }

        private void FillField()
        {
            var type = _db.CompanyType.ToList();
            CompanyTypeComboBox.ItemsSource = type;
            CompanyTypeComboBox.DisplayMemberPath = "Name";
            CompanyTypeComboBox.SelectedValuePath = "Id";
            CompanyTypeComboBox.SelectedIndex = 0;
        }

        private void FillPartner()
        {
            CompanyTypeComboBox.SelectedValue = _partner.Company.CompanyTypeId;
            CompanyNameTextBox.Text = _partner.Company.Name;
            BuisnessAddressTextBox.Text = _partner.Company.BuisnessAddress;
            CompanyINNTextBox.Text = _partner.Company.INN;
            DirectorSurnameTextBox.Text = _partner.Company.DirectorSurname;
            DirectorNameTextBox.Text = _partner.Company.DirectorName;
            DirectorPatronymicTextBox.Text = _partner.Company.DirectorPatronymic;
            PhoneTextBox.Text = _partner.Company.Phone;
            EmailTextBox.Text = _partner.Company.Email;
            CompanyRatingTextBox.Text = _partner.Rating.ToString();
            ProductButton.Visibility = Visibility.Visible;
        }

        private void UpdateApplication()
        {
            if (!ValidateInput())
                return;

            var partner = _db.Partner.Include("Company").FirstOrDefault(p => p.Id == _partner.Id);
            partner.Company.CompanyTypeId = (int)CompanyTypeComboBox.SelectedValue;
            partner.Company.Name = CompanyNameTextBox.Text;
            partner.Company.BuisnessAddress = BuisnessAddressTextBox.Text;
            partner.Company.INN = CompanyINNTextBox.Text;
            partner.Company.DirectorSurname = DirectorSurnameTextBox.Text;
            partner.Company.DirectorName = DirectorNameTextBox.Text;
            partner.Company.DirectorPatronymic = DirectorPatronymicTextBox.Text;
            partner.Company.Phone = PhoneTextBox.Text;
            partner.Company.Email = EmailTextBox.Text;
            partner.Rating = decimal.Parse(CompanyRatingTextBox.Text);

            _db.Partner.AddOrUpdate(_partner);
            SaveChanges();
        }

        private void CreateApplication()
        {
            if (!ValidateInput())
                return;

            Company newCopmany = new Company
            {
                CompanyTypeId = (int)CompanyTypeComboBox.SelectedValue,
                Name = CompanyNameTextBox.Text,
                BuisnessAddress = BuisnessAddressTextBox.Text,
                INN = CompanyINNTextBox.Text,
                DirectorSurname = DirectorSurnameTextBox.Text,
                DirectorName = DirectorNameTextBox.Text,
                DirectorPatronymic = DirectorPatronymicTextBox.Text,
                Phone = PhoneTextBox.Text,
                Email = EmailTextBox.Text,
            };
            _db.Company.Add(newCopmany);
            SaveChanges();

            Partner newPartner = new Partner
            {
                CompanyId = newCopmany.Id,
                Rating = int.Parse(CompanyRatingTextBox.Text),
            };
            _db.Partner.Add(newPartner);
            SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                _db.SaveChanges();
                MessageBox.Show("Заявка партнёра успешно обновлена!\n", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Возникла ошибка при обновлении заявки партнёра!\n", "Ошибка!", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isEdit == false)
            {
                CreateApplication();
            }
            else if (_isEdit == true)
            {
                UpdateApplication();
            }
            else
            {
                Close();
            }
        }

        private bool ValidateInput()
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(CompanyNameTextBox.Text))
                errors.Append("Имя компании не введенно!\n" + "Заполните поле названия компании!\n");

            try
            {
                decimal rating = decimal.Parse(CompanyRatingTextBox.Text);
                if (rating < 0 || rating > 10)
                    errors.Append("Рейтинг должен быть больше 0 и не больше 10!\n" + "Введите корректный рейтинг!\n");
            }
            catch (Exception ex)
            {
                errors.Append("Неудалось обработать рейтинг!\n" + ex.Message);
            }

            if (errors.Length > 0)
            {
                MessageBox.Show($"{errors}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            int partnerId = _partner.Id;
            new ProductInApplicationWindow(partnerId).ShowDialog();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
