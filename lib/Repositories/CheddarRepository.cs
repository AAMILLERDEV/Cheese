using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace lib;

public class CheddarRepository : ICheddarRepository
{
    private readonly DBRepository db;

    public CheddarRepository(IOptionsMonitor<AppSettings> options)
    {
        db = new DBRepository(options.CurrentValue.DbConn);
    }

    public async Task<IEnumerable<Cheddar>> GetCheddar() 
    {
        return await db.GetCheddars();
    }

    public async Task<int> CalcLowest(){
        return 2;     
    }

    public Task<int?> UpsertCheddar(Cheddar ins) => db.UpsertCheddar(ins);
}
