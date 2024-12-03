using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Perfume_Shop.Class;

namespace Perfume_Shop;

/// <summary>
/// Логика взаимодействия для mail_check.xaml
/// </summary>
public partial class mail_check : Window
{
    public string filePath = @"users.json";

    public mail_check(string email)
    {
        InitializeComponent();
        SendMessage(email);
        person = email;
    }
    string cod = "";
    public string person = "";
    DateTime block_time_by_code = new DateTime();

    public async void SendMessage(string gmail)
    {
        try
        {
            Random random = new Random();
            cod = random.Next(1000, 10000).ToString();

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("ruslan16hudya@ya.ru");
            mail.To.Add(new MailAddress(gmail));
            mail.Subject = "Подтверждение личности";
            mail.Body = $"Ваш код подтверждения : {cod}";

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.yandex.ru";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("ruslan16hudya@ya.ru", "awavddcyahtrmhxy");
            client.Send(mail);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }



    }
    int count_check = 4;
    private void legit_click(object sender, RoutedEventArgs e)
    {
        string check = LegitTextBox.Text;
        if (check == cod & count_check > 0)
        {
            MessageBox.Show("Прверка пройдена, добро пожаловать!");
            captcha cap = new captcha(person);
            cap.Show();
            this.Close();
        }
        else
        {
            count_check--;
            if (LegitTextBox.Text == "")
            {
                MessageBox.Show("Введите код!");
            }
            else if (count_check >= 0)
            {
                MessageBox.Show($"Код неверный, у вас осталось {count_check} попыток! ");
                LegitTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("У вас не осталось попыток, вы заблокированы на 1 минуту!");
                block(person, count_check);

                this.Close();
            }


        }
    }
    private List<User> LoadUsersFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            MessageBox.Show("Файл пользователей не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return new List<User>();
        }

        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<User>>(json);
    }

    private void block(string email, int count)
    {
        block_time_by_code = DateTime.Now;
        List<User> users = LoadUsersFromJson(filePath);
        foreach (var user in users)
        {
            if (user.Email == email && count < 1)
            {
                user.LockTime = block_time_by_code;
                user.Check = 0;
                break;
            }
        }
        SaveUsersToJson(filePath, users);
    }

    private void SaveUsersToJson(string filePath, List<User> users)
    {
        string json = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }


}
