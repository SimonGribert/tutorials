using Microsoft.Maui.Controls;

namespace MauiTestApp;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.NotePage), typeof(Views.NotePage));
    }
}