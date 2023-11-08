using System;
using System.Collections;

namespace MatLog5_6Class
{
    public class MySteck
    {
        /// <summary>
        /// Класс для создания очереди любойдлинны путём реализации через List.
        /// </summary>
        int ind = -1;
        private ArrayList steck = new ArrayList();

        public void Push(object item)//add
        {
            ind++;
            if(ind <= steck.Count-1)
            {
                steck[ind] = item;
            }
            else
            {
                steck.Add(item);
            }
        }

        public object Pop()//get
        {
            if (ind >= 0)
            {
                var wr = steck[ind];
                ind--;
                return wr;
            }
            return null;
        }
    }

    public class MyQueue
    {
        /// <summary>
        /// Класс для создания очереди с возможностью добавления и получения значения.
        /// Пренимает переменную или число типа int.
        /// </summary>
        private static int MaxLen;
        private int first_ind = 0;
        private int seknd_ind = -1;
        private bool ob = false;
        private object[] queue;
        private bool start = true;

        public MyQueue(int Max)
        {
            MaxLen = Max;
            queue = new object[MaxLen];
        }

        public void Push(object item)//add
        {
            if (seknd_ind+1<MaxLen)
            {
                if (start)
                {
                    seknd_ind++;
                    queue[seknd_ind] = item;
                    start = false;
                }
                else if (first_ind != seknd_ind + 1)
                {
                    seknd_ind++;
                    queue[seknd_ind] = item;
                }
                else Console.WriteLine("Перебор!");
            }
            else
            {
                if ((seknd_ind+1) % MaxLen != first_ind)
                {
                    ob = true;
                    seknd_ind=(seknd_ind+1)%MaxLen;
                    queue[seknd_ind] = item;
                }
                else Console.WriteLine("Перебор!");
            }
        }

        public object Pop()//get
        {
            if (first_ind <= seknd_ind)
            {
                var wr = queue[first_ind];
                first_ind = (first_ind+1)%MaxLen;
                return wr;
            }
            else if (ob)
            {
                if (first_ind >= seknd_ind)
                {
                    var wr = queue[first_ind];
                    first_ind = (first_ind + 1) % MaxLen;
                    if(first_ind==0) ob = false;
                    return wr;
                }
            }
            return null;
        }
    }
}
