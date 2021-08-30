namespace TheTreasure
{
    // movement contract
    public interface IMovement
    {
        int? PopulateId(int Id, int mazeSize);

        string openMessage { get; }

        string alreadyVistedMessage { get; }
    }
}
