using MauiTestApp.Models;
using SQLite;

namespace MauiTestApp;

public class NoteSqlDatabase
{
    private SQLiteAsyncConnection? _database;

    private async Task Init()
    {
        if (_database is not null)
            return;

        _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await _database.CreateTableAsync<NoteSql>();
    }

    public async Task<List<NoteSql>> GetItemsAsync()
    {
        await Init();
        return await _database!.Table<NoteSql>().ToListAsync();
    }

    public async Task<List<NoteSql>> GetItemsNotDoneAsync()
    {
        await Init();
        return await _database!.Table<NoteSql>().Where(t => t.Done).ToListAsync();

        // SQL queries are also possible
        //return await Database.QueryAsync<NoteSql>("SELECT * FROM [NoteSql] WHERE [Done] = 0");
    }

    public async Task<NoteSql> GetItemAsync(int id)
    {
        await Init();
        return await _database!.Table<NoteSql>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public async Task SaveItemAsync(NoteSql item)
    {
        await Init();
        if (item.ID > 0)
        {
            await _database!.UpdateAsync(item);
            return;
        }

        await _database!.InsertAsync(item);
    }

    public async Task DeleteItemAsync(NoteSql item)
    {
        await Init();
        await _database!.DeleteAsync(item);
    }
}