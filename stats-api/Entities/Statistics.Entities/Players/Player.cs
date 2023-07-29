namespace Statistics.Entities.Players;

public class Player
{
    public string? PlayerId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int EventsCompleted { get; set; }
    public int Wins { get; set; }
}