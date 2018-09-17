using System;
using System.Collections.Generic;
using RealmSample.ViewModels;
using Xamarin.Forms;

namespace RealmSample.Views
{
    public partial class TodoPage : ContentPage
    {
        public TodoPage()
        {
            InitializeComponent();
            this.BindingContext = new TodoPageViewModel();
        }
    }
}
