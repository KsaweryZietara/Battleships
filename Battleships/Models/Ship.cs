using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Models {
    /// <summary>
    /// Represents a ship.
    /// </summary>
    public class Ship {
        /// <summary>
        /// Represents coordinates of the ship.
        /// </summary>
        public List<Coordinates> ShipCoordinates { get; set; } = new List<Coordinates>();
    }
}
