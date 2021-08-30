namespace TheTreasure
{
    //East movement specification by contract
    class EastMovement : IMovement
    {
        public string openMessage => "East is open";

        public string alreadyVistedMessage => "East is already visited";

        public int? PopulateId(int Id, int mazeSize)
        {
            var otherRoomId = (Id + 1);

            if (otherRoomId % mazeSize == 0)
            {
                return null;
            }

            return otherRoomId;
        }

    }
}
