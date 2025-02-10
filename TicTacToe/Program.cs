bool repeat = true;
string coordinateInput = "";
int coordinate1 = 0;
int coordinate2 = 0;
bool pXTurn = true;
bool pOTurn = false;
string pXSign = "X";
string pOSign = "O";
string error = "Unexpected error";
bool win = false;
int wincountPX = 0;
int wincountPO = 0;

string[,] board =
{
    {"X", " ", " " },
    {"X", " ", " " },
    {"X", " ", " " }
};


while (repeat)
{
    Console.Clear();

    //updates and draws board
    Console.WriteLine($"   -----------");
    Console.WriteLine($"1 | {board[0, 0]} | {board[0, 1]} | {board[0, 2]} |");
    Console.WriteLine($"   -----------");
    Console.WriteLine($"2 | {board[1, 0]} | {board[1, 1]} | {board[1, 2]} |");
    Console.WriteLine($"   -----------");
    Console.WriteLine($"3 | {board[2, 0]} | {board[2, 1]} | {board[2, 2]} |");
    Console.WriteLine($"   -----------");
    Console.WriteLine($"    A   B   C");

    // marker placement loop
    while (true)
    {
        Console.WriteLine("Enter coordinates");
        coordinateInput = Console.ReadLine().ToUpper();


        coordinate1 = coordinateInput[0] - '1';
        coordinate2 = coordinateInput[1] - 'A';

        if (board[coordinate1, coordinate2] == " ")
        {
            if (pXTurn)
            {

                board[coordinate1, coordinate2] = pXSign;
                pXTurn = false;
                pOTurn = true;
                break;
            }
            else if (pOTurn)
            {
                board[coordinate2, coordinate1] = pOSign;
                pXTurn = true;
                pOTurn = false;
                break;
            }
            else
            {
                Console.WriteLine(error);
            }
        }
        else
        {
            Console.WriteLine("already guessed");
        }
    }

    // win check    

    for (int i = 0; i < 3; i++) //left vertical line  
    {
        if (board[i, 0] != " ")
        {
            if(board[i, 0] == pXSign)
            {
                wincountPX++;
            }
            else if (board[i, 0] == pOSign)
            {
                wincountPO++;
            }
        }
    }
    if (wincountPX == 3) 
    {
        Console.WriteLine("Player X won");
    }
    else if (wincountPO == 3)
    {
        Console.WriteLine("Player O won");
    }
    Console.WriteLine(wincountPX);
    Console.WriteLine(wincountPO);
    wincountPX = 0;
    wincountPO = 0;


    /*for (int i = 0; i < 3; i++) //middle vertical line  
    {
        if (board[i, 1] != " ")
        {
            if (board[i, 1] == P1Sign)
            {
                wincountP1++;
            }
            else
            {
                wincountP2++;
            }
        }
    }
    if (wincountP1 == 3)
    {
        Console.WriteLine("Player 1 won");
    }
    else if (wincountP2 == 3)
    {
        Console.WriteLine("Player 2 won")
    }
    wincountP1 = 0;
    wincountP2 = 0;*/

    Console.ReadKey();
}    
    
    
    
 

