// using System;
// using System.Collections.Generic;
// using System.Text;
//
// namespace OverloadingAndInterfaces.CustomInterface
// {
//     public abstract class Shape
//     {
//         // Shapes can be assigned a friendly pet name.
//         protected string petName;
//
//         // Constructors.
//         public Shape() { petName = "NoName"; }
//         public Shape(string s) { petName = s; }
//
//         public abstract void Draw();
//
//         public string PetName
//         {
//             get { return petName; }
//             set { petName = value; }
//         }
//     }
//
//     // A given class may implement as many interfaces as necessary,
//     // but may have exactly 1 base class.
//     public class Hexagon : IPointy, IDraw3D, IDraw
//     {
//         public Hexagon() { }
//         public Hexagon(string name) : base(name) { }
//
//         // public override void Draw()
//         // {
//         //     //Recall the Shape class defined the PetName property.
//         //     Console.WriteLine("Drawing {0} the Hexagon", PetName);
//         // }
//
//         #region IPointy Members
//         public byte Points
//         {
//             get { return 6; }
//         }
//
//         public void Draw2d()
//         {
//             { Console.WriteLine("Drawing Hexagon using no abstract class or interface!"); }
//         }
//         #endregion
//
//         #region IDraw3D Members
//         // Using explicit method implementation we are able
//         // to provide distinct Draw() implementations.
//         void IDraw3D.Draw()
//         {
//             { Console.WriteLine("Drawing Hexagon using IDraw3D!"); }
//         }
//
//         void IDraw.Draw()
//         {
//             { Console.WriteLine("Drawing Hexagon using IDraw!"); }
//         }
//         //чтобы вызвать конкретный метод, мы должны скастить объект
//         //к определенному интерфейсу 
//
//         #endregion
//     }
//
//     public class Triangle : Shape, IPointy
//     {
//         public Triangle() { }
//         public Triangle(string name) : base(name) { }
//
//         #region IPointy Members
//         public byte Points
//         {
//             get { return 3; }
//         }
//         #endregion
//
//         public override void Draw()
//         {
//             throw new NotImplementedException();
//         }
//     }
//
//     public class Circle : Shape, IDraw3D
//     {
//         public Circle() { }
//         public Circle(string name) : base(name) { }
//
//         #region IDraw3D Members
//         void IDraw3D.Draw()
//         {
//             { Console.WriteLine("Drawing Circle in 3D!"); }
//         }
//         #endregion
//
//         public override void Draw()
//         {
//             throw new NotImplementedException();
//         }
//     }
//
//
//
//
//     #region Extra classes for examples
//     // Not deriving from Shape, but still injecting a name clash.
//     public class SuperImage : IDraw, IDrawToPrinter, IDraw3D
//     {
//         void IDraw.Draw()
//         {  /* Basic drawing logic. */ }
//         void IDrawToPrinter.Draw()
//         {  /* Printer logic. */}
//         void IDraw3D.Draw()
//         {  /* 3D support. */}
//     }
//
//     class Spear : IPointy
//     {
//         #region IPointy Members
//         byte IPointy.Points
//         {
//             get { return 1; }
//         }
//         #endregion
//     }
//
//     class Fork : IPointy
//     {
//         #region IPointy Members
//         byte IPointy.Points
//         {
//             get { return 4; }
//         }
//         #endregion
//     }
//
//     class PitchFork : IPointy
//     {
//         #region IPointy Members
//         byte IPointy.Points
//         {
//             get { return 3; }
//         }
//         #endregion
//
//     }
//     #endregion
// }
