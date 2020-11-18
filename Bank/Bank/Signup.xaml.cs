using Bank.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class Signup : ContentDialog
    {
        public UserManager UserManager { get; set; }

        public event TypedEventHandler<ContentDialog, string> OnUserSinedup;

        private static string emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";


        public Signup()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (string.IsNullOrEmpty(userNameTextBox.Text))
            {
                args.Cancel = true;
                errorTextBlock.Text = "User name is required.";
            }
            else if (UserManager.Contains(userNameTextBox.Text))
            {
                args.Cancel = true;
                errorTextBlock.Text = "User already exists.";
            }
            else if (string.IsNullOrEmpty(firstNameTextBox.Text))
            {
                args.Cancel = true;
                errorTextBlock.Text = "First name is required.";
            }
            else if (string.IsNullOrEmpty(LastNameTextBox.Text))
            {
                args.Cancel = true;
                errorTextBlock.Text = "Last name is required.";
            }
            else if (string.IsNullOrEmpty(passwordTextBox.Password))
            {
                args.Cancel = true;
                errorTextBlock.Text = "Password is required.";
            }
            else if (!passwordTextBox.Password.Equals(ReenterpasswordTextBox.Password))
            {
                args.Cancel = true;
                passwordTextBox.Password = String.Empty;
                errorTextBlock.Text = "Password mismatch.";
                passwordTextBox.PlaceholderText = "Password mismatch.";
            }
            else if (!Regex.IsMatch(emailTextBox.Text, emailPattern))
            {
                args.Cancel = true;
                emailTextBox.Text = String.Empty;
                errorTextBlock.Text = "Invalid email address.";
                emailTextBox.PlaceholderForeground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            }
            else
            {
                if (!UserManager.AddNewUser(new BankUser(userNameTextBox.Text, passwordTextBox.Password) { Email = emailTextBox.Text, FirstName = firstNameTextBox.Text, LastName = LastNameTextBox.Text }))
                {
                    args.Cancel = true;
                    errorTextBlock.Text = "Failed adding new user.";
                }
                else if(OnUserSinedup != null)
                {
                    OnUserSinedup(this, userNameTextBox.Text);
                }
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Reset();
        }

        private void Reset()
        {
            errorTextBlock.Text = String.Empty;
            userNameTextBox.Text = String.Empty;
            passwordTextBox.Password = String.Empty;
            ReenterpasswordTextBox.Password = String.Empty;
            LastNameTextBox.Text = String.Empty;
            firstNameTextBox.Text = String.Empty;
            emailTextBox.Text = String.Empty;
        }
    }
}
