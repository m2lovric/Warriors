using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fight_game
{
    public class Player
    {
        public int health = 500;
        Weapon1 sword = new Weapon1();
        Weapon2 knife = new Weapon2();

        public int sword_att (int health)
        {
            return health - sword.hlt_reduce;
        }

        public int sword_dmg (int health)
        {
            return health - sword.att_damage;
        }

        public int knife_att(int health)
        {
            return health - knife.hlt_reduce;
        }

        public int knife_dmg(int health)
        {
            return health - knife.att_damage;
        }
    }

    public class Ai_opponent : Player
    {
    }

    public class Weapon1
    {
        public int att_damage = 30;
        public int hlt_reduce = 50;
    }

    public class Weapon2
    {
        public int att_damage = 10;
        public int hlt_reduce = 20;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            Ai_opponent opponent1 = new Ai_opponent();
            Console.WriteLine("Start game : press 1");
            int start = int.Parse(Console.ReadLine());
            if ( start == 1)
            {
                Console.WriteLine("...WARRIORS...");
                Console.WriteLine($"Player stats: \nHealth : {player1.health}\n");
                Console.WriteLine($"Opponent stats: \nHealth : {opponent1.health}\n");
                int player_health = player1.health;
                int opp_health = opponent1.health;
                while( player_health > 0 || opp_health > 0)
                {
                    Console.WriteLine("It's your turn.\n");
                    Console.WriteLine("Choose a weapon : \n{0}Sword : \nAttack damage = 3 \nHealth Reduce = 5");
                    Console.WriteLine("\n{1}Knife : \nAttack damage = 1 \nHealth Reduce = 2\n");
                    int choose = int.Parse(Console.ReadLine());
                    switch (choose)
                    {
                        case 0:
                            player_health = player1.sword_att(player_health);
                            opp_health = player1.sword_dmg(opp_health);
                            Console.WriteLine($"Player health : {player_health}");
                            Console.WriteLine($"Opponent health : {opp_health}");
                            break;

                        case 1:
                            player_health = player1.knife_att(player_health);
                            opp_health = player1.knife_dmg(opp_health);
                            Console.WriteLine($"Player health : {player_health}");
                            Console.WriteLine($"Opponent health : {opp_health}");
                            break;                   
                    }
                    Console.WriteLine("\nIt's opponent turn.\n");
                    Random random_n = new Random();
                    if (random_n.Next(0,2) == 0)
                    {
                        opp_health = opponent1.sword_att(opp_health);
                        player_health = opponent1.sword_dmg(player_health);
                        Console.WriteLine($"Player health : {player_health}");
                        Console.WriteLine($"Opponent health : {opp_health}");
                    }
                    else
                    {
                        opp_health = opponent1.knife_att(opp_health);
                        player_health = opponent1.knife_dmg(player_health);
                        Console.WriteLine($"Player health : {player_health}");
                        Console.WriteLine($"Opponent health : {opp_health}");
                    }
                    if (player_health <= 0)
                    {
                        Console.WriteLine("OPPONENT WIN.");
                        break;
                    }
                    else if (opp_health <= 0)
                    {
                        Console.WriteLine("PLAYER WIN.");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                    /*Console.WriteLine("If you want exit game press 1 . ");
                    int press = int.Parse(Console.ReadLine());
                    if (press == 1)
                    {
                        Environment.Exit(0);
                    }*/
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
