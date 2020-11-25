using System;
using System.Collections.Generic;
using System.Text;

namespace ADONETDemo01.Models
{
    class Fruit
    {
        public int ID { get; set; }
        public string FruitType { get; set; }
        public string FruitName { get; set; }

        public decimal? PricePerKg { get; set; }
        //public Nullable<decimal> PricePerKg { get; set; }

        public override string ToString()
        {
            return $"ID: {ID} Frukttyp: {FruitType} Fruktnamn: {FruitName} Pris: {PricePerKg} kr.";
        }
    }
}
