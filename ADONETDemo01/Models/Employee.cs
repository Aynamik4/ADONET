using System;
using System.Collections.Generic;
using System.Text;

namespace ADONETDemo01.Models
{
    class Employee
    {
        public string Namn { get; set; }
        public decimal Lön { get; set; }
        public string Titel { get; set; }

        public override string ToString()
        {
            return $"Namn: {Namn} Lön: {Lön} Titel {Titel}";
        }
    }
}
