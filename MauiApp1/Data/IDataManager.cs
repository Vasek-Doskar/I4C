using MauiApp1.Models;

namespace MauiApp1.Data
{
    public interface IDataManager
    {
        void Add(Person p);
        void Delete(Person p);
        Person GetById(int? id);
        IList<Person> GetAll();

        bool Exists(Person p);
    }
}
