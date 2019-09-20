using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.IO;

namespace Consoleapplication1
{
    public class Program
    {
        //产生随机运算式
        public static void Create()
        {
            Console.WriteLine("请输入输出的题目个数：");
            int n = int.Parse(Console.ReadLine());
            Random random = new Random();//产生随机数
            for (int i = 0; i < n; i++)
            {
                char[] Operators = new char[] { '+', '-', '*', '/' };
                int amount = random.Next(3, 5);//产生运算数的个数，这里不懂为什么是3，5而不是3，4
                int[] numbers = new int[amount];
                char[] Operator = new char[amount];
                for (int j = 0; j < amount; j++)
                {
                    int number = random.Next(1, 100);
                    numbers[j] = number;//运算数的赋值过程
                }
                for (int j = 0; j < amount; j++)
                {
                    int st = random.Next(4);
                    Operator[j] = Operators[st];//操作符
                }
                string arr = "";
                for (int t = 0; t < numbers.Length; t++)
                {
                    arr += numbers[t].ToString() + Operator[t].ToString();
                }
                Fraction(Operator, numbers);
                arr = arr.Substring(0, arr.Length - 1);
                float result = CalcByDataTable(arr);//计算的值
                arr = arr + "=" + result.ToString();
                if (arr.Contains('.'))
                {
                    i--;
                }
                else newlisi.Add(arr);//将生成的题目连接

                Write(newlisi);//写入文件
            }
        }
        //判断除号的个数，保证可以除尽
        public static int[] Fraction(char[] Operator, int[] numbers)
        {
            int j = 0;
            for (int i = 0; i < Operator.Length - 1; i++)
            {
                if (Operator[i] == '/')
                    j++;
            }
            switch (j)
            {
                case 0:
                    break;
                case 1:
                    for (int m = 0; m < Operator.Length; m++)
                    {
                        if (Operator[m] == '/' && m < Operator.Length - 1)
                        {
                            numbers[m + 1] = Judge(numbers[m], numbers[m + 1]);
                        }
                    }
                    break;
                default:
                    break;
            }
            return numbers;
        }
        //检验是否含有分数，若有则改变除数
        public static int Judge(int a, int b)
        {
            if (a % b != 0 && a == 1)
            {
                b = 1;
            }
            if (a % b != 0 && a != 1)
            {
                for (int x = 2; x <= a; x++)
                    if (a % x == 0)
                    {
                        b = x;
                    }
            }
            return b;
        }
        //利用datatable计算字符串的值
        public static float CalcByDataTable(string expression)
        {
            object result = new DataTable().Compute(expression, "");
            return float.Parse(result + "");
        }
        //写入文件
        public static void Write(ArrayList a)
        {
            FileStream sd = File.Open(@"E:\计算题.txt", FileMode.Create);
            StreamWriter rf = new StreamWriter(sd);
            foreach (string s in a)
            {
                rf.WriteLine(s);
            }
            Console.WriteLine("写入计算题.txt成功！");
            rf.Close();
        }
        public static int JudgePoint(string arr, int i, float result)
        {
            arr = arr + "=" + result.ToString();
            if (arr.Contains('.'))
            {
                i--;//重新生成一道题
            }
            else newlisi.Add(arr);
            Write(newlisi);//写入文件
            return i;
        }
        public static ArrayList newlisi = new ArrayList();
        static void Main(string[] args)
        {
            Create();
        }
    }

}