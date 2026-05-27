namespace VolleyPool.Core.Models
{
    public class MatchDay(int id, DateTime date, TimeOnly time, string homeTeam)
    {
        public int Id { get; set; } = id;
        public DateTime Date { get; set; } = date;
        public TimeOnly Time { get; set; } = time; // start time, end time? Duration?

        public string HomeTeam { get; set; } = homeTeam;

        public int[] TransportIds { get; set; } = [];

        public int[] CancellationIds { get; set; } = [];

        public override string ToString()
        {
            return $"Volgende matchdag voor {HomeTeam}: {Date} {Time}, Vervoer: {TransportIds}, Afmeldingen: {CancellationIds}";
        }
    }
}
