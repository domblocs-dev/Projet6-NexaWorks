using NexaWorks.Data;

using var context = new NexaWorksContext();
Seed.Initialiser(context);
Console.WriteLine("Base remplie avec succès");


