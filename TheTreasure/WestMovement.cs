namespace TheTreasure
{
    //West movement specification by contract
    class WestMovement : IMovement
    {
        public string openMessage => "West is open";

        public string alreadyVistedMessage => "West is already visited";

        public int? PopulateId(int Id, int mazeSize)
        {
            var otherRoomId = Id - 1;

            if (otherRoomId % mazeSize == mazeSize - 1 || otherRoomId < 0)
            {
                return null;
            }

            return otherRoomId;
        }
    }
}
