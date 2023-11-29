namespace AG_appApuntes.Views;

public partial class AG_AboutPage : ContentPage
{
	public AG_AboutPage()
	{
		InitializeComponent();
	}
    
    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.About about)
        {
            await Launcher.Default.OpenAsync("https://aka.ms/maui");
        }
    }
}