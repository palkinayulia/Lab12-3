using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassLibrary10Lab;

namespace Лабораторная_работа_12_3
{
    public class MyTree<T> where T: IInit, IComparable, new()
    {
        Point<T>? root = null;
        int count = 0;
        public int Count => count;
        public MyTree(int length)
        {
            count = length;
            root = MakeTree(length, root);
        }
        public void ShowTree()
        {
            Show(root);
        }
        //ИСД
        Point<T>? MakeTree(int length, Point<T>? point)
        {
            T data = new T();
            data.RandomInit();
            Point<T> newItem = new Point<T>(data);
            if(length == 0)
            {
                return null;
            }
            int nl = length / 2;
            int nr = length - nl - 1;
            newItem.Left = MakeTree(nl, newItem.Left);
            newItem.Right = MakeTree(nr, newItem.Right);
            return newItem;
        }
        void Show(Point<T>? point, int spaces=5) 
        {
            if (point != null)
            {
                Show(point.Left, spaces + 5);
                for(int i = 0; i < spaces; i++)
                    Console.Write(" ");
                Console.WriteLine(point.Data);
                Show(point.Right, spaces + 5);
            }
        }
        //дерево поиска
        void AddPoint(T data)
        {
            Point<T>? point = root;
            Point<T>? current = null;
            bool isExist = false;
            while(point!=null && !isExist)
            {
                current = point;
                if (point.Data.CompareTo(data) == 0)
                {
                    isExist = true;
                }
                else//ищем место
                {
                    if(point.Data.CompareTo(data) < 0)
                    {
                        point = point.Left;
                    }
                    else
                    {
                        point = point.Right;
                    }
                }
                //нашли место
                if (isExist)
                {
                    return;//ничего не добавили
                }
                Point<T> newPoint = new Point<T>(data);
                if (current.Data.CompareTo(data) < 0)
                    current.Left = newPoint;
                else 
                    current.Right = newPoint;
                count++;
            }
        }
        void TransformToArray(Point<T>? point, T[] array, ref int current)
        {
            if (point != null)
            {
                TransformToArray(point.Left, array, ref current);
                array[current] = point.Data;
                current++;
                TransformToArray(point.Right, array, ref current);
            }
        }

        public void TransformToFindTree()
        {
            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current);

            root = new Point<T>(array[0]);
            count = 0;
            for (int i = 1; i < array.Length; i++)
            {
                AddPoint(array[i]);
            }
        }

        // Метод для клонирования дерева
        public MyTree<T> Clone()
        {
            // Создаем новый экземпляр MyTree<T>
            MyTree<T> clonedTree = new MyTree<T>(count);

            // Клонируем корневой узел
            clonedTree.root = root?.Clone();

            return clonedTree;
        }

        // Метод для подсчета количества элементов с заданным ключом
        public int CountElementsWithKey(T key)
        {
            return CountElementsWithKey(root, key);
        }

        private int CountElementsWithKey(Point<T>? point, T key)
        {
            if (point == null)
            {
                return 0;
            }

            int countKey = point.Data.CompareTo(key) == 0 ? 1 : 0;
            countKey += CountElementsWithKey(point.Left, key);
            countKey += CountElementsWithKey(point.Right, key);
            return countKey;
        }
    }
    
}
