using App003SQLite.controller;
using App003SQLite.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App003SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateDelete : ContentPage
    {
        Crud crud = new Crud();
        public UpdateDelete()
        {
            InitializeComponent();
        }
        private async void ActualizarPersonas(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(id.Text))
            {
                Personas update = new Personas
                {
                    id = Convert.ToInt32(id.Text),
                    name =nombre.Text,
                    apellido = apellido.Text,
                    edad = Convert.ToInt32(edad.Text),
                    direccion = direccion.Text,
                    correo = correo.Text,
                    fecha = Convert.ToDateTime(fecha.Date)
                };
                await crud.getPersonasUpdateId(update);
                await DisplayAlert("Update","Datos Actualizados","ok" );
                limpiar();
            }
        }

        public void limpiar()
        {
            id.Text = "";
            nombre.Text = "";
            apellido.Text = "";
            correo.Text = "";
            direccion.Text = "";
            edad.Text = "";

        }


        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
          
                var persona=await crud.getPersonasId(Convert.ToInt32(id.Text));
            if (persona != null)
            {
                await crud.Delete(persona);
                await DisplayAlert("Delete" ,"Datos Eliminados", "ok");
                limpiar();
            }
        }
    }
}