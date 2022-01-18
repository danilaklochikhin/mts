using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mts.Domain.Entities;
using mts.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace mts.Domain.Repositories.EntityFramework
{
    public class EFCitysBaseRepository: ICitysBaseRepository
    {
        private readonly DBContext context;
        public EFCitysBaseRepository(DBContext context)
        {
            this.context = context;
        }

        public IQueryable<CitysBase> GetCitys() 
        {
            return context.citys;
        }
        public CitysBase GetCityByGuid(Guid Id)
        {
            return context.citys.FirstOrDefault(x => x.Id == Id);
        }
        public CitysBase GetCityById(string Id)
        {
            return context.citys.FirstOrDefault(x => x.ID_city == Id);
        }
        public CitysBase GetCityByName(string Name)
        {
            return context.citys.FirstOrDefault(x => x.Title == Name);
        }

        public void SaveCitys(CitysBase citysBase)
        {
            if (citysBase.Id == default)
                context.Entry(citysBase).State = EntityState.Added;
            else
                context.Entry(citysBase).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteCity(Guid Id) 
        {
            context.citys.Remove(new CitysBase() { Id = Id });
            context.SaveChanges();
        }
    }
}
