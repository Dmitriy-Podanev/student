using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_задача_WF
{
    class LogicClass1
    {
        public string Method(string xZN, string num)
        {
            string res="";
            double x;
            int N;
            //res = "Введите переменную X:"+ Environment.NewLine;
            if(!double.TryParse(xZN, out x)||Math.Abs(x)<1)
            {
                return res = "Ошибка1";
            }
            else
            {
                if(!int.TryParse(num,out N))
                {
                    return res = "Ошибка2";
                }
            }





           double t = 1,s = t;
                

            for (int i = 1; i < N; i++)
            {
                t = -t * x * x / (2 * i * (2 * i + 1));
                s = s + t;
            }

            double f = Math.Sin(x) / x;

            res += "===========================================\n" + Environment.NewLine; 
           res+="Сумма ряда: " + s + Environment.NewLine + "\n" + "Функция равна: " + f + Environment.NewLine + "Абсолютная погрешность: " + Math.Abs(s - f) + "\n" +Environment.NewLine;
            res+="Последнее слагаемое: " + t + Environment.NewLine + "Отличие Последнего слогаемого и Абсолютной погрешности: " + Math.Abs(Math.Abs(s - f) - t) + "\n\n"+ Environment.NewLine;








            return res;

        }
        public string Method2(string xZN, string num)
        {


            string res = "";
            

            double x, E;

            if (!double.TryParse(xZN, out x) || Math.Abs(x) < 1)
            {
                return res = "Ошибка1";
            }
           
            if (!double.TryParse(num, out E))
            {
                return res = "Ошибка2";
            }
            


            double t = 1;
            double s = t;
            if (x == 0)
            {
                res="Вы не можете делить на ноль, введите переменную x повторно!" + "\n";

                
                return res;
            }
           
           
            if (E == 0)
            {
               res="Все числа последовательности будут больше Абослютной погрешности!" + "\n";

               
                return res;
            }




            double n = 0;

            while (Math.Abs(t) > E)
            {
                n++;
                t = -t * x * x / (2 * n * (2 * n + 1));

                s = s + t;


            }

           res+="===========================================\n"+ Environment.NewLine;
           res+="Количество X слагаемых, которые по модулю больше Абсолютной величины: " + n + Environment.NewLine;
           res+="Сумма этих слагаемых: " + s  + Environment.NewLine;





            E = E * 10; // АБСОЛЮТНАЯ ВЕЛИЧИНА УВЕЛИЧИНА В 10 РАЗ!!!!!!

            int n1 = 0;
            double t1 = 1, s1 = 0; ;
            while (Math.Abs(t1) > E)
            {

                n1++;
                t1 = -t1 * x * x / (2 * n1 * (2 * n1 + 1));
                s1 = s1 + t1;
            }
            res+="===========================================\n"+Environment.NewLine;
           res+="Количество X слагаемых, которые по модулю больше Абсолютной величины увеличенной в 10 раз: " + n1 + Environment.NewLine;
            res+="Сумма слагаемых с новой Абсолютной величиной : " + s1 + Environment.NewLine;



            res+="Суммирование для двух значений Е, отличающихся на порядок (в 10 раз): " + (s + s1) + Environment.NewLine;








            return res;
        }



           
        
    }
}
