using MaratonaXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaratonaXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritosPage : ContentPage
    {
        private FavoritosViewModel ViewModel => BindingContext as FavoritosViewModel;

        public FavoritosPage()
        {
            InitializeComponent();
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
