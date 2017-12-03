using MaratonaXamarin.Models;

namespace MaratonaXamarin.ViewModels
{
    public class ContentWebViewModel : BaseViewModel
    {
        public Content Content { get; }

        public ContentWebViewModel(Content content)
        {
            Content = content;
        }
    }
}
