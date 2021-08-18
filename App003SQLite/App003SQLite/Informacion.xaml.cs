using App003SQLite.ModelView;
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
    public partial class Informacion : ContentPage
    {
        public Informacion()
        {
            InitializeComponent();
            BindingContext = new PersonsViewModel();
        }
    }
}