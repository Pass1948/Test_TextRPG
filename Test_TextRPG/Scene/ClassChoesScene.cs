using Project_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
enum ClassType
{
    None = 0,
    Novice = 1,
    Warrior = 2,
    Archer = 3,
}
namespace Project_TextRPG
{
    public class ClassChoesScene : Scene
    {

        public ClassChoesScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("직업을 선택해주세요");
            sb.AppendLine("1. 노비스");
            sb.AppendLine("2. 전사");
            sb.AppendLine("3. 궁수");
            sb.AppendLine("당신의 선택 : ");

            Console.Write(sb.ToString());
        }
        
        public override void Update()
        {
            string input = Console.ReadLine();

            int index;
            if (!int.TryParse(input, out index))
            {
                Console.WriteLine("잘못 입력 하셨습니다.");
                Thread.Sleep(1000);
                return;
            }

            switch (index)
            {
                case (int)ClassType.Novice:
                    ChoseNovice();
                    break;
                case (int)ClassType.Warrior:
                    ChoseWarrior();
                    break;
                case (int)ClassType.Archer:
                    ChoseArcher();
                    break;
                default:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }
       
        public void ChoseNovice(string text = "")
        {
            Console.Clear();
            Data.player = new Novice();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine();

            sb.AppendLine();
            sb.AppendLine("Puss the Any Key");
            sb.Append(text);

            Console.WriteLine(sb.ToString());

            string input = Console.ReadLine();
            switch (input)
            {
                case string:
                    game.GameStart();
                    break;
            }
        }
        public void ChoseWarrior(string text = "")
        {
            Console.Clear();
            Data.player = new Warrior();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine();

            sb.AppendLine();
            sb.AppendLine("Puss the Any Key");
            sb.Append(text);

            Console.WriteLine(sb.ToString());

            string input = Console.ReadLine();
            switch (input)
            {
                case string:
                    game.GameStart();
                    break;
            }
        }
        public void ChoseArcher(string text = "")
        {
            Console.Clear();
            Data.player = new Archer();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine();

            sb.AppendLine();
            sb.AppendLine("Puss the Any Key");
            sb.Append(text);

            Console.ReadLine();
            Console.WriteLine(sb.ToString());

            string input = Console.ReadLine();
            switch (input)
            {
                case string:
                    game.GameStart();
                    break;
            }
        }
    }
}
