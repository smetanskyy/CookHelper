using CookerHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.DAL.Interfaces
{
    public interface IKindsOfDishes
    {
        IEnumerable<KindOfDish> KindsOfDishes { get; }
        KindOfDish GetKindOfDish(int kindOfDishId);
    }
}
