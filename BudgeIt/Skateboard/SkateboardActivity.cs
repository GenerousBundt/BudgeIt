using System;
using System.Collections.Generic;
using System.Linq;
using BudgeIt.Skateboard.Models;
using Xamarin.Forms;

namespace BudgeIt.Skateboard
{
    public class SkateboardActivity : ContentPage
    {
        StackLayout activityMainLayout;
        Picker accountPicker;
        ListView activityView;
        List<BudgetEntry> budgetEntries;

        public SkateboardActivity()
        {
            Title = "Budget Activity";
            budgetEntries = BudgetEntry.Ledger();
            activityMainLayout = new StackLayout
            {
                Padding = new Thickness(20, 35, 20, 25),
                Orientation = StackOrientation.Vertical
            };

            ConfigurePicker();

            activityView = new ListView();
            // TODO: Get the list of actions for the selected category
            activityView.ItemsSource = budgetEntries
                .Where(x => x.Category == (string)accountPicker.SelectedItem)
                .Select(x => x.Note);


            accountPicker.SelectedIndexChanged += UpdateItemsSource;
            activityMainLayout.Children.Add(activityView);
            Content = activityMainLayout;

        }

        private void UpdateItemsSource(object sender, EventArgs e)
        {
            activityView.ItemsSource = budgetEntries
                .Where(x => x.Category == (string)accountPicker.SelectedItem)
                .Select(x => x.Note);
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
