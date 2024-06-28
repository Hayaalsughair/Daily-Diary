using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Daily_Diary
{
    public class DailyDiary
    {
        public static string ReadDiaryFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    //Console.WriteLine("-------------------------------------");
                    //Console.WriteLine("This is the daily diary file content:");
                    //Console.WriteLine("-------------------------------------\n");
                    return File.ReadAllText(filePath);
                }
                else
                {
                    Console.WriteLine($"Error: File '{filePath}' not found."); 
                    return $"Error: File '{filePath}' not found."; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return $"Error: File '{filePath}' not found."; 
            }
        }

        public static void AddEntry(string filePath)
        {
            Console.WriteLine("Write The Date YYYY-MM-DD");
            string userDate = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userDate))
            {
                Console.WriteLine("Empty input, try again.");
                return;
            }

            if (DateTime.TryParse(userDate, out DateTime dateEnter))
            {
                Console.WriteLine("Write The Daily:");
                string userDaily = Console.ReadLine();

                Entry newEntry = new Entry(userDate, userDaily);
                try
                {
                    File.AppendAllText(filePath, newEntry.ToString() + Environment.NewLine);
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Added Entry:");
                    Console.WriteLine("-------------------------------------\n");
                    Console.WriteLine(newEntry);
                    Console.WriteLine("Daily added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please try again.");
            }
        }

        public static void DeleteEntry(string filePath)
        {
            Console.WriteLine("Please enter the date of the daily you want to delete:\nThe date should be (YYYY-MM-DD)");
            string dailyDelete = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(dailyDelete))
            {
                Console.WriteLine("You did not enter any date. Please try again.");
                return;
            }

            if (DateTime.TryParse(dailyDelete, out DateTime dateDelete))
            {
                List<string> lines = File.ReadAllLines(filePath).ToList();
                bool deleted = false;

                for (int i = lines.Count - 1; i >= 0; i--)
                {
                    if (lines[i] == dailyDelete)
                    {
                        lines.RemoveAt(i); 
                        if (i < lines.Count)
                        {
                            lines.RemoveAt(i); 
                        }
                        deleted = true;
                    }
                }

                if (deleted)
                {
                    File.WriteAllLines(filePath, lines);
                    Console.WriteLine("Delete successful");
                }
                else
                {
                    Console.WriteLine("Date not found");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a valid date");
            }
        }

        public static int CountEntries(string filePath)
        {
            try
            {
                List<string> DailyLines = new List<string>();
                foreach(string line in File.ReadAllLines(filePath)) {

                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        DailyLines.Add(line);
                    }
                }

                int countLines = DailyLines.Count / 2;
                Console.WriteLine($"Number of entries: {countLines}");
                return countLines;


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1;
            }
        }
    }
}