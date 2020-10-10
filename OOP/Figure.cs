namespace OOP
{
    public abstract class Figure // класс с хранением возможных данных о фигуре, стороны, высота, радиус, углы и тд....
    {
        private double a, b, r, h;
        public double Storona1 { get { return a; } set { a = value; } } //свойства
        public double Storona2 { get { return b; } set { b = value; } }
        public double Radius { get { return r; } set { r = value; } }
        public double Visota { get { return h; } set { h = value; } }
    }
}