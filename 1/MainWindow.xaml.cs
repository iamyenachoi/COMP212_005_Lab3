using _1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
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

namespace _1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Observable collection to trigger update on change
        private ObservableCollection<FoodItemCounter> foodCollection;
        //view model for MVVM
        private MainAppViewModel model;
        
        //Initialization and populating the controls
        public MainWindow()
        {
            //component initialization
            InitializeComponent();

            //reference allocating
            model = new MainAppViewModel();
            //attaching references
            foodCollection = new ObservableCollection<FoodItemCounter>();
            //handle change event
            foodCollection.CollectionChanged += HandleChange;
            //decorate and fill fields
            studentnameHolder.Content = Constants.StudentInfo;

            //content for combobox 
            food_Appetizer.Content = Constants.FoodAppetizer;
            food_Beverage.Content = Constants.FoodBeverage;
            food_MainCourse.Content = Constants.FoodMainCourse;
            food_Dessert.Content = Constants.FoodDessert;

            //Combobox binding of Beverage
            cmbfood_Beverage.ItemsSource = FoodItemInitializer.Beverages;
            cmbfood_Beverage.DisplayMemberPath = "DisplayProp";
            cmbfood_Beverage.SelectedValuePath = "Price";

            //Combobox binding of MainCourse
            cmbfood_MainCourse.ItemsSource = FoodItemInitializer.MainCourse;
            cmbfood_MainCourse.DisplayMemberPath = "DisplayProp";
            cmbfood_MainCourse.SelectedValuePath = "Price";

            //Combobox binding of MainCourse
            cmbfood_Dessert.ItemsSource = FoodItemInitializer.Dessert;
            cmbfood_Dessert.DisplayMemberPath = "DisplayProp";
            cmbfood_Dessert.SelectedValuePath = "Price";

            //Combobox binding of cmbfood_Appetizer
            cmbfood_Appetizer.ItemsSource = FoodItemInitializer.Appetizer;
            cmbfood_Appetizer.DisplayMemberPath = "DisplayProp";
            cmbfood_Appetizer.SelectedValuePath = "Price";

        }

        private void HandleChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            //food collection
            gridAllFood.ItemsSource = foodCollection;

            //data init
            double totalAmount = 0;

            foreach (var item in foodCollection)
                totalAmount += item.Count * item.Price;
            //binding to UI
            lblTotalAmount.Content = Math.Round(totalAmount, 2).ToString();
            lblTax.Content= Math.Round(totalAmount*Constants.TaxRate/100, 2).ToString();
            lblTotal.Content = Math.Round(totalAmount+ totalAmount * Constants.TaxRate / 100,2);
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //navigate to college website
            var psi = new ProcessStartInfo
            {
                FileName = Constants.CollegeUrl,
                UseShellExecute = true
            };
            Process.Start(psi);
        }


        private void Cmbfood_Beverage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (FoodItem)cmbfood_Beverage.SelectedItem;

            //if item is not null then update food collection
            if (item != null)
                AddToFoodCollection(item);
        }

        private void Cmbfood_Appetizer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (FoodItem)cmbfood_Appetizer.SelectedItem;

            //if item is not null then update food collection
            if (item != null)
                AddToFoodCollection(item);
        }

        private void Cmbfood_MainCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ///SelectedItem
            var item = (FoodItem)cmbfood_MainCourse.SelectedItem;

            //SelectedItem is not null then add
            if (item != null)
                AddToFoodCollection(item);
        }

        private void Cmbfood_Dessert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //fetch selected item
            var item = (FoodItem)cmbfood_Dessert.SelectedItem;

            //SelectedItem is not null then add
            if (item != null)
                AddToFoodCollection(item);
        }

        private void AddToFoodCollection(FoodItem item)
        {
            //find the element
            var itemCounter = foodCollection.FirstOrDefault(x => x.Category == item.Category && x.Name == item.Name && x.Price == item.Price);
            //SelectedItem is not null then 
            if (itemCounter != null)
            {
                foodCollection.Remove(itemCounter);
                //update counter
                itemCounter.Count = itemCounter.Count + 1;
            }
            else
            {
                itemCounter = new FoodItemCounter
                {
                    Name = item.Name,
                    Price = item.Price,
                    Category = item.Category,
                    Count = 1
                };

            }
            //update collection by inserting
            foodCollection.Add(itemCounter);
            //MVVM update
            UpdateMVVMPattern(itemCounter.Name, itemCounter.Category, "Insertion/Updation");
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //bind to ui
            gridAllFood.ItemsSource = foodCollection;
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //clear all data in grid
            foodCollection.Clear();
        }

        //Grid selection of row
        private void GridAllFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = ((DataGrid)sender).CurrentColumn.DisplayIndex;
            
            if ((e.AddedItems) != null && (e.AddedItems).Count > 0&&a!=2)
            {
                var selectedItem = (FoodItemCounter)(e.AddedItems)[0];
                var itemCounter = foodCollection.FirstOrDefault(x => x.Category == selectedItem.Category && x.Name == selectedItem.Name);

                if (itemCounter != null)
                {
                    //remove item
                    foodCollection.Remove(itemCounter);

                    //update count
                    itemCounter.Count = itemCounter.Count - 1;

                    //insert the values
                    if (itemCounter.Count > 0)
                        foodCollection.Add(itemCounter);
                }
            }


        }

        private void UpdateMVVMPattern(string dessert, string cbo, string cmd)
        {
            model.DropDownClosedCommand = cmd;
            model.Source4cboDessert = cbo;
            model.SelectedDesert = dessert;
        }
    }
}
