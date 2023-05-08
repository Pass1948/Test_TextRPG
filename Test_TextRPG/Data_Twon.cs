using Project_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_TextRPG;

namespace Project_TextRPG
{
    public class Data_Twon
    {
        public static bool[,] map;
        public static Player player;
        public static List<Item> inventory;

        public static void Init()
        {
            player = new Player();
            inventory = new List<Item>();
            inventory.Add(new Potion());
            inventory.Add(new LargePotion());
        }

        public static void LoadLevel1()
        {
            map = new bool[,]
            {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            };

            player.pos = new Position(2, 2);

        }
    }
}
