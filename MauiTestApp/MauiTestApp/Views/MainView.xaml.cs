using System;
using MauiTestApp.MSALClient;
using Microsoft.Identity.Client;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;

namespace MauiTestApp.Views;

public partial class MainView : ContentPage
{
    public MainView()
    {
        InitializeComponent();

        IAccount cachedUserAccount =
            PublicClientSingleton.Instance.MSALClientHelper.FetchSignedInUserFromCache().Result;

        _ = Dispatcher.DispatchAsync(async () =>
        {
            if (cachedUserAccount == null)
            {
                SignInButton.IsEnabled = true;
            }
            else
            {
                await Shell.Current.GoToAsync("claimsview");
            }
        });
    }

    private async void OnSignInClicked(object sender, EventArgs e)
    {
        await PublicClientSingleton.Instance.AcquireTokenSilentAsync();
        await Shell.Current.GoToAsync("claimsview");
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}