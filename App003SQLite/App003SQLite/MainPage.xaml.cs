using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using App003SQLite.model;
using App003SQLite.controller;
using App003SQLite.ModelView;

namespace App003SQLite
{
    public partial class MainPage : ContentPage
    {  
 
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new PersonsViewModel();
        }

   
     
        private async void lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new home());
        }
    }
}
