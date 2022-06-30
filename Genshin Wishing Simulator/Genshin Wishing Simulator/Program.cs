using System;
using System.Collections.Generic;

namespace Genshin_Wishing_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             
              GENSHIN IMPACT WISH SIMULATOR BY EYRON 
              
              Item Probabilites Explanation (PURELY BASED ON MY PERCEPTION):-
              Probablity of getting a 4* Item:
              - Every 10 pulls, you get a 4* item AKA 4* pity
              - The chance of getting a 4* item is 1%
              - If you pull more than 5 times, its increased by 5%
              - The chance resets if you hit every 4* pity
              
              Probablity of getting a 5* Item:
              - Every 90 pulls, you get a 5* item AKA 5* pity
              - The chance of getting a 5* item is 0.6%
              - If you reach around 75 pulls, 30% chance to get a 5* item
              - If you reach around 80 pulls, 50% chance to get a 5* item
              - The chance resets if you hit every 5* pity

             */

            // 3* ITEMS
            string[] threeStar = { "3* Fillet Blade", "3* Debate Club", "3* White Tassel", "3* Slingshot", "3* Magic Guide" };

            // 4* ITEMS
            string[] fourStar = { 
                // 4* Weapons
                "4* The Flute", "4* The Bell", "4* Dragon's Bane", "4* The Stringless", "4* The Widsth",

                // 4* Characters
                "4* Kaeya", "4* Amber", "4* Lisa", "4* Noelle", "4* Sucrose", "4* Barbara"
            };

            // 5* ITEMS
            string[] fiveStar = { 
                // 5* Weapons
                "5* Skyward Harp", "5* Wolf's Gravestone", "5* Jade Spear", "5* Aquila Favonia", "5* Lost Prayer",

                // 5* Characters
                "5* Keqing", "5* Mona", "5* Diluc", "5* Jean", "5* Qiqi"
            }; 

            // Tracking the amount of total pulls
            int totalPulls = 0;

            // Initialise RNG
            double rng = 0;

            // Tracking pity(s)
            int fourStarPity = 0;
            int fiveStarPity = 0;

            // Initialise probabilities
            double fourStarProb = 99;
            double fiveStarProb = 99.4;

            // Store history pulls
            List<String> historyPulls = new List<string>();
            int tenths = 9;

            Random rnd = new Random();

            // Endless Loop (warning: very dangerous, use it cautiously.)
            while (1 == 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Dark Yellow text
                Console.WriteLine("GENSHIN IMPACT: WISH SIMULATOR");
                Console.ForegroundColor = ConsoleColor.White; // White text
                Console.WriteLine("'0' - Wish History\n'1' - One Pull\n'10' - Ten Pull");

                // Total Pulls
                Console.WriteLine("Total Pulls: {0}", totalPulls);

                // User input
                int input;
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    // Single pull
                    case 1:
                        {
                            Console.WriteLine("---------------------");
                            for (int i = 0; i < input; i++)
                            {
                                // Calling Generate items Function
                                generateItems(rng, ref fourStarPity, ref fourStarProb, ref fiveStarPity, ref fiveStarProb, rnd, fourStar, fiveStar, threeStar, historyPulls);

                                // Increment counters
                                totalPulls++;
                                fourStarPity++;
                                fiveStarPity++;
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("---------------------");
                            break;
                        }

                    // Ten pull
                    case 10:
                        {
                            Console.WriteLine("---------------------");
                            for (int i = 0; i < input; i++)
                            {

                                // Calling Generate items Function
                                generateItems(rng, ref fourStarPity, ref fourStarProb, ref fiveStarPity, ref fiveStarProb, rnd, fourStar, fiveStar, threeStar, historyPulls);

                                // Increment counters
                                totalPulls++;
                                fourStarPity++;
                                fiveStarPity++;
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("---------------------");
                            break;
                        }

                    // History pulls
                    case 0:
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow; // Dark Yellow text
                            Console.WriteLine("WISH HISTORY");
                            Console.ForegroundColor = ConsoleColor.White; // White text
                            Console.WriteLine("---------------------");

                            // Display list of history pulls
                            for (int i = 0; i < historyPulls.Count; i++)
                            {
                                int a = i + 1;
                                Console.WriteLine("{0} - {1}", a, historyPulls[i]);
                               
                                // Print a line every 10 pulls
                                if (i == tenths)
                                {
                                    Console.WriteLine("---------------------");
                                    tenths += 10;
                                }
                            }
                            Console.WriteLine();
                            break;
                        }

                    // Check if user enters different input
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Unknown input");
                            Console.WriteLine();
                            break;
                        }
                }

                // Reset lines in History pulls
                if (historyPulls.Count > 8)
                {
                    tenths = 9;
                }

                // Continue
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        // RNG Function
        static double RNG(double i)
        {
            // RNG using double numbers
            Random rnd = new Random();
            double min = 0;
            double max = 100;
            double rng = rnd.NextDouble() * (max - min) + min;

            return rng;
        }

        // Item Generator Function
        static void generateItems(double rng, ref int fourStarPity, ref double fourStarProb, ref int fiveStarPity, ref double fiveStarProb, Random rnd, string[] fourStar, string[] fiveStar, string[] threeStar, List<string> historyPulls)
        {
            // Calling RNG function                               
            rng = RNG(rng);

            // Manipulate Probablites
            // if user pulls more than 5 times and didn't get 4*, the chance of getting a 4* is increased
            if (fourStarPity >= 4)
            {
                fourStarProb = 95; // 5% chance to get 4*
            }
            else
            {
                fourStarProb = 99;
            }
            // if user pulls more than 75 times didn't get 5*, the chance of getting a 5* is increased
            if (fiveStarPity >= 74)
            {
                fiveStarProb = 70; // 30% chance to get 5*
            }
            else if (fiveStarPity >= 79)
            {
                fiveStarProb = 50; // 50% chance to get 5*
            }
            else
            {
                fiveStarProb = 99.4;
            }

            // Generate 4* items
            if (rng > fourStarProb || fourStarPity >= 9)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                int rndWeapons = rnd.Next(fourStar.Length);
                Console.WriteLine(fourStar[rndWeapons]);

                // Store it to History pulls
                historyPulls.Add(fourStar[rndWeapons]);

                // Reset Pity
                fourStarPity = -1;
            }
            // Generate 5* Items
            else if (rng > fiveStarProb || fiveStarPity >= 89)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int rndWeapons = rnd.Next(fiveStar.Length);
                Console.WriteLine(fiveStar[rndWeapons]);

                // Store it to History pulls
                historyPulls.Add(fiveStar[rndWeapons]);

                // Reset Pity
                fiveStarPity = -1;
            }
            // Generate 3* Items
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                int rndWeapons = rnd.Next(threeStar.Length);
                Console.WriteLine(threeStar[rndWeapons]);

                // Store it to History pulls
                historyPulls.Add(threeStar[rndWeapons]);
            }
        }
    }
}
