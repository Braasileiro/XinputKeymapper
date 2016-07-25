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
 *	Form.TypeSpeed.cs
 *	Author: Lucas Cota (BrasileiroGamer)
 *	Description: XinputKeymapper TypeSpeed Control Form Functions.
 *  Date: 2016-07-24
 */

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace XinputKeymapper
{
	public partial class TypeSpeed : Form
	{
		// Initial Values
		private string tempTypeSpeed = Global.iniTypeSpeed;
		private string tempSendEnter = Global.iniSendEnter;

		public TypeSpeed()
		{
			// Start TypeSpeed Form
			InitializeComponent();

			// Close Event
			FormClosing += TypeSpeed_Close;
		}

		private void TypeSpeed_Load(object sender, EventArgs e)
		{
			//Prechecked Items
			if (Global.iniTypeSpeed == "Gaming")
			{
				radioGaming.Checked = true;
				radioNormal.Checked = false;
			}

			if (Global.iniTypeSpeed == "Normal")
			{
				radioGaming.Checked = false;
				radioNormal.Checked = true;
			}

			if(Global.iniSendEnter == "Enabled")
			{
				checkEnter.CheckState = CheckState.Checked;
			}

			if (Global.iniSendEnter == "Disabled")
			{
				checkEnter.CheckState = CheckState.Unchecked;
			}

			// Tooltips Informations
			ToolTip tipTypeSpeed = new ToolTip();
			tipTypeSpeed.SetToolTip(radioGaming, "Fast typing, hold the button and will write until you release the button.\nIdeal for gaming control mapping\nDon't use this to spamming chats.");
			tipTypeSpeed.SetToolTip(radioNormal, "Normal typing, press the button once to write.\nIdeal for writing a letter or short sentence at a time.");
			tipTypeSpeed.SetToolTip(checkEnter, "Enable send 'ENTER' (RETURN) key after typing to jump the line.\nRecommended use with strings and the 'Normal' mode activated.");
			tipTypeSpeed.SetToolTip(buttonSave, "Save settings and restarts XinputKeymapper.");
			tipTypeSpeed.SetToolTip(buttonCancel, "Cancel settings alterations and exits TypeSpeed Control\nSame thing of clicking  on 'Close' button.");
		}

		// Gaming Radio
		private void radioGaming_CheckedChanged(object sender, EventArgs e)
		{
			tempTypeSpeed = "Gaming";
		}

		// Normal Radio
		private void radioNormal_CheckedChanged(object sender, EventArgs e)
		{
			tempTypeSpeed = "Normal";
		}

		// Enter Checkbox
		private void checkEnter_CheckedChanged(object sender, EventArgs e)
		{
			if (checkEnter.Checked == true)
			{
				tempSendEnter = "Enabled";
			}

			if (checkEnter.Checked == false)
			{
				tempSendEnter = "Disabled";
			}
		}

		// Save Button
		private void buttonSave_Click(object sender, EventArgs e)
		{
			Global.iniTypeSpeed = tempTypeSpeed;

			if (tempSendEnter != null)
			{
				Global.iniSendEnter = tempSendEnter;
			}

			Global.iniKeymapper.Write("TypeSpeed", Global.iniTypeSpeed);
			Global.iniKeymapper.Write("SendEnter", Global.iniSendEnter);

			Systray.systrayIcon.Dispose();
			Process.Start(Application.ExecutablePath);
			Environment.Exit(0);
		}

		// Cancel Button
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			tempTypeSpeed = null;
			tempSendEnter = null;		
			Close();
		}

		// Close Control
		private void TypeSpeed_Close(object sender, FormClosingEventArgs e)
		{
			tempTypeSpeed = null;
			tempSendEnter = null;
		}
	}
}
