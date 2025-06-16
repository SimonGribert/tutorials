namespace MauiTestApp;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.NotePage), typeof(Views.NotePage));
        Routing.RegisterRoute(nameof(Views.NoteSqlPage), typeof(Views.NoteSqlPage));
    }
}