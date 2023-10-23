using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialWork
{
    public interface IPolynomial
    {
        int Size { get; set; }
        List<int> Coeff { get; set; }

        Polynomial Sum_Num(Polynomial p1, int a);
        Polynomial Sum_Pol(Polynomial p1, Polynomial p2);
        Polynomial Diff_Num(Polynomial p1, int a);
        Polynomial Diff_Pol(Polynomial p1, Polynomial p2);
        Polynomial Mul_Pol(Polynomial p1, Polynomial p2);

        int Calculate(Polynomial p1, int a);
        string ToString();
    }
}
