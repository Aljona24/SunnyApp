using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyApp.Models;

namespace SunnyApp.Services.Abstractions
{
    public interface ILocationSearchService
    {
        Task<IList<Location>> GetLocationListByTextAsync(string searchText);
    }
}
