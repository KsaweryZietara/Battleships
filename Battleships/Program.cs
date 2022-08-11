using System;
using System.Threading;

namespace Battleships {
    public class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(string[] args) {
            Grid grid = new Grid();
            
            grid.SetShip(5);
            grid.SetShip(4);
            grid.SetShip(4);
            
            while (true) {
                Console.Clear();

                grid.DisplayGrid();

                Console.Write("\n\nEnter the coordinates: ");
                string coordinatesString = Console.ReadLine();

                if (!coordinatesString.ValidateInput()) {
                    continue;
                }

                Tuple<int, int> coordinates = coordinatesString.GetCoordinates();

                grid.CheckCoordinates(coordinates);
                
                if (grid.CheckShips()) {
                    break;
                }
            }

            Console.Clear();
            grid.DisplayGrid();
            Console.WriteLine();
            Console.Write("You won!!!");
        }
    }
}
