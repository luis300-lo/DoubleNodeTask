// See https://aka.ms/new-console-template for more information
using DoubleList;

class Program
{
    static void Main()
    {
        var list = new DoublyLinkedList<string>();
        int option;

        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Adicionar");
            Console.WriteLine("2. Mostrar hacia adelante");
            Console.WriteLine("3. Mostrar hacia atras");
            Console.WriteLine("4. Ordenar descendentemente");
            Console.WriteLine("5. Mostrar la(s) moda(s)");
            Console.WriteLine("6. Mostrar grafico");
            Console.WriteLine("7. Existe");
            Console.WriteLine("8. Eliminar una ocurrencia");
            Console.WriteLine("9. Eliminar todas las ocurrencias");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Opcion invalida. Intente de nuevo.");
                continue;
            }

            switch (option)
            {
                case 1:
                    Console.Write("Ingrese un valor: ");
                    var input = Console.ReadLine();
                    list.InsertSorted(input!);
                    break;

                case 2:
                    Console.WriteLine("Lista hacia adelante:");
                    Console.WriteLine(list.GetForward());
                    break;

                case 3:
                    Console.WriteLine("Lista hacia atras:");
                    Console.WriteLine(list.GetBackward());
                    break;

                case 4:
                    list.SortDescending();
                    Console.WriteLine("Lista ordenada descendentemente.");
                    break;

                case 5:
                    var modes = list.GetModes();
                    Console.WriteLine("Moda(s): " + string.Join(", ", modes));
                    break;

                case 6:
                    Console.WriteLine("Grafico de ocurrencias:");
                    list.ShowFrequencyGraph();
                    break;

                case 7:
                    Console.Write("Ingrese el valor a buscar: ");
                    var search = Console.ReadLine();
                    Console.WriteLine(list.Contains(search!) ? "Existe en la lista." : "No existe.");
                    break;

                case 8:
                    Console.Write("Ingrese el valor a eliminar (una vez): ");
                    var toDeleteOnce = Console.ReadLine();
                    list.RemoveFirstOccurrence(toDeleteOnce!);
                    Console.WriteLine("Eliminado (si existia).");
                    break;

                case 9:
                    Console.Write("Ingrese el valor a eliminar (todas las veces): ");
                    var toDeleteAll = Console.ReadLine();
                    list.RemoveAllOccurrences(toDeleteAll!);
                    Console.WriteLine("Todas las ocurrencias eliminadas.");
                    break;

                case 0:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }
        } while (option != 0);
    }
}