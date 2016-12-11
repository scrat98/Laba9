using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Laba9
{
    public class Huffman
    {
        class Comparer : IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                return x.count - y.count;
            }
        }

        const string dotName = "huffman.dot";
        const string imgName = "huffman.png";

        public string codeText;
        public double avLen;
        public double minLen;
        public double H;

        bool img;
        string text;
        List<Node> trees = new List<Node>();
        StreamWriter file;
        public List<Node> table = new List<Node>(); //table of symbols
        int curNode; //need for nodeName Node1, Node2 etc.
        string path = AppDomain.CurrentDomain.BaseDirectory; //cur dir

        public void build(string text, bool img = false)
        {
            this.img = img;
            this.text = text;
            makeTree();

            Node root = trees[0];
            makeTable(root, new List<int>());
            if (table.Count == 1) table[0].code.Add(0);//на случай одного элемента
            table.Sort(new Comparer());

            makeCodeText();
            codeLen();

            file = new StreamWriter(path + dotName);
            file.Write("digraph G {\r\n graph [ranksep=0];\r\r\n\n");
            makeDotFile(root);
            file.Write("}");
            file.Close();

            makeImage();
        }

        public void makeTree()
        {
            Dictionary<char, int> def = new Dictionary<char, int>();
            trees.Clear();
            table.Clear();
            curNode = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (!def.ContainsKey(text[i])) def.Add(text[i], 0);
                def[text[i]]++;
            }

            foreach (var key in def.Keys)
            {
                trees.Add(new Node(key, def[key], "Node" + curNode.ToString(), true));
                curNode++;
            }

            while (trees.Count > 1)
            {
                trees.Sort(new Comparer());

                Node left = trees[0];
                trees.RemoveAt(0);

                Node right = trees[0];
                trees.RemoveAt(0);

                trees.Add(new Node(left, right, "Node" + curNode.ToString(), false));
                curNode++;
            }
        }

        public void makeTable(Node root, List<int> code) 
        {
            if (root.left != null)
            {
                code.Add(0);
                makeTable(root.left, code);
            }

            if (root.right != null)
            {
                code.Add(1);
                makeTable(root.right, code);
            }

            if (root.isSymbol)
            {
                for (int i = 0; i < code.Count; i++)
                    root.code.Add(code[i]);
                table.Add(root);
            }

            if (code.Count != 0) code.RemoveAt(code.Count - 1);
        }

        public void writeNode(Node node)
        {
            file.Write("{");
            if (node.isSymbol)
            {
                file.Write(node.nameNode + " [shape = record, label = \"{{");

                if (!img) file.Write(node.symbol);
                else file.Write((int)node.symbol);

                file.Write("|");
                file.Write(node.count);
                file.Write("}|");
                node.code.ForEach(i => file.Write(i));
                file.Write("}\"]");
            }
            else
            {
                file.Write(node.nameNode + " [label=");
                file.Write(node.count);
                file.Write("];");
            }
            file.Write("}");
        }

        public void makeDotFile(Node root)
        {
            if(trees.Count == 1 && trees[0].isSymbol)
            {
                writeNode(trees[0]);
            }

            if (root.left != null)
            {
                writeNode(root);
                file.Write(" -> ");
                writeNode(root.left);
                file.WriteLine(" [label = 0];");
            }

            if (root.right != null)
            {
                writeNode(root);
                file.Write(" -> ");
                writeNode(root.right);
                file.WriteLine(" [label = 1];");
            }

            if (root.left != null || root.right != null) file.WriteLine();

            if (root.left != null) makeDotFile(root.left);
            if (root.right != null) makeDotFile(root.right);
        }

        public void makeImage()
        {
            Process p = new Process();
            p.StartInfo.WorkingDirectory = path;
            p.StartInfo.FileName = path + "GraphViz\\release\\bin\\dot.exe";
            p.StartInfo.Arguments = "-Tpng " + dotName + " -o " + imgName;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            while (!p.HasExited);
            p.Close();
        }

        public void makeCodeText()
        {
            codeText = "";
            for (int i = 0; i < text.Length; i++)
                for (int j = 0; j < table.Count; j++)
                    if (table[j].symbol == text[i])
                        for (int c = 0; c < table[j].code.Count; c++) codeText += table[j].code[c].ToString();
        }

        public void codeLen()
        {
            avLen = 0;
            minLen = 999999;
            H = 0;
            for (int i = 0; i < table.Count; i++)
            {
                H += (double)table[i].count / text.Length * Math.Log((double)table[i].count / text.Length, 2);

                avLen += (double)table[i].count / text.Length * table[i].code.Count;
                minLen = Math.Min(table[i].code.Count, minLen);
            }
            H *= -1;
        }
    }
}
