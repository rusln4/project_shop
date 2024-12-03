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
using System.Windows.Shapes;
using System.IO;
using Perfume_Shop.Class;

namespace Perfume_Shop;

/// <summary>
/// Логика взаимодействия для shop_main.xaml
/// </summary>
public partial class shop_main : Window
{

    public string filePath = @"users.json";
    public string filePath2 = @"items.json";
    public string filePath3 = @"item_basket.json";
    public string historyPath = @"history.json";

    public string person = "";

    public shop_main(string mail)
    {
        InitializeComponent();
        CB_Sort.Focus();

        MailTextBox.Text = mail;
        person = mail;
        if (mail == "")
        {
            NameTextBox.Text = "Гость";
            MailTextBox.Text = "Гость";
            btn_reg.Visibility = Visibility.Hidden;
            LoadData();
            BuyBasketBtn.Visibility = Visibility.Hidden;
            Notlable.Visibility = Visibility.Visible;

        }
        else
        {
            get_user_info();
            LoadData();
            LoadDataItem();
        }

    }

    public void LoadData()
    {
        string json = File.ReadAllText(filePath2);
        List<Product> all_products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();

        foreach (var product in all_products)
        {
            var UC_Prod = new UC_Product();
            UC_Prod.SetCurrentUser(person);
            UC_Prod.SetProduct(product);
            UC_Prod.ProductDeleted += UC_Prod_ProductDeleted;
            ItemsListView.Items.Add(UC_Prod);
        }
    }

    private void UC_Prod_ProductDeleted(object sender, EventArgs e)
    {
        ClearItemsListView();
        LoadData();
    }
    public void ClearItemsListView()
    {
        ItemsListView.Items.Clear();
    }

    public void LoadDataItem()
    {
        if (!File.Exists(filePath3))
        {
            MessageBox.Show("Файл корзины не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        string json = File.ReadAllText(filePath3);
        List<Item> all_items = JsonConvert.DeserializeObject<List<Item>>(json) ?? new List<Item>();

        basketListView.Items.Clear();


        var userItems = all_items.Where(item => item.User == person).ToList();

        foreach (var item in userItems)
        {
            var UC_Item = new UC_Item();
            UC_Item.SetItem(item);
            basketListView.Items.Add(UC_Item);
        }
    }

    public void clear()
    {
        ItemsListView.Items.Clear();
    }

    private void get_user_info()
    {
        List<User> users = LoadUsersFromJson(filePath);
        foreach (User user in users)
        {
            if (user.Email == person)
            {
                NameTextBox.Text = user.Name;
                SernameTextBox.Text = user.LastName;
                DadTextBox.Text = user.Otchestvo;
                PassBox.Password = user.Password;
            }
        }
    }

    public List<User> LoadUsersFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            MessageBox.Show("Файл пользователей не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return new List<User>();
        }

        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();


    }

    private void btn_reg_Click(object sender, RoutedEventArgs e)
    {
        NameTextBox.IsEnabled = true;
        NameTextBox.BorderBrush = new SolidColorBrush(Colors.DeepSkyBlue);
        SernameTextBox.IsEnabled = true;
        SernameTextBox.BorderBrush = new SolidColorBrush(Colors.DeepSkyBlue);
        DadTextBox.IsEnabled = true;
        DadTextBox.BorderBrush = new SolidColorBrush(Colors.DeepSkyBlue);
        PassBox.IsEnabled = true;
        PassBox.BorderBrush = new SolidColorBrush(Colors.DeepSkyBlue);
        btn_save.Visibility = Visibility.Visible;
    }

    private void btn_save_Click(object sender, RoutedEventArgs e)
    {

        if (string.IsNullOrWhiteSpace(NameTextBox.Text) || NameTextBox.Text.Length < 3 ||
            string.IsNullOrWhiteSpace(SernameTextBox.Text) || SernameTextBox.Text.Length < 3 ||
            string.IsNullOrWhiteSpace(DadTextBox.Text) || DadTextBox.Text.Length < 3 ||
            string.IsNullOrWhiteSpace(PassBox.Password) || PassBox.Password.Length < 3)
        {
            MessageBox.Show("Все поля должны содержать не менее 3 символов и не быть пустыми");
            return;
        }

        List<User> users = LoadUsersFromJson(filePath);
        foreach (User user in users)
        {
            if (user.Email == person)
            {
                user.Name = NameTextBox.Text;
                user.LastName = SernameTextBox.Text;
                user.Otchestvo = DadTextBox.Text;
                user.Password = PassBox.Password;
            }
        }
        SaveUsersToJson(filePath, users);

        NameTextBox.IsEnabled = false;
        SernameTextBox.IsEnabled = false;
        DadTextBox.IsEnabled = false;
        PassBox.IsEnabled = false;
        NameTextBox.BorderBrush = new SolidColorBrush(Colors.DarkBlue);
        SernameTextBox.BorderBrush = new SolidColorBrush(Colors.DarkBlue);
        DadTextBox.BorderBrush = new SolidColorBrush(Colors.DarkBlue);
        PassBox.BorderBrush = new SolidColorBrush(Colors.DarkBlue);
        btn_save.Visibility = Visibility.Hidden;
        MessageBox.Show("Данные сохранены");
    }


    private void SaveUsersToJson(string filePath, List<User> users)
    {
        string json = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    private void TabControlShop_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (TabControlShop.SelectedItem == basketTabItem)
        {
            LoadDataItem();
        }
    }

    private void BuyBasketBtn_Click(object sender, RoutedEventArgs e)
    {
        if (!File.Exists(filePath3))
        {
            MessageBox.Show("Файл корзины не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        string json = File.ReadAllText(filePath3);
        List<Item> all_items = JsonConvert.DeserializeObject<List<Item>>(json) ?? new List<Item>();
        var userItems = all_items.Where(item => item.User == person).ToList();

        if (!userItems.Any())
        {
            MessageBox.Show("Ваша корзина пуста.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        decimal totalPrice = userItems.Sum(item => item.Price);

        List<Item> updatedItems = all_items.Where(item => item.User != person).ToList();
        string updatedJson = JsonConvert.SerializeObject(updatedItems, Formatting.Indented);
        File.WriteAllText(filePath3, updatedJson);

        SavePurchaseHistory(userItems);

        MessageBox.Show($"Вы купили товары на сумму: {totalPrice:C}", "Покупка совершена", MessageBoxButton.OK, MessageBoxImage.Information);
        basketListView.Items.Clear();
    }
    private void SavePurchaseHistory(List<Item> purchasedItems)
    {

        List<Item> history = new List<Item>();
        if (File.Exists(historyPath))
        {
            string historyJson = File.ReadAllText(historyPath);
            history = JsonConvert.DeserializeObject<List<Item>>(historyJson) ?? new List<Item>();
        }

        history.AddRange(purchasedItems);

        string updatedHistoryJson = JsonConvert.SerializeObject(history, Formatting.Indented);
        File.WriteAllText(historyPath, updatedHistoryJson);
    }


    private void exit_btn_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void history_btn_Click(object sender, RoutedEventArgs e)
    {
        if (!File.Exists(historyPath))
        {
            MessageBox.Show("История покупок пуста.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        string historyJson = File.ReadAllText(historyPath);
        List<Item> historyItems = JsonConvert.DeserializeObject<List<Item>>(historyJson) ?? new List<Item>();

        if (historyItems == null || !historyItems.Any())
        {
            MessageBox.Show("История покупок пуста.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }


        StringBuilder message = new StringBuilder("Ваши покупки:\n");
        foreach (var item in historyItems.Where(i => i.User == person))
        {
            message.AppendLine($"- {item.Name} (Цена: {item.Price:C})");
        }

        MessageBox.Show(message.ToString(), "История покупок", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void AddNewBtn_Click(object sender, RoutedEventArgs e)
    {
        item_update item = new item_update(this);

        item.WindowStartupLocation = WindowStartupLocation.Manual;
        item.Left = this.Left + this.Width - item.Width - 60;
        item.Top = this.Top + 110;

        item.Show();
    }

    private void PassBox_MouseEnter(object sender, MouseEventArgs e)
    {
        List<User> users = new List<User>();
        string json = File.ReadAllText(filePath);

        users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();

        foreach (var user in users)
        {
            if (user.Email == person)
            {
                PassBox.ToolTip = user.Password;
                break;
            }
        }
    }

    private void FindTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        if (FindTextBox.Text == "🔍")
        {
            FindTextBox.Text = string.Empty;
        }
    }

    private void FindTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(FindTextBox.Text))
        {
            FindTextBox.Text = "🔍";
        }
    }
    public string Name;

    private void get_chenged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(FindTextBox.Text) && FindTextBox.Text != "🔍")
        {
            FindTextBox_TextChanged();
        }
        if (string.IsNullOrEmpty(FindTextBox.Text))
        {
            ClearItemsListView();
            LoadData();
        }
        else
        {
            return;
        }
    }

    private void FindTextBox_TextChanged()
    {
        Name = FindTextBox.Text.ToLower();
        List<Product> products = new List<Product>();
        string json = File.ReadAllText(filePath2);
        products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();

        var filteredProducts = products.Where(p => p.Name.ToLower().StartsWith(Name)).ToList();
        DisplayFilteredProducts(filteredProducts);
    }

    private void DisplayFilteredProducts(List<Product> filteredProducts)
    {
        ClearItemsListView();

        foreach (var product in filteredProducts)
        {
            var UC_Prod = new UC_Product();
            UC_Prod.SetCurrentUser(person);
            UC_Prod.SetProduct(product);
            UC_Prod.ProductDeleted += UC_Prod_ProductDeleted;
            ItemsListView.Items.Add(UC_Prod);
        }
    }

    private void CB_Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ClearItemsListView();
        string json = File.ReadAllText(filePath2);
        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();

        Func<Product, object> keySelector = null;

        switch (CB_Sort.SelectedIndex)
        {
            case 0:
                keySelector = p => p.Price;
                break;
            case 1:
                keySelector = p => -p.Price; 
                break;
            case 2:
                keySelector = p => -p.Count; 
                break;
            case 3:
                keySelector = p => p.Count;
                break;
            default:
                DisplayFilteredProducts(products);
                return;
        }

        var sortedProducts = products.OrderBy(keySelector).ToList();
        DisplayFilteredProducts(sortedProducts);
    }




    private void FindTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
        {
            if (e.Key == Key.V)
            {
                e.Handled = true;
            }
        }
    }
}
