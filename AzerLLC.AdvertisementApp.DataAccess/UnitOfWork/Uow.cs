using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azer_LLC.AdvertisementApp.DataAccess.Contexts;
using Azer_LLC.AdvertisementApp.DataAccess.Interfaces;
using Azer_LLC.AdvertisementApp.DataAccess.Repositories;
using Azer_LLC.AdvertisementApp.Entities;

namespace Azer_LLC.AdvertisementApp.DataAccess.UnitOfWork
{
    public class Uow:IUow
    {
        private readonly AdvertisementContext _context;

        public Uow(AdvertisementContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
