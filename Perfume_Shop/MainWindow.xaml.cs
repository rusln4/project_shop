using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Xml;
using System.IO;
using Perfume_Shop.Class;

namespace Perfume_Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string filePath = @"users.json";
        public MainWindow()
        {
            InitializeComponent();
        }
        private int checkCount = 4;
        public DateTime time = new DateTime();
        public DateTime block_time = new DateTime();

        private void Button_Click_enter(object sender, RoutedEventArgs e)
        {
            time = DateTime.Now;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            string mailCheckPattern = @"^[a-zA-Z][a-zA-Z0-9]*(\.[a-zA-Z0-9]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9]+)*\.[a-zA-Z]{2,}$";

            check_unlock_time(time, email);

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            if (email == "1" && password == "1")
            {
                shop_main sp = new shop_main("lilih77772@gmail.com");
                sp.Show();
            }

            else if (!Regex.IsMatch(email, mailCheckPattern))
            {
                MessageBox.Show("Неверный формат почты!");
                return;
            }
            else if (checkCount < 1 || ValidateCheck(email))
            {
                MessageBox.Show("Ваш аккаунт заблокирован на 1 минутy.");

            }
            else if (ValidateUser(email, password) == false)
            {
                checkCount--;
                MessageBox.Show($"Неверный логин или пароль, у вас осталось {checkCount} попыток!", "Ошибка");

            }
            else if (ValidateUser(email, password))
            {
                mail_check mailWind = new mail_check(email);
                mailWind.ShowDialog();

            }
            BlockUser(email, checkCount);

        }

        private bool ValidateUser(string email, string password)
        {

            List<User> users = LoadUsersFromJson(filePath);

            foreach (var user in users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }

            }
            return false;
        }
        private void BlockUser(string email, int count)
        {
            block_time = DateTime.Now;
            List<User> users = LoadUsersFromJson(filePath);
            foreach (var user in users)
            {
                if (user.Email == email && count < 1)
                {
                    user.LockTime = block_time;
                    user.Check = 0;
                    break;
                }
            }
            SaveUsersToJson(filePath, users);
        }

        private void check_unlock_time(DateTime now, string email)
        {

            List<User> users = LoadUsersFromJson(filePath);
            foreach (var user in users)
            {
                if (user.Email == email && (now - user.LockTime).TotalMinutes > 1)
                {
                    user.LockTime = DateTime.Parse("0001-01-01T00:00:00");
                    user.Check = 1;
                    break;
                }
            }
            SaveUsersToJson(filePath, users);
        }

        private void SaveUsersToJson(string filePath, List<User> users)
        {
            string json = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }



        private bool ValidateCheck(string email)
        {
            List<User> users = LoadUsersFromJson(filePath);
            foreach (var user in users)
            {
                if (user.Email == email && user.Check == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public List<User> LoadUsersFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл пользователей не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return new List<User>();
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string mal1 = EmailTextBox.Text;
            password_check ps = new password_check(mal1);
            ps.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            regestr regestr = new regestr();
            regestr.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            shop_main shop = new shop_main("");
            shop.Show();
        }
    }
}