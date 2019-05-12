using StYouDent.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StYouDent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RightCategoryPage : ContentPage
    {
        public RightCategoryPage(RightHandPageViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        RightHandPageViewModel _viewModel
        {
            get { return BindingContext as RightHandPageViewModel; }
            set { _viewModel = value; }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            _viewModel.ChangeCategory(button.Text);
            Navigation.PopModalAsync();
        }
    }
}