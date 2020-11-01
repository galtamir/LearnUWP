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

namespace NumberBoxStatisticsCalculator
{
    public sealed partial class MySlider : UserControl
    {
        public string Header { get; set; }

        public double Value
        {
            get { return InternalSlider.Value; }
            set { InternalSlider.Value = value; }
        }

        public event RangeBaseValueChangedEventHandler ValueChanged
        {
            add { InternalSlider.ValueChanged += value; }
            remove { InternalSlider.ValueChanged -= value; }
        }


        public MySlider()
        {
            this.InitializeComponent();
        }

        private void UpButtonClicked(object sender, RoutedEventArgs e)
        {
            InternalSlider.Value++;
        }

        private void DownButtonClicked(object sender, RoutedEventArgs e)
        {
            InternalSlider.Value--;
        }
    }
}
