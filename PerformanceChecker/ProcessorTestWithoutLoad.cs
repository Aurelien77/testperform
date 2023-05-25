using System;
using System.Diagnostics;

public class ProcessorTestWithoutLoad
{
    public static void Execute()
    {
        Console.WriteLine("\nNote basée sur le test du processeur sans charge :");
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine("Entrez la durée de diagnostic (en secondes) :");
        int diagnosticDuration = Convert.ToInt32(Console.ReadLine());

        double processorTestScoreWithoutLoad = GenerateProcessorTestScoreWithoutLoad(diagnosticDuration);
        double processorTestNormalizedScoreWithoutLoad = NormalizeScore(processorTestScoreWithoutLoad, 100);

        Console.WriteLine($"Note de performance actuelle : {processorTestNormalizedScoreWithoutLoad:F2} sur 100");
    }

    public static double GenerateProcessorTestScoreWithoutLoad(int diagnosticDuration)
    {
        var timer = new Stopwatch();
        timer.Start();

        Console.WriteLine("Début du test du processeur sans charge...");

        // Effectuer le test du processeur sans charge...
        // ...

        // Attendre la durée spécifiée avant de continuer
        System.Threading.Thread.Sleep(diagnosticDuration * 1000);

        timer.Stop();
        double processorTestScore = timer.Elapsed.TotalSeconds;

        Console.WriteLine("Fin du test du processeur sans charge.");
        Console.WriteLine($"Temps total écoulé : {processorTestScore:F2} secondes");

        return processorTestScore;
    }

    public static double NormalizeScore(double score, double maxValue)
    {
        return (maxValue - score) / maxValue * 100;
    }
}
