using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships {
    /// <summary>
    /// Represents types of fields on the board. 
    /// </summary>
    public enum FieldTypes {
        /// <summary>
        /// Represents field with the ship.
        /// </summary>
        ship,
        /// <summary>
        /// Represents field with the sunken ship.
        /// </summary>
        sunkenShip,
        /// <summary>
        /// Represents field with the ocean.
        /// </summary>
        ocean,
        /// <summary>
        /// Represents field with the ocean, which was hit by the user.
        /// </summary>
        miss
    }
}
