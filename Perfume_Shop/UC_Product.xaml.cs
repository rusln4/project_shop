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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Perfume_Shop.Class;

namespace Perfume_Shop;

public partial class UC_Product : UserControl
{
    private Product currentProduct;
    private string currentUser;
    private string oldProductName;

    public string filePath2 = @"items.json";
    private List<Product> products;


    public delegate void ProductDeletedEventHandler(object sender, EventArgs e);


    public event ProductDeletedEventHandler ProductDeleted;

    public void SetCurrentUser(string user)
    {
        currentUser = user;
    }

    public UC_Product()
    {
        InitializeComponent();
        buttonBuy.Click += ButtonBuy_Click;
        deleteProductbtn.Click += ButtonDelete_Click;
        update_products_btn.Click += UpdateProductCard;
        UpdateThisProductbtn.Click += enterUpdate;
    }

    public void SetProduct(Product product)
    {
        currentProduct = product;
        oldProductName = product.Name;
        UpdateProductDisplay();
        UpdateJson();
    }

    public void UpdateProductDisplay()
    {
        NameItemlable.Text = currentProduct.Name;
        PriceItemLable.Text = $"{currentProduct.Price} руб.";
        CountItemLable.Text = $"{currentProduct.Count} шт.";
        ItemImage.Fill = new ImageBrush
        {
            ImageSource = new BitmapImage(new Uri(currentProduct.Image, UriKind.RelativeOrAbsolute))
        };
    }

    private void ButtonBuy_Click(object sender, RoutedEventArgs e)
    {
        if (currentProduct.Count > 0)
        {
            currentProduct.Count--;
            CountItemLable.Text = currentProduct.Count.ToString();
            UpdateJson();
            AddPurchasedItem(currentProduct);
        }
        else
        {
            MessageBox.Show("Товар закончился", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        UpdateProductDisplay();
    }

    private void UpdateProductCard(object sender, RoutedEventArgs e)
    {
        buttonBuy.Visibility = Visibility.Hidden;
        update_products_btn.Visibility = Visibility.Hidden;
        NameItemlable.IsEnabled = true;
        PriceItemLable.IsEnabled = true;
        CountItemLable.IsEnabled = true;


        NameItemlable.Text = NameItemlable.Text.Replace(" руб.", "").Trim();
        PriceItemLable.Text = PriceItemLable.Text.Replace(" руб.", "").Trim();
        CountItemLable.Text = CountItemLable.Text.Replace(" шт.", "").Trim();


        UpdateThisProductbtn.Visibility = Visibility.Visible;
    }
    private void enterUpdate(object sender, RoutedEventArgs e)
    {
        buttonBuy.Visibility = Visibility.Visible;
        update_products_btn.Visibility = Visibility.Visible;

        string priceText = PriceItemLable.Text.Replace(" руб.", "").Trim();
        string countText = CountItemLable.Text.Replace(" шт.", "").Trim();
        

        bool isPriceValid = int.TryParse(priceText, out int price);
        bool isCountValid = int.TryParse(countText, out int count);

        if (isPriceValid && isCountValid && count > 0)
        {
            currentProduct.Name = NameItemlable.Text;
            currentProduct.Price = price;
            currentProduct.Count = count;

            UpdateItem(currentProduct);
            UpdateProductDisplay();
        }
        else
        {
            MessageBox.Show("Пожалуйста, введите корректные значения для цены и количества.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }



    private void UpdateItem(Product product)
    {
        try
        {
            product.Name = NameItemlable.Text;
            product.Price = Convert.ToInt32(PriceItemLable.Text);
            product.Count = Convert.ToInt32(CountItemLable.Text);

            string json = File.ReadAllText(filePath2);
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();

            var existingProduct = products.FirstOrDefault(p => p.Name == oldProductName);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                oldProductName = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Count = product.Count;


                NameItemlable.IsEnabled = false;
                PriceItemLable.IsEnabled = false;
                CountItemLable.IsEnabled = false;
                UpdateThisProductbtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Некорректое значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            string updatedJson = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(filePath2, updatedJson);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Неизвестная ошибка {ex}");
        }

    }


    private void ButtonDelete_Click(object sender, RoutedEventArgs e)
    {
        var result = MessageBox.Show("Вы уверены что хотите удалить товар?", "Поддврждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
            DeleteItem(currentProduct);
            OnProductDeleted();
        }
        else
        {
            return;
        }
        
    }

    private void OnProductDeleted()
    {
        ProductDeleted?.Invoke(this, EventArgs.Empty);
    }

    private void DeleteItem(Product product)
    {
        string json = File.ReadAllText(filePath2);
        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();
        products.RemoveAll(item => item.Name == product.Name && item.Price == product.Price);

        string updatedJson = JsonConvert.SerializeObject(products, Formatting.Indented);
        File.WriteAllText(filePath2, updatedJson);
    }

    private void UpdateJson()
    {
        string json = File.ReadAllText(filePath2);
        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();

        foreach (var product in products)
        {
            if (product.Name == currentProduct.Name)
            {
                product.Count = currentProduct.Count;
                break;
            }
        }

        string updatedJson = JsonConvert.SerializeObject(products, Formatting.Indented);
        File.WriteAllText(filePath2, updatedJson);
    }

    private void AddPurchasedItem(Product product)
    {
        string purchasedFilePath = @"item_basket.json";
        List<Item> purchasedItems;

        if (File.Exists(purchasedFilePath))
        {
            string json = File.ReadAllText(purchasedFilePath);
            purchasedItems = JsonConvert.DeserializeObject<List<Item>>(json) ?? new List<Item>();
        }
        else
        {
            purchasedItems = new List<Item>();
        }

        Item purchasedItem = new Item
        {
            Name = product.Name,
            Price = product.Price,
            Count = 1,
            User = currentUser
        };

        purchasedItems.Add(purchasedItem);

        string updatedJson = JsonConvert.SerializeObject(purchasedItems, Formatting.Indented);
        File.WriteAllText(purchasedFilePath, updatedJson);
    }

    


}
