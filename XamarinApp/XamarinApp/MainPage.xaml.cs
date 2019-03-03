﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void NotesListPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NotesListPage());
        }

        private void ContactsListPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactsListPage());
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }
    }
}
