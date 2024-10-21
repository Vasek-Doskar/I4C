using MauiApp1.Models;

namespace MauiApp1.Data
{
    public interface ICarManager
    {
        Car GetById(int? id);
        IList<Car> GetAll();
        void Delete(Car car);
        void Add(Car car);
    }
}
