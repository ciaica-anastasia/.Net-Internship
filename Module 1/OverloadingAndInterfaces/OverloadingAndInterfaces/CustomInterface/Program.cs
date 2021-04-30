// using System;
//
// namespace OverloadingAndInterfaces.CustomInterface
// {
//     class Program
//     {
//         #region Static helper methods
//         // Interface type as method parameter
//         // I'll draw anyone supporting IDraw3D!
//         public static void DrawIn3D(IDraw3D itf3d)
//         {
//             Console.WriteLine("-> Drawing IDraw3D compatible type");
//             itf3d.Draw();
//         }
//         // Interface type as return value
//         static IPointy ExtractPointyness(object o)
//         {
//             if (o is IPointy)
//                 return (IPointy)o;
//             else
//                 return null;
//         }
//         #endregion
//
//         static void Main(string[] args)
//         {
//             IDraw3D a = new Hexagon();
//             a.Draw(); //можно вызвать приватный метод через интерфейс
//             //a.Draw2d(); //нельзя из-за интерфейса
//             Hexagon b = new Hexagon();
//             b.Draw(); //нельзя, так как он приватный либо будет вызван Shape
//             b.Draw2d();
//
//             var c = (IDraw) a;
//
//
//
//
//             // Shape[] s = { new Hexagon(), new Circle(), new Triangle("Trident"),
//             //   new Circle("Ring")};
//             // for (int i = 0; i < s.Length; i++)
//             // {
//             //     // Recall the Shape base class defines an abstract Draw() member,
//             //     // so all shapes know how to draw themselves.
//             //     s[i].Draw();
//             //
//             //     // Who's pointy?
//             //     if (s[i] is IPointy)
//             //         Console.WriteLine("-> Points: {0} ", ((IPointy)s[i]).Points);
//             //     else
//             //         Console.WriteLine("-> {0}\'s not pointy!", s[i].PetName);
//             //
//             //     // Can I draw you in 3D?
//             //     if (s[i] is IDraw3D)
//             //         DrawIn3D((IDraw3D)s[i]);
//             //
//             //     Console.WriteLine("----------------------------");
//             // }
//
//             //#region Interfaces as return values
//             //// Attempt to get IPointy.
//             //Circle c = new Circle();
//             //// IPointy itfPt = c as IPointy;
//             //IPointy itfPt = ExtractPointyness(c);
//             //if (itfPt != null)
//             //    Console.WriteLine("Object has {0} points.", itfPt.Points);
//             //#endregion
//
//             //#region Print all the members in IPointy array
//             //Console.WriteLine("\n***** Printing out members in IPointy array *****");
//             //IPointy[] myPointyObjects = new IPointy[] {new Hexagon(), new Spear(),
//             //    new Triangle(), new Fork(), new PitchFork()};
//
//             //for (int i = 0; i < myPointyObjects.Length; i++)
//             //    Console.WriteLine("Object has {0} points.", myPointyObjects[i].Points);
//             //#endregion
//
//             //Console.ReadLine();
//         }
//     }
// }
