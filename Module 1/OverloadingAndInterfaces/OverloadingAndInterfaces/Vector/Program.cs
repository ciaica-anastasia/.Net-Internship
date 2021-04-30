// using System;
//
// namespace OverloadingAndInterfaces.Vector
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // code to demonstrate arithmetic operations
//             //Vector vect1, vect2, vect3;
//             //vect1 = new Vector(1.0, 1.5, 2.0);
//             //vect2 = new Vector(0.0, 0.0, -10.0);
//             //vect3 = vect1 + vect2;
//             //Console.WriteLine("vect1 = " + vect1);
//             //Console.WriteLine("vect2 = " + vect2);
//             //Console.WriteLine("vect3 = vect1 + vect2 = " + vect3);
//             //Console.WriteLine("2*vect3 = " + 2 * vect3);
//             //vect3 += vect2;
//             //Console.WriteLine("vect3+=vect2 gives " + vect3);
//             //vect3 = vect1 * 2;
//             //Console.WriteLine("Setting vect3=vect1*2 gives " + vect3);
//             //double dot = vect1 * vect3;
//             //Console.WriteLine("vect1*vect3 = " + dot);
//
//             // code to demonstrate comparison operations
//             Vector vect1, vect2, vect3;
//             vect1 = new Vector(3.0, 3.0, -10.0);
//             vect2 = new Vector(3.0, 3.0, -10.0);
//             vect3 = new Vector(2.0, 3.0, 6.0);
//             Console.WriteLine("vect1==vect2 returns  " + (vect1 == vect2));
//             Console.WriteLine("vect1==vect3 returns  " + (vect1 == vect3));
//             Console.WriteLine("vect2==vect3 returns  " + (vect2 == vect3));
//             Console.WriteLine();
//             Console.WriteLine("vect1!=vect2 returns  " + (vect1 != vect2));
//             Console.WriteLine("vect1!=vect3 returns  " + (vect1 != vect3));
//             Console.WriteLine("vect2!=vect3 returns  " + (vect2 != vect3));
//
//             // code to demonstrate indexer
//             Console.WriteLine("\nvect1 = " + vect1);
//             Console.WriteLine("vect1[2] = " + vect1[2]);
//             for (int i = 0; i < 3; i++)
//                 vect2[i] = i;
//             Console.WriteLine("vect2 = " + vect2);
//             Console.WriteLine();
//
//             foreach (double Component in vect2)
//             {
//                 foreach (double Next in vect2)
//                     Console.Write("  " + Next + "  ");
//                 Console.WriteLine(Component);
//             }
//
//             Console.ReadLine();
//         }
//     }
// }
