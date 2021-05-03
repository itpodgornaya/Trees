using System;

namespace LBTree
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Добро Пожаловать в программу.");

            TypeTreeController _typeTree = new TypeTreeController(); // вызываем конструктор виды деревьев

            TreeController _tree = new TreeController(); // вызываем конструктор деревьев
            
            bool ProgramClose = true; // Нужно чтобы прекратить цикл бесконечного выполнения while

            while(ProgramClose)
            {
                Console.WriteLine("Выберите действие");

                StartMenu(_typeTree, _tree); // Вызываем метод старта нашей программы

                Console.WriteLine("Если вы хотите выйти из программы пропишите exit, чтобы продолжить нажмите enter");

                string exit = Console.ReadLine(); // Создается перменная для выхода из программы
                // Если пользователь напишет exit то программа прекратит свою работу
                if(exit == "exit")
                {
                    ProgramClose = false;
                }
                Console.WriteLine("");
            }
            
        }

        private static void StartMenu(TypeTreeController typeTree, TreeController tree)
        {
            #region Вывод в консоль возможности программы
            Console.WriteLine("Вывести список видов деревьев - types tree\n");
            Console.WriteLine("Вывести список деревьев - trees\n");
            Console.WriteLine("Добавить новый вид дерева - add type\n");
            Console.WriteLine("Добавить новое дерево - add tree\n");
            Console.WriteLine("Удалить вид дерева - del type\n");
            Console.WriteLine("Удалить дерево - del tree\n");
            Console.WriteLine("Очистить консоль - clear\n");
            #endregion
            //Выбор Кейса для выполения методов
            switch (Console.ReadLine())
            {
                case "types tree":
                    Types(typeTree);
                    break;

                case "add type":
                    AddType(typeTree);
                    Types(typeTree);
                    break;

                case "del type":
                    DelType(typeTree);
                    Types(typeTree);
                    break;

                case "trees":
                    Trees(tree);
                    break;

                case "add tree":
                    AddTree(tree);
                    Trees(tree);
                    break;

                case "del tree":
                    Deltree(tree);
                    Trees(tree);
                    break;

                case "clear":
                    Console.Clear();
                    break;
            }
        }
        /// <summary>
        /// Удаление дерева
        /// </summary>
        /// <param name="tree">Контроллер дерева</param>
        private static void Deltree(TreeController tree)
        {
            Console.WriteLine("Введите название дерева которое хотите удалить");
            string name = Console.ReadLine();
            tree.Remove(name);//вызываем метод Remove в классе TreeController
        }
        /// <summary>
        /// Вывод списка деревьев
        /// </summary>
        /// <param name="tree"></param>
        private static void Trees(TreeController tree)
        {
            //перебираем список деревьев с помощью foreach
            foreach(var item in tree.Trees())
            {
                Console.WriteLine($"Название Дерева: {item._Name}, вид дерева: {item._TypeTree._Name}, плотность дерева: {item._Density}, цвет дерева: {item._Color}, твердость дерева: {item._Hardness}");
            }
        }
        /// <summary>
        /// Добавление дерева
        /// </summary>
        /// <param name="tree">Контроллер дерева</param>
        private static void AddTree(TreeController tree)
        {
            #region Ввод данных с клавиатуры
            Console.WriteLine("Введите название дерева");
            string name = Console.ReadLine();
            Console.WriteLine("Введите вид дерева");
            string typeTree = Console.ReadLine();
            Console.WriteLine("Введите плотность дерева");
            string density = Console.ReadLine();
            Console.WriteLine("Введите цвет дерева");
            string color = Console.ReadLine();
            Console.WriteLine("Введите твердость дерева");
            string hadness = Console.ReadLine();
            #endregion
            //Проверка являются ли пустые строки или содержат только проверка для метода add так как там находятся два одинаковых метода с разным ввод данных
            if (string.IsNullOrWhiteSpace(density) || string.IsNullOrWhiteSpace(color) || string.IsNullOrWhiteSpace(hadness))
            {
                try
                { 
                    tree.Add(name, typeTree); //вызываем метод Add и передаем параметр name(название дерева) и typeTree(вид дерева) в классе TreeController
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            // Выполнения кода если заполнены все данные
            else
            {
                // Try попытаться выполнить код если это не получается то выдается ошибка
                try
                {
                    tree.Add(name, typeTree, density, color, hadness); //вызываем метод Add и передаем параметр name(Название дерева), typeTree(Вид дерева), density(Плотность), color(Цвет), hadness(Твердость) в классе TreeController
                }
                // Catch вывод ошибки в консоль
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        /// <summary>
        /// Выводит информацию о виде деревьев
        /// </summary>
        /// <param name="typeTree">Контроллер вид деревьев</param>
        private static void Types(TypeTreeController typeTree)
        {
            foreach(var item in typeTree.TypeTrees())
            {
                Console.WriteLine($"Виды деревьев: {item._Name}");
            }
        }
        /// <summary>
        /// Удаление видов деревьев
        /// </summary>
        /// <param name="typeTree">Контроллер вид деревьев</param>
        private static void DelType(TypeTreeController typeTree)
        {
            Console.WriteLine("Введите вид дерева которое хотите удалить");
            string name = Console.ReadLine();
            typeTree.Remove(name); //вызываем метод Remove и передаем параметр name в классе TypeTreeController
        }
        /// <summary>
        /// Добавить новый вид дерева
        /// </summary>
        /// <param name="typeTree">Контроллер вид деревьев</param>
        private static void AddType(TypeTreeController typeTree)
        {
            Console.WriteLine("Введите вид дерева");
            string name = Console.ReadLine();
            typeTree.Add(name); //вызываем метод Add и передаем параметр name в классе TypeTreeController
        }
    }
}
