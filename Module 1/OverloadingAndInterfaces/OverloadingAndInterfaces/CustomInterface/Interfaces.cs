using System;
using System.Collections.Generic;
using System.Text;

namespace OverloadingAndInterfaces.CustomInterface
{
    //No data, no ctors!
    public interface IPointy
    {
        // Implicitly public and abstract.
        byte Points { get; }
    }

    // The 3D drawing behavior.
    public interface IDraw3D
    {
        void Draw();
    }

    // Three interfaces each defining identical methods.
    public interface IDraw
    {
        void Draw();
    }

    public interface IDrawToPrinter
    {
        void Draw();
    }
}
