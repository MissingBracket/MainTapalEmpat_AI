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
        public void insertMoves(Tree_Node begin)
        {
            if (!(begin.children.Count == 0))// if we are at the final node
                for (int i = 0; i < 3; i++)
                {
                    begin.add(255);
                }

            foreach (Tree_Node tn in begin.children)
            {
                insertMoves(tn);
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
