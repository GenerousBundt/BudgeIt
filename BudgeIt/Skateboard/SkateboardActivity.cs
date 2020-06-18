using System;
using System.Collections.Generic;
using BudgeIt.Skateboard.Models;
using Xamarin.Forms;

namespace BudgeIt.Skateboard
{
    public class SkateboardActivity : ContentPage
    {
        StackLayout activityMainLayout;
        Picker accountPicker;

        public SkateboardActivity()
        {
            Title = "Budget Activity";
            activityMainLayout = new StackLayout
            {
                Padding = new Thickness(20, 35, 20, 25),
                Orientation = StackOrientation.Vertical
            };

            ConfigurePicker();

            ListView listView = new ListView();
            listView.ItemsSource = new List<string> { "First", "Second", "Third" };

            activityMainLayout.Children.Add(listView);
            Content = activityMainLayout;

        }

        private void ConfigurePicker()
        {
            var listOfCategories = new Categories().CategoryList;
            accountPicker = new Picker
            {
                Title = "Select a Category",
                TitleColor = Color.Indigo,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            accountPicker.ItemsSource = listOfCategories;
            accountPicker.SelectedItem = listOfCategories[0];
            activityMainLayout.Children.Add(accountPicker);
        }
    }
}
