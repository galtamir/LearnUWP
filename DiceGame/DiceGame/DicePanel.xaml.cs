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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DiceGame
{
    public sealed partial class DicePanel : UserControl
    {


        public int NumberOfDice
        {
            get { return (int)GetValue(NumberOfDicesProperty); }
            set { UpdateNumberOfDice(NumberOfDice, value); SetValue(NumberOfDicesProperty, value);  }
        }

        // Using a DependencyProperty as the backing store for NumberOfDies.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberOfDicesProperty =
            DependencyProperty.Register("NumberOfDice", typeof(int), typeof(DicePanel), new PropertyMetadata(0));

        private List<Dice> dices;

        public DicePanel()
        {
            this.InitializeComponent();
            dices = new List<Dice>();
        }

        public DiceResult Roll()
        {
            foreach(var dice in dices)
            {
                dice.Roll();
            }
            return new DiceResult 
            { 
                Sum = dices.Sum(x => x.Value), 
                Average = dices.Average(x=>x.Value), 
                NumberOfDice = dices.Count
            };
        }

        private void UpdateNumberOfDice(int oldValue, int newValue)
        {
            for(int i = oldValue; i< newValue; i++)
            {
                AddDice();
            }
            for (int i = newValue; i < oldValue; i++)
            {
                RemoveDice();
            }
        }

        private void AddDice()
        {
            var dice = new Dice();
            MainPanel.Children.Add(dice);
            MainPanel.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetColumn(dice, dices.Count);
            dices.Add(dice);
            
        }

        private void RemoveDice()
        {
            var toRemove = dices.Last();
            MainPanel.Children.Remove(toRemove);
            dices.Remove(toRemove);
            MainPanel.ColumnDefinitions.Remove(MainPanel.ColumnDefinitions.Last());
        }
    }
}
