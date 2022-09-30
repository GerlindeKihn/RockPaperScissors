using RockPaperScissors.Enums;

namespace RockPaperScissors;

public class Program
{
    private static readonly Random Random = new();
    
    public static void Main(string[] args)
    {
        var playAgain = true;

        while (playAgain)
        {
            var scorePlayer = 0;
            var scoreCpu = 0;
            
            while (scorePlayer < 3 && scoreCpu < 3)
            {
                var inputPlayer = GetPlayersInput();
                var inputCpu = GetCpusInput();
                var result = ResultFor(inputPlayer, inputCpu);
                
                EvaluateResult(result, ref scorePlayer, ref scoreCpu);
            }

            if (scorePlayer == 3)
            {
                Console.WriteLine("Player WON!");
            }
            if (scoreCpu == 3)
            {
                Console.WriteLine("CPU WON!");
            }

            string loop = null; 
            
            while (loop != "y" && loop != "n")
            {
                Console.WriteLine("Do you want to play again? (y/n)");
                loop = Console.ReadLine();
                if (loop == "y")
                {
                    playAgain = true;
                }
                if (loop == "n")
                {
                    playAgain = false;
                }
            }
        }
    }

    private static Result ResultFor(string playersChoice, string cpusChoice)
    {
        return (playersChoice, cpusChoice) switch
        {
            ("ROCK", "PAPER") => Result.CpuWins,
            ("ROCK", "SCISSORS") => Result.PlayerWins,
            ("PAPER", "ROCK") => Result.PlayerWins,
            ("PAPER", "SCISSORS") => Result.CpuWins,
            ("SCISSORS", "PAPER") => Result.PlayerWins,
            ("SCISSORS", "ROCK") => Result.CpuWins,
            _ => Result.Draw
        };
    }

    private static void EvaluateResult(Result result, ref int scorePlayer, ref int scoreCPU)
    {
        if (result == Result.PlayerWins)
        {
            Console.WriteLine("PLAYER WINS!");
            scorePlayer++;
        }
        if (result == Result.CpuWins)
        {
            Console.WriteLine("CPU WINS!");
            scoreCPU++;
        }
        if (result == Result.Draw)
        {
            Console.WriteLine("DRAW!");
        }
    }

    private static string GetPlayersInput()
    {
        while (true)
        {
            Console.WriteLine("Choose between ROCK, PAPER and SCISSORS:");
            var playersInput = Console.ReadLine()?.Trim().ToUpper();

            if (playersInput == "ROCK" || playersInput == "PAPER" || playersInput == "SCISSORS") return playersInput;
            
            Console.WriteLine("Invalid entry!");
        }
    }

    private static string GetCpusInput()
    {
        var randomInt = Random.Next(1, 4);
        var cpuInput = randomInt switch { 1 => "ROCK", 2 => "PAPER", 3 => "SCISSORS", _ => null };
        Console.WriteLine($"CPU chose {cpuInput}.");
        return cpuInput;
    }
}