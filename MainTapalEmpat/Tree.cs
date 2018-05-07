using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class Tree
    {
        public Tree_Node root;
        private int level;

        public Tree(int x)
        {
            this.level = 1;
            root = new Tree_Node(x);
        }

        public void traverse(Tree_Node begin)
        {
            Console.WriteLine("value : " + begin.val);
            foreach (Tree_Node tn in begin.children)
            {
                traverse(tn);
            }
        }
        //  To be yet implemented better
        //  requires parameters with moves to be added to each node
        //  Should be recursive and remove elements as it goes
        //  Or not
        Operacje op;
        public void insertMoves(Tree_Node begin, Plansza nowa)
        {
            op = new Operacje();
            if (!(begin.children.Count == 0))// if we are at the final node
                for (int i = 0; i < op.tabRu.Count; i++)
                {
                    // begin.add(255);
                    //generujruchy
                    op.generujMozliweRuchyWilkow(2, nowa.zmien(nowa, op.tabRu.ElementAt(i)));
                    begin.add(12, op.tabRu);
                    //begin.add(0, wszystkieRuchy.ElementAt(0).ElementAt(i));
                }
            //List<List<List<Ruch>>> temp = wszystkieRuchy;
            //temp.RemoveAt(0;
            int current = 0;
            foreach (Tree_Node tn in begin.children)
            {
                op.generujMozliweRuchyWilkow(2, nowa);
                tn.ruchy = op.tabRu;
                Plansza temp = nowa.zmien(nowa, op.tabRu.ElementAt(current));
                if(current < op.tabRu.Count)
                    current++;
                insertMoves(tn, temp);
            }
        }

        public void addToLevel(int x)
        {
            this.root.add(x);
        }
        public void addNewLevel(int x)
        {
            Tree_Node cursor = root;
            //  while node has children
            while (!(cursor.children.Count == 0))
            {
                cursor = cursor.children[0];
            }
            //  now we found leftmost (!!!) empty node
            cursor.add(x);
        }

        public int getLevel()
        {
            return this.level;
        }

        public void addMovesToLevel(Tree_Node node, List<int> values)
        {
            foreach (int x in values)
                node.add(x);
        }
    }
}
