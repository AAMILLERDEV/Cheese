﻿using System.Threading.Channels;

namespace lib;

public interface ICheddarRepository
{
    public Task<IEnumerable<Cheddar>> GetCheddar();

    public Task<int> CalcLowest();
}
