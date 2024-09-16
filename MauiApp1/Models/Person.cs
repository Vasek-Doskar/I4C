using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // ? určuje že property je tzv "nullable", tedy může nabývat i hodnoty NULL
        public virtual ICollection<Car>? Cars { get; set; }

        public override string ToString() => Name;
      
    }
}
