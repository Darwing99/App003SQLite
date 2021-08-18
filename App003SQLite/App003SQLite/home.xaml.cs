using App003SQLite.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App003SQLite.model;

namespace App003SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class home : ContentPage
    {
  
        public home()
        {
            InitializeComponent();

            OnAppearing();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ModelView.ListImageViewModel(Navigation);
        }

        private void menuToolbar_Clicked(object sender, EventArgs e)
        {

        }


       


     
    }
}