using System.Threading.Tasks;
using Foundation;
using MauiTestApp.MSALClient;
using Microsoft.Identity.Client;
using Microsoft.Maui.Hosting;
using UIKit;

namespace MauiTestApp;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // configure platform specific params
        PlatformConfig.Instance.RedirectUri = $"msal{PublicClientSingleton.Instance.MSALClientHelper.AzureAdConfig.ClientId}://auth";

        // Initialize MSAL and platformConfig is set
        IAccount existinguser = Task.Run(async () => await PublicClientSingleton.Instance.MSALClientHelper.InitializePublicClientAppAsync()).Result;

        return base.FinishedLaunching(application, launchOptions);
    }
}