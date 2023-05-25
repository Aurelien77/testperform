using System;
using System.Diagnostics;
using System.Management;

public class MemoryTestWithLoad
{
    public static void Execute()
    {
        Console.WriteLine("\nNote basée sur le test de la mémoire avec charge :");
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine("Entrez la durée de diagnostic (en secondes) :");
        int diagnosticDuration = Convert.ToInt32(Console.ReadLine());

        double memoryTestScoreWithLoad = GenerateMemoryTestScoreWithLoad(diagnosticDuration);
        double memoryTestNormalizedScoreWithLoad = NormalizeScore(memoryTestScoreWithLoad, 10);

        Console.WriteLine($"Note de performance actuelle : {memoryTestNormalizedScoreWithLoad:F2} sur 100");

        // Obtenir les informations de mémoire système
        Console.WriteLine("\nInformations de mémoire système :");
        Console.WriteLine("--------------------------------");

        Console.WriteLine(GetMemoryInfo());
    }

    public static string GetMemoryInfo()
    {
        var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
        var memoryInfo = string.Empty;

        foreach (var obj in searcher.Get())
        {
            var memory = (ManagementObject)obj;
            memoryInfo += $"Emplacement : {memory["DeviceLocator"]}\n";
            memoryInfo += $"Capacité : {ConvertToGB(memory["Capacity"])} GB\n";
            memoryInfo += $"Vitesse : {memory["Speed"]} MHz\n";
        }

        return memoryInfo;
    }

    public static double GenerateMemoryTestScoreWithLoad(int diagnosticDuration)
    {
        var timer = new Stopwatch();
        timer.Start();
        double totalMemoryUsage = 0;
        double initialMemoryUsage = 0;

        Console.WriteLine("Début du test de la mémoire avec charge...");

        var currentProcess = Process.GetCurrentProcess();
        initialMemoryUsage = (double)currentProcess.PrivateMemorySize64;

        // Effectuer le test de la mémoire avec charge...
        // ...

        currentProcess = Process.GetCurrentProcess();
        var memoryUsage = (double)currentProcess.PrivateMemorySize64;
        var memoryUsageDifference = memoryUsage - initialMemoryUsage;
        totalMemoryUsage += memoryUsageDifference;

        // Attendre la durée spécifiée avant de continuer
        System.Threading.Thread.Sleep(diagnosticDuration * 1000);

        timer.Stop();
        double averageMemoryUsage = totalMemoryUsage;
        double memoryTestScore = averageMemoryUsage / 1024 / 1024; // Convertir en Mo

        Console.WriteLine("Fin du test de la mémoire avec charge.");
        Console.WriteLine($"Octets utilisés en plus : {totalMemoryUsage}");
        Console.WriteLine($"Taux d'utilisation de la mémoire en plus : {memoryUsageDifference / initialMemoryUsage * 100:F2}%");

        return memoryTestScore;
    }

    public static double NormalizeScore(double score, double maxValue)
    {
        return (score / maxValue) * 100;
    }

    // Méthode utilitaire pour convertir la capacité en octets en gigaoctets
    public static double ConvertToGB(object bytes)
    {
        return Convert.ToDouble(bytes) / (1024 * 1024 * 1024);
    }
}
