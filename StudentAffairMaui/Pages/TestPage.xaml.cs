using System.Diagnostics;

namespace StudentAffairMaui;

public partial class TestPage : ContentPage
{
    int count { get; set; } = 0;
    public TestPage()
    {
        var myScrollView = new ScrollView();
        var myStackLayout = new VerticalStackLayout();
        myScrollView.Content = myStackLayout;

        var PageTitle = new Label
        {
            Text = "Test Page",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center
        };
        myStackLayout.Children.Add(PageTitle);
        var CounterLabel = new Label
        {
            Text = "Current count: 0",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center
        };
        myStackLayout.Children.Add(CounterLabel);


        var myButton = new Button
        {
            Text = "Click me",
            HorizontalOptions = LayoutOptions.Center
        };
        myStackLayout.Children.Add(myButton);
        myButton.Clicked += OnCounterClicked;
        var callButton = new Button
        {
            Text = "Dial me",
            HorizontalOptions = LayoutOptions.Center
        };
        callButton.Clicked += (async (e,s)=> await OnDial(e,s,"01098015491"));
        myStackLayout.Children.Add(callButton);

        this.Content = myScrollView;
    }
    private async Task OnDial(object sender, EventArgs e, string number)
    {
        if (await this.DisplayAlert("Dial me.", $"my Number is {number}", "Yes", "No")){

            try
            {
                if (PhoneDialer.Default.IsSupported)
                    PhoneDialer.Default.Open(number);
            }
            catch (ArgumentNullException)
            {
                await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
            }
            catch (Exception)
            {
                // Other error has occurred.
                await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
            }


        }
        

    }
    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        CounterLabel.Text = $"Current count: {count}";

        SemanticScreenReader.Announce(CounterLabel.Text);
    }
}