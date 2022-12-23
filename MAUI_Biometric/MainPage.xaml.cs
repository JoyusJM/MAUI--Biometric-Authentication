using Microsoft.Maui.Controls;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;

namespace MAUI_Biometric;

public partial class MainPage : ContentPage
{

	private readonly IFingerprint fingerprint;

    public MainPage(IFingerprint fingerprint)
	{
		InitializeComponent();
        this.fingerprint = fingerprint;
    }

	private async void OnCounterClicked(object sender, EventArgs e)
	{

        var isEnabled = await CrossFingerprint.Current.IsAvailableAsync();

        if(isEnabled)
        {
            var request = new AuthenticationRequestConfiguration("Authentication", "Please autheticate to login");

            var result = await CrossFingerprint.Current.AuthenticateAsync(request);

            if (result.Authenticated)
            {
             
                await Shell.Current.GoToAsync("///HomePage");
            }
            else
            {
                await Shell.Current.GoToAsync("///PinEntry");
            }

        }
        else
        {
            bool answer = await DisplayAlert("Biometric disabled", "Would you like to continue with entering password?", "Yes", "No");

            if (answer)
            {
                await Shell.Current.GoToAsync("///PinEntry");
            }
        }
    }
}


