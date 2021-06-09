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
using Android.Graphics;

namespace App003SQLite
{
    public partial class MainPage : ContentPage
    {  
        Coneccion conn = new Coneccion();
        Crud crud = new Crud();
        public MainPage()
        {
            InitializeComponent();         
        }

        private async void saveInfo(object sender, EventArgs e)
        {
            var validarDatos = new ValidarDatos();
            if (validarDatos.validarPersona(nombre.Text,apellido.Text,Convert.ToInt32(edad.Text),correo.Text,direccion.Text))
            {

                var personas = new Personas()
                {
                    id = 0,
                    name = nombre.Text,
                    apellido = apellido.Text,
                    edad = Convert.ToInt32(edad.Text),
                    direccion = direccion.Text,
                    correo = correo.Text,
                    fecha = fecha.Date,
                   

                };

                try
                {
                    /*SQLiteConnection conn1 = new SQLiteConnection(App.UBICACIONDB);
                    conn1.CreateTable<Personas>();
                    conn1.Insert(personas);
                    conn1.Close();*/

                    conn.Conn().CreateTable<Personas>();
                    conn.Conn().Insert(personas);
                    conn.Conn().Close();

                    await DisplayAlert("Success", "Datos Guardados", "Ok");
                    await Navigation.PushAsync(new home());
                    limpiar();
                 
                }
                catch (SQLiteException)
                {
                    await DisplayAlert("Warning", "Correo Ya existe", "Ok");
                }
            }
            else
            {
               await  DisplayAlert("Warning", "Debe Llenar todos los campos", "Ok");
            }
           
            
            
           
           

        }


        public void limpiar()
        {
            nombre.Text = "";
            apellido.Text = "";
            edad.Text = "";
            correo.Text = "";
            direccion.Text = "";

        }
        private async void lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new home());
        }
    }
}
