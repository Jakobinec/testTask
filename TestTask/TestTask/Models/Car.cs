using System;

namespace TestTask.Models
{
    /// <summary>
    /// Car model class
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Car id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Car owner Id
        /// </summary>
        public int DriverId { get; set; }

        /// <summary>
        /// Car description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Year of created car
        /// </summary>
        public int YearOfCreated { get; set; }
    }
}