using System;
using static System.Console;

namespace P2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Operators binary, unary, ternary
            // Binary Operators
            int n1 = 4, n2 = 6;

            // Binary Operator needs 2 literals and 1 assignation
            WriteLine($"n1 + n2 {n1 + n2}");
            WriteLine($"n1 - n2 {n1 - n2}");
            WriteLine($"n1 / n2 {n1 / n2}");
            WriteLine($"n1 * n2 {n1 * n2}");
            WriteLine($"n1 % n2 {n1 % n2}");

            //Unary Operators
            WriteLine($"n1++ {n1++}");
            WriteLine($"n2-- {n2--}");
            WriteLine($"n1+=5 {n1 += 5}");
            WriteLine($"n1-=2 {n1 -= 2}");
            WriteLine($"n2*=7 {n2 *= 7}");
            WriteLine($"n1/=2 {n1 /= 2}");

            //Ternary Operators
            //expression ? return if true : return if false
            int res = n1 >= n2 ? n1++ : n2 = n1;
            #endregion

            #region Logical Operators

            //& Logic Operator
            //&& Comparator Operator
            bool a = true;
            bool b = false;

            WriteLine();
            WriteLine("AND a | b");
            WriteLine($"a {a & a,5} | {a & b,5}");
            WriteLine($"b {a & b,5} | {b & b,5}");
            WriteLine();

            WriteLine("OR a | b");
            WriteLine($"a {a | a,5} | {a | b,5}");
            WriteLine($"b {a | b,5} | {b | b,5}");
            WriteLine();

            WriteLine("XOR a | b");
            WriteLine($"a {a ^ a,5} | {a ^ b,5}");
            WriteLine($"b {a ^ b,5} | {b ^ b,5}");
            WriteLine();
            #endregion

            #region Comparator Operators
            WriteLine($"b && doStuff() {b && doStuff()}");
            WriteLine($"b & doStuff() {b & doStuff()}");
            WriteLine($"b | doStuff() {b | doStuff()}");
            WriteLine($"b || doStuff() {b || doStuff()}");
            #endregion

            #region Convertions
            //Implicit convertions are automatic and SAFE
            int n3 = 12;
            double d1 = n3;

            //Explicit convertions aka casting are NOT SAFE
            decimal d = 9.8M;
            int n4 = (int)d;
            WriteLine(n4);
            #endregion
        }

        static bool doStuff()
        {
            WriteLine("Doing Stuff");
            return true;
        }
    }
}

