using CookerHelper.DAL.EFContext;
using CookerHelper.DAL.Interfaces;
using CookerHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.DAL.Repositories
{
    public class KindsOfDishesRepository : IKindsOfDishes
    {
        private readonly EFDbContext _context;

        public KindsOfDishesRepository(EFDbContext context)
        {
            _context = context;
        }

        public IEnumerable<KindOfDish> KindsOfDishes => _context.KindsOfDishes.AsEnumerable();

        public KindOfDish GetKindOfDish(int kindOfDishId) => 
            _context.KindsOfDishes.FirstOrDefault(k => k.KindOfDishId == kindOfDishId);
    }
}
