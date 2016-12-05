using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    public class Node
    {
        public int count;
        public bool isSymbol;
        public char symbol;
        public List<int> code;
        public string nameNode;

        public Node left;
        public Node right;

        public Node(char symbol, int count, string nameNode, bool isSymbol)
        {
            this.symbol = symbol;
            this.count = count;
            this.code = new List<int>();
            this.nameNode = nameNode;
            this.isSymbol = isSymbol;
        }

        public Node(Node left, Node right, string nameNode, bool isSymbol) //create parent
        {
            this.symbol = (char)0;
            this.left = left;
            this.right = right;
            this.count = left.count + right.count;
            this.code = new List<int>();
            this.nameNode = nameNode;
            this.isSymbol = isSymbol;
        }

        /// <summary>
        /// node for fano
        /// </summary>
        public int s;
        public int e;

        public Node(int s, int e, string nameNode)
        {
            this.s = s;
            this.e = e;
            this.code = new List<int>();
            this.nameNode = nameNode;
        }

        public Node(char symbol, int count)
        {
            this.symbol = symbol;
            this.count = count;
            this.code = new List<int>();
        }
    }
}
