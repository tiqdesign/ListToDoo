using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListToDoo.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
            //Shake Shake Shake
            img_logo.GestureRecognizers.Add(new TapGestureRecognizer(async view =>
            {
                uint timeout = 50;
                await img_logo.TranslateTo(-15, 0, timeout);
                await img_logo.TranslateTo(15, 0, timeout);
                await img_logo.TranslateTo(-10, 0, timeout);
                await img_logo.TranslateTo(10, 0, timeout);
                await img_logo.TranslateTo(-5, 0, timeout);
                await img_logo.TranslateTo(5, 0, timeout);
                img_logo.TranslationX = 0;
            }));
        }

    }
}