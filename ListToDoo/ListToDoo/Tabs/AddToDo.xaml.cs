using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListToDoo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListToDoo.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddToDo : ContentPage
    {
        Dictionary<string, string> priorityToDo = new Dictionary<string, string>
        {
            {"Çok Aciiil!","#9B0B21"},{"Acil Gibi Gibi","#D7680C"},{"Yaniiii Bilemedim","#DBDB08"},{"Amaan Çok Şey Değil","#7BDB08"}
        };

        public static string priColor = "-";
        public static int priInt = 0;

        public AddToDo()
        {
            InitializeComponent();
            foreach (var VARIABLE in priorityToDo)
            {
                pc_pri.Items.Add(VARIABLE.Key);
            }

        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();
            db.CreateTable<ToDo>();
            ToDo toDo = new ToDo()
            {
                Title = tb_baslik.Text,
                Body = tb_not.Text,
                IsDone = false,
                Priority = priColor,
                ColorP = priInt
            };
            db.Insert(toDo);

            await Navigation.PushAsync(new MainPage());
        }

        private void Pc_pri_OnSelectedIndexChanged(object sender, EventArgs e)
        {
          var pri=pc_pri.Items[pc_pri.SelectedIndex];
          priColor = priorityToDo[pri];

          switch (priColor)
          {
                case "#9B0B21":
                    priInt = 0;
                    break;
                case "#D7680C":
                    priInt = 1 ;
                    break;
                case "#DBDB08":
                    priInt = 2;
                    break;
                case "#7BDB08":
                    priInt = 3;
                    break;
          }

        }
    }
}