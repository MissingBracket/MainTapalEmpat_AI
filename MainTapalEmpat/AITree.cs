using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    public enum pawnType
    {
        SHEEP, TIGER
    }
    class AITree
    {
        private AITree_Node root;

        private pawnType pawntype;

        public AITree(pawnType pt)
        {
            this.pawntype = pt;
        }

        public AITree_Node getRoot() { return root; }

    }
}
