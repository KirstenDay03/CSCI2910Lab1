using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;

namespace CSCI2910Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Step 1
            List<VideoGame> games = new List<VideoGame>();                          //creates a new list of VideoGames called games
            string fileName = $@"..\..\..\DataFile\videogames.csv";                 //saves the relative path to videogames.csv as a string

            try                                                                     //try to validate contained code
            {
                using (StreamReader rdr = new StreamReader(fileName))               //opens videogames.csv using StreamReader
                {
                    string nextLine = rdr.ReadLine();                               //reads the first line in videogames.csv and saves it in nextLine as a string
                    while (rdr.Peek() != -1)                                        //while loop to make sure there is another line to read
                    {
                        nextLine = rdr.ReadLine();                                  //reads the next line in videogames.csv

                        string[] fields = nextLine.Split(',');                      //creates a string array to hold each individual value in nextLine

                        VideoGame v = new VideoGame(fields[0], fields[1], int.Parse(fields[2]), fields[3], fields[4], double.Parse(fields[5]), double.Parse(fields[6]), double.Parse(fields[7]), double.Parse(fields[8]), double.Parse(fields[9]));
                        //creates a new VideoGame v and uses the values stored in fields as parameters

                        games.Add(v);                                               //adds VideoGame v to games
                    }//End While

                    rdr.Close();                                                    //closes StreamReader rdr
                }//End using
            }//End Try
            catch(Exception e)                                                      //catches any exception that could be thrown
            {
                Console.WriteLine(e.Message);                                       //displays the error message
            }
            //End Step 1

            //Step 2
            games.Sort();                                                           //sorts all the VideoGames in games alphabetically by title
            //End Step 2

            //Step 3
            List<VideoGame> publisher = new List<VideoGame>();                      //creates a new list of VideoGames called publisher

            for (int x = 0; x < games.Count; x++)                                   //for loop runs till the last object in games has been checked
            {
                if (games[x].GetPublisher() == "Nintendo")                          //tests if any of the VideoGames in games were published by Nintendo
                {
                    publisher.Add(games[x]);                                        //adds VideoGame objects to publisher
                }
            }//End for

            Console.WriteLine("Games Published By Nintendo (First 50 in List)");     //title for games published by Nintendo
            Console.WriteLine();                                                    //formats console output

            for (int x = 0; x < 50; x++)                                             //for loop runs till x is not less than 50
            {
                Console.WriteLine($"{x+1}: {publisher[x]}");                        //displays the first 50 VideoGame objects in publisher to the console
            }//End for
            //End Step 3

            //Step 4
            double totalCount = games.Count;                                        //count of VideoGame objects in games
            double pubCount = publisher.Count;                                      //count of VideoGame objects in publisher
            double pubPercent = (pubCount / totalCount) * 100;                      //the percent of VideoGame objects made by Nintendo out of all the VideoGame objects

            Console.WriteLine($"Out of {totalCount} games, {pubCount} are developed by Nintendo, which is {String.Format("{0:0.00}", pubPercent)}%");   //displays pubPercent
            //End Step 4

            Console.WriteLine();                                                    //formats console output
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine();

            //Step 5
            List<VideoGame> genre = new List<VideoGame>();                          //creates a new list of VideoGames called genre
            for (int x = 0; x < games.Count; x++)                                   //for loop runs till the last object in games has been checked
            {
                if (games[x].GetGenre() == "Action")                                //tests if any of the VideoGames in games had the genre Action
                {
                    genre.Add(games[x]);                                            //adds VideoGame objects to genre
                }
            }//End for

            Console.WriteLine("Action Games (First 50 in List)");                   //title for Action games
            Console.WriteLine();                                                    //formats console output

            for (int x = 0; x < 50; x++)                                            //for loop runs till x is not less than 50
            {
                Console.WriteLine($"{x+1}: {genre[x]}");                            //displays the first 50 VideoGame objects in genre to the console
            }//End for
            //End Step 5

            //Step 6
            double genreCount = genre.Count;                                        //count of VideoGame objects in genre
            double genrePercent = (genreCount / totalCount) * 100;                  //the percent of VideoGame objects with the genre Action out of all VideoGame objects

            Console.WriteLine($"Out of {totalCount} games, {genreCount} are Action games, which is {String.Format("{0:0.00}", genrePercent)}%");    //displays genrePercent
            //End Step 6

            Console.WriteLine();                                                    //formats console output
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine();

            //Step 7/8
            Program p = new Program();                                              //Creates a new program
            bool quit = false;                                                      //bool to control while loop
            while(!quit)                                                            //while run till quit is true
            {
                Console.WriteLine("---------------------------------------------------------------------\n" +   //Creates a menu heading
                                  "Please enter the number of the menu option you would like to select:\n" +
                                  "1. Search for a specific publisher\n" +
                                  "2. Search for a specific genre\n" +
                                  "3. Quit\n" +
                                  "---------------------------------------------------------------------");
                string option = Console.ReadLine();                                                             //String option is equal to the user's menu choice

                if(option == "1")                                                                               //Asks the user what publisher they want to search for and then calls PublisherData 
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter the name of the publisher you want to search for:");
                    string publisherName = Console.ReadLine();
                    p.PublisherData(publisherName, games);
                }
                else if(option == "2")                                                                          //Asks the user what genre they want to search for and then calls GenreData
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter the genre you want to search for:");
                    string genreName = Console.ReadLine();
                    p.GenreData(genreName, games);
                }
                else if(option == "3")                                                                          //Turns quit to true, ending the while loop
                {
                    quit = true;
                }
                else                                                                                            //If none of the options are selected, this message is displayed
                {
                    Console.WriteLine("That is not one of the options. Please try again.");
                }
            }//End While

        }//End Main

        public void PublisherData(string publisherName, List<VideoGame> games)
        {
            List<VideoGame> publisher = new List<VideoGame>();                      //creates a new list of VideoGames called publisher

            for (int x = 0; x < games.Count; x++)                                   //for loop runs till the last object in games has been checked
            {
                if (games[x].GetPublisher() == publisherName)                       //tests if any of the VideoGames in games were published by publisherName
                {
                    publisher.Add(games[x]);                                        //adds VideoGame objects to publisher
                }
            }//End for

            if (publisher.Count > 0)                                                    //Tests if publisher has any VideoGames to display
            {
                Console.WriteLine($"Games Published By {publisherName}");               //title for games published by publisherName
                Console.WriteLine();                                                    //formats console output

                for (int x = 0; x < publisher.Count; x++)                               //for loop runs till x is greater than publisher.Count
                {
                    Console.WriteLine($"{x + 1}: {publisher[x]}");                      //displays all VideoGame objects in publisher to the console
                }//End for

                double totalCount = games.Count;                                        //count of VideoGame objects in games
                double pubCount = publisher.Count;                                      //count of VideoGame objects in publisher
                double pubPercent = (pubCount / totalCount) * 100;                      //the percent of VideoGame objects made by publisherName out of all the VideoGame objects

                Console.WriteLine($"Out of {totalCount} games, {pubCount} are developed by {publisherName}, which is {String.Format("{0:0.00}", pubPercent)}%");   //displays pubPercent
                                                                                                                                                            

                Console.WriteLine();                                                    //formats console output
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine();
            }
            else                                                                        //If publisher has no games, this message displays
            {
                Console.WriteLine("No games were published by this developer");         
            }
        }




        public void GenreData(string genreName, List<VideoGame> games)
        {
            List<VideoGame> genre = new List<VideoGame>();                          //creates a new list of VideoGames called genre

            for (int x = 0; x < games.Count; x++)                                   //for loop runs till the last object in games has been checked
            {
                if (games[x].GetGenre() == genreName)                               //tests if any of the VideoGames in games have the same genre as genreName
                {
                    genre.Add(games[x]);                                            //adds VideoGame objects to genre
                }
            }//End for

            if (genre.Count > 0)                                                    //Tests if genre has any VidoeGames to display
            {
                Console.WriteLine($"{genreName} Games");                            //title for genreName games
                Console.WriteLine();                                                //formats console output

                for (int x = 0; x < genre.Count; x++)                               //for loop runs till x is greater than genre.Count
                {
                    Console.WriteLine($"{x + 1}: {genre[x]}");                      //displays all VideoGame objects in genre
                }//End for

                double totalCount = games.Count;                                     //count of VideoGame objects in games
                double genreCount = genre.Count;                                     //count of VideoGame objects in genre
                double genrePercent = (genreCount / totalCount) * 100;               //the percent of VideoGame objects that have genreName as their genre out of all the VideoGame objects

                Console.WriteLine($"Out of {totalCount} games, {genreCount} are {genreName} games, which is {String.Format("{0:0.00}", genrePercent)}%");   //displays genrePercent


                Console.WriteLine();                                                    //formats console output
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine();
            }
            else                                                                     //If genre has no games, this message displays
            {
                Console.WriteLine("No games have this genre");
            }
        }
    }
}