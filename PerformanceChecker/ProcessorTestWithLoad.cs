using System;
using System.Diagnostics;
using System.Threading;

public class ProcessorPerformanceTest
{
    public static void Execute()
    {
        Console.WriteLine("\nTest de performance du processeur :");
        Console.WriteLine("----------------------------------");

        Console.WriteLine("Entrez la durée du test (en secondes) :");
        int testDuration = Convert.ToInt32(Console.ReadLine());

        double processorTestScore = GenerateProcessorTestScore(testDuration);
        double processorTestNormalizedScore = NormalizeScore(processorTestScore, testDuration);

        Console.WriteLine($"Note de performance : {processorTestNormalizedScore:F2} sur 100");
    }

    public static double GenerateProcessorTestScore(int testDuration)
    {
        Console.WriteLine("Début du test de performance du processeur...");

        long iterationCount = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds < testDuration)
        {
            // Effectuer des opérations de calcul intensives pour charger le processeur
            for (int i = 0; i < 1000000; i++)
            {
                // Exemple d'opération de calcul intensive
                double result = Math.Sqrt(i) * Math.Log10(i) + Math.Pow(i, 2);
            }

            iterationCount++;
        }

        stopwatch.Stop();

        Console.WriteLine("Fin du test de performance du processeur.");
        Console.WriteLine($"Nombre d'itérations : {iterationCount}");
        Console.WriteLine($"Durée totale : {stopwatch.Elapsed.TotalSeconds:F2} secondes");

        return iterationCount;
    }

    public static double NormalizeScore(double score, double maxValue)
    {
        return (score / maxValue) * 100;
    }
}
