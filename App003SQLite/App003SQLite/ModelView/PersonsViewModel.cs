using App003SQLite.controller;
using App003SQLite.model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App003SQLite.ModelView
{
    public class PersonsViewModel : BaseViewModel
    {
        Coneccion conn = new Coneccion();
        Crud crud = new Crud();
        private int id;
        private string _name;
        private string _apellido;
        private string _correo;
        private double _edad;
        private string _direccion;
        private string _puesto;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; OnPropertyChanged(); }
        }
        public double Edad
        {
            get { return _edad; }
            set { _edad = value; OnPropertyChanged(); }
        }
        public string Correo
        {
            get { return _correo; }
            set { _correo = value; OnPropertyChanged(); }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; OnPropertyChanged(); }
        }
        public string Puesto
        {
            get { return _puesto; }
            set { _puesto = value; OnPropertyChanged(); }
        }
        public async void Guardar()
        {
            if (string.IsNullOrEmpty(Name))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de nombre vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de Apellido vacio", "Ok");
                return;
            }   
            if (string.IsNullOrEmpty(Edad.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de edad vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Correo))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de correo vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Direccion))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de direccion vacio", "Ok");
                return;
            }
         
            if (string.IsNullOrEmpty(Puesto))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de puesto vacio", "Ok");
                return;
            }
            var personas = new Personas()
            {
                id = Id,
                name = Name,
                apellido = Apellido,
                edad=Edad,
                direccion = Direccion,
                correo = Correo,
                puesto=Puesto
                
            };

            try
            {


                conn.Conn().CreateTable<Personas>();
                conn.Conn().Insert(personas);
                conn.Conn().Close();
                
                await App.Current.MainPage.DisplayAlert("Success", "Datos Guardados", "Ok");
                await App.Current.MainPage.Navigation.PushAsync(new home());
              

            }
            catch (SQLiteException)
            {
                await App.Current.MainPage.DisplayAlert("Warning", "Correo Ya existe", "Ok");
            }
        }
       
        public ICommand ClearCommand { private set; get; }
        public ICommand SendEmailCommand { private set; get; }

        public PersonsViewModel()
        {
            ClearCommand = new Command(() => Clear());
           
        }

        public ICommand GuardarCommand
        {
            get { return new Command(() => Guardar()); }
        }
        public ICommand DeleteCommand { get { return new Command(() => eliminar()); } }
        public ICommand UpdateCommand { get { return new Command(() => actualizar()); } }
        void Clear()
        {
           
            Name = string.Empty;
            Apellido = string.Empty;
            Correo = string.Empty;
            Direccion = string.Empty;
            Puesto = string.Empty;
          
        
        }
        async void  eliminar()
        {
            var persona = await crud.getPersonasId(Convert.ToInt32(Id));
            bool conf = await App.Current.MainPage.DisplayAlert("Delete", "Eliminar Persona", "Accept", "Cancel");
            if (conf)
            {
                if (persona != null)
                {
                    await crud.Delete(persona);
                    await App.Current.MainPage.DisplayAlert("Delete", "Datos Eliminados", "ok");
                    Clear();
                    await App.Current.MainPage.Navigation.PushAsync(new home());

                }
            }
           
        }
        async void actualizar()
        {
            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                Personas update = new Personas
                {
                    id = Convert.ToInt32(Id.ToString()),
                    name = Name,
                    apellido = Apellido,
                    edad = Convert.ToDouble(Edad),
                    direccion = Direccion,
                    correo = Correo,
                    puesto = Puesto
                };
                await crud.getPersonasUpdateId(update);
                await App.Current.MainPage.DisplayAlert("Update", "Datos Actualizados", "ok");
                await App.Current.MainPage.Navigation.PushAsync(new home());
               
            }
        }

    }
}
