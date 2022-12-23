
namespace MAUI_Biometric;


public partial class PinEntry : ContentPage
{
	public PinEntry()
	{
		InitializeComponent();
	}

    private async void  OnContinueClicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("///HomePage");
    }
}
