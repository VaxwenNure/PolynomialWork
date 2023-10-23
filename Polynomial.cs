using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialWork
{
    public class Polynomial : IPolynomial
    {
        private int size;
        public int Size
        {
            get { return size; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Size must be a non-negative number");
                }
                size = value;
            }
        }
        private int[] coef;
        public int[] Coeff
        {
            get { return coef; }
            set
            {
                if (value.Length + 1 <= size)
                {
                    throw new ArgumentException("The number of coefficients must match the size of the array");
                }
                coef = value;
            }
        }

        List<int> IPolynomial.Coeff { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Polynomial(int size, int[] coef)
        {
            Size = size;
            Coeff = coef;
        }

        public Polynomial()
        {

        }

        int IPolynomial.Calculate(Polynomial p1, int a)
        {
            int i, res = 0;
            for (i = 0; i < p1.Coeff.Length; i++)
                res += (int)(p1.Coeff[i] * Math.Pow(a, i));

            return res;
        }

        Polynomial IPolynomial.Diff_Num(Polynomial p1, int a)
        {
            {
                Polynomial res = p1;
                res.Coeff[0] -= a;

                return res;
            }
        }

        Polynomial IPolynomial.Diff_Pol(Polynomial p1, Polynomial p2)
        {
            {

                int minN = Math.Min(p1.Size, p2.Size);

                Polynomial res = new Polynomial(p1.Coeff.Length, new int[] { 0, 0, 0 });

                for (int i = 0; i < minN; i++)
                    res.Coeff[i] = p1.Coeff[i] - p2.Coeff[i];
                return res;

            }
        }

        public bool Is_Not_Equal(Polynomial p1, Polynomial p2)
        {
            throw new NotImplementedException();
        }

        Polynomial IPolynomial.Mul_Pol(Polynomial p1, Polynomial p2)
        {
            Polynomial res = new Polynomial(p1.Size + p2.Size - 1, new int[] { 0, 0, 0, 0, 0 });

            for (int i = 0; i < p1.Size; i++)
                for (int j = 0; j < p2.Size; j++)
                    res.Coeff[i + j] += p1.Coeff[i] * p2.Coeff[j];

            return res;

        }

        Polynomial IPolynomial.Sum_Num(Polynomial p1, int a)
        {
            {
                Polynomial res = p1;
                res.Coeff[0] += a;

                return res;
            }
        }

        Polynomial IPolynomial.Sum_Pol(Polynomial p1, Polynomial p2)
        {
            int minN = Math.Min(p1.Size, p2.Size);
            Polynomial res = new Polynomial(p1.Coeff.Length, new int[] { 0, 0, 0 });
            for (int i = 0; i < p1.Size; i++)
                res.Coeff[i] = p1.Coeff[i] + p2.Coeff[i];

            return res;
        }



        public override string ToString()
        {
            string result = null;
            int dim = 0;
            foreach (double coef in Coeff)
            {
                result += coef.ToString() + "x^" + dim.ToString() + " + ";
                dim++;
            }
            result = result.Remove(result.Length - 3, 3);
            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is Polynomial p1 && p1.Size == Size && p1.Coeff.SequenceEqual(Coeff);
        }

        public override int GetHashCode()
        {
            int hashCode = -1837172754;
            hashCode = hashCode * -1521134295 + Size.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(Coeff);
            return hashCode;
        }




    }

}
