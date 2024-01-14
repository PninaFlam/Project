namespace Solid.Core.Entities
{
    public class Travels
    {
        public int Id { get; set; }

        public string Destination { get; set; }

        public DateTime Date { get; set; }

        public List<Orders> Orders { get; set; }

    }
}
