using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTree
{
    public class TypeTree
    {

        public string _Name { get; private set; } //Переменная строка для присваивания названия группы
        #region Конструкторы
        /// <summary>
        /// Создание конструкторы без названия
        /// </summary>
        public TypeTree()
        {
            _Name = "Нет";
        }
        /// <summary>
        /// Создания коструктора с названием группы
        /// </summary>
        /// <param name="name">Название группы</param>
        public TypeTree(string name) :this()
        {
            //Проверка является ли name пустой строкой или содержит только пробелы
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Группа не может быть пустой или сожержать только пробелы", nameof(name));
            }
            _Name = name;
        }
        #endregion

    }
}
