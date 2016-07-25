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
 *	Core.Settings.cs
 *	Author: Lucas Cota (BrasileiroGamer)
 *	Description: XinputKeymapper Settings.
 *  Date: 2016-07-23
 */

using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace XinputKeymapper
{
	class Settings
	{
		// Configuration Wizard
		public static void FirstRun()
		{
			File.Delete("XinputKeymapper.ini");

			// Wizard Configuration
			Button.A = Interaction.InputBox("Button A", "XinputKeymapper Wizard");
			Button.B = Interaction.InputBox("Button B", "XinputKeymapper Wizard");
			Button.X = Interaction.InputBox("Button X", "XinputKeymapper Wizard");
			Button.Y = Interaction.InputBox("Button Y", "XinputKeymapper Wizard");
			Button.LB = Interaction.InputBox("Left Bumper (LB)", "XinputKeymapper Wizard");
			Button.RB = Interaction.InputBox("Right Bumper (RB)", "XinputKeymapper Wizard");
			Button.LT = Interaction.InputBox("Left Trigger (LT)", "XinputKeymapper Wizard");
			Button.RT = Interaction.InputBox("Right Trigger (RT)", "XinputKeymapper Wizard");
			Button.LTS = Interaction.InputBox("Left Thumbstick (LTS)", "XinputKeymapper Wizard");
			Button.RTS = Interaction.InputBox("Right Thumbstick (RTS)", "XinputKeymapper Wizard");
			Button.Back = Interaction.InputBox("Back", "XinputKeymapper Wizard");
			Button.Start = Interaction.InputBox("Start", "XinputKeymapper Wizard");
			Button.DPadUp = Interaction.InputBox("DPad Up", "XinputKeymapper Wizard");
			Button.DPadDown = Interaction.InputBox("DPad Down", "XinputKeymapper Wizard");
			Button.DPadLeft = Interaction.InputBox("DPad Left", "XinputKeymapper Wizard");
			Button.DPadRight = Interaction.InputBox("DPad Right", "XinputKeymapper Wizard");

			// Writing Configurations
			Global.iniKeymapper.Write("FirstRun", "Disabled");
			Global.iniKeymapper.Write("TypeSpeed", "Gaming");
			Global.iniKeymapper.Write("SendEnter", "Disabled");
			Global.iniKeymapper.Write("A", Button.A);
			Global.iniKeymapper.Write("B", Button.B);
			Global.iniKeymapper.Write("X", Button.X);
			Global.iniKeymapper.Write("Y", Button.Y);
			Global.iniKeymapper.Write("LB", Button.LB);
			Global.iniKeymapper.Write("RB", Button.RB);
			Global.iniKeymapper.Write("LT", Button.LT);
			Global.iniKeymapper.Write("RT", Button.RT);
			Global.iniKeymapper.Write("LTS", Button.LTS);
			Global.iniKeymapper.Write("RTS", Button.RTS);
			Global.iniKeymapper.Write("Back", Button.LTS);
			Global.iniKeymapper.Write("Start", Button.RTS);
			Global.iniKeymapper.Write("DPadUp", Button.DPadUp);
			Global.iniKeymapper.Write("DPadDown", Button.DPadDown);
			Global.iniKeymapper.Write("DPadLeft", Button.DPadLeft);
			Global.iniKeymapper.Write("DPadRight", Button.DPadRight);
		}

		// Manual Configuration
		public static void FirstRunManual()
		{
			File.Delete("XinputKeymapper.ini");

			// Writing Configurations
			Global.iniKeymapper.Write("FirstRun", "Disabled");
			Global.iniKeymapper.Write("TypeSpeed", "Gaming");
			Global.iniKeymapper.Write("SendEnter", "Disabled");
			Global.iniKeymapper.Write("A", "");
			Global.iniKeymapper.Write("B", "");
			Global.iniKeymapper.Write("X", "");
			Global.iniKeymapper.Write("Y", "");
			Global.iniKeymapper.Write("LB", "");
			Global.iniKeymapper.Write("RB", "");
			Global.iniKeymapper.Write("LT", "");
			Global.iniKeymapper.Write("RT", "");
			Global.iniKeymapper.Write("LTS", "");
			Global.iniKeymapper.Write("RTS", "");
			Global.iniKeymapper.Write("Back", "");
			Global.iniKeymapper.Write("Start", "");
			Global.iniKeymapper.Write("DPadUp", "");
			Global.iniKeymapper.Write("DPadDown", "");
			Global.iniKeymapper.Write("DPadLeft", "");
			Global.iniKeymapper.Write("DPadRight", "");

			MessageBox.Show
			(
				"Remember that you must now set the 'XinputKeymapper.ini' file manually (or use the application icon on system tray). Blank buttons will enter not." + Environment.NewLine + Environment.NewLine +
				"The application will now open the file for configuration. Close the configuration file after editing to program continue the work." + Environment.NewLine + Environment.NewLine +
				"NOTE: Do not modify the values of the entries 'FirstRun', 'TypeSpeed' and 'SendEnter' manually. Use the TypeSpeed Control for it!" + Environment.NewLine + Environment.NewLine +
				"Press OK to continue",
				"XinputKeymapper Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information
			);
			Process.Start("XinputKeymapper.ini").WaitForExit();
		}

		// Read Configurations
		public static void ReadSettings()
		{
			Button.A = Global.iniKeymapper.Read("A");
			Button.B = Global.iniKeymapper.Read("B");
			Button.X = Global.iniKeymapper.Read("X");
			Button.Y = Global.iniKeymapper.Read("Y");
			Button.LB = Global.iniKeymapper.Read("LB");
			Button.RB = Global.iniKeymapper.Read("RB");
			Button.LT = Global.iniKeymapper.Read("LT");
			Button.RT = Global.iniKeymapper.Read("RT");
			Button.LTS = Global.iniKeymapper.Read("LTS");
			Button.RTS = Global.iniKeymapper.Read("RTS");
			Button.Back = Global.iniKeymapper.Read("Back");
			Button.Start = Global.iniKeymapper.Read("Start");
			Button.DPadUp = Global.iniKeymapper.Read("DPadUp");
			Button.DPadDown = Global.iniKeymapper.Read("DPadDown");
			Button.DPadLeft = Global.iniKeymapper.Read("DPadLeft");
			Button.DPadRight = Global.iniKeymapper.Read("DPadRight");
		}
	}
}
