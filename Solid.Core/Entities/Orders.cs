namespace Solid.Core.Entities
{
    public class Orders
    {
        public int Id { get; set; }

        //public DateOnly Date { get; set; }

        //public TimeOnly Time { get; set; }

        public int NumOfPlaces { get; set; }

        public int TravelId { get; set; }

        public Travels Travel { get; set; }
    }
}
