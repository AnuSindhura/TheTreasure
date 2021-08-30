namespace TheTreasure
{
    //North movement specification by contract
    class NorthMovement : IMovement
    {
        public string openMessage => "North is open";

        public string alreadyVistedMessage => "North is already visited";

        public int? PopulateId(int Id, int mazeSize)
        {
            int otherRoomId = Id - mazeSize;

            if (otherRoomId < 0)
            {
                return null;
            }

            return otherRoomId;
        }
    }
}
