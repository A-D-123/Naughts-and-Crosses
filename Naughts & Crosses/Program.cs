namespace Naughts___Crosses
{
    internal class Program
    { 
        
        static void Main(string[] args)
        {
            Board Board = new Board();
            Handler handler = new Handler();



            Board.Reset();
            Board.Print();

            



            Console.ReadKey();
        }
    }
}
