using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int CarImageId { get; set; }
        public int CarId { get; set; }
        public string CarImagePath { get; set; }
        public DateTime Date { get; set; }  
    }
}
