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

namespace BasicStatistics
{
    public sealed partial class InputPanel : UserControl
    {
        private readonly List<MySlider> sliders;

        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set
            {
                if (value >= 0)
                {
                    var oldValue = Size;
                    SetValue(SizeProperty, value);
                    SizeChainged(oldValue, value);
                }
            }
        }

        // Using a DependencyProperty as the backing store for Size.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(int), typeof(InputPanel), new PropertyMetadata(0));


        public double Average
        {
            get { return (double)GetValue(AverageProperty); }
            set { SetValue(AverageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Average.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AverageProperty =
            DependencyProperty.Register("Average", typeof(double), typeof(InputPanel), new PropertyMetadata(0.0));



        public double Medean
        {
            get { return (double)GetValue(MedeanProperty); }
            set { SetValue(MedeanProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Medean.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MedeanProperty =
            DependencyProperty.Register("Medean", typeof(double), typeof(InputPanel), new PropertyMetadata(0));



        private void SizeChainged(int oldValue, int newValue)
        {
            for (int i = oldValue; i < newValue; i++)
            {
                AddInput();
            }
            for (int i = newValue; i < oldValue; i++)
            {
                RemoveInput();
            }
            ValueChanged(this, null);
        }


        public InputPanel()
        {
            this.InitializeComponent();
            sliders = new List<MySlider>();
        }

        internal void Clear()
        {
            foreach (var slider in sliders)
            {
                slider.Value = 0;
            }
        }

        private double average()
        {
            return sliders.Select(x => x.Value).Average();
        }

        private double median()
        {
            return sliders.Select(x => x.Value).OrderBy(x => x).ElementAt(Size / 2);
        }

        private void AddInput()
        {
            InputGrid.RowDefinitions.Add(new RowDefinition());
            var s = new MySlider() { Header = (sliders.Count + 1).ToOrdinalWords().Pascalize() + " Input" };
            sliders.Add(s);
            s.ValueChanged += ValueChanged;

            InputGrid.Children.Add(s);
            Grid.SetRow(s, sliders.Count - 1);
            Grid.SetColumn(s, 1);
        }

        private void ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (Size > 0)
            {
                Average = sliders.Average(x => x.Value);
                Medean = sliders.Select(x => x.Value).OrderBy(x => x).ElementAt(Size / 2);
            }
            else
            {
                Average = Double.NaN;
                Medean = Double.NaN;
            }

        }

        private void RemoveInput()
        {
            if (sliders.Any())
            {
                InputGrid.RowDefinitions.RemoveAt(sliders.Count - 1);
                InputGrid.Children.Remove(sliders.Last());

                sliders[sliders.Count - 1].ValueChanged -= ValueChanged;
                sliders.RemoveAt(sliders.Count - 1);

            }
        }

        private void AddInputCleacked(object sender, RoutedEventArgs e)
        {
            Size++;
        }

        private void RemoveInputCleacked(object sender, RoutedEventArgs e)
        {
            Size--;
        }
    }
}
