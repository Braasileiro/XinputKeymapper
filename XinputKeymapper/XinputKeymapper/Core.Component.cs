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
 *	Core.Component.cs
 *	Author: Lucas Cota (BrasileiroGamer)
 *	Description: XinputKeymapper Component Checker.
 *  Date: 2016-07-23
 */

using System;
using System.IO;
using SharpDX.XInput;
using System.Windows.Forms;

namespace XinputKeymapper
{
	class Component
	{
		// Check Controller
		public static void CheckPads()
		{
			var padList = new[]
			{
				new Controller(UserIndex.One),
				new Controller(UserIndex.Two),
				new Controller(UserIndex.Three),
				new Controller(UserIndex.Four)
			};

			foreach (var padSelect in padList)
			{
				if (padSelect.IsConnected)
				{
					Global.xinputController = padSelect;
					break;
				}
			}

			if (Global.xinputController == null)
			{
				MessageBox.Show
				(
					"Could not find any XInput control!" + Environment.NewLine +
					"Try unplugging and replugging the control, it does not work, make sure it is working properly." + Environment.NewLine + Environment.NewLine +
					"The application will be closed.",
					"XinputKeymapper", MessageBoxButtons.OK, MessageBoxIcon.Error
				);
				Environment.Exit(1);
			}
		}

		// Check Settings
		public static void CheckSettings()
		{
			if (!File.Exists("XinputKeymapper.ini") || Global.iniFirstRun == "Enabled" || File.ReadAllLines("XinputKeymapper.ini").Length < 20 || new FileInfo("XinputKeymapper.ini").Length < 178)
			{
				MessageBoxManager.Yes = "Wizard";
				MessageBoxManager.No = "Manual";
				MessageBoxManager.Cancel = "Exit";

				MessageBoxManager.Register(); DialogResult dialogWizard = MessageBox.Show
				(
					"Well, it looks like it's your first configuration or some part of the configuration file is missing." + Environment.NewLine + Environment.NewLine +
					"All buttons that you want to not change, just leave the field blank or click cancel." + Environment.NewLine + Environment.NewLine +
					"You can even type in complete sentences for the buttons, but keep in mind that it may be a slight delay to the system 'type' words." + Environment.NewLine + Environment.NewLine +
					"If you delete something accidentally on file, delete the current file and the program will generate a new automatically (same of use the 'Configuration Wizard' on apllication in system tray). With incomplete settings the program may not work properly!" + Environment.NewLine + Environment.NewLine +
					"Click 'Wizard' to continue the setup wizard. If you click 'Manual', you have to set up the file manually.",
					"XinputKeymapper Wizard", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information
				); MessageBoxManager.Unregister();

				// Configuration Wizard
				if (dialogWizard == DialogResult.Yes)
				{
					Settings.FirstRun();
				}

				// Manual Configuration
				if (dialogWizard == DialogResult.No)
				{
					Settings.FirstRunManual();
				}

				// Exit Button
				if (dialogWizard == DialogResult.Cancel)
				{
					About.AboutBox();
					Environment.Exit(0);
				}
			}
			// Read Settings
			Settings.ReadSettings();
		}
	}
}
