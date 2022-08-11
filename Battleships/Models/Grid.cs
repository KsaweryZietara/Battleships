using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Battleships.Models {
    /// <summary>
    /// Represents board for the game.
    /// </summary>
    class Grid {
        /// <summary>
        /// Represents fields on the board.
        /// </summary>
        public FieldTypes[,] Fields { get; set; } = new FieldTypes[Settings.GridHeight, Settings.GridWidth];

        /// <summary>
        /// Represents ships on the board.
        /// </summary>
        public List<Ship> Ships { get; set; } = new List<Ship>();

        /// <summary>
        /// Initializes a new instance of the Grid class.
        /// </summary>
        public Grid() {
            for (int i = 0; i < Settings.GridHeight; i++) {
                for (int j = 0; j < Settings.GridWidth; j++) {
                    Fields[i, j] = FieldTypes.ocean;
                }
            }
        }

        /// <summary>
        /// Places ship on the board.
        /// </summary>
        /// <param name="size">Size of the ship.</param>
        public void SetShip(int size) {
            Random rnd = new Random();

            while (true) {
                
                bool check = true;
                int number = rnd.Next(2);

                if (number == 0) {
                    
                    int height = rnd.Next(Settings.GridHeight - (size - 1));
                    int width = rnd.Next(10);

                    for (int i = 0; i < size; i++) {
                        if(Fields[height + i, width] == FieldTypes.ship) {
                            check = false;
                        }
                    }

                    if (check) {
                        Ship ship = new Ship();

                        for (int i = 0; i < size; i++) {
                            Fields[height + i, width] = FieldTypes.ship;
                            Coordinates coordinates = new Coordinates(height + i, width);
                            ship.ShipCoordinates.Add(coordinates);
                        }

                        Ships.Add(ship);

                        break;
                    }
                    
                }

                if (number == 1) {
                    
                    int height = rnd.Next(10);
                    int width = rnd.Next(Settings.GridWidth - (size - 1));

                    for (int i = 0; i < size; i++) {
                        if (Fields[height, width + i] == FieldTypes.ship) {
                            check = false;
                        }
                    }

                    if (check) {
                        Ship ship = new Ship();

                        for (int i = 0; i < size; i++) {
                            Fields[height, width + i] = FieldTypes.ship;
                            Coordinates coordinates = new Coordinates(height, width + i);
                            ship.ShipCoordinates.Add(coordinates);
                        }

                        Ships.Add(ship);

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Displays grid in console.
        /// </summary>
        public void DisplayGrid() {

            Console.Write("   ");

            for(int i = 0; i < Settings.GridWidth; i++) {
                Console.Write($"{Settings.Letters[i]} ");
            }
            
            Console.WriteLine();

            for(int i = 0; i < Settings.GridHeight; i++) {

                if (i < 9) {
                    Console.Write($" {i + 1} ");
                }
                else {
                    Console.Write($"{i + 1} ");
                }

                for(int j = 0; j < Settings.GridWidth; j++) {
                    
                    if (Fields[i, j] == FieldTypes.ocean ||
                        Fields[i, j] == FieldTypes.ship) {
                        Console.Write("O ");
                    }

                    else if (Fields[i, j] == FieldTypes.miss) {
                        Console.Write("M ");
                    }

                    else if (Fields[i, j] == FieldTypes.sunkenShip) {
                        Console.Write("X ");
                    }

                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Checks if the user hit the ship.
        /// </summary>
        /// <param name="coordinates">Coordinates from user.</param>
        public void CheckCoordinates(Coordinates coordinates) {

            if (Fields[coordinates.Height, coordinates.Width] == FieldTypes.ocean) {
                Console.WriteLine("Miss!");
                Fields[coordinates.Height, coordinates.Width] = FieldTypes.miss;
            }

            else if (Fields[coordinates.Height, coordinates.Width] == FieldTypes.ship) {
                Fields[coordinates.Height, coordinates.Width] = FieldTypes.sunkenShip;

                if (CheckIfSunk()) {
                    Console.WriteLine("Sunk!");
                }
                else {
                    Console.WriteLine("Hit!");
                } 
            }

            else if (Fields[coordinates.Height, coordinates.Width] == FieldTypes.miss ||
                     Fields[coordinates.Height, coordinates.Width] == FieldTypes.sunkenShip) {
                Console.WriteLine("You've already hit this field.");
            }

            Thread.Sleep(800);
        }

        /// <summary>
        /// Checks whether they are any ships left on the board.
        /// </summary>
        /// <returns>Returns true if there are no ships, false otherwise.</returns>
        public bool CheckShips() {
            int counter = 0;

            for (int i = 0; i < Settings.GridHeight; i++) {
                for (int j = 0; j < Settings.GridWidth; j++) {
                    if (Fields[i, j] == FieldTypes.ship) {
                        counter++;
                    }
                }
            }

            if (counter == 0) {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if user sunk the ship.
        /// </summary>
        /// <returns>Returns true if user sunk a ship, false otherwise.</returns>
        public bool CheckIfSunk() {
            foreach (var ship in Ships) {
                bool result = true;
                
                foreach(var c in ship.ShipCoordinates) {
                    if(Fields[c.Height, c.Width] == FieldTypes.ship) {
                        result = false;
                    }
                }

                if (result) {
                    Ships.Remove(ship);
                    return true;
                }
            }

            return false;
        }
    }
}
