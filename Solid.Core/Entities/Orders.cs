namespace Solid.Core.Entities
{
    public class Orders
    {
        public int Id { get; set; }

        public int NumOfPlaces { get; set; }

        public int TravelsId { get; set; }

        public Travels Travels { get; set; }

        public int CustomersId { get; set; }

        public Customers Customer { get; set; }

    }
}
