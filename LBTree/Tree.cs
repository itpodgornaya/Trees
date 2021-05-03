using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTree
{
    class Tree
    {
        public string _Name { get; private set; } //Название дерева
        public TypeTree _TypeTree { get; private set; } //Ассоциативный класс обращаемся к виду дерева
        public double _Density { get; private set; } //Плотность, double переменная с плавающей точкой
        public string _Color { get; private set; } //Цвет
        public double _Hardness { get; private set; } //Твердость, double переменная с плавающей точкой
        #region Конструкторы
        /// <summary>
        /// Конструктор создание Пустого дерева
        /// </summary>
        public Tree()
        {
            _Name = "Неизвестно";
            _TypeTree = new TypeTree("Неизвестно");
            _Density = 0;
            _Color = "Нет";
            _Hardness = 0;
        }
        /// <summary>
        /// Конструктор создание дерева
        /// </summary>
        /// <param name="name">Название дерева</param>
        public Tree(string name) : this() //this обращение к начальному конструктору
        {
            checkNullSpaceString(name); // Проверка на пустоту строки
            _Name = name;
        }
        /// <summary>
        /// Конструктор создание дерева
        /// </summary>
        /// <param name="name">Название дерева</param>
        /// <param name="typeTree">Вид дерева</param>
        public Tree(string name, TypeTree typeTree) : this() //this обращение к начальному конструктору
        {
            checkNullSpaceString(name); // Проверка на пустоту строки
            _Name = name;
            _TypeTree = typeTree; 
        }
        /// <summary>
        /// Конструктор создание дерева
        /// </summary>
        /// <param name="name">Название дерева</param>
        /// <param name="destiny">Плотность дерева</param>
        public Tree(string name, TypeTree typeTree, double destiny) :this()
        {
            //Если плотность дерева больше 2000 или меньше 0 то вылезает ошибка
            if(destiny > 2000 || destiny < 0)
            {
                throw new ArgumentException("Плотность дерева не может быть больше 2000 или меньше 0", nameof(destiny));
            }
            _Name = name;
            _TypeTree = typeTree;
            _Density = destiny;
        }
        /// <summary>
        /// Конструктор создание дерева
        /// </summary>
        /// <param name="name">Название дерева</param>
        /// <param name="destiny">Плотность дерева</param>
        /// <param name="color">Цвет дерева</param>
        public Tree(string name, TypeTree typeTree, double destiny, string color) :this()
        {
            checkNullSpaceString(color);
            _Name = name;
            _TypeTree = typeTree;
            _Density = destiny;
            _Color = color;
        }
        /// <summary>
        /// Конструктор создание дерева
        /// </summary>
        /// <param name="name">Название дерева</param>
        /// <param name="destiny">Плотность дерева</param>
        /// <param name="color">Цвет дерева</param>
        /// <param name="hardness">Твердость дерева</param>
        public Tree(string name, TypeTree typeTree, double destiny, string color, double hardness) :this()
        {
            //Если твердость дерева больше 2000 или меньше 0 то вылезает ошибка
            if (hardness > 2000 || hardness < 0)
            {
                throw new ArgumentException("Плотность дерева не может быть больше 2000 или меньше 0", nameof(destiny));
            }
            _Name = name;
            _TypeTree = typeTree;
            _Density = destiny;
            _Color = color;
            _Hardness = hardness;
        }
        #endregion
        /// <summary>
        /// Проверка на то пустая ли строка или присутствуют только пробелы в ней
        /// </summary>
        /// <param name="str">Название строки</param>
        public void checkNullSpaceString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentNullException("Название вида деревьев не может быть пустым или содержать только пробелы", nameof(str));
            }
        }
    }
}
