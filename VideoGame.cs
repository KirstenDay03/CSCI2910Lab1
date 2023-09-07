using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI2910Lab1
{
    internal class VideoGame : IComparable<VideoGame>
    {
        //Fields
        private string name;
        private string platform;
        private int year;
        private string genre;
        private string publisher;
        private double na_sales;
        private double eu_sales;
        private double jp_sales;
        private double other_sales;
        private double global_sales;

        //Constructors
        /// <summary>
        /// Base Constructor, sets all fields to default values
        /// </summary>
        public VideoGame()
        {
            name = "";
            platform = "";
            year= 0;
            genre = "";
            publisher = "";
            na_sales= 0.0;
            eu_sales= 0.0;
            jp_sales= 0.0;
            other_sales= 0.0;
            global_sales= 0.0;
        }

        /// <summary>
        /// Parameterized Constructor, sets fields to the passed values
        /// </summary>
        /// <param name="name"></param>
        /// <param name="platform"></param>
        /// <param name="year"></param>
        /// <param name="genre"></param>
        /// <param name="publisher"></param>
        /// <param name="na_sales"></param>
        /// <param name="eu_sales"></param>
        /// <param name="jp_sales"></param>
        /// <param name="other_sales"></param>
        /// <param name="global_sales"></param>
        public VideoGame(string name, string platform, int year, string genre, string publisher, double na_sales, double eu_sales, double jp_sales, double other_sales, double global_sales)
        {
            this.name = name;
            this.platform = platform;
            this.year = year;
            this.genre = genre;
            this.publisher = publisher;
            this.na_sales = na_sales;
            this.eu_sales = eu_sales;
            this.jp_sales = jp_sales;
            this.other_sales = other_sales;
            this.global_sales = global_sales;
        }

        //Getters
        /// <summary>
        /// GetPublisher(), returns publisher
        /// </summary>
        /// <returns>string publisher</returns>
        public string GetPublisher()
        {
            return publisher;
        }

        /// <summary>
        /// GetGenre(), returns genre
        /// </summary>
        /// <returns>string genre</returns>
        public string GetGenre()
        {
            return genre;
        }

        /// <summary>
        /// CompareTo(), method implemented from IComparable. Compares one VideoGame object to another VideoGame object ,and then sorts them.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareTo(VideoGame other)
        {
            if(this.name.CompareTo(other.name) < 0)
            {
                return -1;
            }
            else if(this.name.CompareTo(other.name) == 0)
            {
                if (this.year.CompareTo(other.year) < 0)
                {
                    return -1;
                }
                else if (this.year.CompareTo(other.year) == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// ToString(), displays VideoGame objects in a formatted way as a string
        /// </summary>
        /// <returns>string message</returns>
        public override String ToString()
        {
            string message;

            message = $"{name}, {year}, {genre}\n" +
                      $"    Published by {publisher} on {platform}.\n";

            return message;
        }
    }
}
