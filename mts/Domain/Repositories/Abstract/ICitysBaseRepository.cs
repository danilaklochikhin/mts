using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mts.Domain.Entities;

namespace mts.Domain.Repositories.Abstract
{
    public interface ICitysBaseRepository
    {
        IQueryable<CitysBase> GetCitys();
        CitysBase GetCityByGuid(Guid Id);
        CitysBase GetCityById(string Id);
        CitysBase GetCityByName(string Name);
        void SaveCitys(CitysBase citysBase);
        void DeleteCity(Guid Id);
    }
}
