using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace bingo
{
    public class Program
    {
        public static void Main(string[] args)
        {

whoIsPlaying:

          Console.WriteLine("Who is playing?");
        string names = Console.ReadLine(); // gets names of playrers
        names = names.ToUpper(); // makes it look nice

        string[] nameArray = names.Split(", "); // makes it an array
        int playerCount = nameArray.Length; // gets the amount of players to multiply card value later

      IDictionary<string, int> stats = new Dictionary<string, int>(); //initializing stats dictionary

      for (int i = 0; i < nameArray.Length; i++)
      {stats.Add(nameArray[i], 0);} // adds all the players to the stats list


          Console.WriteLine("Players:");

        foreach (var name in nameArray) // lists all players for confirmation
        {
          Console.WriteLine(name);
        }
          Console.WriteLine($"There are {playerCount} players, correct?"); //user confirmation
          string playerConfirm = Console.ReadLine();
            if (playerConfirm.ToLower() == "yes") { //if yes, cool, continue
              goto cost;
            }
            else if (playerConfirm == "no") { // if no then it asks who is playing again
              goto whoIsPlaying;
            }

cost:
        Console.WriteLine("How much does a bingo card cost?");
        string card = Console.ReadLine();
        int cost = Convert.ToInt32(card); // makes the string reply into an interger
        Console.WriteLine($"For each round there is a ${playerCount*cost} prize, correct?"); // playerCount*cost calcuates how much money is being bet
        string costConfirm = Console.ReadLine();

          if (costConfirm.ToLower() == "yes"){ //if yes then the play begins
            goto play;
          }
          else{ // if the number is wrong then it asks agin
            goto cost;
          }

play:

        foreach (var player in stats)
        {
          player.Value = player.Value-cost;
        }

        Console.WriteLine("Once someone wins, hit ENTER"); // leave open until there is a winner
        string endPlay = Console.ReadLine();

        if (endPlay != "a single mango"){
          goto winner;
        }

winner:

        Console.WriteLine("How many winners are there?");
        string winnerCount = Console.ReadLine();
        int numberOfWinners = Convert.ToInt32(winnerCount); // lets us know how many winners to divide the prize by
        int prize = (playerCount*cost)/numberOfWinners; // the prize is everything stated before divided by the winners

        if (numberOfWinners == 1){

        Console.WriteLine("What is the name of the winner?"); // correct grammar is important
        goto winnernames;
}
      else if (numberOfWinners > 1 ){
        Console.WriteLine("What are the names of the winners?");
        goto winnernames;
      }

winnernames:

      string winnerNames = Console.ReadLine(); // takes the names of the winners
      winnerNames = winnerNames.ToUpper(); // makes it look nice
      string[] winnerArray = winnerNames.Split(", "); // makes it an array


      foreach (KeyValuePair<string, int> person in stats)
      {
        foreach (var winner in winnerArray)
        {
          if (person.Key == winner){
            person.Value = person.Value + prize;
          }

        }
      }

  //so like pop each value and compare against an exisiting key, if it exists then add the prize value to the existing value for each person like IF match then add prize else cont to new player count if number rises, add person to dict if not then keep going... to card value... then play and loop that Oh also every game subtract the cost from each person  thank you future dominique

      }





}

}
