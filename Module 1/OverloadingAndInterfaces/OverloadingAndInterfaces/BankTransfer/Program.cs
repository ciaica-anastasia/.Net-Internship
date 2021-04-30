// using System;
//
// namespace OverloadingAndInterfaces.BankTransfer
// {
//     class Program
//     {
//         //static void Main(string[] args)
//         {
//             IBankAccount sa = new SaverAccount();
//             ITransferBankAccount ca = new CurrentAccount();
//             sa.PayIn(200);
//             ca.PayIn(500);
//
//             Console.WriteLine("Before transfer operation:");
//             Console.WriteLine(sa.ToString());
//             Console.WriteLine(ca.ToString());
//
//             sa.TransferTo(ca, 100);
//
//             Console.WriteLine("After transfer operation:");
//             Console.WriteLine(sa.ToString());
//             Console.WriteLine(ca.ToString());
//
//             Console.ReadLine();
//         }
//     }
// }
