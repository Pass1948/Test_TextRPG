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

            Console.SetCursorPosition(0, Data_Twon.map.GetLength(0) + 1);
        }
        private void PrintMap()
        {
            StringBuilder sb = new StringBuilder();
            Console.ForegroundColor = ConsoleColor.White;
            for (int y = 0; y < Data_Twon.map.GetLength(0); y++)
            {
                for (int x = 0; x < Data_Twon.map.GetLength(1); x++)
                {
                    if (Data_Twon.map[y, x])
                        sb.Append('　');
                    else
                        sb.Append('▩');
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Data_Twon.player.pos.x * 2, Data_Twon.player.pos.y);
            Console.Write(Data_Twon.player.icon);
        }

        private void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            (int left, int top) pos = Console.GetCursorPosition();
            Console.SetCursorPosition(Data_Twon.map.GetLength(1) * 2 + 3, 1);
            Console.Write("메뉴 : Q");
            Console.SetCursorPosition(Data_Twon.map.GetLength(1) * 2 + 3, 3);
            Console.Write("이동 : 방향키");
            Console.SetCursorPosition(Data_Twon.map.GetLength(1) * 2 + 3, 4);
            Console.Write("인벤토리 : I");
        }

        private void PrintInfo()
        {
            Console.SetCursorPosition(0, Data_Twon.map.GetLength(0) + 1);
            Console.Write($"HP : {Data_Twon.player.CurHp,3}/{Data_Twon.player.MaxHp,3}\t");
            Console.Write($"EXP : {Data_Twon.player.CurExp,3}/{Data_Twon.player.MaxExp,3}");
        }

        public override void Update()
        {

        }
    }
}
