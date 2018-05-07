using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class Tree_Node
    {
        public List<Tree_Node> children;
        public List<Ruch> ruchy;
        public int val;

        public Tree_Node(int x)
        {
            children = new List<Tree_Node>();
            this.val = x;
        }

        public void add(int x)
        {
            this.children.Add(new Tree_Node(x));
            this.children.Sort();
            this.ruchy = new List<Ruch>();
        }

        public void add(int x, List<Ruch> ruchy)
        {
            this.children.Add(new Tree_Node(x));
            this.children.Sort();
            this.ruchy = ruchy;
        }

        public void print()
        {
            Console.WriteLine(this.val);
            foreach (Tree_Node a in children)
            {
                Console.Write(a.val + " ");
            }
            Console.WriteLine();
        }
    }
}
