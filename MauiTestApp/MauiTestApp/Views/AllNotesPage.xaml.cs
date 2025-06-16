using Microsoft.Maui.Controls;

namespace MauiTestApp.Views;

public partial class AllNotesPage
{
    public AllNotesPage()
    {
        InitializeComponent();
    }
    
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        NotesCollection.SelectedItem = null;
    }
}