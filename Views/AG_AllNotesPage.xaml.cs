namespace AG_appApuntes.Views;

public partial class AG_AllNotesPage : ContentPage
{
	public AG_AllNotesPage()
	{
		InitializeComponent();
        
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }

}