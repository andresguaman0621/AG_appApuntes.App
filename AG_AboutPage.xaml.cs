namespace AG_appApuntes;

public partial class AG_AboutPage : ContentPage
{
	public AG_AboutPage()
	{
		InitializeComponent();
	}

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        
        await Launcher.Default.OpenAsync("https://aka.ms/maui");
    }
}