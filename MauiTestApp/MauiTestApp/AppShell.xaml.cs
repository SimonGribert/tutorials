using MauiTestApp.Views;
using Microsoft.Maui.Controls;

namespace MauiTestApp;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(NotePage), typeof(NotePage));
        Routing.RegisterRoute(nameof(MainView), typeof(MainView));
        Routing.RegisterRoute(nameof(ClaimsView), typeof(ClaimsView));
    }
}