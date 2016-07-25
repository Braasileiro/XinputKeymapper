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
 *	Core.Systray.cs
 *	Author: Lucas Cota (BrasileiroGamer)
 *	Description: XinputKeymapper Systray Thread.
 *  Date: 2016-07-23
 */

using System;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace XinputKeymapper
{
	class Systray
	{
		// Resources
		private static Thread systrayApp;
		private static int manualWarning = 1;
		public static NotifyIcon systrayIcon;
		private static ContextMenu systrayMenu;

		public static void StartApp()
		{
			// Systray Thread
			systrayApp = new Thread
			(
				delegate ()
				{
					// Menu Resources
					systrayMenu = new ContextMenu();
					systrayMenu.MenuItems.Add("About XinputKeymapper", ShowAbout);
					systrayMenu.MenuItems.Add("TypeSpeed Control", ShowControl);
					systrayMenu.MenuItems.Add("Manual Configuration", ManualConfiguration);
					systrayMenu.MenuItems.Add("Configuration Wizard", ConfigurationWizard);
					systrayMenu.MenuItems.Add("Exit", ExitApp);

					systrayIcon = new NotifyIcon();
					systrayIcon.Text = "XinputKeymapper";
					systrayIcon.Icon = new Icon("XinputKeymapper.ico");
					systrayIcon.ContextMenu = systrayMenu;
					systrayIcon.Visible = true;

					systrayIcon.ShowBalloonTip(10000, "XinputKeymapper", "Use 'Configuration Wizard' to open initial configuration wizard again (reset).\nUse 'Manual Configuration' to edit the configuration manually.", ToolTipIcon.Info);
					Application.Run();
				}
			);
			systrayApp.Start(); // Start Systray Thread
		}

		// Configuration Wizard Menu Item
		private static void ConfigurationWizard(object sender, EventArgs e)
		{
			systrayIcon.ShowBalloonTip(10000, "XinputKeymapper Settings", "Complete the configuration wizard to program continue the work. Leave blank or click 'Cancel', the buttons that you do not want to map.", ToolTipIcon.Info);
			systrayIcon.Visible = false;

			Settings.FirstRun();
			Settings.ReadSettings();

			systrayIcon.Visible = true;
			systrayIcon.ShowBalloonTip(10000, "XinputKeymapper", "Configuration saved sucessfully! Now, test your new mapped keys (or strings).", ToolTipIcon.Info);
		}

		// Manual Configuration Menu Item
		private static void ManualConfiguration(object sender, EventArgs e)
		{
			systrayIcon.ShowBalloonTip(10000, "XinputKeymapper Settings", "After editing, don't forget to close the configuration file to program continue the work.", ToolTipIcon.Info);
			systrayIcon.Visible = false;

			if(manualWarning == 1)
			{
				MessageBox.Show
				(
					"NOTE: Do not modify the values of the entries 'FirstRun', 'TypeSpeed' and 'SendEnter' manually. Use the TypeSpeed Control for it!" + Environment.NewLine + Environment.NewLine +
					"Press OK to continue",
					"XinputKeymapper Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
				);
			}
			Process.Start("XinputKeymapper.ini").WaitForExit();
			Settings.ReadSettings();

			systrayIcon.Visible = true;
			systrayIcon.ShowBalloonTip(10000, "XinputKeymapper", "Configuration terminated! Now, test your new mapped keys (or strings).", ToolTipIcon.Info);
		}

		// Show TypeSpeed Form
		private static void ShowControl(object sender, EventArgs e)
		{
			new TypeSpeed().ShowDialog();
		}

		// Show About Dialog
		private static void ShowAbout(object sender, EventArgs e)
		{
			About.AboutBox();
		}

		// Exit Menu Item
		private static void ExitApp(object sender, EventArgs e)
		{
			systrayIcon.Dispose();
			About.AboutBox();
			Environment.Exit(0);
		}
	}
}
