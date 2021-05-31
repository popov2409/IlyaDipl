using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using IlyaDipl.Models;

namespace IlyaDipl
{
    interface IControlInterface
    {
        /// <summary>
        /// Выделить
        /// </summary>
        void Selected();
        /// <summary>
        /// Снять выделение
        /// </summary>
        void UnSelected();
        void Move(Point p);
        bool IsSelected { get; set; }
        /// <summary>
        /// Елемент
        /// </summary>
        Element Element { get; set; }
    }
}
