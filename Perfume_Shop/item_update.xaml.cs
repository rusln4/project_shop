using Microsoft.Win32;
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
using System.IO;
using Newtonsoft.Json;
using Perfume_Shop.Class;
using Perfume_Shop;

namespace Perfume_Shop;

/// <summary>
/// Логика взаимодействия для item_update.xaml
/// </summary>
public partial class item_update : Window

{
    private readonly shop_main _shopMain;
    public item_update(shop_main shopMain)
    {
        InitializeComponent();
        _shopMain = shopMain;
    }

    public string image_path;
    public string filePath2 = @"items.json";

    private void ImageBtn_Click(object sender, RoutedEventArgs e)
    {

        OpenFileDialog wind = new OpenFileDialog
        {
            InitialDirectory = "C:\\Mac\\Home\\Desktop\\Картинки",
            Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
        };
        try
        {
            wind.ShowDialog();
            string fileName = wind.FileName;
            image_path = fileName;
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(fileName));
            brush.Stretch = Stretch.Fill;
            ImageBtn.Background = brush;
            ImageBtn.Content = string.Empty;
        }
        catch (Exception)
        {
            MessageBox.Show("Выберите изображение");
        }
    }

    private void PriceTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!char.IsDigit(e.Text, 0))
        {
            e.Handled = true;
        }
    }

    private void Get_foc(object sender, RoutedEventArgs e)
    {
        TextBox tb = (TextBox)sender;
        if (tb.Text == "Количство (шт.)" || tb.Text == "Цена в рублях" || tb.Text == "Название товара")
        {
            tb.Text = string.Empty;
        }
    }



    private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
        {
            e.Handled = true;
        }
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
        {
            e.Handled = true;
        }
    }

    private void TitleTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (TitleTextBox.Text == string.Empty)
        {
            TitleTextBox.Text = "Название товара";
        }
    }

    private void PriceTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (PriceTextBox.Text == string.Empty)
        {
            PriceTextBox.Text = "Цена в рублях";
        }
    }

    private void CountTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (CountTextBox.Text == string.Empty)
        {
            CountTextBox.Text = "Количство (шт.)";
        }
    }

    private void AddBtn_Click(object sender, RoutedEventArgs e)
    {

        if (!string.IsNullOrEmpty(TitleTextBox.Text) &&
        !string.IsNullOrEmpty(PriceTextBox.Text) &&
        !string.IsNullOrEmpty(CountTextBox.Text) &&
        !string.IsNullOrEmpty(image_path))
        {
            Product product = new Product();
            product.Name = TitleTextBox.Text;


            if (!int.TryParse(CountTextBox.Text, out int count))
            {
                MessageBox.Show("Введите корректное количество товара.");
                return;
            }
            product.Count = count;

            if (!int.TryParse(PriceTextBox.Text, out int price))
            {
                MessageBox.Show("Введите корректную цену товара.");
                return;
            }
            if (CountTextBox.Text == "0")
            {
                MessageBox.Show("Количество не может быть 0");
                return;
            }
            if (PriceTextBox.Text == "0")
            {
                MessageBox.Show("Цена не можеть быть 0");
                return;
            }
            product.Price = price;

            product.Image = image_path;

            AddNewItem(product);
            _shopMain.clear();
            _shopMain.LoadData();
            this.Close();
        }
        else
        {
            MessageBox.Show("Все поля должны быть заполнены.");
        }



    }

    private void AddNewItem(Product product)
    {
        try
        {
            List<Product> products;
            string json = File.ReadAllText(filePath2);
            products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();

            bool itemExists = false;

            for (int i = 0; i < products.Count; i++)
            {
                var item = products[i];
                if (item.Name == product.Name && item.Price == product.Price && item.Image == product.Image)
                {
                    item.Count += product.Count;
                    itemExists = true;
                    break;
                }
            }
            if (!itemExists)
            {
                products.Add(product);
            }

            string newJson = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(filePath2, newJson);
            PriceTextBox.Text = PriceTextBox.Text + " руб.";
            CountTextBox.Text = CountTextBox.Text + " шт.";
            MessageBox.Show("Товар успешно добавлен");
        }
        catch (Exception)
        {
            MessageBox.Show("Ошибка добавления");
        }
    }

    private void CountTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!char.IsDigit(e.Text, 0))
        {
            e.Handled = true;
        }
    }
}
