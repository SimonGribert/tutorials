using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MauiTestApp.Models;
using Microsoft.Maui.Controls;

namespace MauiTestApp.ViewModels;

internal class NotesViewModel : IQueryAttributable
{
    public ObservableCollection<NoteViewModel> AllNotes { get; }
    public ICommand NewCommand { get; }
    public ICommand SelectNoteCommand { get; }

    public NotesViewModel()
    {
        AllNotes = new ObservableCollection<NoteViewModel>(Note.LoadAll()
            .Select(n => new NoteViewModel(n)));
        NewCommand = new AsyncRelayCommand(NewNoteAsync);
        SelectNoteCommand = new AsyncRelayCommand<NoteViewModel>(SelectNoteAsync);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("deleted", out var deleted))
        {
            var noteId = deleted.ToString();
            var matchedNote = AllNotes.FirstOrDefault(n => n.Identifier == noteId);

            // If note exists, delete it
            if (matchedNote != null)
                AllNotes.Remove(matchedNote);
        }
        else if (query.TryGetValue("saved", out var saved))
        {
            var noteId = saved.ToString();
            var matchedNote = AllNotes.FirstOrDefault(n => n.Identifier == noteId);

            // If the note is found, update it
            if (matchedNote != null)
            {
                matchedNote.Reload();
                AllNotes.Move(AllNotes.IndexOf(matchedNote), 0);
            }
            

            // If the note isn't found, it's new; add it.
            else if (noteId != null) AllNotes.Insert(0, new NoteViewModel(Note.Load(noteId)));
        }
    }

    private async Task NewNoteAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.NotePage));
    }

    private async Task SelectNoteAsync(NoteViewModel? note)
    {
        if (note != null)
            await Shell.Current.GoToAsync($"{nameof(Views.NotePage)}?load={note.Identifier}");
    }
}