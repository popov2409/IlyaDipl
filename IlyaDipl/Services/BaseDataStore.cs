using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml.Serialization;
using IlyaDipl.Models;

namespace IlyaDipl.Services
{
    public static class BaseDataStore
    {
        /// <summary>
        /// Путь к файлу с данными
        /// </summary>
        public const string DATA_PATH = "data\\db.xml";
        /// <summary>
        /// Список всех элементов
        /// </summary>
        public static List<Element> Elements { get; set; }
        /// <summary>
        /// Список всех типов элементов
        /// </summary>
        public static Dictionary<int, string> ElementTypes { get; set; }

        /// <summary>
        /// Добавить элемент в базу
        /// </summary>
        /// <param name="el"></param>
        public static void AddElement(Element el)
        {
            Elements.Add(el);
            SaveData();
        }
        /// <summary>
        /// Удалить элемент из базы
        /// </summary>
        /// <param name="el"></param>
        public static void RemoveElement(Element el)
        {
            Elements.Remove(Elements.First(c => c.Id == el.Id));
            SaveData();
        }
        /// <summary>
        /// Сохранить все данные в файл
        /// </summary>
        public static void SaveData()
        {

            XmlSerializer formatter = new XmlSerializer(typeof(List<Element>));

            using (FileStream fs = new FileStream(DATA_PATH, FileMode.Create))
            {
                formatter.Serialize(fs, Elements);
            }
        }
        /// <summary>
        /// Загрузить данные из файла
        /// </summary>
        public static void LoadData()
        {
            Elements = new List<Element>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Element>));

            using (FileStream fs = new FileStream(DATA_PATH, FileMode.OpenOrCreate))
            {
                try
                {
                    Elements = (List<Element>)formatter.Deserialize(fs);
                }
                catch (Exception e)
                {
                    //ignore
                    MessageBox.Show(e.Message);
                }


            }

        }

    }

}
