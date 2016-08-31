using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monty_Hall_Problem
{
    class Game
    {
        public void Run()
        {
            const int ITERATIONS = 50;
            Random doorSeed = new Random();
            Random contestantBot = new Random();
            Boolean gutFeeling;
            int randomDoor, 
                chosenDoor, 
                revealedDoor,
                winTally = 0,
                lossTally = 0;
            decimal winRatio;

            ConsoleKeyInfo input;

            //User Input
            while (true)
            {
                Console.WriteLine("Welcome to the Monty Hall Problem simulation!\nWhich simulation would you like to run?\n1: Always keep | 2: Always change");
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.D1)
                {
                    gutFeeling = true;
                    Console.WriteLine();
                    break;
                }
                else if (input.Key == ConsoleKey.D2)
                {
                    gutFeeling = false;
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            //--------------------
            //--BEGIN SIMULATION--
            //--------------------

            for (int x = 0; x < ITERATIONS; x++)
            {
                bool[] doors = { false, false, false };
                doorSeed = new Random();

                randomDoor = doorSeed.Next(3);
                //Set the winning door
                doors[randomDoor] = true;

                //ContestantBot picks a random door
                chosenDoor = contestantBot.Next(3);

                //One remaining false door is revealed
                //If winner door, then reveal either door
                if (doors[chosenDoor] == true)
                {
                    while (true)
                    {
                        revealedDoor = doorSeed.Next(3);
                        if (doors[revealedDoor] != true)
                        {
                            break;
                        }
                    }
                }
                //If loser door, subtract chosen door and winner door to get remaining door
                else
                {
                    while (true)
                    {
                        revealedDoor = doorSeed.Next(3);
                        if (doors[revealedDoor] == false && revealedDoor != chosenDoor)
                        {
                            break;
                        }
                        else
                        {
                        }
                    }
                }


                //Chance to change doors (Gut-Feeling or Switch?)
                if (gutFeeling == false)
                {
                    int changeDoor = 0;
                    while (true)
                    {
                        if (chosenDoor == changeDoor || revealedDoor == changeDoor)
                        {
                            changeDoor++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    chosenDoor = changeDoor;
                }


                //Final Check
                //Tally to win/loss ratio
                if (doors[chosenDoor] == true)
                {
                    winTally++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Win:\t" + winTally);
                }
                else
                {
                    lossTally++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Loss:\t" + lossTally);
                }
            }

            //After loops, calculate win/loss percentage
            winRatio = ((decimal)winTally / (decimal)ITERATIONS);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("The total win ratio is : " + winRatio.ToString());

            Console.ReadLine();
        }
    }
}
