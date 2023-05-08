using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Village_chief : NPC
    {
        public Village_chief()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("####################");
            sb.AppendLine("#                  #");
            sb.AppendLine("#  (    촌장    )  #");
            sb.AppendLine("#  (텍스트 이미지)  #");
            sb.AppendLine("#                  #");
            sb.AppendLine("####################");
            image = sb.ToString();
        }

        public override void Interaction()
        {
            throw new NotImplementedException();
        }
    }
}
