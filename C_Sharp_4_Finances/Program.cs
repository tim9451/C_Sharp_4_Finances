using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_4_Finances
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            #region УсловиеЗадачи
            // Задание 1.
            // Заказчик просит вас написать приложение по учёту финансов
            // и продемонстрировать его работу.
            // Суть задачи в следующем: 
            // Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
            // За год получены два массива – расходов и поступлений.
            // Определить прибыли по месяцам
            // Количество месяцев с положительной прибылью.
            // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
            // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
            // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

            // Пример
            //       
            // Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
            //     1              100 000             80 000                 20 000
            //     2              120 000             90 000                 30 000
            //     3               80 000             70 000                 10 000
            //     4               70 000             70 000                      0
            //     5              100 000             80 000                 20 000
            //     6              200 000            120 000                 80 000
            //     7              130 000            140 000                -10 000
            //     8              150 000             65 000                 85 000
            //     9              190 000             90 000                100 000
            //    10              110 000             70 000                 40 000
            //    11              150 000            120 000                 30 000
            //    12              100 000             80 000                 20 000
            // 
            // Худшая прибыль в месяцах: 7, 4, 1, 5, 12
            // Месяцев с положительной прибылью: 10
            #endregion

            int[] arrayCosts = new int[12], arrayIncome = new int[12], arrayProfit = new int[12], arrayProfitSort = new int[12];
            int countPositiveProfit = 0;
            string lowProfitMonth = "";
            Random r = new Random();

            Console.Write("{0,10}", "Месяц");
            Console.Write("{0,25}", "Доход, тыс. руб.");
            Console.Write("{0,25}", "Расход, тыс. руб.");
            Console.WriteLine("{0,25}", "Прибыль, тыс. руб.");
            for (int i = 0; i < 12; i++)
            {
                arrayIncome[i] = r.Next(100_000, 200_000);
                arrayCosts[i] = r.Next(100_000, 200_000);

                arrayProfit[i] = arrayIncome[i] - arrayCosts[i];

                Console.Write("{0,10}", i + 1);
                Console.Write("{0,25}", arrayIncome[i]);
                Console.Write("{0,25}", arrayCosts[i]);
                Console.WriteLine("{0,25}", arrayProfit[i]);
                if (arrayProfit[i] > 0) countPositiveProfit++;
            }

            Array.ConstrainedCopy(arrayProfit, 0, arrayProfitSort, 0, 12);
            Array.Sort(arrayProfitSort);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (arrayProfitSort[i] == arrayProfit[j])
                    {
                        lowProfitMonth = (lowProfitMonth == "") ? lowProfitMonth + " " + (j + 1) : lowProfitMonth + ", " + (j + 1);
                    }
                }
            }

            Console.WriteLine($"Худшая прибыль в месяцах {lowProfitMonth}");
            Console.WriteLine($"Месяцев с положительной прибылью {countPositiveProfit}");

            Console.ReadKey();
        }
    }
}
