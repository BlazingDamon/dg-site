namespace Statistics.Domain.Results;

public class UpdateResult<T>
{
    public long MatchedCount { get; init; }
    public long ModifiedCount { get; init; }
    public T? Result { get; init; }
}
