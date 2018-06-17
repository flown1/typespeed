using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TypeSpeed
{
    class ColorPalette
    {
        public static System.Windows.Media.SolidColorBrush GREEN = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#0A0"));
        public static System.Windows.Media.SolidColorBrush RED = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#C00"));
        public static System.Windows.Media.SolidColorBrush YELLOW = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#CC0"));

    }
}
