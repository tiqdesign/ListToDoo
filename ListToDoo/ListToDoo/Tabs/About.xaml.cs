using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListToDoo.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        //Asagıda acıkladıgım kısma dahil
        //public ICommand AddText { get; private set; }
        //public ICommand AddText2 { get; private set; }
        //public ICommand GeriAl { get; private set; }

        private Stack<ICommand> _Undo;
        public About()
        {
            //dahil
            InitializeComponent();
            //BindingContext = new AboutViewModel();
            //AddText = new Command(ekle);
            //AddText2=new Command(ekle2);
            //GeriAl = new Command(gerial);

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

        //Burada yapılanlar viewmodel kısmında yapılması gerekiyor

        //public void ekle()
        //{
        //    lb_dene.Text += "+";
        //    _Undo.Push(AddText);
        //}

        //public void undoEkle()
        //{
        //    lb_dene.Text.ToString().Remove('+');
        //}
        //public void undoEkle2()
        //{
        //    lb_dene.Text="";
        //}

        //public void ekle2()
        //{
        //    lb_dene.Text += "++";
        //    _Undo.Push(AddText);
        //}
        //public void gerial()
        //{
        //    string prevCommand = _Undo.Peek().ToString();

        //    switch (prevCommand)
        //    {
        //        case "AddText":
        //            undoEkle();break;
        //        case "AddText2":
        //            undoEkle2();break;

        //    }
        //}

    }
}