bool repeat = true;
string coordinateInput = "";
int coordinate1 = 0;
int coordinate2 = 0;

string[,] board =
{
    {"1", "2", "3" },
    {"4", "5", "5" },
    {"7", "8", "9" }
}; 
    
    
    

while (repeat)
{
    //updates and draws board
    Console.WriteLine($"   -----------");
    Console.WriteLine($"1 | {board[0, 0]} | {board[0, 1]} | {board[0, 2]} |");
    Console.WriteLine($"   -----------");
    Console.WriteLine($"2 | {board[1, 0]} | {board[1, 1]} | {board[1, 2]} |");
    Console.WriteLine($"   -----------");
    Console.WriteLine($"3 | {board[2, 0]} | {board[2, 1]} | {board[2, 2]} |");
    Console.WriteLine($"   -----------");
    Console.WriteLine($"    A   B   C");

    Console.WriteLine("Enter coordinates");
    coordinateInput = Console.ReadLine().ToUpper();
    

    if (!coordinateInput.Contains("A") || !coordinateInput.Contains("B") || !coordinateInput.Contains("C") || !coordinateInput.Contains("1") || !coordinateInput.Contains("2") || !coordinateInput.Contains("3"))
    {
        Console.WriteLine("oaiwhfoa");
    }
    else
    {
        coordinate1 = coordinateInput[0] - '1';
        coordinate2 = coordinateInput[1] - 'A';
        Console.WriteLine(board[coordinate1, coordinate2]);
        
    }
    
    
    
    Console.ReadKey();
}
