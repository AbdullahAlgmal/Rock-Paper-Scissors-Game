bool Again = true;
string YesNo = "";
RockPaperScissors Game = new RockPaperScissors();
while (Again)
{
    Console.Clear();
    Game.StartGame();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Do You Want To Paly Again:\n1-Yes :-)\n2-No :-(");
    Again = Convert.ToBoolean(((YesNo = Console.ReadLine())[0] == '1' ? true : false));
}

public class RockPaperScissors
{
    enum enChoices { Roock, Paper, Scissors };
    enum enResult { Win, Lose, Draw };
    struct stResult
    {
        public byte RoundsNo;
        public byte PlayerOneWinTimes;
        public byte PlayerTwoWinTimes;
        public byte DrawTimes;
        public enResult Result;
    }
    stResult _Result;
    enChoices _PlayerChoice;
    enChoices _ComputerChoice;
    void PrintResultScreen()
    {
        Console.Clear();
        if (_Result.Result == enResult.Win) Console.ForegroundColor = ConsoleColor.Green;
        else if (_Result.Result == enResult.Lose) Console.ForegroundColor = ConsoleColor.Red;
        else Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t\t\t\t*******************************************");
        Console.WriteLine("\t\t\t\t*************** GAME RESULT ***************");
        Console.WriteLine("\t\t\t\t*******************************************");
        Console.WriteLine("\t\t\t\tGame Rounds: {0}", _Result.RoundsNo);
        Console.WriteLine("\t\t\t\tPlayer Wins: {0}", _Result.PlayerOneWinTimes);
        Console.WriteLine("\t\t\t\tComputer Wins: {0}", _Result.PlayerTwoWinTimes);
        Console.WriteLine("\t\t\t\tDraw Times: {0}", _Result.DrawTimes);
        Console.WriteLine("\t\t\t\tWinner: {0}", _Result.Result);
        Console.WriteLine("\t\t\t\t*******************************************");
    }
    void PrintRoundResultScreen(byte RoundNumber)
    {
        Console.Clear();
        if (_Result.Result == enResult.Win) Console.ForegroundColor = ConsoleColor.Green;
        else if (_Result.Result == enResult.Lose) Console.ForegroundColor = ConsoleColor.Red;
        else Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t\t\t\t********************************************");
        Console.WriteLine($"\t\t\t\t************** Round {RoundNumber} RESULT **************");
        Console.WriteLine("\t\t\t\t********************************************");
        Console.WriteLine("\t\t\t\tPlayer Choice: {0}", _PlayerChoice);
        Console.WriteLine("\t\t\t\tComputer Choice: {0}", _ComputerChoice);
        Console.WriteLine("\t\t\t\tWinner: {0}", _Result.Result);
        Console.WriteLine("\t\t\t\t********************************************");
        Console.ForegroundColor = ConsoleColor.White;
    }
    void SetChoice(byte Choice)
    {
        _PlayerChoice = Choice switch
        {
            1 => enChoices.Roock,
            2 => enChoices.Paper,
            3 => enChoices.Scissors,
            _ => enChoices.Roock
        };
        Random random = new Random();
        _ComputerChoice = random.Next(3) + 1 switch
        {
            1 => enChoices.Roock,
            2 => enChoices.Paper,
            3 => enChoices.Scissors,
            _ => enChoices.Roock
        };
    }
    void Game(byte RoundsNumber)
    {
        byte Choice;
        for (byte i = 1; i <= RoundsNumber; i++)
        {
            Console.WriteLine("Write Your Choice:\n1-Roock\n2-Paper\n3-Scissors");
            Choice = Convert.ToByte(Console.ReadLine());
            SetChoice(Choice);
            if (_PlayerChoice == enChoices.Roock && _ComputerChoice == enChoices.Scissors)
            {
                _Result.PlayerOneWinTimes++;
                _Result.Result = enResult.Win;
            }
            else if (_PlayerChoice == enChoices.Roock && _ComputerChoice == enChoices.Paper)
            {
                _Result.PlayerTwoWinTimes++;
                _Result.Result = enResult.Lose;
            }
            else if (_PlayerChoice == enChoices.Scissors && _ComputerChoice == enChoices.Roock)
            {
                _Result.PlayerTwoWinTimes++;
                _Result.Result = enResult.Lose;
            }
            else if (_PlayerChoice == enChoices.Scissors && _ComputerChoice == enChoices.Paper)
            {
                _Result.PlayerOneWinTimes++;
                _Result.Result = enResult.Win;
            }
            else if (_PlayerChoice == enChoices.Paper && _ComputerChoice == enChoices.Scissors)
            {
                _Result.PlayerTwoWinTimes++;
                _Result.Result = enResult.Lose;
            }
            else if (_PlayerChoice == enChoices.Paper && _ComputerChoice == enChoices.Roock)
            {
                _Result.PlayerOneWinTimes++;
                _Result.Result = enResult.Win;
            }
            else { _Result.DrawTimes++; _Result.Result = enResult.Draw; }
            PrintRoundResultScreen(i);
        }
        if (_Result.PlayerOneWinTimes > _Result.PlayerTwoWinTimes) _Result.Result = enResult.Win;
        else if (_Result.PlayerOneWinTimes < _Result.PlayerTwoWinTimes) _Result.Result = enResult.Lose;
        else _Result.Result = enResult.Draw;
    }
    public void StartGame()
    {
        Console.WriteLine("Enter The Number Of Rounds You Want To Play:");
        byte rounds = Convert.ToByte(Console.ReadLine());
        _Result.RoundsNo = rounds;
        Game(rounds);
        PrintResultScreen();
    }
}

