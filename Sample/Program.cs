using ConvertTextBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
	class Program
	{
		static void Main(string[] args)
		{
			sample1();
			sample2();
		}

		private static void sample1()
		{
			var convertText = new ConvertText();
			convertText.SetEncoding(Encoding.UTF8);
			if (convertText.Open("../../App.config", "sample.txt"))
			{
				while (true)
				{
					// input
					var line = convertText.ReadText();
					if (line == null) break;

					// convert
					var convertedText = line.Replace('<', '[').Replace('>', ']');

					// output
					convertText.WriteText(convertedText);
				}
				convertText.Close();
			}
		}

		private static void sample2()
		{
			Converter converter = new Converter();
			converter.SetEncoding(Encoding.UTF8);
			converter.Fetch("../../App.config", "sample.txt", sample2_fetch_event);
		}

		private static void sample2_fetch_event(string readLine, Converter.OutputText output)
		{
			// convert
			var convertedText = readLine.Replace('<', '[').Replace('>', ']');

			// output
			var result = output(convertedText);
		}
	}
}
