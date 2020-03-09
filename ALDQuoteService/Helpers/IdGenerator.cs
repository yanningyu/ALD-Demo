using System;

namespace ALDQuoteService.Services
{
    /// <summary>
    /// Utility class for generating unique identifiers
    /// </summary>
    public class IdGenerator
    {
        /// <summary>
        /// Generates a new unique identifier string
        /// </summary>
        /// <returns></returns>
        public static string NewId()
        {
            return new Random().Next(100000, 999999).ToString();
        }
    }
}