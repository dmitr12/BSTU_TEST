using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Testing_Lab3
{
    public class Triangle
    {
        public bool IsTriangle(float a, float b, float c)
        {
            if(a>0 && b>0 && c>0)
            {
                if (a + b > c && b + c > a && c + a > b)
                    return true;
            }
            return false;
        }
    }
}
