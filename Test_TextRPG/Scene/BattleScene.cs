using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class BattleScene : Scene
    {
        private Monster monster;

        public BattleScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            Console.WriteLine();
            Console.WriteLine($"{monster.name}    {monster.curHp,3}/{monster.maxHp,3}");
            Console.WriteLine();
            Console.WriteLine(monster.image);
            Console.WriteLine();
            Console.WriteLine(Data_Don.player.image);
            Console.WriteLine();
            Console.WriteLine($"플레이어    {Data_Don.player.CurHp,3}/{Data_Don.player.MaxHp}");
            Console.WriteLine();
        }

        public override void Update()
        {
            for (int i = 0; i < Data_Don.player.skills.Count; i++)
            {
                Console.Write($"{i + 1,2}. {Data_Don.player.skills[i].name} ");
            }
            Console.WriteLine();
            Console.Write("명령을 입력하세요 : ");

            string input = Console.ReadLine();

            int index;
            if (!int.TryParse(input, out index))
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                return;
            }
            if (index < 1 || index > Data_Don.player.skills.Count)
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                return;
            }

            Data_Don.player.skills[index-1].action(monster);

            // 턴 결과
            if (monster.curHp <= 0)
            {
                game.Map();
                return;
            }

            // 몬스터 턴
            monster.Attack(Data_Don.player);

            // 턴 결과
            if (Data_Don.player.CurHp <= 0)
            {
                game.GameOver("몬스터에게 패배했습니다.");
                return;
            }
        }

        public void StartBattle(Monster monster)
        {
            this.monster = monster;
            Data_Don.monsters.Remove(monster);

            Console.Clear();
            Console.WriteLine($"{monster.name}(와/과) 전투 시작!");
            Thread.Sleep(1000);
        }

        public void EndBattle()
        {
            Console.Clear();
            Console.WriteLine("전투에서 승리했다!");

            Thread.Sleep(2000);
            game.Map();
        }
    }
}
