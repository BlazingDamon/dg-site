namespace Statistics.Domain.Players;

public class PlayerDTO
{
    public string? PlayerId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int EventsCompleted { get; set; }
    public int Wins { get; set; }
    public float WinPercentage { get => CalculateWinPercentage(); }

    private float CalculateWinPercentage()
    {
        if (Wins < 1 || EventsCompleted < 1) return 0;

        return (float)Math.Round(100f * ((float)Wins / EventsCompleted), 2);
    }
}