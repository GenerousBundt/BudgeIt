using System;
using Xamarin.Forms;
using BudgeIt.Skateboard.Models;
using BudgeIt.Infrastructure;
using System.Globalization;
using System.Threading.Tasks;
using System.Text.Json;

namespace BudgeIt.Skateboard
{
    public class SkateboardHomePage : ContentPage
    {
        StackLayout mainLayout;
        StackLayout entriesLayout;
        StackLayout btnLayout;
        Entry amtEntry;
        Entry notesEntry;
        Picker accountPicker;

        FileEngine fileEngine = new FileEngine();

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
            amtEntry = new Entry
            {
                Placeholder = defaultAmtValue.ToString("C", CultureInfo.CurrentCulture),
                WidthRequest = 110,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Keyboard = Keyboard.Numeric,
            };

            notesEntry = new Entry
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
            accountPicker = new Picker
            {
                Title = "Select a Category",
                TitleColor = Color.Indigo,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            accountPicker.ItemsSource = listOfCategories;
            mainLayout.Children.Add(accountPicker);
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

            submitWithdrawalBtn.Clicked += Withdrawal_Clicked;
            Button submitDepositBtn = new Button
            {
                Text = "Deposit",
                BackgroundColor = Color.DarkGreen,
                CornerRadius = 5,
                WidthRequest = 100,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            submitDepositBtn.Clicked += Deposit_Clicked;
            btnLayout = new StackLayout
            {
                Padding = new Thickness(0),
                Orientation = StackOrientation.Horizontal
            };
            btnLayout.Children.Add(submitDepositBtn);
            btnLayout.Children.Add(submitWithdrawalBtn);

            mainLayout.Children.Add(btnLayout);
        }
        private async void Withdrawal_Clicked(object sender, EventArgs e)
        {
            await Button_Clicked(sender, e, BudgetAction.Withdrawal);
        }
        private async void Deposit_Clicked(object sender, EventArgs e)
        {
            var entries = await fileEngine.ReadTextAsync(new Categories().CategoryList[0]);
            Console.WriteLine(entries);
        }
        private async Task Button_Clicked(object sender, EventArgs e, BudgetAction action)
        {
            if(accountPicker.SelectedItem == null)
            {
                Console.WriteLine("You must select an account.");
                return;
            }
            string amount = amtEntry.Text;
            if ((!string.IsNullOrEmpty(amount))
                &&
                decimal.TryParse(amount, out decimal amtDecimal))
            {
                var budgetEntry = new BudgetEntry(action);
                budgetEntry.Amount = amtDecimal;
                budgetEntry.Category = (string)accountPicker.SelectedItem;
                budgetEntry.Note = notesEntry.Text;

                await fileEngine.WriteTextAsync(
                    budgetEntry.Category,
                    JsonSerializer.Serialize(budgetEntry)
                    );
            }
                
            else
                Console.WriteLine("Amount must be filled in with a valid amount.");
        }
    }
}
