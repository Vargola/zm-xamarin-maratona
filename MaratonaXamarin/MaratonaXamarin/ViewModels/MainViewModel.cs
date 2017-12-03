using MaratonaXamarin.Models;
using MaratonaXamarin.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaratonaXamarin.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IVargolaService _monkeyHubApiService;

        public ObservableCollection<Tag> Tags { get; }

        public Command<Tag> ShowCategoriaCommand { get; }

        public MainViewModel(IVargolaService monkeyHubApiService)
        {
            _monkeyHubApiService = monkeyHubApiService;
            Tags = new ObservableCollection<Tag>();
            ShowCategoriaCommand = new Command<Tag>(ExecuteShowCategoriaCommand);
        }

        private async void ExecuteShowCategoriaCommand(Tag tag)
        {
            await PushAsync<FavoritosViewModel>(_monkeyHubApiService, tag);
        }

        public async Task LoadAsync()
        {
            var tags = await _monkeyHubApiService.GetTagsAsync();
            Tags.Clear();
            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    Tags.Add(tag);
                }
            }
        }
    }
}
