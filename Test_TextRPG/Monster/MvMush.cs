using Project_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Test_TextRPG
{
    
    public class MvMush : Monster
    {
        public MvMush()
        {
            name = "머쉬레인보우";
            curHp = 5;
            maxHp = 5;
            ap = 0;
            dp = 5;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("####################");
            sb.AppendLine("#                  #");
            sb.AppendLine("#   (무지개 버섯)   #");
            sb.AppendLine("#  (버섯버섯버섯링) #");
            sb.AppendLine("#                  #");
            sb.AppendLine("####################");
            image = sb.ToString();
        }


        
        public Random random = new Random();
        private int moveTurn = 0;
        public override void MoveAction()
        {
            switch (moveTurn++)
            {
                case 1:
                    TryMove2();
                    break;
                case 3:
                    TryMove2();
                    break;
            }
            if (moveTurn == 4)
            {
                moveTurn = 0;
            }
        }
        protected void TryMove2()
        {
            int rand = random.Next(0, 8);
            Position prevPos = pos;
            while (true)
            {
                switch (rand)
                {
                    case 0:         // 위
                        pos.y--;
                        break;
                    case 1:         // 아래
                        pos.y++;
                        break;
                    case 2:         // 왼쪽
                        pos.x--;
                        break;
                    case 3:         // 오른쪽
                        pos.x++;
                        break;
                    case 4:         // 왼쪽 위 대각
                        pos.y--;
                        pos.x--;
                        break;
                    case 5:         // 오른쪽 위 대각
                        pos.y--;
                        pos.x++;
                        break;
                    case 6:         // 왼쪽 아래 대각
                        pos.y++;
                        pos.x--;
                        break;
                    case 7:
                        pos.y++;    // 오른쪽 아래 대각
                        pos.x++;
                        break;
                }
                if (Data_Don.map[pos.y, pos.x])
                {
                    break;
                }
                else if (!Data_Don.IsObjectInPos(pos))
                {
                    break;
                }
                else
                {
                    pos = prevPos;
                }
            }
        }
    }
}
