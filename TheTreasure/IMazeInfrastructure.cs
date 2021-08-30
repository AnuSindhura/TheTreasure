using System.Collections.Generic;


namespace TheTreasure
{
    /// <summary>
    /// Maze base infrastructure contract
    /// </summary>
    public interface IMazeInfrastructure
    {
        Dictionary<char, IMovement> MovementLookup { get; set; }
        Room[,] Maze { get; set; }
        int mazeSize { get; set; }
    }
}
