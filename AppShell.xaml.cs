namespace AG_appApuntes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.AG_NotePage), typeof(Views.AG_NotePage));
    }
}
