using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Nen.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    string firstName;

    [ObservableProperty]

    string lastName;

    [RelayCommand]
     async void GoogleLoginAttempt()
    {
        // Use Service to go validate deatils in database
        Console.WriteLine("DEBUG: Google Login");

        try
        {
            WebAuthenticatorResult authResult = await WebAuthenticator.Default.AuthenticateAsync(
                new Uri("NenAPI.com/Auth/Google"),
                new Uri("Nen://"));

            string accessToken = authResult?.AccessToken;

            // Do something with the token
        }
        catch (TaskCanceledException e)
        {
            // Use stopped auth
            Console.WriteLine(e.Message);
        }
    }

    [RelayCommand]
    void LoginAttempt()
    {
        // Use Service to go validate deatils in database
    }
}
