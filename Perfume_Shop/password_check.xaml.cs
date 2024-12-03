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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Perfume_Shop.Class;

namespace Perfume_Shop;

/// <summary>
/// Логика взаимодействия для password_check.xaml
/// </summary>
public partial class password_check : Window
{
    public string filePath = @"users.json";
    public password_check(string mail_for_check)
    {
        InitializeComponent();
        mail_for_password_textBox.Text = mail_for_check;
        person = mail_for_check;
    }
    string cod = "";
    public DateTime time_code = new DateTime();
    public DateTime check_time_code = new DateTime();
    public string person = "";

    private void legit_password_button_Click(object sender, RoutedEventArgs e)
    {
        string mail_for_legit = mail_for_password_textBox.Text;
        if (mail_for_legit != string.Empty)
        {
            try
            {
                Random random = new Random();
                cod = random.Next(1000, 10000).ToString();
                time_code = DateTime.Now;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("ruslan16hudya@ya.ru");
                mail.To.Add(new MailAddress(mail_for_legit));
                mail.Subject = "Поддтверждение личности";
                mail.Body = $"Ваш код поддтвенрждения : {cod}. Использование этого кода доступно в течении минуты!";

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.yandex.ru";
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("ruslan16hudya@ya.ru", "awavddcyahtrmhxy");
                client.Send(mail);

                assepct_password_button.Visibility = Visibility.Visible;

            }

            catch (Exception)
            {
                MessageBox.Show("Неверная почта!");
            }
        }
        else
        {
            MessageBox.Show("Введите почту!");
        }


    }

    private void Password_on_mail()
    {

        string mail_for_legit = mail_for_password_textBox.Text;
        try
        {
            Random random = new Random();
            cod = GetPassword(mail_for_legit);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("ruslan16hudya@ya.ru");
            mail.To.Add(new MailAddress(mail_for_legit));
            mail.Subject = "Восстановление пароля";
            mail.Body = $"Ваш пароль : {cod}";

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.yandex.ru";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("ruslan16hudya@ya.ru", "awavddcyahtrmhxy");
            client.Send(mail);

            assepct_password_button.Visibility = Visibility.Visible;

        }

        catch (Exception)
        {
            MessageBox.Show("Неверная почта!");
        }



    }

    int count_fo_mail = 4;
    DateTime block_time_gmail_pass = new DateTime();

    private void assepct_password_button_Click(object sender, RoutedEventArgs e)
    {
        string try_cod = cod_for_password.Text;
        check_time_code = DateTime.Now;
        if ((check_time_code - time_code).TotalMinutes < 1)
        {
            if (try_cod != string.Empty)
            {
                if (try_cod == cod && count_fo_mail >= 1)
                {
                    MessageBox.Show("Пароль отправлен вам на почту!");
                    Password_on_mail();
                    this.Close();
                }
                else if (try_cod != cod && count_fo_mail >= 1)
                {
                    count_fo_mail--;
                    MessageBox.Show($"Неверный код, у вас осталось {count_fo_mail} попыток!");
                }
                else if (count_fo_mail <= 0)
                {
                    MessageBox.Show("Ваш аккаунт заплокирован!");
                    block(person, count_fo_mail);
                }
            }
        }
        else
        {
            MessageBox.Show("Код не действителен! Запросите код заного!");
        }

    }

    private string GetPassword(string email)
    {
        List<User> users = LoadUsersFromJson(filePath);
        foreach (var user in users)
        {
            if (user.Email == email)
            {
                return user.Password;
            }
        }
        return null;
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
        block_time_gmail_pass = DateTime.Now;
        List<User> users = LoadUsersFromJson(filePath);
        foreach (var user in users)
        {
            if (user.Email == email && count < 1)
            {
                user.LockTime = block_time_gmail_pass;
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
