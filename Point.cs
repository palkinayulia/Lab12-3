using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_12_3
{
    public class Point<T> where T: IComparable
    {
        public T? Data { get; set; }
        public Point<T>? Left { get; set; }
        public Point<T>? Right { get; set; }
        public Point()
        {
            this.Data = default(T);
            this.Left = null;
            this.Right = null;
        }

        public Point(T data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
        public override string ToString()
        {
            if (Data == null)
                return "";
            else
                return Data.ToString();
        }

        //public override int GetHashCode()
        //{
        //    return Data == null ? 0 : Data.GetHashCode();
        //}

        public int CompareTo(Point<T> other)
        {
            return Data.CompareTo(other.Data);
        }
        // Метод для клонирования узла
        public Point<T> Clone()
        {
            // Создаем новый узел с тем же значением
            Point<T> newNode = new Point<T>(Data);

            // Рекурсивно клонируем левое поддерево
            if (Left != null)
            {
                newNode.Left = Left.Clone();
            }

            // Рекурсивно клонируем правое поддерево
            if (Right != null)
            {
                newNode.Right = Right.Clone();
            }

            return newNode;
        }
    }
}
