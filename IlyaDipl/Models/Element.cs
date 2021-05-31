using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace IlyaDipl.Models
{
    [Serializable]
    public class Element
    {
        public Guid Id { get; set; } //ИД элемента
        public int ElementType { get; set; }//Тип, указаны в словаре в классе базы
        public Point Location { get; set; }//Позиция
        public string Mark { get; set; }//Маркировка
        public string Purpose { get; set; }//Назначение
        public int Rotate { get; set; }//Поворот, если допускается
        public string ImageSource { get; set; }//Картинка, если имеется
        public Size Size { get; set; } //Размер
        public List<string> Documents { get; set; } // Список документов

        public Element()
        {
            Documents=new List<string>();
        }
    }
}
