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
    public sealed partial class ChangePasswordPage : Page
    {
        private BankUser user;

        public ChangePasswordPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            user = e.Parameter as BankUser;
            base.OnNavigatedTo(e);
        }

        private void ChangePassword(object sender, RoutedEventArgs e)
        {
            if (!user.Credentials.IsPasswordCorect(OldPassword.Password)) 
            {
                OldPassword.Password = string.Empty;
                OldPassword.PlaceholderText = "Incorrect password";
                
                return;
            }

            if (!NewPassword.Password.Equals(ReenterPassword.Password))
            {
                ReenterPassword.Password = string.Empty;
                ReenterPassword.PlaceholderText = "Passwords dose not match";

                return;
            }

            user.Credentials.CahngePassword(OldPassword.Password, NewPassword.Password);

            OldPassword.Password = string.Empty;
            NewPassword.Password = string.Empty;
            ReenterPassword.Password = string.Empty;
        }
    }
}
