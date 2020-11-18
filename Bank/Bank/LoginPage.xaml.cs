using Bank.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Bank
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public event TypedEventHandler<Page, BankUser> OnUserLogin;

        private SignIn SignInDialog;
        private Signup SignUpDialog;

        public LoginPage()
        {
            SignInDialog = new SignIn();
            SignUpDialog = new Signup();
            SignInDialog.OnUserLogin += UserLogedin;
            SignUpDialog.OnUserSinedup += UserSinedupAsync;
            this.InitializeComponent();
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var page = e.Parameter as MainPage;
            SignInDialog.UserManager = page.userManager;
            SignUpDialog.UserManager = page.userManager;
            SignInDialog.OnUserLogin += page.NavigateToAccount;
            base.OnNavigatedTo(e);
        }

        private async void SignInButtonClickedAsync(object sender, RoutedEventArgs e)
        {
            var result = await SignInDialog.ShowAsync();
        }



        private async void SignupButtonClickedAsync(object sender, RoutedEventArgs e)
        {
            var result = await SignUpDialog.ShowAsync();

        }

        private void UserLogedin(SignIn sender, BankUser args)
        {
            if (OnUserLogin != null)
                OnUserLogin(this, args);
        }

        private async void UserSinedupAsync(object sender, string userName)
        {
            SignInDialog.SetUserName(userName);
        }
    }
}
