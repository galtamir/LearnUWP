using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.RemoteDesktop;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiceGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public IEnumerable<int> NumberOfDiceSource { get; } = Enumerable.Range(1, 6);

        private ObservableCollection<DiceResult> _results = new ObservableCollection<DiceResult>();
        
        public ObservableCollection<DiceResult> Results
        {
            get { return this._results; }
        }


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Roll(object sender, RoutedEventArgs e)
        {
            Results.Add(Dices.Roll());
        }
        
        public string PrintLast(ObservableCollection<DiceResult> dices)
        {
            if (dices.Any())
            {
                return dices.Last().ToString();
            }
            return "";
        }

        public int SelectedToInt(object selected)
        {
            if (selected == null)
                return 0;
            return (int)selected;
        }
    }
}
