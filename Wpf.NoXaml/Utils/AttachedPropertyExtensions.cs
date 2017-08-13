﻿using System.Windows;

namespace Wpf.NoXaml.Utils
{
    public static class AttachedPropertyExtensions
    {
        public static T Attach<T, TProp>(this T element, DependencyProperty dp, TProp value)
            where T : DependencyObject
        {
            element.SetValue(dp, value);
            return element;
        }
    }
}