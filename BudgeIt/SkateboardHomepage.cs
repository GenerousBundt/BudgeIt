using System;

using Xamarin.Forms;

namespace BudgeIt
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

            Label mainLabel = new Label
            {
                Text = Title,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            mainLayout.Children.Add(mainLabel);
            entriesLayout = new StackLayout
            {
                Padding = new Thickness(0),
                Orientation = StackOrientation.Horizontal
            };

            Label dollarLabel = new Label
            {
                WidthRequest = 10,
                HorizontalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "$"
            };
            Entry amtEntry = new Entry
            {
                Placeholder = "0.00",
                WidthRequest = 100,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Keyboard = Keyboard.Numeric,
            };
            Entry notesEntry = new Entry
            {
                Placeholder = "Note",
                WidthRequest = 110,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

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

            entriesLayout.Children.Add(dollarLabel);
            entriesLayout.Children.Add(amtEntry);
            entriesLayout.Children.Add(notesEntry);

            mainLayout.Children.Add(entriesLayout);
            mainLayout.Children.Add(btnLayout);

            Content = mainLayout;

        }
    }
}
