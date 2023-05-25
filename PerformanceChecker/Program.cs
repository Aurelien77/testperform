using System;


public class Program
{
    public static void Main()
    {
        Console.WriteLine("1. Test de la mémoire avec charge");
        Console.WriteLine("2. Test de la mémoire sans charge");
        Console.WriteLine("3. Test du processeur avec charge");
        Console.WriteLine("4. Test du processeur sans charge");

        Console.WriteLine("Choisissez une option :");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                MemoryTestWithLoad.Execute();
                break;
            case 2:
                MemoryTestWithoutLoad.Execute();
                break;
            case 3:
                ProcessorPerformanceTest.Execute();
                break;
            case 4:
                ProcessorTestWithoutLoad.Execute();
                break;
            default:
                Console.WriteLine("Option invalide. Veuillez choisir une option valide (1, 2, 3 ou 4).");
                break;
        }

        Console.ReadLine();
    }
}
