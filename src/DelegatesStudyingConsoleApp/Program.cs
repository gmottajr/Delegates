// See https://aka.ms/new-console-template for more information

using DelegatesStudyingConsoleApp.Classes;

Console.WriteLine("Hello, World!");
var msgNova = Console.ReadLine();
Worker.Process(msgNova, msg => Console.WriteLine(msg)); // Output: All set!
Console.ReadLine();