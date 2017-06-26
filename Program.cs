using System;
using System.Collections.Generic;
using System.IO;
using RoboCup.AtHome.CommandGenerator;
using RoboCup.AtHome.CommandGenerator.Containers;
using RoboCup.AtHome.CommandGenerator.ReplaceableTypes;

namespace SRGSConverter
{
	public class Program
	{
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main (string[] args)
		{
			List<Grammar> gs = Loader.LoadGrammars();
			List<Gesture> gestures = Loader.Load<GestureContainer>(Loader.GetPath("Gestures.xml")).Gestures;
			Loader.LoadLocations(Loader.GetPath("Locations.xml"));
			List<PersonName> names = Loader.Load<NameContainer>(Loader.GetPath("Names.xml")).Names;
			List<PredefinedQuestion> questions = Loader.Load<QuestionsContainer>(Loader.GetPath("Questions.xml")).Questions;
			Loader.LoadObjects(Loader.GetPath("Objects.xml"));
			if (!Directory.Exists("srgs"))
				Directory.CreateDirectory("srgs");
			foreach (Grammar g in gs)
			{
				try
				{
					Console.Write("Converting {0}... ", g.Name);
					string output = Path.Combine("srgs", String.Format("{0}_srgs.xml", g.Name));
					GrammarConverter.SaveToSRGS(g, output, gestures, names, questions);
					Console.WriteLine("Saved as {0}", output);
					Console.WriteLine();
				}
				catch (Exception ex) {
					Console.WriteLine(ex.Message);
				}
			}
			Console.WriteLine("Done!");
		}
	}
}
