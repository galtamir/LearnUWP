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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DiceGame
{
    public sealed partial class Dice : UserControl
    {
        static private Random _random = new Random();
        static private readonly int MaxDiceValue = 6;

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set 
            { 
                if(value > MaxDiceValue)
                {
                    SetValue(ValueProperty, MaxDiceValue);
                }
                else if (value < 1)
                {
                    SetValue(ValueProperty, 1);
                }
                else
                {
                    SetValue(ValueProperty, value);
                }
            }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(Dice), new PropertyMetadata(1));

        public Uri NumberToBitmap(int number)
        {
            return new Uri(BaseUri, $"Images/dice_{number}.svg");
        }

        public Dice()
        {
            this.InitializeComponent();
        }

        public void Roll()
        {
            Value = _random.Next(1,MaxDiceValue + 1);
        }
    }
}
