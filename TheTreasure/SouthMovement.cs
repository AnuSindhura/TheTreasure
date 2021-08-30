namespace TheTreasure
{
    //South movement specification by contract
    class SouthMovement : IMovement
    {
        public string openMessage => "South is open";

        public string alreadyVistedMessage => "South is already visited";

        public int? PopulateId(int Id, int mazeSize)
        {
            int otherRoomId = Id + mazeSize;

            if (otherRoomId >= mazeSize * mazeSize)
            {
                return null;
            }

            return otherRoomId;
        }
    }
}
