using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);

        ICollection<T> GetEntities(int page = 1, int size = int.MaxValue);
    }
}
