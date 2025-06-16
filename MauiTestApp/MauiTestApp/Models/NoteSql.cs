using SQLite;

namespace MauiTestApp.Models;

public class NoteSql
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }

    public bool Done { get; set; } = false;
    public string Text { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Now;

    private static NoteSqlDatabase GetClient()
    {
        var client = new NoteSqlDatabase();

        return client;
    }

    public async Task Save()
    {
        var client = GetClient();

        await client.SaveItemAsync(this).ConfigureAwait(false);
    }

    public async Task Delete()
    {
        var client = GetClient();

        await client.DeleteItemAsync(this).ConfigureAwait(false);
    }

    public static async Task<NoteSql> Load(int id)
    {
        var client = new NoteSqlDatabase();
        var note = await client.GetItemAsync(id).ConfigureAwait(false);

        if (note is null)
            throw new Exception($"Unable to find note in database with ID: {id}");

        return note;
    }

    public static async Task<IEnumerable<NoteSql>> LoadAll()
    {
        // Get the folder where the notes are stored.
        var client = new NoteSqlDatabase();

        // Use Linq extensions to load the *.notes.txt files.
        var notes = await client.GetItemsAsync().ConfigureAwait(false);

        return notes;
    }
}