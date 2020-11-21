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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Bank
{
    public sealed partial class SignIn : ContentDialog
    {
        public event TypedEventHandler<SignIn, BankUser> OnUserLogin;

        public UserManager UserManager { get; set; }

        public SignIn()
        {
            this.InitializeComponent();
        }

        public void SetUserName(string userName)
        {
            userNameTextBox.Text = userName;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Ensure the user name and password fields aren't empty. If a required field
            // is empty, set args.Cancel = true to keep the dialog open.
            if (string.IsNullOrEmpty(userNameTextBox.Text))
            {
                args.Cancel = true;
                errorTextBlock.Text = "User name is required.";
            }
            else if (string.IsNullOrEmpty(passwordTextBox.Password))
            {
                args.Cancel = true;
                errorTextBlock.Text = "Password is required.";
            }
            else
            {
                var result = UserManager.Login(userNameTextBox.Text, passwordTextBox.Password, out BankUser user);
                if (LoginResult.InvalidPassword.Equals(result))
                {
                    args.Cancel = true;
                    errorTextBlock.Text = "Invalid Password.";
                }
                if (LoginResult.InvalidUser.Equals(result))
                {
                    args.Cancel = true;
                    errorTextBlock.Text = "Invalid User.";
                }
                else if(OnUserLogin != null)
                {
                    OnUserLogin(this, user);
                }
            }
            Reset();

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Reset();
        }

        private void Reset()
        {
            passwordTextBox.Password = String.Empty;
            userNameTextBox.Text = String.Empty;
        }
    }
}
