using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        // Navigation properties => for relationships
        // UserId => Foreign Key
        public int UserId { get; set; }
        public Person User { get; set; }

        public override string? ToString()=> $"{Brand} {Model}";
    }
}
