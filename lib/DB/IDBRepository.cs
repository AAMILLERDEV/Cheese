using System.Data;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace lib;

interface IDBRepository 
{
    public Task<IEnumerable<Cheddar>> GetCheddars();
    public Task<int?> UpsertCheddar(Cheddar ins);
}