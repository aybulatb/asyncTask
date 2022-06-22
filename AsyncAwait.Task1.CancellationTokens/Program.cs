/*
* Study the code of this application to calculate the sum of integers from 0 to N, and then
* change the application code so that the following requirements are met:
* 1. The calculation must be performed asynchronously.
* 2. N is set by the user from the console. The user has the right to make a new boundary in the calculation process,
* which should lead to the restart of the calculation.
* 3. When restarting the calculation, the application should continue working without any failures.
*/

using System;
using System.Threading;

namespace AsyncAwait.Task1.CancellationTokens;

internal class Program
{
    //private static CancellationTokenSource cts = new();
    /// <summary>
    /// The Main method should not be changed at all.
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        Console.WriteLine("Mentoring program L2. Async/await.V1. Task 1");
        Console.WriteLine("Calculating the sum of integers from 0 to N.");
        Console.WriteLine("Use 'q' key to exit...");
        Console.WriteLine();

        var cts = new CancellationTokenSource();
        var token = cts.Token;

        Console.WriteLine("Enter N: ");

        var input = Console.ReadLine();
        while (input.Trim().ToUpper() != "Q")
        {
            if (input.Trim().ToUpper() == "N")
            {
                cts.Cancel();
            }
            else if (int.TryParse(input, out var n))
            {
                if (token.IsCancellationRequested)
                {
                    cts.Dispose();
                    cts = new CancellationTokenSource();
                    token = cts.Token;
                }
                CalculateSum(n, token);
            }
            else
            {
                Console.WriteLine($"Invalid integer: '{input}'. Please try again.");
                Console.WriteLine("Enter N: ");
            }

            input = Console.ReadLine();
        }

        cts.Dispose();
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }

    private static async void CalculateSum(int n, CancellationToken token)
    {
        // todo: make calculation asynchronous
        Console.WriteLine($"The task for {n} started... Enter N to cancel the request:");
        var sum = await Calculator.Calculate(n, token);

        Console.WriteLine($"Sum for {n} = {sum}.");
        Console.WriteLine();
        
        if (token.IsCancellationRequested)
        {
            Console.WriteLine($"Sum for {n} cancelled...");
            Console.WriteLine("Enter new N: ");
        }
    }
}
