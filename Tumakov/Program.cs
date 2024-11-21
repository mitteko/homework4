using System;
using System.Diagnostics.Eventing.Reader;


namespace Tumakov
{
    internal class Program
    {

        //1
        // Написать метод, возвращающий наибольшее из двух чисел. Входные параметры метода – два целых числа.Протестировать метод.

        static int Maximus(int a, int b)
        {
            return a > b ? a : b;
        }


        //2
        //Написать метод, который меняет местами значения двух передаваемых параметров.Параметры передавать по ссылке. Протестировать метод.

        static void Exchange(ref string a, ref string b)
        {
            string kopia = a;
            a = b;
            b = kopia;
        }

        //3
        /// Написать метод вычисления факториала числа, результат вычислений передавать в выходном параметре. 

        static bool Fact(int n, out long res)
        {
            res = 1;
            try
            {
                checked
                {
                    for (int i = 1; i <= n; i++)
                    {
                        res *= i;
                    }
                }
                return true;
            }
            catch (OverflowException)
            {
                return false;
            }
        }


        //4
        //Написать рекурсивный метод вычисления факториала числа.

        static long Recursion_Fact(int n)
        {
            if (n == 0) return 1;
            return n * Recursion_Fact(n - 1);
        }


        //5.1
        //Написать метод, который вычисляет НОД двух натуральных чисел (алгоритм Евклида). Написать метод с тем же именем, который вычисляет НОД трех натуральных чисел.

        static int NOD(int a, int b)
        {
            int res = b;
            while (!(a % b == 0))
            {
                res = a % b;
                int tes = a;
                a = b;
                b = tes % b;
            }

            return res;
        }

        static int NOD(int a, int b, int c)
        {
            return NOD(NOD(a, b), c);
        }

        //5.2
        ///Написать рекурсивный метод, вычисляющий значение n-го числа ряда Фибоначчи. 
        /// Написать рекурсивный метод, вычисляющий значение n-го числа ряда Фибоначчи.
        /// Ряд Фибоначчи – последовательность натуральных чисел 1, 1, 2, 3, 5, 8, 13...  
        /// Написать рекурсивный метод, вычисляющий значение n-го числа ряда Фибоначчи. Для таких чисел верно соотношение Fk = Fk - 1 + Fk - 2

        static long Fibonacci(int n)
        {
            if (n <= 1) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }



        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task51();
            Task52();
        }

        //1
        static void Task1()
        {
            Console.WriteLine("1)");
            Console.WriteLine("Написать метод, возвращающий наибольшее из двух чисел");

            Console.Write("Введите число 1: ");
            bool anum = int.TryParse(Console.ReadLine(), out int a);
            Console.Write("Введите число 2: ");
            bool bnum = int.TryParse(Console.ReadLine(), out int b);
            if (anum && bnum)
            {
                Console.WriteLine("Наибольшее из чисел {0} и {1}, это {2}", a, b, Maximus(a, b));
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
        }

        //2
        static void Task2()
        {
            Console.WriteLine("2)");
            Console.WriteLine("Написать метод, который меняет местами значения двух передаваемых параметров");
            
            Console.Write("Введите значение a: ");
            string a= Console.ReadLine();
            Console.Write("Введите значение b: ");
            string b= Console.ReadLine();
            Exchange(ref a, ref b);
            Console.WriteLine("a = {0}, b = {1}", a, b);
        }

        //3
        static void Task3()
        {
            Console.WriteLine("3)");
            Console.WriteLine("Написать метод вычисления факториала числа");

            Console.Write("Введите число, факториал которого хотите вычислить:");
            int number = int.Parse(Console.ReadLine());
            if (Fact(number, out long res))
                Console.WriteLine($"Факториал числа {number} = {res}");
            else
                Console.WriteLine("Произошло переполнение при вычислении факториала.");
        }

        //4
        static void Task4()
        {
            Console.WriteLine("4)");
            Console.WriteLine("Написать рекурсивный метод вычисления факториала числа");

            Console.Write("Введите число, факториал которого хотите вычислить:");
            int num = int.Parse(Console.ReadLine());
            long recursion_factorial = Recursion_Fact(num);

            Console.WriteLine($"Факториал числа {num} = {recursion_factorial}");

        }

        //5.1
        static void Task51()
        {
            Console.WriteLine("5.1)");
            Console.WriteLine("Написать метод вычисления факториала числа");

            Console.Write("Введите число 1:");
            bool isone = int.TryParse(Console.ReadLine(), out int one);
            Console.Write("Введите число 2:");
            bool istwo = int.TryParse(Console.ReadLine(), out int two);

            if (isone && istwo)
            {
                if (one > two)
                {
                    Console.WriteLine("НОД этих чисел = {0}", NOD(one, two));
                }
                else
                {
                    Console.WriteLine("НОД этих чисел = {0}", NOD(one, two));
                }
            }
            else
            {
                Console.WriteLine("Некорректные данные");
            }
            
            
            // нод для трех чисел

            Console.Write("Введите первое число:");
            bool isthree = int.TryParse(Console.ReadLine(), out int three);
            Console.Write("Введите второе число:");
            bool isfour = int.TryParse(Console.ReadLine(), out int four);
            Console.Write("Введите третье число:");
            bool isfive = int.TryParse(Console.ReadLine(), out int five);

            if (isthree && isfour && isfive)
            {
                int[] ints = { three, four, five };
                Array.Sort(ints);  //способ сортировки массивов
                Console.WriteLine("НОД этих чисел = {0}", NOD(ints[0], ints[1], ints[2]));
            }
            else
            {
                Console.WriteLine("Некорректные данные");
            }
        }

        
        //5.2
        static void Task52()
        {
            Console.WriteLine("5.2)");
            Console.WriteLine("Написать метод вычисления факториала числа");

            Console.Write("Введите номер числа Фибоначчи: ");
            bool num = int.TryParse(Console.ReadLine(), out int n);
            if (num)
            {
                long fibonnaci_num = Fibonacci(n);
                Console.WriteLine($"{n} число ряда Фибоначчи = {fibonnaci_num}");
            }
            else
            {
                Console.WriteLine("Некорректные данные");
            }
            Console.ReadKey();
        }
    }
}
