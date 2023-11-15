using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace icetest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private ObservableCollection<CartItem> cartItems = new ObservableCollection<CartItem>();

        private double dietBananaKalori = 175; // Diet Banana'nın kalori değeri
        private double dietBananaFiyat = 0.55; // Diet Banana'nın fiyatı

        private double dietStrawberryKalori = 135; // Diet Strawberry'nin kalori değeri
        private double dietStrawberryFiyat = 0.75; // Diet Strawberry'nin fiyatı

        private double dietChocoKalori = 235; // Diet Choco'nun kalori değeri
        private double dietChocoFiyat = 0.85; // Diet Choco'nun fiyatı

        private double dietLemonKalori = 115; // Diet Lemon'un kalori değeri
        private double dietLemonFiyat = 0.25; // Diet Lemon'un fiyatı

        private double lowFatBananaKalori = 325; // Low Fat Banana'nın kalori değeri
        private double lowFatBananaFiyat = 0.65; // Low Fat Banana'nın fiyatı

        private double lowFatStrawberryKalori = 225; // Low Fat Strawberry'nin kalori değeri
        private double lowFatStrawberryFiyat = 0.85; // Low Fat Strawberry'nin fiyatı

        private double lowFatChocoKalori = 340; // Low Fat Choco'nun kalori değeri
        private double lowFatChocoFiyat = 0.90; // Low Fat Choco'nun fiyatı

        private double lowFatLemonKalori = 125; // Low Fat Lemon'un kalori değeri
        private double lowFatLemonFiyat = 0.35; // Low Fat Lemon'un fiyatı

        private double fatBananaKalori = 365; // Fat Banana'nın kalori değeri
        private double fatBananaFiyat = 0.85; // Fat Banana'nın fiyatı

        private double fatStrawberryKalori = 20; // Fat Strawberry'nin kalori değeri
        private double fatStrawberryFiyat = 0.85; // Fat Strawberry'nin fiyatı

        private double fatChocoKalori = 400; // Fat Choco'nun kalori değeri
        private double fatChocoFiyat = 1.0; // Fat Choco'nun fiyatı

        private double fatLemonKalori = 175; // Fat Lemon'un kalori değeri
        private double fatLemonFiyat = 0.40; // Fat Lemon'un fiyatı

        private double peanutKalori = 30;
        private double hazelnutKalori = 45;
        private double antepnutKalori = 75;
        private void fullnametxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int caretIndex = textBox.CaretIndex;

            // get string from the textbox
            string text = textBox.Text;

            // makes the first letter upper 
            string formattedText = FormatName(text);

            // update textbox format 
            textBox.Text = formattedText;

            // save caretindex
            textBox.CaretIndex = caretIndex;
        }
        private string FormatName(string fullName)
        {
            string[] names = fullName.Split(' ');
            for (int i = 0; i < names.Length; i++)
            {
                if (!string.IsNullOrEmpty(names[i]))
                {
                    names[i] = char.ToUpper(names[i][0], CultureInfo.CurrentCulture) + names[i].Substring(1).ToLower();
                }
            }
            return string.Join(" ", names);
        }

        private void fullnametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // first and after space do uppercase
                string fullName = fullnametxt.Text;
                string formattedName = FormatName(fullName);

                // auto complete
                fullnametxt.Text = formattedName;

                // passing adress textbox
                adresstxt.Focus();
            }
        }
        private void adresstxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // enable when user press enter key 
                dietRadioButton.IsEnabled = true;
                lowFatRadioButton.IsEnabled = true;
                fatRadioButton.IsEnabled = true;
                lemonCheckBox.IsEnabled = true;
                bananaCheckBox.IsEnabled = true;
                strawberryCheckBox.IsEnabled = true;
                chocoCheckBox.IsEnabled = true;
            }
            
        }
        private void adresstxt_GotFocus(object sender, RoutedEventArgs e)
        {
            // when user pass adress box it shows warning what user should do 
            MessageBox.Show("When you press enter after typing the address, you can choose the milk type.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
                    lemonTextBox.Text = ((int)lemonSlider.Value).ToString();
                    bananaTextBox.Text = ((int)bananaSlider.Value).ToString();
                    strawberryTextBox.Text = ((int)strawberrySlider.Value).ToString();
                    chocoTextBox.Text = ((int)chocoSlider.Value).ToString();
            UpdateTotal();
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            UpdateTotal();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            CheckBox checkBox = (CheckBox)sender;
            string checkBoxName = checkBox.Name;
            EnableControls(checkBoxName);
            UpdateTotal();
            UpdateInsertButtonState();
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            
            CheckBox checkBox = (CheckBox)sender;
            string checkBoxName = checkBox.Name;
            DisableControls(checkBoxName);
            UpdateTotal();
            UpdateInsertButtonState();
        }
        private void EnableControls(string checkBoxName)
        {
            switch (checkBoxName)
            {
                case "lemonCheckBox":
                    lemonTextBox.IsEnabled = true;
                    lemonSlider.IsEnabled = true;
                    break;
                
                case "strawberryCheckBox":
                    strawberryTextBox.IsEnabled = true;
                    strawberrySlider.IsEnabled = true;
                    break;
                case "chocoCheckBox":
                    chocoTextBox.IsEnabled = true;
                    chocoSlider.IsEnabled = true;
                    break;
                case "bananaCheckBox":
                    bananaTextBox.IsEnabled = true;
                    bananaSlider.IsEnabled = true;
                    break;
            }
        }
        private void DisableControls(string checkBoxName)
        {
             
            switch (checkBoxName)
            {
                case "lemonCheckBox":
                    lemonTextBox.IsEnabled = false;
                    lemonSlider.IsEnabled = false;
                    break;
                
                case "strawberryCheckBox":
                    strawberryTextBox.IsEnabled = false;
                    strawberrySlider.IsEnabled = false;
                    break;
                case "chocoCheckBox":
                    chocoTextBox.IsEnabled = false;
                    chocoSlider.IsEnabled = false;
                    break;
                case "bananaCheckBox":
                    bananaTextBox.IsEnabled = false;
                    bananaSlider.IsEnabled = false;
                    break;
            }
        }
        private void UpdateTotal()
        {
            int bananaquantity = (int)bananaSlider.Value;
            int strawbquantity = (int)strawberrySlider.Value;
            int chocoquantity = (int)chocoSlider.Value;
            int lemonquntity = (int)lemonSlider.Value;
            double totalcalories = 0;
            double totalprice = 0;

            if (dietRadioButton.IsChecked == true)
            {
                if(lemonCheckBox.IsChecked== true)
                {
                    totalcalories += lemonquntity * dietLemonKalori;
                    totalprice += lemonquntity * dietLemonFiyat;
                }
                
                if(strawberryCheckBox.IsChecked == true)
                {
                    totalcalories += strawbquantity * dietStrawberryKalori;
                    totalprice += strawbquantity * dietStrawberryFiyat;
                }

                if(chocoCheckBox.IsChecked == true)
                {
                    totalcalories += chocoquantity * dietChocoKalori;
                    totalprice += chocoquantity * dietChocoFiyat;
                }
                if(bananaCheckBox.IsChecked == true)
                {
                    totalcalories += bananaquantity * dietBananaKalori;
                    totalprice += bananaquantity * dietBananaFiyat;
                }
            
            }
            else if (lowFatRadioButton.IsChecked== true)
            {
                if (lemonCheckBox.IsChecked == true)
                {
                    totalcalories += lemonquntity * lowFatLemonKalori;
                    totalprice += lemonquntity * lowFatLemonFiyat;
                }

                if (strawberryCheckBox.IsChecked == true)
                {
                    totalcalories += strawbquantity * lowFatStrawberryKalori;
                    totalprice += strawbquantity * lowFatStrawberryFiyat;
                }

                if (chocoCheckBox.IsChecked == true)
                {
                    totalcalories += chocoquantity * lowFatChocoKalori;
                    totalprice += chocoquantity * lowFatChocoFiyat;
                }
                if (bananaCheckBox.IsChecked == true)
                {
                    totalcalories += bananaquantity * lowFatBananaKalori;
                    totalprice += bananaquantity * lowFatBananaFiyat;
                }
            }
            else if(fatRadioButton.IsChecked == true)
            {
                if (lemonCheckBox.IsChecked == true)
                {
                    totalcalories += lemonquntity * fatLemonKalori;
                    totalprice += lemonquntity * fatLemonFiyat;
                }

                if (strawberryCheckBox.IsChecked == true)
                {
                    totalcalories += strawbquantity * fatStrawberryKalori;
                    totalprice += strawbquantity * fatStrawberryFiyat;
                }

                if (chocoCheckBox.IsChecked == true)
                {
                    totalcalories += chocoquantity * fatChocoKalori;
                    totalprice += chocoquantity * fatChocoFiyat;
                }
                if (bananaCheckBox.IsChecked == true)
                {
                    totalcalories += bananaquantity * fatBananaKalori;
                    totalprice += bananaquantity * fatBananaFiyat;
                }
            }
            
            if (pearbtn.IsChecked== true)
            {
                totalcalories += peanutKalori;
            }
            else if (hazelrbtn.IsChecked == true)
            {
                totalcalories += hazelnutKalori;
            }
            else if (anteprbtn.IsChecked == true)
            {
                totalcalories += antepnutKalori;
            }

            totalCaloriesTxt.Text = totalcalories.ToString();
            totalPriceTxt.Text = totalprice.ToString();
        }

        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            

            string milkType = "";
            if (dietRadioButton.IsChecked == true)
            {
                milkType = "Diet";
            }
            else if (lowFatRadioButton.IsChecked == true)
            {
                milkType = "Low Fat";
            }
            else if (fatRadioButton.IsChecked == true)
            {
                milkType = "Fat";
            }

            string extra = "";
            if(pearbtn.IsChecked==true)
            {
                extra = "Peanut";
            }
            else if (anteprbtn.IsChecked == true)
            {
                extra = "Antepnut";
            }
            else if (hazelrbtn.IsChecked == true)
            {
                extra = "Hazelnut";
            }

            string additions = "";
            if (lemonCheckBox.IsChecked == true)
            {
                additions += "Lemon ";
            }

            if (bananaCheckBox.IsChecked == true)
            {
                additions += "Banana ";
            }
            if (chocoCheckBox.IsChecked == true)
            {
                additions += "Choco ";
            }

            if (strawberryCheckBox.IsChecked == true)
            {
                additions += "Strawb ";
            }

            double totalCalories = double.Parse(totalCaloriesTxt.Text);
            double totalPrice = double.Parse(totalPriceTxt.Text);

            cartItems.Add(new CartItem
            {
                MilkType = milkType,
                Additions = additions,
                Extra = extra, 
                TotalValue = totalPrice,
                TotalCalorie = totalCalories
            });
            listView.ItemsSource = cartItems;
            CalculateGrandTotal();
        }
        public class CartItem
        {
            public string MilkType { get; set; }
            public string Additions { get; set; }
            public string Extra { get; set; }
            public double TotalValue { get; set; }
            public double TotalCalorie { get; set; }
        }

        private void NewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            dietRadioButton.IsChecked = false;
            lowFatRadioButton.IsChecked = false;
            fatRadioButton.IsChecked = false;

            lemonCheckBox.IsChecked = false;
            bananaCheckBox.IsChecked = false;
            strawberryCheckBox.IsChecked = false;
            chocoCheckBox.IsChecked = false;

            bananaSlider.Value = 0;
            chocoSlider.Value = 0;
            lemonSlider.Value = 0;
            strawberrySlider.Value = 0;

            totalCaloriesTxt.Text = "0";
            totalPriceTxt.Text = "0";

            hazelrbtn.IsChecked = false;
            anteprbtn.IsChecked = false;
            pearbtn.IsChecked = false;
        }
        private void UpdateInsertButtonState()
        {
            if (lemonCheckBox.IsChecked == true || bananaCheckBox.IsChecked == true || strawberryCheckBox.IsChecked == true || chocoCheckBox.IsChecked == true)
            {
                insertButton.IsEnabled = true;
            }
            else
            {
                insertButton.IsEnabled = false;
            }
        }

        private void newcustomerbtn_Click(object sender, RoutedEventArgs e)
        {
            dietRadioButton.IsChecked = false;
            lowFatRadioButton.IsChecked = false;
            fatRadioButton.IsChecked = false;

            lemonCheckBox.IsChecked = false;
            bananaCheckBox.IsChecked = false;
            strawberryCheckBox.IsChecked = false;
            chocoCheckBox.IsChecked = false;

            bananaSlider.Value = 0;
            chocoSlider.Value = 0;
            lemonSlider.Value = 0;
            strawberrySlider.Value = 0;

            totalCaloriesTxt.Text = "0";
            totalPriceTxt.Text = "0";

            hazelrbtn.IsChecked = false;
            anteprbtn.IsChecked = false;
            pearbtn.IsChecked = false;

            fullnametxt.Text = "";
            adresstxt.Text = "";

        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedItems();
            CalculateGrandTotal();
        }
        private void DeleteSelectedItems()
        {
            foreach (var selectedItem in listView.SelectedItems.OfType<CartItem>().ToList())
            {
                cartItems.Remove(selectedItem);
            }
        }

        private void CalculateGrandTotal()
        {
            double grandTotal = cartItems.Sum(item => item.TotalValue);
            grandtotaltxt.Text = grandTotal.ToString();
        }

    }
}
