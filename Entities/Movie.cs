namespace Movies_API.Entities
{
    public class Movie
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearofRelease { get; set; }
        public string Genre { get; set; }
        public int userId { get; set; }
        public string  userName { get; set; }
        public int Review { get; set; }


    }
}

