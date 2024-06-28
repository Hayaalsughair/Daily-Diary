namespace Daily_Diary
{
    public class Program
    {
        static void Main(string[] args)
        {

            string pathDailyDiary = @"..\..\..\data.txt";

            while (true)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("Welcome to Our DailyDiary! \nChoose Process to Start:");
                Console.WriteLine("===========================================");
                Console.WriteLine("[V] View All Diary.\n[W] Write to Diary. \n[D] Delete Entry. \n[C] Count Entries. \n[Q] Quit. ");
                string userChoice = Console.ReadLine().ToUpper();

                switch (userChoice)
                {
                    case "V":
                        DailyDiary.ReadDiaryFile(pathDailyDiary);
                        break;
                    case "W":
                        DailyDiary.AddEntry(pathDailyDiary);
                        break;
                    case "D":
                        DailyDiary.DeleteEntry(pathDailyDiary);
                        break;
                    case "C":
                        DailyDiary.CountEntries(pathDailyDiary);
                        break;
                    case "Q":
                        Console.WriteLine("Exiting the application.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter\n[V] View All Diary.\n[W] Write to Diary. \n[D] Delete Entry. \n[C] Count Entries. \n[Q] Quit. ");
                        break;


                }
            }
        }
    }
}
