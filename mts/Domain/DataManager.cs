using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mts.Domain.Repositories.Abstract;

namespace mts.Domain
{
    public class DataManager
    {
        ICitysBaseRepository CitysBase { get; set; }
        ITarifsBaseRepository tarifsBase { get; set; }

        public DataManager(ICitysBaseRepository citysBaseRepository, ITarifsBaseRepository tarifsBaseRepository)
        {
            CitysBase = citysBaseRepository;
            tarifsBase = tarifsBaseRepository;
        }
    }
}
