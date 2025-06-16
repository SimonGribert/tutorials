using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiTestApp.MSALClient;
using Microsoft.Identity.Client;
using Microsoft.Maui.Controls;

namespace MauiTestApp.Views;

public partial class ClaimsView
{
    public IEnumerable<string> IdTokenClaims { get; set; } = new string[] {"No claims found in ID token"};
    public ClaimsView()
    {
        BindingContext = this;
        InitializeComponent();

        _ = SetViewDataAsync();
    }

    private async Task SetViewDataAsync()
    {
        try
        {
            _ = await PublicClientSingleton.Instance.AcquireTokenSilentAsync();

            IdTokenClaims = PublicClientSingleton.Instance.MSALClientHelper.AuthResult.ClaimsPrincipal.Claims.Select(c => c.Value);

            Claims.ItemsSource = IdTokenClaims;
        }

        catch (MsalUiRequiredException)
        {
            await Shell.Current.GoToAsync("claimsview");
        }
    }

    protected override bool OnBackButtonPressed() { return true; }

    private async void SignOutButton_Clicked(object sender, EventArgs e)
    {
        await PublicClientSingleton.Instance.SignOutAsync().ContinueWith((t) =>
        {
            return Task.CompletedTask;
        });

        await Shell.Current.GoToAsync("mainview");
    }
}