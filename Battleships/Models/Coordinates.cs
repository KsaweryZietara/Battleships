using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Models {
    /// <summary>
    /// Represents coordinates.
    /// </summary>
    public class Coordinates {
        /// <summary>
        /// Represents height coordinate.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Represents width coordinate.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Initializes a new instance of the Coordinates class.
        /// </summary>
        /// <param name="height">Represents height coordinate.</param>
        /// <param name="width">Represents width coordinate.</param>
        public Coordinates(int height, int width) {
            Height = height;
            Width = width;
        }
    }
}
