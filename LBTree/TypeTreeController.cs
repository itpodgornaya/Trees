using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTree
{
    class TypeTreeController
    {
        private List<TypeTree> typeTrees = new List<TypeTree>(); //Создаем список видов деревьев для дальнейшего использования
        private string[] defaultTypes = {"Шереховатый", "Болотный", "Черенчатый", "Красный", "обыкновенный"}; // По умолчанию создаются несколько видов деревьев и хранятсяв массиве

        /// <summary>
        /// Конструктор с данными по умолчанию
        /// </summary>
        public TypeTreeController()
        {
            AddDefault(defaultTypes, typeTrees);
        }
        /// <summary>
        /// Возвращает список видов деревьев
        /// </summary>
        /// <returns>typeTrees</returns>
        public List<TypeTree> TypeTrees()
        {
            return typeTrees; //возвращает весь список вид деревьев используется в переборе к примеру для цикла foreach
        }
        /// <summary>
        /// Добавление нового вида в typeTrees
        /// </summary>
        /// <param name="name">Название вида</param>
        public void Add(string name)
        {
            checkNullSpaceString(name); //вызов метода на проверку пустых названий
            typeTrees.Add(new TypeTree(name)); //Добавляем в список конструктор с именем которое мы вписали
        }
        /// <summary>
        /// Удаление вида из typeTrees
        /// </summary>
        /// <param name="name">Название вида</param>
        public void Remove(string name)
        {
            checkNullSpaceString(name);
            foreach(var item in typeTrees)
            {
                if(item._Name.ToLower().TrimStart().TrimEnd() == name.ToLower().TrimStart().TrimEnd())
                {
                    typeTrees.Remove(item);
                    break;
                }
            }
        }
        /// <summary>
        /// Проверка на то пустая ли строка или присутствуют только пробелы в ней
        /// </summary>
        /// <param name="str">Название строки</param>
        public void checkNullSpaceString(string str)
        {
            if(string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentNullException("Название вида деревьев не может быть пустым или содержать только пробелы", nameof(str));
            }
        }
        /// <summary>
        /// Добавление Видов деревьев по умолчанию в список TypeTrees
        /// </summary>
        /// <param name="groups">Передаем массив с видом деревьев</param>
        /// <param name="listgroup">Педаем сам список куда нужно записать</param>
        public void AddDefault(string[] groups, List<TypeTree> listgroup)
        {

            foreach(var item in groups)
            {
                checkNullSpaceString(item); //вызов метода на проверку пустых названий
                listgroup.Add(new TypeTree(item)); //добавляем в список новый элемент
            }
        }
    }
}
