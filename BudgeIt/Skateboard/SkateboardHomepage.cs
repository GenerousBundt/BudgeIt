using System;
using Xamarin.Forms;
using BudgeIt.Skateboard.Models;
using System.Globalization;

namespace BudgeIt.Skateboard
{
    public class SkateboardHomePage : ContentPage
    {
        StackLayout mainLayout;
        StackLayout entriesLayout;
        StackLayout btnLayout;
        Picker accountPicker;


        public SkateboardHomePage()
        {
            Title = "Tim Denison's BudgeIt";
            mainLayout = new StackLayout
            {
                Padding = new Thickness(20, 35, 20, 25),
                Orientation = StackOrientation.Vertical
            };

            ConfigureTitle();

            ConfigureEntries();

            ConfigurePicker();

            ConfigureButtons();

            Content = mainLayout;

        }
        private void ConfigureTitle()
        {
            Label mainLabel = new Label
            {
                Text = Title, // This value is set in constructor
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            mainLayout.Children.Add(mainLabel);
        }
        private void ConfigureEntries()
        {
            entriesLayout = new StackLayout
            {
                Padding = new Thickness(0),
                Orientation = StackOrientation.Horizontal
            };

            var defaultAmtValue = 0.00M;
            Entry amtEntry = new Entry
            {
                Placeholder = defaultAmtValue.ToString("C", CultureInfo.CurrentCulture),
                WidthRequest = 110,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Keyboard = Keyboard.Numeric,
            };

            Entry notesEntry = new Entry
            {
                Placeholder = "Note",
                WidthRequest = 110,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            entriesLayout.Children.Add(amtEntry);
            entriesLayout.Children.Add(notesEntry);

            mainLayout.Children.Add(entriesLayout);
        }
        private void ConfigurePicker()
        {

            var listOfCategories = new Categories().CategoryList;
            var picker = new Picker
            {
                Title = "Select a Category",
                TitleColor = Color.Indigo,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            picker.ItemsSource = listOfCategories;
            mainLayout.Children.Add(picker);
        }
        private void ConfigureButtons()
        {
            Button submitWithdrawalBtn = new Button
            {
                Text = "Withdraw",
                BackgroundColor = Color.DarkOrange,
                CornerRadius = 5,
                WidthRequest = 100,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            Button submitDepositBtn = new Button
            {
                Text = "Deposit",
                BackgroundColor = Color.DarkGreen,
                CornerRadius = 5,
                WidthRequest = 100,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            btnLayout = new StackLayout
            {
                Padding = new Thickness(0),
                Orientation = StackOrientation.Horizontal
            };
            btnLayout.Children.Add(submitDepositBtn);
            btnLayout.Children.Add(submitWithdrawalBtn);

            mainLayout.Children.Add(btnLayout);
        }
    }
}
