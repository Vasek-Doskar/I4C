using MauiApp1.Models;

namespace MauiApp1.Data
{
    public class CarManager : ICarManager
    {
        private readonly Context _context;

        public CarManager(Context context)
        {
            _context = context;
        }
        public void Add(Car car)
        {
            if (car is not null)
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
            }
        }
        public void Delete(Car car)
        {
            if (car is not null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }
        public IList<Car> GetAll() => _context.Cars.ToList();

        public Car GetById(int? id) => _context.Cars.Find(id);
    }
}
