using CommunityToolkit.Mvvm.Input;
using SongManager.Desktop.Models;

namespace SongManager.Desktop.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}