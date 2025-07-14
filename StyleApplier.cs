using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SeoulStay
{
    public class StyleApplier
    {
        public static string fontName = "OpenSans";
        public static string seoulRed = "#e51a2e";
        public static string textColor = "#333333";
        public static string background = "#bbbbbb";
        public static string white = "#ffffff";

        public static void Apply(Panel panel)
        {
            var fontFamily = new FontFamily(new Uri("pack://application:,,,/"), $"./Open_Sans/#{fontName}");
            var redBrush = (Brush) new BrushConverter().ConvertFromString(seoulRed);
            var textBrush = (Brush)new BrushConverter().ConvertFromString(textColor);
            var backgBrush = (Brush)new BrushConverter().ConvertFromString(background);
            var whiteBrush = (Brush)new BrushConverter().ConvertFromString(white);

            if(panel.Parent is Window window)
            {
                window.Background = backgBrush;
            }

            foreach(UIElement element in panel.Children)
            {
                if(element is Panel)
                {
                    Apply(element as Panel);
                }

                if(element is Label lbl)
                {
                    lbl.Foreground = textBrush;
                }
                if(element is Button btn)
                {
                    btn.Background = redBrush;
                    btn.Foreground = whiteBrush;
                    btn.BorderThickness = new Thickness(0);

                }
                if(element is DataGrid dataGrid)
                {
                    dataGrid.FontFamily = fontFamily;
                    dataGrid.GridLinesVisibility = DataGridGridLinesVisibility.None;
                    dataGrid.Foreground = textBrush;
                }
                if(element is TabControl tabControl)
                {
                    tabControl.FontFamily = fontFamily;

                    foreach(var tabitem in tabControl.Items)
                    {
                        if(tabitem is Panel)
                        {
                            Apply(tabitem as Panel);
                        }
                    }
                }
            }
        }

    }
}
