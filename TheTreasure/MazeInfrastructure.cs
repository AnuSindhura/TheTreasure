using System.Collections.Generic;


namespace TheTreasure
{
    /// <summary>
    /// Maze infrastructure
    /// </summary>
    public class MazeInfrastructure : IMazeInfrastructure
    {
        public Dictionary<char, IMovement> MovementLookup { get; set; }
        public Room[,] Maze { get; set; }
        public int mazeSize { get; set; }
    }
}
