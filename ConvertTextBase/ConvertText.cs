using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertTextBase
{
	/// <summary>
	/// Text Converter
	/// </summary>
    public class ConvertText
	{
		/// <summary>
		/// Source File Encording
		/// </summary>
		private Encoding srcEncording;

		/// <summary>
		/// Destination File Encording
		/// </summary>
		private Encoding destEncording;

		/// <summary>
		/// Source File Read Object
		/// </summary>
		private StreamReader srcReader = null;

		/// <summary>
		/// Destination File Write Object
		/// </summary>
		private StreamWriter destWriter = null;

		/// <summary>
		/// Constructor
		/// </summary>
		public ConvertText()
		{
			srcEncording = Encoding.UTF8;
			destEncording = Encoding.UTF8;
		}

		/// <summary>
		/// Open Input File And Output File
		/// </summary>
		/// <param name="srcFilePath">Source File Path</param>
		/// <param name="destFilePath">Destination File Path</param>
		/// <returns>Result</returns>
		public bool Open(string srcFilePath, string destFilePath)
		{
			try
			{
				srcReader = new StreamReader(srcFilePath, srcEncording);
				destWriter = new StreamWriter(destFilePath, false, destEncording);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Read Line Text From Source File
		/// </summary>
		/// <returns>Readed Line Text (Null When The EOF Or Error)</returns>
		public string ReadText()
		{
			try
			{
				return srcReader.ReadLine();
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// Write Line Text To Destination File
		/// </summary>
		/// <param name="text">Write Line Text</param>
		/// <returns>Result</returns>
		public bool WriteText(string text)
		{
			try
			{
				destWriter.WriteLine(text);
				return true;
			}
			catch
			{
				return false;
			}
		}
		
		/// <summary>
		/// Close Input File And OutputFile
		/// </summary>
		/// <returns>Result</returns>
		public bool Close()
		{
			bool result = true;

			// Close Input File
			try
			{
				if (srcReader != null) srcReader.Close();
			}
			catch
			{
				result = false;
			}

			// Close Output File
			try
			{
				if (destWriter != null) destWriter.Close();
			}
			catch
			{
				result = false;
			}

			return result;
		}
	}
}
