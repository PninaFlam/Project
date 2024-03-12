using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.DTOs
{
    public class OrdersDto
    {
        public int Id { get; set; }

        public int NumOfPlaces { get; set; }

        //public int TravelsId { get; set; }

        public TravelsDto Travel { get; set; }

        //public int CustomersId { get; set; }

        public CustomerDto Customer { get; set; }


    }
}
