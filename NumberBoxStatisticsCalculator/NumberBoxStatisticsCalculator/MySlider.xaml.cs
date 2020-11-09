﻿using System;
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
using Microsoft.UI.Xaml.Controls;

namespace NumberBoxStatisticsCalculator
{
    public sealed partial class MySlider : UserControl
    {

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(MySlider), new PropertyMetadata(""));

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

    }
}
