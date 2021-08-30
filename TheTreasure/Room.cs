namespace TheTreasure
{
    //Maze room definition
    public class Room
    {
        public int RoomId { get; set; }

        public bool treasure { get; set; }

        public bool trap { get; set; }

        public bool visited { get; set; }

        public bool entrance { get; set; }

        public Room(int roomId)
        {
            RoomId = roomId;
        }

        // can see the room content

        public override string ToString()
        {
            return entrance ? "->" : treasure ? "*" : trap ? "#" : RoomId.ToString();
        }
    }
}
