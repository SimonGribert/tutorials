using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MauiTestApp.Models;
using MauiTestApp.Views;

namespace MauiTestApp.ViewModels;

internal class NoteSqlsViewModel : IQueryAttributable
{
    public ObservableCollection<NoteSqlViewModel> AllNotes { get; }
    public ICommand NewCommand { get; }
    public ICommand SelectNoteCommand { get; }

    public NoteSqlsViewModel()
    {
        AllNotes = [];
        NewCommand = new AsyncRelayCommand(NewNoteAsync);
        SelectNoteCommand = new AsyncRelayCommand<NoteSqlViewModel>(SelectNoteAsync);

        var load = new AsyncRelayCommand(ReloadAsync);

        load.Execute(this);
    }

    private async Task ReloadAsync()
    {
        AllNotes.Clear();
        var notes = await NoteSql.LoadAll();
        foreach (var note in notes)
        {
            AllNotes.Add(new NoteSqlViewModel(note));
        }
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        try
        {
            if (query.TryGetValue("deleted", out var deleted))
            {
                var noteId = int.Parse(deleted.ToString()!);
                var matchedNote = AllNotes.FirstOrDefault(n => n.Identifier == noteId);

                // If note exists, delete it
                if (matchedNote != null)
                    AllNotes.Remove(matchedNote);
            }
            else if (query.TryGetValue("saved", out var saved))
            {
                var noteId = int.Parse(saved.ToString()!);
                var matchedNote = AllNotes.FirstOrDefault(n => n.Identifier == noteId);

                // If the note is found, update it
                if (matchedNote != null)
                {
                    await matchedNote.Reload();
                    AllNotes.Move(AllNotes.IndexOf(matchedNote), 0);
                }

                // If the note isn't found, it's new; add it.
                else if (noteId > 0) AllNotes.Insert(0, new NoteSqlViewModel(await NoteSql.Load(noteId)));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error applying query attributes: {e.Message}");
        }
    }

    private async Task NewNoteAsync()
    {
        await Shell.Current.GoToAsync(nameof(NoteSqlPage));
    }

    private async Task SelectNoteAsync(NoteSqlViewModel? note)
    {
        if (note != null)
            await Shell.Current.GoToAsync($"{nameof(NoteSqlPage)}?load={note.Identifier}");
    }
}