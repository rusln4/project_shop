using Newtonsoft.Json;
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
using System.IO;
using System.Windows.Shapes;
using Perfume_Shop.Class;

namespace Perfume_Shop;

/// <summary>
/// Логика взаимодействия для captcha.xaml
/// </summary>
public partial class captcha : Window
{
    public string filePath = @"/users.json";
    public string person = "";
    int right_count = 4;
    DateTime block_time_by_captcha = new DateTime();
    Random random = new Random();
    int num1;
    int num2;

    public captcha(string mail)
    {
        InitializeComponent();
        person = mail;
        GenerateNewNumbers();
    }

    private void GenerateNewNumbers()
    {
        num1 = random.Next(1, 51);
        num2 = random.Next(1, 51);
        num1_textBox.Text = num1.ToString();
        num2_textBox.Text = num2.ToString();
    }

    private void new_nums_but_Click(object sender, RoutedEventArgs e)
    {
        GenerateNewNumbers();
        ans_textBox.Text = "";
    }

    int your_ans = 0;

    private void ans_but_Click(object sender, RoutedEventArgs e)
    {
        int ans = num1 + num2;


        if (string.IsNullOrEmpty(ans_textBox.Text))
        {
            MessageBox.Show("Пожалуйста, введите каптчу");
            return;
        }


        if (!int.TryParse(ans_textBox.Text, out your_ans))
        {
            MessageBox.Show("Пожалуйста, введите корректное числовое значение");
            return;
        }


        if (your_ans == ans && right_count >= 1)
        {
            MessageBox.Show("Каптча пройдена!");
            shop_main sh = new shop_main(person);
            sh.Show();
            this.Close();
        }
        else if (your_ans != ans && right_count >= 1)
        {
            right_count--;
            MessageBox.Show($"Неверная каптча, у вас осталось {right_count} попыток!");
        }
        else if (right_count <= 0)
        {
            MessageBox.Show("Вы похоже бот! Аккаунт заблокирован!");
            Block(person, right_count);
            this.Close();
        }
    }


    private void Block(string email, int count)
    {
        block_time_by_captcha = DateTime.Now;
        List<User> users = LoadUsersFromJson(filePath);
        foreach (var user in users)
        {
            if (user.Email == email && count < 1)
            {
                user.LockTime = block_time_by_captcha;
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
}
