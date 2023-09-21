using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace lib;

public class DBRepository : IDBRepository
{
    private string connectionString { get; }

    public DBRepository(string connString)
    {
        connectionString = connString;
    }

    public async Task<IEnumerable<Cheddar>> GetCheddars()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Cheddar>("hist.cheeses_Get", commandType: CommandType.StoredProcedure);

        } catch (Exception ex) {
            return default;
        }
    }

    public async Task<Cheddar> GetCheddars(int id)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Cheddar>("hist.cheeses_Get", commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            return default;
        }
    }

    public async Task<int?> UpsertCheddar(Cheddar ins)
    {
        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@name", ins.Name },
            { "@holes", ins.Holes },
            { "@density", ins.Density },
            { "@description", ins.Description },
        });

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.ExecuteAsync("hist.cheeses_Get", parameters, commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            return default;
        }
    }
}