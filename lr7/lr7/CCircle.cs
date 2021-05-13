using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lr7
{
    public class CCircle
    {
        // Константи
        const int DefaultRadius = 50; // Радіус кола за замовчуванням, пікс

        // Поля
        private Graphics graphics;
        private int _radius; // Підтримуюче поле для властивості Radius

        // Властивості
        public int X { get; set; } // Координата X центра кола
        public int Y { get; set; } // Координата Y центра кола
        public int Radius
        { // Радіус кола
            get
            {
                return _radius;
            }
            set
            {
                _radius = value >= 200 ? 200 : value;
                _radius = value <= 5 ? 5 : value;
            }
        }
        // Конструктор, створює об'єкт кола (для заданої поверхні
        // малювання GDI+) з заданими координатами.
        // Радіус кола приймається за замовчуванням
        public CCircle(Graphics graphics, int X, int Y)
        {
            this.graphics = graphics;
            this.X = X;
            this.Y = Y;
            this.Radius = DefaultRadius;
        }
        // Конструктор, створює об'єкт кола (для заданої поверхні
        // малювання GDI+) з заданими координатами та радіусом
        public CCircle(Graphics graphics, int X, int Y, int Radius)
        {
            this.graphics = graphics;
            this.X = X;
            this.Y = Y;
            this.Radius = Radius;
        }
        // Малює коло на поверхні малювання GDI+.
        // Параметри кола задає перо pen
        private void Draw(Pen pen)
        {
            Rectangle rectangle = new Rectangle(X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            graphics.DrawEllipse(pen, rectangle);
            Point[] points_triada =
            {
                new Point(X, Y - Radius),
                new Point(X + Convert.ToInt32(Radius * 0.93), Y  + Convert.ToInt32(Radius * 0.4)),
                new Point(X - Convert.ToInt32(Radius * 0.93), Y  + Convert.ToInt32(Radius * 0.4))
            };
            graphics.DrawPolygon(pen, points_triada);
            points_triada[0].Offset(0, 2 * Radius);
            points_triada[1].Offset(0, -Convert.ToInt32(Radius * 0.85));
            points_triada[2].Offset(0, -Convert.ToInt32(Radius * 0.85));
            graphics.DrawPolygon(pen, points_triada);
        }
        // Показує коло (малює на поверхні малювання GDI+ кольором
        // переднього плану)
        public void Show()
        {
            Draw(Pens.Red);
        }
        // Приховує коло (малює на поверхні малювання GDI+ кольором фону)
        public void Hide()
        {
            Draw(Pens.White);
        }
        // Розширює коло: збільшує радіус на один піксель
        public void Expand()
        {
            Hide();
            Radius++;
            Show();
        }
        // Розширює коло: збільшує радіус на dR пікселів
        public void Expand(int dR)
        {
            Hide();
            Radius = Radius + dR;
            Show();
        }
        // Стискає коло: зменшує радіус на один піксель
        public void Collapse()
        {
            Hide();
            Radius--;
            Show();
        }
        // Стискає коло: зменшує радіус на dR пікселів
        public void Collapse(int dR)
        {
            Hide();
            Radius = Radius - dR;
            Show();
        }
        // Переміщує коло
        public void Move(int dX, int dY)
        {
            Hide();
            X = X + dX;
            Y = Y + dY;
            Show();
        }
    }
}
