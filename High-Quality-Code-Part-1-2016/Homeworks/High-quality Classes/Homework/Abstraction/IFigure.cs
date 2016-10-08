namespace Abstraction
{
    public interface IFigure
    {
        double Width
        {
            get;
            set;
        }

        double Height
        {
            get;
            set;
        }

        double Radius
        {
            get;
            set;
        }

        double CalcPerimeter();

        double CalcSurface();
    }
}
