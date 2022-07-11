using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5.String
{
    public class Letters : IComparer<IGrouping<char, char>>
    {
        public int Compare(IGrouping<char, char>? x, IGrouping<char, char>? y)
        {
            if (x.Count() == y.Count()) 
            {
                if (x.Key == y.Key)
                    return 0;
                else if (x.Key < y.Key)
                    return 1;
                else
                    return -1;
            }

            else if (x.Count() > y.Count())
            {
                return 1;
            }

            else
            {
                return -1;
            }
        }
    }
}
