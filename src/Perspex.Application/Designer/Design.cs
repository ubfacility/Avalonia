﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Perspex.Controls;

namespace Perspex
{
    public static class Design
    {
        public static bool IsDesignMode { get; internal set; }

        public static readonly PerspexProperty<double> HeightProperty = PerspexProperty
            .RegisterAttached<TopLevel, double>("Height", typeof (Design));

        public static void SetHeight(TopLevel topLevel, double value)
        {
            topLevel.SetValue(HeightProperty, value);
        }

        public static double GetHeight(TopLevel topLevel)
        {
            return (double) topLevel.GetValue(HeightProperty);
        }

        public static readonly PerspexProperty<double> WidthProperty = PerspexProperty
    .RegisterAttached<TopLevel, double>("Width", typeof(Design));

        public static void SetWidth(TopLevel topLevel, double value)
        {
            topLevel.SetValue(WidthProperty, value);
        }

        public static double GetWidth(TopLevel topLevel)
        {
            return (double)topLevel.GetValue(WidthProperty);
        }

        public static readonly PerspexProperty<object> DataContextProperty = PerspexProperty
            .RegisterAttached<TopLevel, object>("DataContext", typeof (Design));

        public static void SetDataContext(TopLevel topLevel, object value)
        {
            topLevel.SetValue(DataContextProperty, value);
        }

        public static object GetDataContext(TopLevel topLevel)
        {
            return topLevel.GetValue(DataContextProperty);
        }

        static Design()
        {
            WidthProperty.Changed.Subscribe(OnChanged);
            HeightProperty.Changed.Subscribe(OnChanged);
            DataContextProperty.Changed.Subscribe(OnChanged);
        }

        static void OnChanged(PerspexPropertyChangedEventArgs args)
        {
            if(!IsDesignMode)
                return;
            if (args.Property == WidthProperty)
                ((TopLevel) args.Sender).Width = (double) args.NewValue;
            if (args.Property == HeightProperty)
                ((TopLevel)args.Sender).Height = (double)args.NewValue;
            if (args.Property == DataContextProperty)
                ((TopLevel) args.Sender).DataContext = args.NewValue;
        }
    }
}
