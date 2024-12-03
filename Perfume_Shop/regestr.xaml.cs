using Newtonsoft.Json;
using System.Windows;
using System.IO;
using System.Windows.Input;
using Perfume_Shop.Class;
using Perfume_Shop;

namespace Perfume_Shop;

/// <summary>
/// Логика взаимодействия для regestr.xaml
/// </summary>
public partial class regestr : Window
{
    public string filePath = @"users.json";

    public regestr()
    {
        InitializeComponent();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
            string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
            string.IsNullOrWhiteSpace(OtchestvoTextBox.Text) ||
            string.IsNullOrWhiteSpace(MailTextBox.Text) ||
            string.IsNullOrWhiteSpace(passwordTextBox.Text) ||
            string.IsNullOrWhiteSpace(passwordTextBoxRepit.Text) ||
            DatePickerBirhdate.SelectedDate == null)
        {
            MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (passwordTextBox.Text != passwordTextBoxRepit.Text)
        {
            MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (IsEmailAlreadyRegistered(MailTextBox.Text))
        {
            MessageBox.Show("Эта почта уже зарегистрирована.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(MailTextBox.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+[a-zA-Z]{2,}$"))
        {

            MessageBox.Show("Неверный формат почты.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }



        if (!System.Text.RegularExpressions.Regex.IsMatch(NameTextBox.Text, "^[а-яА-Я]+$"))
        {

            MessageBox.Show("Используйте кирилицу для написания имени.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(LastNameTextBox.Text, "^[а-яА-Я]+$"))
        {

            MessageBox.Show("Используйте кирилицу для написания Фамилии.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(MailTextBox.Text, @"^[a-zA-Z][a-zA-Z0-9]*(\.[a-zA-Z0-9]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9]+)*\.[a-zA-Z]{2,}$"))
        {
            MessageBox.Show("Неверный формат почты.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }


        if (!System.Text.RegularExpressions.Regex.IsMatch(OtchestvoTextBox.Text, "^[а-яА-Я]+$"))
        {

            MessageBox.Show("Используйте кирилицу для написания Отчества.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (OtchestvoTextBox.Text.Length < 2 | OtchestvoTextBox.Text.Length > 10)
        {
            MessageBox.Show("Количество символов плохое", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (passwordTextBox.Text != passwordTextBoxRepit.Text)
        {
            MessageBox.Show("пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }


        User newUser = new User
        {
            Name = NameTextBox.Text,
            LastName = LastNameTextBox.Text,
            Otchestvo = OtchestvoTextBox.Text,
            Email = MailTextBox.Text,
            Password = passwordTextBox.Text,
            BirthDate = DatePickerBirhdate.SelectedDate.Value

        };

        SaveUserToJson(newUser);
        MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        NameTextBox.Text = "";
        LastNameTextBox.Text = "";
        OtchestvoTextBox.Text = "";
        MailTextBox.Text = "";
        passwordTextBox.Text = "";
        passwordTextBoxRepit.Text = "";
        DatePickerBirhdate.Text = "";
    }

    private bool IsEmailAlreadyRegistered(string email)
    {

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();

            foreach (var user in users)
            {
                if (user.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void SaveUserToJson(User user)
    {

        List<User> users;

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
        }
        else
        {
            users = new List<User>();
        }

        users.Add(user);
        string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(filePath, updatedJson);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void enter_to_enter(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
    private void DatePickerBirthdate_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        e.Handled = true;
    }





}
