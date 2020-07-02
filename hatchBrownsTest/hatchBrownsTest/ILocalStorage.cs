using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hatchBrownsTest
{
    public interface ILocalStorage
    {
        Task Store(string filename);
        Task<List<string>> Get();
    }
}
