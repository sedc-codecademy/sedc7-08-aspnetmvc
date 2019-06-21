namespace EFDemo.Models
{
    public class MovieHall
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
