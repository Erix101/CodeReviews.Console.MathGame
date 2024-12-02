

using System.Text.Json.Serialization;

Console.OutputEncoding = System.Text.Encoding.UTF8;

DateTime date = DateTime.Now;
int questionNumber = 1;
int score = 0;   //add 1 for each correct answer
string pastQuestions = "\nPast Questions\n";
string name = null;
bool valid = true;


do
{
    Console.WriteLine("Welcome to the math game!  Before we start, lets get aquainted.  I'm Calc, whats your name?");
    name = Console.ReadLine();
    try
    {
        Console.WriteLine($"Hi {Char.ToUpper(name[0])}{name.Substring(1).ToLower()}, pleased to meet you.  It's  {date.Hour}:{date.Minute} You have 10 questions. Lets start!");
        valid = true;
    }
    catch (IndexOutOfRangeException e)
    {
        valid = false;
        Console.WriteLine($"{e.Message}");
        Console.WriteLine();
    }
} while (!valid);

Console.WriteLine();


do
{
    Console.WriteLine(@"Please choose which game you'd like to play:
1 - Addition
2 - Subtraction
3 - Multiplication
4 - Division
P - Past Questions
Q - Quit the game
");

    try
    {
        string option = Console.ReadLine().ToUpper().Trim();
        Console.Clear();
        if (option == "Q")
        {
            Console.WriteLine($"Good job {Char.ToUpper(name[0])}{name.Substring(1).ToLower()}!  You scored {score}/{questionNumber - 1} !");   //nice to have is to change the message according to score
            Console.WriteLine(pastQuestions);
            Console.WriteLine();
            Console.WriteLine("Thank you for playing!");
            Console.ReadKey();
            Environment.Exit(0);
        }
        else if (option == "P")
        {
            Console.WriteLine(pastQuestions);
        }
        else if (Int32.Parse(option) >= 1 && Int32.Parse(option) <= 4)
        {
            PlayGame(option);
            questionNumber++;
        }

    }
    catch (FormatException e)
    {
        Console.WriteLine(e.Message);

    }

} while (true);  





void PlayGame(string option)
{

    Random random = new Random();
    int num1 = random.Next(1, 11);
    int num2 = random.Next(1, 11);
    valid = false;
    int answer = 0;
    int correctAnswer = 0;

    switch (option)
    {
        case "1":
            Console.WriteLine("you chose an Addition");
            Console.WriteLine($"Q{questionNumber}.  {num1} + {num2} =");
            correctAnswer = num1 + num2;
            do
            {
                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    if (correctAnswer == answer)
                    {
                        Console.WriteLine($"Correct\n");
                        pastQuestions += $"Q{questionNumber}.  {num1} + {num2} = {correctAnswer} \u2714 \n";
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"That is not correct, the answer is {correctAnswer}\n");
                        pastQuestions += $"Q{questionNumber}.  {num1} + {num2} = {answer} \u274C   (Ans={correctAnswer})\n";
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("That's not an integer, please try again");

                }
            } while (true);

            break;
        case "2":
            Console.WriteLine("you chose a Subtraction");
            Console.WriteLine($"Q{questionNumber}.  {num1} - {num2} =");
            correctAnswer = num1 - num2;
            do
            {
                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    if (correctAnswer == answer)
                    {
                        Console.WriteLine($"Correct\n");
                        pastQuestions += $"Q{questionNumber}.  {num1} - {num2} = {correctAnswer} \u2714 \n";
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"That is not correct, the answer is {correctAnswer}\n");
                        pastQuestions += $"Q{questionNumber}.  {num1} - {num2} = {answer} \u274C   (Ans={correctAnswer})\n";
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("That's not an integer, please try again");
                }
            } while (true);
            break;
        case "3":
            Console.WriteLine("you chose a Multipication");
            Console.WriteLine($"Q{questionNumber}.  {num1} * {num2} =");
            correctAnswer = num1 * num2;
            do
            {

                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    if (correctAnswer == answer)
                    {
                        Console.WriteLine($"Correct\n");
                        pastQuestions += $"Q{questionNumber}.  {num1} * {num2} = {correctAnswer} \u2714 \n";
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"That is not correct, the answer is {correctAnswer}\n");
                        pastQuestions += $"Q{questionNumber}.  {num1} * {num2} = {answer} \u274C   (Ans={correctAnswer})\n";
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("That's not an integer, please try again");
                }
            } while (true);
            break;
        case "4":
            Console.WriteLine("you chose a Division");
            num1 = num1 * num2;
            Console.WriteLine($"Q{questionNumber}.  {num1} / {num2} =");
            correctAnswer = num1 / num2;
            do
            {
                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    if (correctAnswer == answer)
                    {
                        Console.WriteLine($"Correct\n");
                        pastQuestions += $"Q{questionNumber}.  {num1} / {num2} = {correctAnswer} \u2714 \n";
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"That is not correct, the answer is {correctAnswer}\n");
                        pastQuestions += $"Q{questionNumber}.  {num1} / {num2} = {answer} \u274C   (Ans={correctAnswer})\n";
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("That's not an integer, please try again");
                }

            } while (true);
            break;
    }
}

