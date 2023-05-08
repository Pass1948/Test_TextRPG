using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    // 던전맵과 마을맵 분리 구현(목표)
    // 상점, 대장간 등 이용시설 구현 (목표)
    // 
    public class DonjonScene : Scene
    {
        public DonjonScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            PrintMap();
            PrintMenu();
            PrintInfo();

            Console.SetCursorPosition(0, Data_Don.map.GetLength(0) + 1);
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

            // 시스템 키 입력시 씬 전환
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

            // 플레이어 이동
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    Data_Don.player.TryMove(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data_Don.player.TryMove(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data_Don.player.TryMove(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data_Don.player.TryMove(Direction.Right);
                    break;
            }

            // 아이템 습득
            Item item = Data_Don.ItemInPos(Data_Don.player.pos);
            if (item != null)
            {
                Data_Don.player.GetItem(item);
                Data_Don.items.Remove(item);
            }

            // 몬스터 전투
            Monster monster = Data_Don.MonsterInPos(Data_Don.player.pos);
            if (monster != null)
            {
                game.Battle(monster);
                return;
            }

            // 몬스터 이동
            foreach (Monster m in Data_Don.monsters)
            {
                m.MoveAction();
                if (m.pos.x == Data_Don.player.pos.x &&
                    m.pos.y == Data_Don.player.pos.y)
                {
                    game.Battle(m);
                    return;
                }
            }
        }

        public void GenerateMap()
        {
            Data_Don.LoadLevel1();
        }

        private void PrintMap()
        {
            StringBuilder sb = new StringBuilder();
            Console.ForegroundColor = ConsoleColor.White;
            for (int y = 0; y < Data_Don.map.GetLength(0); y++)
            {
                for (int x = 0; x < Data_Don.map.GetLength(1); x++)
                {
                    if (Data_Don.map[y, x])
                        sb.Append('　');
                    else
                        sb.Append('▩');
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());

            foreach (Monster monster in  Data_Don.monsters)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(monster.pos.x*2, monster.pos.y);
                Console.Write(monster.icon);
            }

            foreach (Item item in Data_Don.items)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(item.pos.x * 2, item.pos.y);
                Console.Write(item.icon);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Data_Don.player.pos.x * 2, Data_Don.player.pos.y);
            Console.Write(Data_Don.player.icon);
        }

        private void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            (int left, int top) pos = Console.GetCursorPosition();
            Console.SetCursorPosition(Data_Don.map.GetLength(1)*2 + 3, 1);
            Console.Write("메뉴 : Q");
            Console.SetCursorPosition(Data_Don.map.GetLength(1) * 2 + 3, 3);
            Console.Write("이동 : 방향키");
            Console.SetCursorPosition(Data_Don.map.GetLength(1) * 2 + 3, 4);
            Console.Write("인벤토리 : I");
        }

        private void PrintInfo()
        {
            Console.SetCursorPosition(0, Data_Don.map.GetLength(0) + 1);
            Console.Write($"HP : {Data_Don.player.CurHp,3}/{Data_Don.player.MaxHp,3}\t");
            Console.Write($"EXP : {Data_Don.player.CurExp,3}/{Data_Don.player.MaxExp,3}");
        }
    }
}
