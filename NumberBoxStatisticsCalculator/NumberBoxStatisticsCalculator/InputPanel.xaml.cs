﻿using Humanizer;
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
    public sealed partial class InputPanel : UserControl
    {
        private readonly List<MySlider> sliders;

        public InputPanel()
        {
            this.InitializeComponent();
            sliders = new List<MySlider>();
        }

        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                var oldValue = Size;
                SetValue(SizeProperty, value);
                SizeChainged(oldValue, value);
            }
        }

        // Using a DependencyProperty as the backing store for Size.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(int), typeof(InputPanel), new PropertyMetadata(0));


        public Statistics Statistics
        {
            get { return (Statistics)GetValue(StatisticsProperty); }
            set { SetValue(StatisticsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Average.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatisticsProperty =
            DependencyProperty.Register("Statistics", typeof(Statistics), typeof(InputPanel), new PropertyMetadata(0.0));


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

        internal void Clear()
        {
            foreach (var slider in sliders)
            {
                slider.Value = 0;
            }
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
                Statistics = Statistics.Calculate(sliders.Select(x=>x.Value));
            }
            else
            {
                Statistics = Statistics.Empty;
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
