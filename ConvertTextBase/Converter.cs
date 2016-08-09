using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConvertTextBase
{
	/// <summary>
	/// Text Converter Wrapper
	/// </summary>
	public class Converter
	{
		/// <summary>
		/// Text Converter
		/// </summary>
		private ConvertText convertText = new ConvertText();

		/// <summary>
		/// Write Text To Destination File Delegate
		/// </summary>
		/// <param name="readText">Readed Line Text</param>
		/// <returns>Write Text Result</returns>
		public delegate bool OutputText(string readText);

		/// <summary>
		/// Set Source File And Destination File Encodings
		/// </summary>
		/// <param name="encoding">Encoding</param>
		public void SetEncoding(Encoding encoding)
		{
			convertText.SetEncoding(encoding);
		}

		/// <summary>
		/// Fetch Line Text Event
		/// </summary>
		/// <param name="srcFilePath">Source File Path</param>
		/// <param name="destFilePath">Destination File Path</param>
		/// <param name="convertLogic">User's Convert Logic Delegate</param>
		public void Fetch(string srcFilePath, string destFilePath,
						  Action<string, OutputText> convertLogic)
		{
			if (convertText.Open(srcFilePath, destFilePath))
			{
				while (true)
				{
					// input
					var line = convertText.ReadText();
					if (line == null) break;

					// convert and output
					convertLogic(line, writeText);
				}
				convertText.Close();
			}
		}

		/// <summary>
		/// Write Line Text To Destination File
		/// </summary>
		/// <param name="text">Write Line Text</param>
		/// <returns>Result</returns>
		private bool writeText(string text)
		{
			return convertText.WriteText(text);
		}
	}
}
