using Project_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project_TextRPG
{
    public class Potal 
    {
        protected Game game;
        public string image;
        public char icon = '♨';
        public Position pos;

        public Potal()
        {
            StringBuilder sb = new StringBuilder();
            image = sb.ToString();
        }

            public void MoveDon()
        {
            game.Donjon();
        }
        
    }
}
