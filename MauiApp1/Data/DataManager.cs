using MauiApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.Data
{

   
    public class DataManager : IDataManager
    {
        private readonly Context _context;

        public DataManager(Context context)
        {
            _context = context;
        }

        public void Add(Person p)
        {
            if(p is not null)
            {
                _context.Add(p);
            }
        }

        public void Delete(Person p)
        {
            if(Exists(p)) 
            {
                _context.Remove(p);
                _context.SaveChanges();
            }
        }

        public IList<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public Person GetById(int? id)
        {
            if (id is not null)
                return _context.Persons.Include(x => x.Cars).FirstOrDefault(x => x.Id == id);
            return null;
        }

        public bool Exists(Person p)
        {
            return _context.Persons.Any(x => x.Name == p.Name && x.Id == p.Id);
        }
    }
}
