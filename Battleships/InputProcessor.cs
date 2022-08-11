using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships {
    /// <summary>
    /// Represents tools for managing user input.
    /// </summary>
    public static class InputProcessor {
        /// <summary>
        /// Validates whether input is correct. 
        /// </summary>
        /// <param name="input">Input from user.</param>
        /// <returns>Returns true if input is valid, or false otherwise.</returns>
        public static bool ValidateInput(this string input) {
            if (input.Length == 0) {
                return false;
            }

            if (Array.IndexOf(Settings.Letters, input[0]) == -1) {
                return false;
            }

            input = input.Substring(1);

            if (!int.TryParse(input, out int number)) {
                return false;
            }

            if (number < 1) {
                return false;
            }

            if (number > Settings.GridWidth) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Generates tuple with coordinates from user input.
        /// </summary>
        /// <param name="input">Input from user.</param>
        /// <returns>Returns tuple with coordinates.</returns>
        public static Tuple<int, int> GetCoordinates(this string input) {
            int width = Array.IndexOf(Settings.Letters, input[0]);

            int.TryParse(input.Substring(1), out int height);

            return Tuple.Create(height - 1, width);
        }
    }
}
