// See https://aka.ms/new-console-template for more information
using DoubleList;

class Program
{
    static void Main()
    {
        var list = new DoublyLinkedList<string>();
        string opc = "0";

        do
        {
            opc = Menu();

            switch (opc)
            {
                case "1":
                    Console.Write("Enter a value: ");
                    var input = Console.ReadLine();
                    if (input != null)
                        list.InsertSorted(input);
                    break;

                case "2":
                    Console.WriteLine("List forward:");
                    Console.WriteLine(list.GetForward());
                    break;

                case "3":
                    Console.WriteLine("List backward:");
                    Console.WriteLine(list.GetBackward());
                    break;

                case "4":
                    list.SortDescending();
                    Console.WriteLine("List sorted in descending order.");
                    break;

                case "5":
                    var modes = list.GetModes();
                    Console.WriteLine("Mode(s): " + string.Join(", ", modes));
                    break;

                case "6":
                    Console.WriteLine("Frequency graph:");
                    list.ShowFrequencyGraph();
                    break;

                case "7":
                    Console.Write("Enter the value to search: ");
                    var search = Console.ReadLine();
                    Console.WriteLine(list.Contains(search!) ? "Exists in the list." : "Does not exist.");
                    break;

                case "8":
                    Console.Write("Enter the value to remove (once): ");
                    var remove = Console.ReadLine();
                    list.RemoveFirstOccurrence(remove!);
                    Console.WriteLine("Removed (if existed).");
                    break;

                case "9":
                    Console.Write("Enter the value to remove (all occurrences): ");
                    var removeAll = Console.ReadLine();
                    list.RemoveAllOccurrences(removeAll!);
                    Console.WriteLine("All occurrences removed.");
                    break;

                case "0":
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
        while (opc != "0");
    }

    static string Menu()
    {
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Show forward");
        Console.WriteLine("3. Show backward");
        Console.WriteLine("4. Sort descending");
        Console.WriteLine("5. Show mode(s)");
        Console.WriteLine("6. Show frequency graph");
        Console.WriteLine("7. Contains");
        Console.WriteLine("8. Remove one occurrence");
        Console.WriteLine("9. Remove all occurrences");
        Console.WriteLine("0. Exit");
        Console.Write("Choose an option: ");
        return Console.ReadLine() ?? "0";
    }
}