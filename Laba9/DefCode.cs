using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    public class DefCode
    {
        public List<Node> table = new List<Node>();
        public string text;
        public string TextCode;
        public double I;
        public double AvLen;
        public double minLen;
        public int maxLength;

        public void build(List<Node> tableParant, string text)
        {
            table.Clear();
            this.text = text;
            TextCode = "";

            for (int i = 0; i < tableParant.Count; i++)
                table.Add(new Node(tableParant[i].symbol, tableParant[i].count));

            maxLength = (int)Math.Ceiling(Math.Log(table.Count, 2));
            AvLen = maxLength;
            minLen = maxLength;

            I = 0;
            for (int i = 0; i < table.Count; i++)
            {
                I += (double)table[i].count / text.Length * Math.Log((double)table[i].count / text.Length, 2);

                //коды
                int curLength;
                if (i < 2) curLength = 1;
                else
                {
                    curLength = (int)Math.Floor(Math.Log(i, 2));
                    curLength++;
                }

                for (int ii = curLength; ii < maxLength; ii++) table[i].code.Add(0); //add zero for uniform code

                List<int> buf = new List<int>();
                int temp = i;
                while(temp > 0)
                {
                    buf.Add(temp % 2);
                    temp /= 2;
                }
                if(i == 0) table[i].code.Add(0);

                for (int j = buf.Count - 1; j >= 0; j--) table[i].code.Add(buf[j]);
            }
            I *= -1;

            for(int i = 0; i < text.Length; i++)
                for(int j = 0; j < table.Count; j++)
                    if(table[j].symbol == text[i])
                        for (int c = 0; c < table[j].code.Count; c++) TextCode += table[j].code[c].ToString();
        }
    }
}
