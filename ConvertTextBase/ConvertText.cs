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
		public Encoding SrcEncording;

		/// <summary>
		/// Destination File Encording
		/// </summary>
		public Encoding DestEncording;

		/// <summary>
		/// Source File Read Object
		/// </summary>
		protected StreamReader srcReader = null;

		/// <summary>
		/// Destination File Write Object
		/// </summary>
		protected StreamWriter destWriter = null;

		/// <summary>
		/// Constructor
		/// </summary>
		public ConvertText()
		{
			SrcEncording = Encoding.UTF8;
			DestEncording = Encoding.UTF8;
		}

		/// <summary>
		/// Set Source File And Destination File Encodings
		/// </summary>
		/// <param name="encoding">Encoding</param>
		public void SetEncoding(Encoding encoding)
		{
			SrcEncording = encoding;
			DestEncording = encoding;
		}

		/// <summary>
		/// Open Input File And Output File
		/// </summary>
		/// <param name="srcFilePath">Source File Path</param>
		/// <param name="destFilePath">Destination File Path</param>
		/// <param name="isOverride">Is Delete And Create Destination File?</param>
		/// <returns>Result</returns>
		public bool Open(string srcFilePath, string destFilePath, bool isOverride = true)
		{
			try
			{
				srcReader = new StreamReader(srcFilePath, SrcEncording);
				destWriter = new StreamWriter(destFilePath, !isOverride, DestEncording);
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
