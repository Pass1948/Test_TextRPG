using Project_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class TwounSene : Scene
    {
        public TwounSene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            PrintMap();
            PrintMenu();
            PrintInfo();

            Console.SetCursorPosition(0, Data.map.GetLength(0) + 1);
        }

        public override void Update()
        {
            ConsoleKeyInfo input;

            while (true)
            {
                input = Console.ReadKey();

                if (input.Key == ConsoleKey.Q ||
                    input.Key == ConsoleKey.I ||
                    input.Key == ConsoleKey.UpArrow ||
                    input.Key == ConsoleKey.DownArrow ||
                    input.Key == ConsoleKey.LeftArrow ||
                    input.Key == ConsoleKey.RightArrow)
                {
                    break;
                }
            }
            if (input.Key == ConsoleKey.Q)
            {
                game.MainMenu();
                return;
            }
            else if (input.Key == ConsoleKey.I)
            {
                game.Inventory();
                return;
            }

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    Data.player.TryMove(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.player.TryMove(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data.player.TryMove(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.player.TryMove(Direction.Right);
                    break;
            }

            // 아이템 습득
            Item item = Data.ItemInPos(Data.player.pos);
            if (item != null)
            {
                Data.player.GetItem(item);
                Data.items.Remove(item);
            }

            // 포탈이동
            Potal potal = Data.PotalInPos(Data.player.pos);
            if (potal != null)
            {
                game.Donjon();
                return;
            }

            // 상점이용 구현

        }
        public void GenerateMap()
        {
            Data.LoadTwon();
        }
        private void PrintMap()
        {
            StringBuilder sb = new StringBuilder();
            Console.ForegroundColor = ConsoleColor.White;
            for (int y = 0; y < Data.map.GetLength(0); y++)
            {
                for (int x = 0; x < Data.map.GetLength(1); x++)
                {
                    if (Data.map[y, x])
                        sb.Append('　');
                    else
                        sb.Append('▩');
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());

            foreach (Potal potal in Data.potals)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(potal.pos.x * 2, potal.pos.y);
                Console.Write(potal.icon);
            }

            foreach (NPC npc in Data.npcs)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(npc.pos.x * 2, npc.pos.y);
                Console.Write(npc.icon);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Data.player.pos.x * 2, Data.player.pos.y);
            Console.Write(Data.player.icon);
        }

        private void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            (int left, int top) pos = Console.GetCursorPosition();
            Console.SetCursorPosition(Data.map.GetLength(1) * 2 + 3, 1);
            Console.Write("메뉴 : Q");
            Console.SetCursorPosition(Data.map.GetLength(1) * 2 + 3, 3);
            Console.Write("이동 : 방향키");
            Console.SetCursorPosition(Data.map.GetLength(1) * 2 + 3, 4);
            Console.Write("인벤토리 : I");
        }

        private void PrintInfo()
        {
            Console.SetCursorPosition(0, Data.map.GetLength(0) + 1);
            Console.Write($"HP : {Data.player.CurHp,3}/{Data.player.MaxHp,3}\t");
            Console.Write($"EXP : {Data.player.CurExp,3}/{Data.player.MaxExp,3}");
        }
    }
}
