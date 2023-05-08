using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_TextRPG;

namespace Project_TextRPG
{
    public static class Data
    {
        public static bool[,] map;
        public static Player player;
        public static List<NPC> npcs;
        public static List<Item> inventory;
        public static List<Monster> monsters;
        public static List<Item> items;
        public static List<Potal> potals;

        public static void Init()
        {
            player = new Player();

            inventory = new List<Item>();
            monsters = new List<Monster>();
            items = new List<Item>();
            potals = new List<Potal>();
            npcs = new List<NPC>();

            inventory.Add(new Potion());
            inventory.Add(new LargePotion());
        }

        public static bool IsObjectInPos(Position pos)
        {
            return MonsterInPos(pos) == null && ItemInPos(pos) == null && PotalInPos(pos) == null;
        }

        public static Monster MonsterInPos(Position pos)
        {
            foreach (Monster monster in monsters)
            {
                if (monster.pos.x == pos.x &&
                    monster.pos.y == pos.y)
                {
                    return monster;
                }
            }
            return null;
        }

        public static Item ItemInPos(Position pos)
        {
            foreach (Item item in items)
            {
                if (item.pos.x == pos.x &&
                    item.pos.y == pos.y)
                {
                    return item;
                }
            }
            return null;
        }

        public static Potal PotalInPos(Position pos)
        {
            foreach (Potal potal in potals)
            {
                if (potal.pos.x == pos.x &&
                    potal.pos.y == pos.y)
                {
                    return potal;
                }
            }
            return null;
        }

        public static void LoadLevel1()
        {
            map = new bool[,]
            {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false, false,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true, false, false, false, false,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            };

            player.pos = new Position(2, 2);

            monsters.Clear();
            items.Clear();
            potals.Clear();

            Slime slime1 = new Slime();
            slime1.pos = new Position(3, 5);
            monsters.Add(slime1);

            Slime slime2 = new Slime();
            slime2.pos = new Position(7, 5);
            monsters.Add(slime2);

            Goblin goblin = new Goblin();
            goblin.pos = new Position(9, 8);
            monsters.Add(goblin);

            Dragon dragon = new Dragon();
            dragon.pos = new Position(12, 12);
            monsters.Add(dragon);

            MvMush mvMush = new MvMush();
            mvMush.pos = new Position(3, 12);
            monsters.Add(mvMush);

            Item potion = new Potion();
            potion.pos = new Position(9, 2);
            items.Add(potion);

            Potal potal = new Potal();
            potal.pos = new Position(12, 2);
            potals.Add(potal);
        }
        public static void LoadTwon()
        {
            map = new bool[,]
           {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
           };

            player.pos = new Position(2, 2);

            Trader npc = new Trader();
            npc.pos = new Position(4, 1);
            npcs.Add(npc);

            Village_chief npc2 = new Village_chief();
            npc2.pos = new Position(8, 1);
            npcs.Add(npc2);

            Potal potal = new Potal();
            potal.pos = new Position(12, 2);
            potals.Add(potal);
        }
    }
}
