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
			var convertText = new ConvertText();
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
	}
}
