using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Android.Graphics.Drawables.Shapes;
using Android.Util;

namespace Project_Sizes_Mattias1800
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            double fontSizeDefault = Device.GetNamedSize(NamedSize.Default, typeof(Label));
            stepperSize.FontSize = fontSizeDefault;
            stepperSize.Text = stepperSize.Text = "Named size: Micro (" + fontSizeDefault + ")";

            fontSlider.ValueChanged += FontSlider_ValueChanged;
            fontStepper.ValueChanged += FontStepper_ValueChanged;
        }

        void FontSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            DisplayMetrics metrics = new DisplayMetrics();
            int dpi = (int)metrics.DensityDpi;

            if (dpi == 0){
                dpi = 160;
            }

            int pointSizeFromSlider = (int)fontSlider.Value;

            if (pointSizeFromSlider <= 0){
                fontSizeSlider.Text = "";
                return;
            }

            fontSizeSlider.FontSize = dpi * pointSizeFromSlider / 72;
            fontSizeSlider.Text = "Point size: " + pointSizeFromSlider + "("+ (dpi * pointSizeFromSlider / 72).ToString() + ")";

        }

        void FontStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int stepperValue = (int)fontStepper.Value;

            switch (stepperValue){
                case 1:
                    double fontSizeMicro = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
                    stepperSize.FontSize = fontSizeMicro;
                    stepperSize.Text = "Named size: Micro (" + fontSizeMicro + ")";
                    break;
                case 2:
                    double fontSizeSmall = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    stepperSize.FontSize = fontSizeSmall;
                    stepperSize.Text = "Named size: Small (" + fontSizeSmall + ")";
                    break;
                case 3:
                    double fontSizeMedium = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    stepperSize.FontSize = fontSizeMedium;
                    stepperSize.Text = "Named size: Medium (" + fontSizeMedium + ")";
                    break;
                case 4:
                    double fontSizeLarge = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                    stepperSize.FontSize = fontSizeLarge;
                    stepperSize.Text = "Named size: Large (" + fontSizeLarge + ")";
                    break;
            }

        }

    }
}
