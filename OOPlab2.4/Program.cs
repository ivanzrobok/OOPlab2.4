using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPlab2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(2, 2);
            Matrix matrix1 = new Matrix(2, 2);
            string valueSwitch  = "";

            while(valueSwitch != "0")
            {
                Console.WriteLine("Введіть значення");
                Console.WriteLine("[1]Вввести значення");
                Console.WriteLine("[2]Вивести на дисплей 1-шу");
                Console.WriteLine("[3]Вивести на дисплей 2-шу");
                Console.WriteLine("[4]Нормаль матриці");
                Console.WriteLine("[5]Помножити матриці");

                valueSwitch = Console.ReadLine();
                switch (valueSwitch)
                {
                    case "1":
                        matrix.InputMatrix();
                        matrix1.InputMatrix();
                        break;
                    case "2":
                        matrix.DisplayMatrix();
                        break;
                    case "3":
                        matrix1.DisplayMatrix();
                        break;
                    case "4":
                        Console.WriteLine(matrix.NormaMatrix());
                        break;
                    case "5":
                        matrix *= matrix1;
                        matrix1.DisplayMatrix();
                        break;
                    default:
                        break;
                }
            }
           
        }
    }
}
