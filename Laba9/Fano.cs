using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Laba9
{
    public class Fano
    {
        class Comparer : IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                return y.count - x.count;
            }
        }

        const string dotName = "fano.dot";
        const string imgName = "fano.png";

        public string codeText;
        public double avLen;
        public double minLen;

        bool img;
        string text;
        Node tree; //our tree's root
        List<Node> defNodes = new List<Node>(); //def symblos 
        public List<Node> table = new List<Node>();
        int curNode; //need for nodeName Node1, Node2 etc.
        StreamWriter file;
        string path = AppDomain.CurrentDomain.BaseDirectory; //cur dir

        public void build(string text, bool img = false)
        {
            this.img = img;
            this.text = text;
            Init();
            makeTree(tree);
            table.Sort(new Comparer());

            makeCodeText();
            codeLen();

            file = new StreamWriter(path + dotName);
            file.Write("digraph G {\r\n graph [ranksep=0];\r\r\n\n");
            makeDot(tree);
            file.Write("}");
            file.Close();

            makeImage();
        }

        public void Init()
        {
            curNode = 0;
            table.Clear();
            defNodes.Clear();
            Dictionary<char, int> def = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!def.ContainsKey(text[i])) def.Add(text[i], 0);
                def[text[i]]++;
            }

            foreach (var key in def.Keys)
            {
                defNodes.Add(new Node(key, def[key]));
            }

            defNodes.Sort(new Comparer());
            tree = new Node(0, defNodes.Count - 1, "Node" + curNode.ToString());
            curNode++;
        }

        public void makeTree(Node cur)
        {
            if (tree.e != tree.s)
            {
                int sum = 0;
                for (int i = cur.s; i <= cur.e; i++)
                    sum += defNodes[i].count; //for avarage rezult

                cur.count = sum;

                int s = 0;
                int curPoz = cur.s;
                while (2 * (s + defNodes[curPoz].count) < sum && curPoz < cur.e)
                {
                    s += defNodes[curPoz].count;
                    curPoz++;
                }

                cur.left = new Node(cur.s, curPoz, "Node" + curNode.ToString());
                for (int i = 0; i < cur.code.Count; i++)
                    cur.left.code.Add(cur.code[i]);
                cur.left.code.Add(0);
                curNode++;

                cur.right = new Node(curPoz + 1, cur.e, "Node" + curNode.ToString());
                for (int i = 0; i < cur.code.Count; i++)
                    cur.right.code.Add(cur.code[i]);
                cur.right.code.Add(1);
                curNode++;

                if (cur.left.s != cur.left.e) makeTree(cur.left);
                else
                {
                    cur.left.count = defNodes[cur.left.s].count;
                    cur.left.nameNode = "Node" + curNode.ToString();
                    cur.left.symbol = defNodes[cur.left.s].symbol;
                    curNode++;
                    table.Add(cur.left);
                }

                if (cur.right.s != cur.right.e) makeTree(cur.right);
                else
                {
                    cur.right.count = defNodes[cur.right.s].count;
                    cur.right.nameNode = "Node" + curNode.ToString();
                    cur.right.symbol = defNodes[cur.right.s].symbol;
                    curNode++;
                    table.Add(cur.right);
                }
            }
            else
            {
                tree.code.Add(0);
                tree.symbol = defNodes[0].symbol;
                tree.count = defNodes[0].count;
                table.Add(cur);
            }
        }

        public void writeNode(Node node)
        {
            if (node.e != node.s)
            {
                file.Write("{" + node.nameNode);

                file.Write(" [shape = record, label = \"{");
                file.Write(node.count);
                file.Write("|");

                for (int i = node.s; i <= node.e; i++) //name
                    if (!img) file.Write(defNodes[i].symbol);
                        else file.Write((int)defNodes[i].symbol + " ");

                file.Write("}\"]}");
            }
            else
            {
                file.Write("{" + node.nameNode);

                file.Write(" [shape = record, label = \"{{");
                file.Write(node.count);
                file.Write("|");

                for (int i = node.s; i <= node.e; i++) //name
                    if (!img) file.Write(defNodes[i].symbol);
                        else file.Write((int)defNodes[i].symbol);

                file.Write("}|");

                node.code.ForEach(i => file.Write(i));
                file.Write("}\"]");
                file.Write("}");
            }
        }

        public void makeDot(Node root)
        {
            if (tree.s == tree.e)
                writeNode(root);

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

            if (root.left != null) makeDot(root.left);
            if (root.right != null) makeDot(root.right);
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
            while (!p.HasExited) ;
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
            for (int i = 0; i < table.Count; i++)
            {
                avLen += (double)table[i].count / text.Length * table[i].code.Count;
                minLen = Math.Min(table[i].code.Count, minLen);
            }
        }
    }
}
