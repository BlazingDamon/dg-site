namespace Statistics.Models.Players;

public class PlayerRequestBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int EventsCompleted { get; set; }
    public int Wins { get; set; }
}
