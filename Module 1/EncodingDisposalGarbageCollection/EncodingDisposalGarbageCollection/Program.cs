// using System;
// using System.Text;
//
// namespace EncodingDisposalGarbageCollection
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Encoding ascii = Encoding.ASCII;
//             Encoding unicode = Encoding.Unicode;
//
//             string str = "0123456789";
//
//             byte[] utf8Bytes = Encoding.UTF8.GetBytes(str);
//             Console.WriteLine(utf8Bytes.Length); //10 - 1 byte each char
//             string original = Encoding.UTF8.GetString(utf8Bytes);
//             Console.WriteLine(original);
//
//             string unicodeString = "This string contains the Unicode character Pi (\u03C0)";
//             byte[] unicodeBytes = unicode.GetBytes(unicodeString);
//             byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);
//             string asciiString = ascii.GetString(asciiBytes);
//
//             Console.WriteLine(unicodeString);
//             Console.WriteLine("ASCII converted string: {0}", asciiString);
//
//         }
//     }
// }