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
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Perfume_Shop.Class;

namespace Perfume_Shop;

/// <summary>
/// Логика взаимодействия для UC_Item.xaml
/// </summary>
public partial class UC_Item : UserControl
{
    public UC_Item()
    {
        InitializeComponent();
    }

    private Item currentItem;
    public string filePath3 = @"item_basket.json";

    public void SetItem(Item item)
    {
        currentItem = item;
        UpdateJsonItems();
        UpdateItemDisplay();
    }

    public void UpdateItemDisplay()
    {
        NameItemlable_basket.Content = currentItem.Name;
        PriceItemLable_basket.Content = $"{currentItem.Price} руб.";
    }

    private void UpdateJsonItems()
    {
        string json2 = File.ReadAllText(filePath3);
        List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json2) ?? new List<Item>();

        foreach (Item item in items)
        {
            if (item.Name == currentItem.Name)
            {
                item.Price = currentItem.Price;
                break;
            }
        }
        string updatedJson = JsonConvert.SerializeObject(items, Formatting.Indented);
        File.WriteAllText(filePath3, updatedJson);
    }
}
