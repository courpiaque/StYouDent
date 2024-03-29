﻿using StYouDent.Models;
using StYouDent.ViewModels;
using StYouDent.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StYouDent
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        MainPageViewModel _viewModel
        {
            get { return BindingContext as MainPageViewModel; }
            set { _viewModel = value; }
        }

        protected override void OnAppearing()
        {
            _viewModel.LoadList();

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            _viewModel.Disappear();
            base.OnDisappearing();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushModalAsync(new DetailPage((Item)e.SelectedItem));
        }
    }
}
