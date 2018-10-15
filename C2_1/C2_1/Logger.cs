using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_1
{
    public delegate string Message(string a);
    /// <summary>
    /// Варианты событий
    /// </summary>
    enum Logs
    {
        GetDMG,
        Shoot,
        DestroyAst,
        GetHeal,
        Die
    }    
    class Logger
    {   /// <summary>
    /// ПРисваеваем данные
    /// </summary>
    /// <param name="log">нужно выбрать тип из перечисления Енам</param>
    /// <param name="a">можно указать число для некоторых вызываевым кейсов</param>
    /// <returns></returns>
        public static string LogThis(Logs log, int a)
        {
            string b = string.Empty;
            switch (log)
            {               
                case Logs.GetDMG:
                    b = $"Вам был нанесён урон в размере {a}";
                    break;                                
                case Logs.DestroyAst:
                    b = $"Астероид был уничтожен";
                    break;
                case Logs.GetHeal:
                    b = $"Сожалею, но вас 'Отхилили' на {a}";
                    break;
                case Logs.Die:
                    b = $"Игра для Вас закончилась, Вы были убиты";
                    break;
            }
            return b;
        }
        /// <summary>
        /// Делегат 
        /// </summary>
        /// <param name="b">входные данные</param>
        /// <param name="msg">входной метод</param>
        public static void LogtoConsole(string b, Message msg)
        {
            msg(b);                       
        }
        /// <summary>
        /// Создаём метод написания в консоль
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string Method(string a)
        {
            Console.WriteLine(a);
            return a;
        }        
    }
}
