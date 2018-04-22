using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{


    class BusinessHouseGame
    {
       static void Main(string[] args)
        {

          
            var userInput = "E,E,J,H,E,T,J,T,E,E,H,J,T,H,E,E,J,H,E,T,T,E,E,H,J,T,H,J,E,E,J,H,E,T,J,T,E,E,H,J,T,E,H,E";

            // create cells
            var cells = CreateCells(userInput);

            // create players
            var players = CreatePlayers();

            var diceOutput = "4,4,4,6,7,8,5,11,10,12,2,3,5,6,7,8,5,11,10,12,2,3,5,6,7,8,5,11,10,12,10,10,10,12,13,11";

            // play game
            PlayGame(diceOutput,players,cells);

            // declare winner
            DeclareWinner(players, cells);

            Console.ReadLine();

        }

        static void PlayGame(string diceOutput,List<Player> players,List<Cell> cells)
        {
            char[] splitchar = { ',' };
            var diceOutputs = diceOutput.ToString().Split(splitchar);
            var numberOfGames = diceOutputs.Count() / players.Count;

            for (var i = 1; i <= numberOfGames; i++)
            {
                var dicePlayed = new List<string>();


                dicePlayed = diceOutputs.ToList().Select(d => d).Skip(players.Count * (i - 1)).Take(players.Count).ToList();

                for (int j = 0; j < dicePlayed.Count(); j++)
                {
                    // select player 
                    var player = players.Select(p => p).Where(p => p.PlayerId == j + 1).FirstOrDefault();

                    // no of steps to go 
                    player.Steps = Convert.ToInt32(dicePlayed[j]);

                    // if dice counts going out of cells 
                    if (player.CurrentPosition + player.Steps > cells.Count)
                        player.CurrentPosition = (player.CurrentPosition + player.Steps) - cells.Count;

                    else
                        player.CurrentPosition += player.Steps;



                    var currentCell = cells[player.CurrentPosition-1];



                    if (currentCell.GetCellType() == CellTypes.HOTEL.ToString())
                    {
                        var temHotel = (Hotel)currentCell;
                        if (temHotel.IsOwned)
                        {
                            if (temHotel.OwnedBy.PlayerId != player.PlayerId)
                            {
                                player.TotalAmount = player.TotalAmount - temHotel.Rent;
                            }

                        }
                        else
                        {
                            temHotel.IsOwned = true;
                            temHotel.OwnedBy = player;
                            player.TotalAmount = player.TotalAmount - currentCell.GetCellValue();

                        }

                    }
                    else
                        player.TotalAmount = player.TotalAmount + currentCell.GetCellValue();



                }

            }
        }
        static List<Cell> CreateCells(string userInput)
        {
            List<Cell> cells = new List<Cell>();
            char[] splitchar = { ',' };
            var userInputs = userInput.ToString().Split(splitchar);

            foreach (var eachInput in userInputs)
            {
                if (eachInput == "E")
                    cells.Add(new Empty());
                else if (eachInput == "J")
                    cells.Add(new Jail());
                else if (eachInput == "H")
                    cells.Add(new Hotel());
                else if ((eachInput == "T"))
                    cells.Add(new Treasure());
            }
            return cells;
        }

        static List<Player> CreatePlayers()
        {

            List<Player> players = new List<Player>();
            players.Add(new Player(1200) { PlayerId = 1 });
            players.Add(new Player(1200) { PlayerId = 2 });
            players.Add(new Player(1050) { PlayerId = 3 });
            players.Add(new Player(1060) { PlayerId = 4 });
            return players;
        }
        static void DeclareWinner(List<Player> players,List<Cell> cells)
        {

          //  var finalplayer = players.Select(p => p).OrderByDescending(p => p.TotalAmount);

            var Hotels = cells.Select(c => c).Where(c => c.GetCellType() == CellTypes.HOTEL.ToString()).ToList();

            foreach (var player in players)
            {
                var HotelWorth = 0;
               
                if (Hotels.Any())
                {
                    HotelWorth = Hotels.Select(c => c).Where(c => ((Hotel)c).IsOwned == true && ((Hotel)c).OwnedBy.PlayerId == player.PlayerId).Count() * (int)CellValues.HOTELVALUE;
                }

                player.TotalAmount = player.TotalAmount + HotelWorth;
            }
            var finalplayer = players.Select(p => p).OrderByDescending(p => p.TotalAmount); 
            foreach (var player in finalplayer)
            {

                Console.WriteLine("Player" + player.PlayerId + " has " + (player.TotalAmount) + " including Hotel worth!");

            }
            }
    }
}
