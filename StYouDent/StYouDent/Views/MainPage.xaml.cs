using StYouDent.ViewModels;
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

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
