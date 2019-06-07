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
    public partial class Tab2 : ContentPage
    {

        public Tab2()
        {
            InitializeComponent();
            var db = DependencyService.Get<ISQLite>().GetConnection();
            db.CreateTable<ToDo>();
            mail.Text = Application.Current.Properties["user"].ToString();
            get_progress();
           
            e_name.Text = db.Table<User>().First(u => u.Mail == mail.Text).fullName;
            e_age.Text = db.Table<User>().First(u => u.Mail == mail.Text).DateOfBirth;
            e_def.Text = db.Table<User>().First(u => u.Mail == mail.Text).Definition;
            btn_kaydet.IsEnabled = false;

            pl_refresh.RefreshCommand = new Command(() =>
            {

                get_progress();
                mail.Text = Application.Current.Properties["user"].ToString();
                pl_refresh.IsRefreshing = false;
                btn_kaydet.IsEnabled = false;
            });

        }

        public void get_progress()
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();

            if (db.Table<ToDo>().Any())
            {
                double donet = db.Table<ToDo>().Count(t => t.IsDone == true);
                double donef = db.Table<ToDo>().Count(t => t.IsDone == false);

                double ratio = donet / (donef + donet);

                progress.Progress = ratio;

                lb_progress.Text = "Notlarınızın Tamamlanma Oranı: %" + Convert.ToInt32(ratio * 100);

                if (string.IsNullOrEmpty(db.Table<User>().First(u => u.Mail == mail.Text).fullName)&& string.IsNullOrEmpty(db.Table<User>().First(u => u.Mail == mail.Text).DateOfBirth)&& string.IsNullOrEmpty(db.Table<User>().First(u => u.Mail == mail.Text).Definition))
                {
                        
                }
                else
                {
                    e_name.Text = db.Table<User>().First(u => u.Mail == mail.Text).fullName;
                    e_age.Text = db.Table<User>().First(u => u.Mail == mail.Text).DateOfBirth;
                    e_def.Text = db.Table<User>().First(u => u.Mail == mail.Text).Definition;
                }
                
            }
            
        }

        private void Btn_kaydet_OnClicked(object sender, EventArgs e)
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();
            var one_user = db.Table<User>().First(u => u.Mail == mail.Text);
            one_user.fullName = e_name.Text;
            one_user.DateOfBirth = e_age.Text;
            one_user.Definition = e_def.Text;
            db.Update(one_user);
            btn_kaydet.IsEnabled = false;

        }

        private void E_name_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            btn_kaydet.IsEnabled = true;
        }
    }
}