using System;
using System.Collections.Generic;
using System.Text;

namespace IndexerSmallDemo
{
    class MyList
    {
        string s, t;

        // indexer (snippet available)
        public string this[bool index]
        {
            get
            {
                if (index)
                    return s;
                else
                    return t;
            }

            set
            {
                if (index)
                    s = value;
                else
                    t = value;
            }
        }
    }
}
