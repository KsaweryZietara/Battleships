using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships {
    /// <summary>
    /// Represents settings of the game.
    /// </summary>
    public static class Settings {
        /// <summary>
        /// Represents width of the grid.
        /// </summary>
        public static int GridWidth = 10;

        /// <summary>
        /// Represents height of the grid.
        /// </summary>
        public static int GridHeight = 10;

        /// <summary>
        /// Represents letters from top side of the grid.
        /// </summary>
        public static char[] Letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
    }
}

