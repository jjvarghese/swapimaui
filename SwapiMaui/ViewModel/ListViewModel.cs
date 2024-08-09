using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using SwapiMaui.Service;
using SwapiMaui.ViewModel;

public partial class ListViewModel : BaseViewModel
{
    private readonly SwapiService swapiService;

    public ObservableCollection<Person> People { get; } = new();

    public ListViewModel(SwapiService swapiService)
    {
        Title = "Swapi Maui";

        this.swapiService = swapiService;
    }

    [RelayCommand]
    private async Task GetPeopleAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;

            var people = await swapiService.GetPeople();
            
            if (People.Count != 0) People.Clear();

            foreach (var person in people)
            {
                People.Add(person);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);

            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}