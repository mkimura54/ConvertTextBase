using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertTextBase
{
    public class ConvertText
	{
		private Encoding srcEncording;

		private Encoding destEncording;

		private StreamReader srcReader = null;

		private StreamWriter destWriter = null;

		public ConvertText()
		{
			srcEncording = Encoding.UTF8;
			destEncording = Encoding.UTF8;
		}

		public bool Open(string srcFilePath, string destFilePath)
		{
			srcReader = new StreamReader(srcFilePath, srcEncording);
			destWriter = new StreamWriter(destFilePath, false, destEncording);

			return true;
		}

		public string ReadText()
		{
			return srcReader.ReadLine();
		}

		public bool WriteText(string text)
		{
			destWriter.WriteLine(text);
			return true;
		}
		
		public bool Close()
		{
			bool result = true;
			try
			{
				if (srcReader != null) srcReader.Close();
			}
			catch
			{
				result = false;
			}

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
