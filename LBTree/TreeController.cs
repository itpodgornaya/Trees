using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTree
{
    class TreeController
    {
        private List<Tree> trees = new List<Tree>(); // Список где хранятся наши деревья

        TypeTreeController treeController = new TypeTreeController(); // Вызываем конструктор видов деревьев

        private string[] defaultTreeNames = { "Дуб", "Береза", "Сосна", "Ель" }; //создаем массив строк с именами деревьев
        private double[] defaultTreeDensity = { 20.3, 56.8, 100.5, 200.1 }; //создаем массив чисел с плавающей точкой Плотность дерева
        private string[] defaultTreeColor = { "Дуб венге", "Светлая береза", "Светло коричневая сосна", "Темная ель" }; //Создаем массив строк с цветом деревьев
        private double[] defaultTreeHadness = { 300.4, 100.4, 245.5, 401.3 }; //Создаем массив чисел с плавающей точкой Твердость дерева
        //Конструктор
        public TreeController()
        {
            AddDefault();
        }
        /// <summary>
        /// Метод для вывода списка деревьев
        /// </summary>
        /// <returns></returns>
        public List<Tree> Trees()
        {
            return trees;
        }

        public void Add(string name, string typeTree)
        {
            //Если вид дерева не удается найти
            if (FindType(typeTree))
            {
                Console.WriteLine($"Не удается найти такой вид дерева {typeTree}");
                return;
            }
            int indexTypeTree = treeController.TypeTrees().FindIndex(n => n._Name.ToLower().TrimStart().TrimEnd() == typeTree.ToLower().TrimStart().TrimEnd()); //Находим индекс вида дерева чтобы потом обратится к нему и добавить в список деревьев
            trees.Add(new Tree(name, treeController.TypeTrees()[indexTypeTree])); // Добавление в список с помощью двух параметров name и вида дерева
        }

        public void Add(string name, string typeTree, string destiny, string color, string hadness)
        {
            checkNullSpaceString(name);
            checkNullSpaceString(color);
            //Проверка на конвертирование строки в число double
            if(!AssertDouble(destiny) || !AssertDouble(hadness))
            {
                Console.WriteLine($"Не удается преобразовать строку {destiny} или {hadness} в число с плавающей точкой");
                return;
            }
            //Если вид дерева не удается найти
            if(FindType(typeTree))
            {
                Console.WriteLine($"Не удается найти такой вид дерева {typeTree}");
                return;
            }
            int indexTypeTree = treeController.TypeTrees().FindIndex(n => n._Name.ToLower().TrimStart().TrimEnd() == typeTree.ToLower().TrimStart().TrimEnd()); //Находим индекс вида дерева чтобы потом обратится к нему и добавить в список деревьев
            trees.Add(new Tree(name, treeController.TypeTrees()[indexTypeTree], Convert.ToDouble(destiny), color, Convert.ToDouble(hadness))); // Добавление в список с помощью 4 параметров
        }
        /// <summary>
        /// Удаление дерева
        /// </summary>
        /// <param name="name">Передаем название дерева</param>
        public void Remove(string name)
        {
            checkNullSpaceString(name);
            foreach(var item in trees)
            {
                if(item._Name.ToLower().TrimStart().TrimEnd() == name.ToLower().TrimStart().TrimEnd())
                {
                    trees.Remove(item);
                    break;
                }
            }
        }
        /// <summary>
        /// Добавление готовых деревьев в список по умолчанию
        /// </summary>
        private void AddDefault()
        {
            for(int i = 0; i < defaultTreeColor.Length; i++)
            {
                trees.Add(new Tree(defaultTreeNames[i], treeController.TypeTrees()[i], defaultTreeDensity[i], defaultTreeColor[i], defaultTreeHadness[i]));
            }
        }
        /// <summary>
        /// Проверка строки на то является ли она пустой или содержит только пробелы
        /// </summary>
        /// <param name="str">Название строки</param>
        public void checkNullSpaceString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine($"Строка не может быть пустой или содержать только пробелы: {str}");
                return;
            }
        }
        /// <summary>
        /// Проверка конвертируется ли строка в число с плавающей точкой
        /// </summary>
        /// <param name="s">Назавание</param>
        /// <returns>True or False</returns>
        private bool AssertDouble(string s)
        {
            double doubleS;
            bool isDouble = double.TryParse(s, out doubleS);
            return isDouble; // возваращает правду или ложь не само число
        }
        /// <summary>
        /// Найти вид дерева по имени
        /// </summary>
        /// <param name="name">Название дерева</param>
        /// <returns>True or False</returns>
        private bool FindType(string name)
        {
            checkNullSpaceString(name); //Проверка на пустую строку
            foreach(var item in treeController.TypeTrees()) //цикл foreach
            {
                if(item._Name.ToLower().TrimStart().TrimEnd() == name.ToLower().TrimStart().TrimEnd())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
