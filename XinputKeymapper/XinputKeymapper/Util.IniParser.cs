/*
    XinputKeymapper: A program to map letters or strings using a XInput control.

    Copyright (C) 2016  Lucas Cota (BrasileiroGamer)
    lucasbrunocota@live.com
    <http://www.github.com/BrasileiroGamer/>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

/*
 *	Util.IniParser.cs
 *	Author: Danny Beckett <http://stackoverflow.com/questions/217902/reading-writing-an-ini-file>
 *  Description: Simple Ini Parser.
 *	Date: 2016-07-21
 */

using System.IO;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace XinputKeymapper
{
	class IniParser
	{
		string iniPath;
		string iniExe = Assembly.GetExecutingAssembly().GetName().Name;

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		static extern long WritePrivateProfileString(string iniSection, string iniKey, string iniValue, string iniFile);

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		static extern int GetPrivateProfileString(string iniSection, string iniKey, string iniDefault, StringBuilder iniReturn, int iniSize, string iniFile);

		public IniParser(string iniFile = null)
		{
			iniPath = new FileInfo(iniFile ?? iniExe + ".ini").FullName.ToString();
		}

		public string Read(string iniKey, string iniSection = null)
		{
			var iniReturn = new StringBuilder(255);
			GetPrivateProfileString(iniSection ?? iniExe, iniKey, "", iniReturn, 255, iniPath);
			return iniReturn.ToString();
		}

		public void Write(string iniKey, string iniValue, string iniSection = null)
		{
			WritePrivateProfileString(iniSection ?? iniExe, iniKey, iniValue, iniPath);
		}

		public void DeleteKey(string iniKey, string iniSection = null)
		{
			Write(iniKey, null, iniSection ?? iniExe);
		}

		public void DeleteSection(string iniSection = null)
		{
			Write(null, null, iniSection ?? iniExe);
		}

		public bool KeyExists(string iniKey, string iniSection = null)
		{
			return Read(iniKey, iniSection).Length > 0;
		}
	}
}
