﻿using System;
using System.Collections.Generic;
using System.IO;
using RoboCup.AtHome.CommandGenerator;
using RoboCup.AtHome.CommandGenerator.Containers;

namespace SGRSConverter
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
			LocationManager locations = Loader.LoadLocations(Loader.GetPath("Locations.xml"));
			List<PersonName> names = Loader.Load<NameContainer>(Loader.GetPath("Names.xml")).Names;
			List<PredefindedQuestion> questions = Loader.Load<QuestionsContainer>(Loader.GetPath("Questions.xml")).Questions;
			GPSRObjectManager objects = Loader.LoadObjects(Loader.GetPath("Objects.xml"));
			if (!Directory.Exists("srgs"))
				Directory.CreateDirectory("srgs");
			foreach (Grammar g in gs)
			{
				Console.Write("Converting {0}... ", g.Name);
				string output = Path.Combine("srgs", String.Format("{0}_srgs.xml", g.Name));
				GrammarConverter.SaveToSRGS(g, output, gestures, locations, names, objects, questions);
				Console.WriteLine("Saved as {0}",output);
				Console.WriteLine();
			}
			Console.WriteLine("Done!");
		}
	}
}