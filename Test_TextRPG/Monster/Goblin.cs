using Project_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Goblin : Monster
    {

        public Goblin()
        {
            name = "고블린";
            curHp = 15;
            maxHp = 15;
            ap = 5;
            dp = 1;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("####################");
            sb.AppendLine("#                  #");
            sb.AppendLine("#   (엄청난 고블린) #");
            sb.AppendLine("#  (고블고블고블린) #");
            sb.AppendLine("#                  #");
            sb.AppendLine("####################");
            image = sb.ToString();
        }

        private int moveTurn = 0;

        public override void MoveAction()
        {
               switch(moveTurn++)
                {
                    case 0:
                        TryMove(Direction.Left);
                        break;
                    case 1:
                        TryMove(Direction.Right);
                        break;
                    case 2:
                        TryMove(Direction.Right);
                        break;
                    case 3:
                        TryMove(Direction.Left);
                        break;
                }
            if (moveTurn == 4)
            {
                moveTurn = 0;
            }
            Position prevPos = pos;
        }
    }
}

