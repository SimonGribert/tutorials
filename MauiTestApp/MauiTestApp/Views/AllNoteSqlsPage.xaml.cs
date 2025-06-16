namespace MauiTestApp.Views;

public partial class AllNoteSqlsPage
{
    public AllNoteSqlsPage()
    {
        InitializeComponent();
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        NotesCollection.SelectedItem = null;
    }
}