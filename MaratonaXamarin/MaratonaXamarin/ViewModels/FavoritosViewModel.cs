using MaratonaXamarin.Models;
using MaratonaXamarin.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaratonaXamarin.ViewModels
{
    public class FavoritosViewModel : BaseViewModel
    {
        private readonly IVargolaService _monkeyHubApiService;
        private readonly Tag _tag;

        public string Title { get; }

        public ObservableCollection<Content> Contents { get; }

        public Command<Content> ShowContentCommand { get; }

        public FavoritosViewModel(IVargolaService monkeyApiHubService, Tag tag)
        {
            _monkeyHubApiService = monkeyApiHubService;
            _tag = tag;
            Title = _tag.Name;
            Contents = new ObservableCollection<Content>();
            ShowContentCommand = new Command<Content>(ExecuteShowContentCommand);
        }

        async void ExecuteShowContentCommand(Content content)
        {
            await PushAsync<ContentWebViewModel>(content);
        }

        public async Task LoadAsync()
        {
            var contents = await _monkeyHubApiService.GetContentsByTagIdAsync(_tag.Id);
            Contents.Clear();
            foreach (var content in contents)
            {
                Contents.Add(content);
            }
        }
    }
}
