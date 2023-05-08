using Project_TextRPG;
using System.Text;

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
            icon = '▲';

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
            int randx = random.Next(1, 6);
            int randy = random.Next(10, 15);
            switch (moveTurn++)
            {
                case 1:
                    TryMove2();
                    pos = new Position(randx, randy);
                    break;
                case 4:
                    TryMove2();
                    pos = new Position(randx, randy);
                    break;
            }
            if (moveTurn == 5)
            {
                moveTurn = 0;
            }
        }
        protected void TryMove2()
        {
            Position prevPos = pos;
           
            if (!Data_Don.map[pos.y, pos.x])
            {
                pos = prevPos;
            }
            else if (Data_Don.IsObjectInPos(pos))
            {
                pos = prevPos;
            }
        }
    }
}
