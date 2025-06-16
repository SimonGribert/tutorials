using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiTestApp.Models;

namespace MauiTestApp.ViewModels;

internal class NoteSqlViewModel : ObservableObject, IQueryAttributable
{
    private NoteSql _note;

    public string Text
    {
        get => _note.Text;
        set
        {
            if (_note.Text == value) return;
            
            _note.Text = value;
            OnPropertyChanged();
        }
    }

    public DateTime Date => _note.Date;
    public int Identifier => _note.ID;
    public ICommand SaveCommand { get; private set; }
    public ICommand DeleteCommand { get; private set; }

    public NoteSqlViewModel()
    {
        _note = new NoteSql();
        SaveCommand = new AsyncRelayCommand(Save);
        DeleteCommand = new AsyncRelayCommand(Delete);
    }

    public NoteSqlViewModel(NoteSql note)
    {
        Console.WriteLine($"2 - Note ID: {note.ID}, Text: {note.Text}, Date: {note.Date}");
        _note = note;
        SaveCommand = new AsyncRelayCommand(Save);
        DeleteCommand = new AsyncRelayCommand(Delete);
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        try
        {
            if (!query.TryGetValue("load", out var load)) return;
            var noteId = int.Parse(load.ToString()!);
            _note = await NoteSql.Load(noteId);

            RefreshProperties();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading note: {e.Message}");
        }
    }

    public async Task Reload()
    {
        Console.WriteLine($"Reloading Note ID: {_note.ID}, Text: {_note.Text}, Date: {_note.Date}");
        _note = await NoteSql.Load(_note.ID);
        
        Console.WriteLine($"Reloading Note ID: {_note.ID}, Text: {_note.Text}, Date: {_note.Date}");
        RefreshProperties();
    }

    private async Task Save()
    {
        _note.Date = DateTime.Now;
        
        Console.WriteLine($"Testing Save: {_note.ID}, Text: {_note.Text}, Date: {_note.Date}");
        
        await _note.Save();
        
        Console.WriteLine($"Testing Save: {_note.ID}, Text: {_note.Text}, Date: {_note.Date}");
        await Shell.Current.GoToAsync($"..?saved={_note.ID}");
    }

    private async Task Delete()
    {
        await _note.Delete();
        await Shell.Current.GoToAsync($"..?deleted={_note.ID}");
    }

    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(Text));
        OnPropertyChanged(nameof(Date));
    }
}