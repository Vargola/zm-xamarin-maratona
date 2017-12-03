using MaratonaXamarin.Services;
using MaratonaXamarin.ViewModels;
using Xamarin.Forms;

namespace MaratonaXamarin.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(new VargolaService());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(ViewModel != null)
            {
                await ViewModel.LoadAsync();
            }
        }
    }
}
