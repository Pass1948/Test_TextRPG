using Project_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project_TextRPG
{
    public class Warp
    {
        private DonjonScene donjonScene;
        private void Init()
        {

            Data_Don.Init();
            donjonScene = new DonjonScene(this);
            
        }
        public void Donjon()
        {
            scene = donjonScene;
        }
    }
}
