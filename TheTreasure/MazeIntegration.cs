using System.Collections.Generic;
using System.Text;


namespace TheTreasure
{
    public class MazeIntegration : IMazeInitializer, IMazeIntegration
    {
        private IMazeInfrastructure MazeInfrastructure;

        public MazeIntegration()
        {
            MazeInfrastructure = new MazeInfrastructure();

            MazeInfrastructure.MovementLookup = new Dictionary<char, IMovement>

            {
                {'N', new NorthMovement() },
                {'S', new SouthMovement() },
                {'E', new EastMovement() },
                {'W', new WestMovement() }
            };

            MazeInfrastructure.mazeSize = 0;
        }

        public void BuildMaze(int size)
        {
            MazeInfrastructure.mazeSize = size;

            MazeInfrastructure.Maze = new Room[size, size];

            int roomIdCounter = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var room = new Room(roomIdCounter);

                    MazeInfrastructure.Maze[i, j] = room;

                    roomIdCounter++;
                }
            }

            //Definition of entrance
            DefineEntrance();

            //configuration value or random value
            PutTrap(1, 3);


            //Configuration value or random value
            PutTreasure(5);

        }

        public int GetEntranceRoom()
        {
            var entranceRoom = GetRoom(8);

            entranceRoom.visited = true;

            return 8;
        }

        public int? GetRoom(int roomId, char direction)
        {
            var movement = MazeInfrastructure.MovementLookup[direction];

            int? otherRoomId = movement.PopulateId(roomId, MazeInfrastructure.mazeSize);

            if (otherRoomId.HasValue == false)
                return null;

            var otherRoom = GetRoom(otherRoomId.Value);

            otherRoom.visited = true;

            return otherRoomId;
        }

        public string GetDescription(int roomId)
        {
            var room = GetRoom(roomId);

            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"current room is {roomId}.");

            foreach (var movement in MazeInfrastructure.MovementLookup)
            {
                var otherRoomId = movement.Value.PopulateId(roomId, MazeInfrastructure.mazeSize);
                if (otherRoomId.HasValue)
                {
                    var otherRoom = GetRoom(otherRoomId.Value);
                    descriptionBuilder.AppendLine(movement.Value.openMessage);
                    if (otherRoom.visited)
                    {
                        descriptionBuilder.AppendLine(movement.Value.alreadyVistedMessage);
                    }
                }
            }

            return descriptionBuilder.ToString();
        }

        public Room GetRoom(int roomId)
        {
            int rowLength = MazeInfrastructure.Maze.GetLength(0);

            int colLength = MazeInfrastructure.Maze.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (MazeInfrastructure.Maze[i, j].RoomId == roomId)
                    {
                        return MazeInfrastructure.Maze[i, j];
                    }
                }
            }
            return null;
        }

        public bool HasTreasure(int roomId)
        {
            return GetRoom(roomId).treasure;
        }

        public bool CausesInjury(int roomId)
        {
            return GetRoom(roomId).trap;
        }

        public void DefineEntrance()
        {
            var lastRoomCounterValue = (MazeInfrastructure.mazeSize * MazeInfrastructure.mazeSize) - 1;

            var room = GetRoom(lastRoomCounterValue);

            room.entrance = true;
        }

        public void PutTreasure(params int[] rooms)
        {
            foreach (var id in rooms)
            {
                var room = GetRoom(id);

                room.treasure = true;
            }
        }

        public void PutTrap(params int[] rooms)
        {
            foreach (var id in rooms)
            {
                var room = GetRoom(id);

                room.trap = true;
            }
        }

    }
}
