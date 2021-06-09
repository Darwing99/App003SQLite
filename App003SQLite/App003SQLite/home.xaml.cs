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
        Coneccion conn = new Coneccion();
        Crud crud = new Crud();
        public home()
        {
            InitializeComponent();

            mostrarDatos();
        }

        private void menuToolbar_Clicked(object sender, EventArgs e)
        {

        }


       

        public async void mostrarDatos()
        {
            try
            {
                 var personasList = await crud.getReadPersonas();
                 

                if (personasList != null)
                {
                    lista.ItemsSource = personasList;
                }
               
            }catch(SQLiteException e)
            {
                await DisplayAlert("Lista","no hay registros","ok");

            }

           
        }


        private async void selectedList(object sender, SelectedItemChangedEventArgs e)
        {

            var personas = new Personas();
           
            var obj = (Personas)e.SelectedItem;
            if (!string.IsNullOrEmpty(obj.id.ToString())) {
                var persona = await crud.getPersonasId(obj.id);
                if (persona != null)
                {
                    var update = new UpdatePersona
                    {
                        id=persona.id,
                        name=persona.name,
                        apellido=persona.apellido,
                        edad=persona.edad, 
                        direccion=persona.direccion,
                        correo=persona.correo,
                        fecha=persona.fecha.ToString()

                    };
                    var pageUpdate = new UpdateDelete();
                    pageUpdate.BindingContext = update;
                    await Navigation.PushAsync(pageUpdate);
                }
            
            }

            

        }
    }
}