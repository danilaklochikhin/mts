using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mts.Domain.Entities;

namespace mts.Domain.Repositories.Abstract
{
    public interface ITarifsBaseRepository
    {
        IQueryable<TarifsBase> GetTarifs();
        TarifsBase GetTarifByGuid(Guid Id);
        TarifsBase GetTarifByName(string Name);
        void SaveTarifs(TarifsBase tarifsBase);
        void DeleteTarif(Guid Id);
    }
}
