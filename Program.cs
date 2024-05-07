using ClassLibrary10Lab;
using System.Collections.Generic;

namespace Лабораторная_работа_12_3
{
    internal class Program
    {
        static int NumberCheck() //проверка ввода числа
        {
            bool isConvert;
            int n;
            do
            {
                Console.Write("Введите число: ");
                string input = Console.ReadLine();
                isConvert = int.TryParse(input, out n);
                if (!isConvert || n <= 0) Console.WriteLine("Неправильно введено число \nПопробуйте еще раз.");
            } while (!isConvert || n <= 0);
            return n;
        }
        static void Main(string[] args)
        {
            MyTree<Watch> tree = new MyTree<Watch>(0);
            int numberMenu;
            int size = 0;
            do //меню для 3 части
            {
                Console.WriteLine("1.Создать идеально сбалансированное бинарное дерево");
                Console.WriteLine("2.Вывести дерево");
                Console.WriteLine("3.Количество элементов с заданным ключом");
                Console.WriteLine("4.Преобразовать начальное дерево в дерево поиска и напечатать");
                Console.WriteLine("5.Удаление деревa из памяти");
                Console.WriteLine("6.Выход");
                numberMenu = NumberCheck();
                switch (numberMenu)
                {
                    case 1: //создание дерева
                        {
                            Console.Write("Введите количество элементов дерева - ");
                            size = NumberCheck();
                            tree = new MyTree<Watch>(size); //создаем дерево
                            Console.WriteLine("Дерево создано");//сообщение для пользователя
                            
                            break;
                        };
                    case 2://печать дерева
                        {
                            tree.ShowTree();//выводим дерево
                            break;
                        };
                    case 3://поиск
                        {
                            Console.WriteLine("Введите бренд часов для поиска: ");
                            Watch clock = new Watch();
                            clock.Init();
                            if (tree.CountElementsWithKey(clock) == 0) Console.WriteLine("Такого элемента нет в списке");
                            else Console.Write("Количество элементов c таким брендом: ");
                            Console.WriteLine(tree.CountElementsWithKey(clock));
                            break;
                        };
                    case 4://преобразование
                        {
                            MyTree<Watch> findTree = tree.Clone();
                            findTree.TransformToFindTree();
                            Console.WriteLine("Исходное дерево: ");
                            tree.ShowTree();
                            Console.WriteLine("Преобразованное: ");
                            findTree.ShowTree();

                            break;
                        };
                    case 5://удаление из памяти
                        {
                            tree = null;
                            GC.Collect(); //вызываем сборщик мусора
                            Console.WriteLine("Clean");
                            tree.ShowTree();
                            break;
                        }
                    case 6: { break; } //возвращение в главное меню
                    default: { Console.WriteLine("Неправильно задан пункт меню \nПопробуйте еще раз"); break; };
                }
            } while (numberMenu != 6);
        }
    }
}
