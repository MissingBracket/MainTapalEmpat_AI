using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class AITree_Node
    {
        //  Value of action
        private int score = 0;
        private List<AITree_Node> children;

        public AITree_Node(int val)
        {
            this.score = val;
        }
    }
}
