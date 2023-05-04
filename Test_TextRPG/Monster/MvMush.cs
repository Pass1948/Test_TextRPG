using Project_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
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

        
        private Random random = new Random();
        private int moveTurn = 0;
        public override void MoveAction()
        {

            
            //
            do
            {
                int x = random.Next(0, 5);
                int y = random.Next(0, 5);

               

            } while (!Data.map[pos.y, pos.x] && Data.IsObjectInPos(pos)) ; 

        }
    }
}
