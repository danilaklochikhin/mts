using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mts.Domain.Entities;
using mts.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace mts.Domain.Repositories.EntityFramework
{
    public class EFTarifsBaseRepository: ITarifsBaseRepository
    {
        private readonly DBContext context;
        public EFTarifsBaseRepository(DBContext context)
        {
            this.context = context;
        }

        public IQueryable<TarifsBase> GetTarifs()
        {
            return context.tarifs;
        }
        public TarifsBase GetTarifByGuid(Guid Id)
        {
            return context.tarifs.FirstOrDefault(x => x.Id == Id);
        }
        public TarifsBase GetTarifByName(string Name)
        {
            return context.tarifs.FirstOrDefault(x => x.Title == Name);
        }

        public void SaveTarifs(TarifsBase tarifsBase)
        {
            if (tarifsBase.Id == default)
                context.Entry(tarifsBase).State = EntityState.Added;
            else
                context.Entry(tarifsBase).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteTarif(Guid Id)
        {
            context.tarifs.Remove(new TarifsBase() { Id = Id });
            context.SaveChanges();
        }
    }
}
