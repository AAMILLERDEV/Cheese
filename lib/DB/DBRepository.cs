using System.Data;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace lib;

class DBRepository 
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

   
}