using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var maxSize = Console.ReadLine()?.Trim()?.Split(' ')?.Select(int.Parse)?.ToList();
            var startPositions = Console.ReadLine()?.Trim()?.Split(' ');
            Position position = new Position();

            if (startPositions.Count() == 3)
            {
                int.TryParse(startPositions[0], out int xCoordinate);
                int.TryParse(startPositions[1], out int yCoordinate);
                position.X = xCoordinate;
                position.Y = yCoordinate;
                position.Direction = (Directions)Enum.Parse(typeof(Directions), startPositions[2]);
            }

            var directions = Console.ReadLine()?.ToUpper();

            try
            {
                position.Start(maxSize, directions);
                Console.WriteLine($"{position.X} {position.Y} {position.Direction.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
