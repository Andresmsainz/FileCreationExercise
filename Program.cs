using System;
using System.IO;

namespace FileCreationExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FileCreation!");

            bool directoryExists = false;
            string dir;
            string logFile = "log.txt";
            StreamWriter sw = new StreamWriter(logFile);


            foreach (var language in Enum.GetValues(typeof(Languages)))
            {
                Console.WriteLine($"Currently looking at {language}");

                //First we create a directory if it doesn't exist
                dir = @"C:\temp\" + language + @"\";
                directoryExists = Directory.Exists(dir);

                Console.WriteLine($"Currently looking at {dir} directory with a " + directoryExists);

                if (!directoryExists)
                {
                    Console.WriteLine($"Directory does not exist... creating");
                    Directory.CreateDirectory(dir);
                }

                //Second we write to the log file
                Console.WriteLine($"Writing to log file " + dir + logFile);
                sw = new System.IO.StreamWriter(dir + logFile);
                sw.WriteLine($"{language} file created at " + DateTime.Now);
                sw.Close();
            }
        }

        enum Languages
        {
            English,
            Spanish,
            German,
            Arabic,
            Chinese
        }

    }


}
