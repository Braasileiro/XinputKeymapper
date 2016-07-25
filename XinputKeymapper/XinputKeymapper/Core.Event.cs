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
 *	Core.Event.cs
 *	Author: Lucas Cota (BrasileiroGamer)
 *	Description: XinputKeymapper Events.
 *  Date: 2016-07-23
 */

using System;
using WindowsInput;
using SharpDX.XInput;
using System.Threading;
using System.Windows.Forms;

namespace XinputKeymapper
{
	class Event
	{
		public static void PollController()
		{
			// Exception Handler
			try
			{
				// Event Selector
				if(Global.iniTypeSpeed == "Gaming")
				{
					Event.PollGaming();
				}

				if(Global.iniTypeSpeed == "Normal")
				{
					Event.PollNormal();
				}
			}

			// Default Exception
			catch (SharpDX.SharpDXException)
			{
				Systray.systrayIcon.Dispose();

				MessageBox.Show
				(
					"XInput control disconnected!" + Environment.NewLine +
					"Try unplugging and replugging the control, it does not work, make sure it is working properly." + Environment.NewLine + Environment.NewLine +
					"The application will be closed.",
					"XinputKeymapper", MessageBoxButtons.OK, MessageBoxIcon.Error
				);
				Environment.Exit(1);
			}
		}

		// Gaming Event
		private static void PollGaming()
		{
			if(Global.iniSendEnter == "Disabled")
			{
				while (Global.xinputController.IsConnected)
				{
					Thread.Sleep(1);
					Event.ButtonEvents();
				}
			}

			if(Global.iniSendEnter == "Enabled")
			{
				while (Global.xinputController.IsConnected)
				{
					Thread.Sleep(1);
					Event.ButtonEventsEnter();
				}
			}
		}

		// Normal Event
		private static void PollNormal()
		{
			var previousState = Global.xinputController.GetState();

			if(Global.iniSendEnter == "Disabled")
			{
				while (Global.xinputController.IsConnected)
				{
					Thread.Sleep(50);

					var nextState = Global.xinputController.GetState();

					if (previousState.PacketNumber != nextState.PacketNumber)
					{
						Event.ButtonEvents();
					}
					previousState = nextState;
				}
			}

			if(Global.iniSendEnter == "Enabled")
			{
				while (Global.xinputController.IsConnected)
				{
					Thread.Sleep(50);

					var nextState = Global.xinputController.GetState();

					if (previousState.PacketNumber != nextState.PacketNumber)
					{
						Event.ButtonEventsEnter();
					}
					previousState = nextState;
				}
			}
		}

		// Button Events
		private static void ButtonEvents()
		{
			// A, B, X, Y
			if (Button.A != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.A) InputSimulator.SimulateTextEntry(Button.A);
			if (Button.B != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.B) InputSimulator.SimulateTextEntry(Button.B);
			if (Button.X != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.X) InputSimulator.SimulateTextEntry(Button.X);
			if (Button.Y != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.Y) InputSimulator.SimulateTextEntry(Button.Y);

			// LB, RB
			if (Button.LB != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.LeftShoulder) InputSimulator.SimulateTextEntry(Button.LB);
			if (Button.RB != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.RightShoulder) InputSimulator.SimulateTextEntry(Button.RB);

			// LT, RT
			if (Button.LT != "" && Global.xinputController.GetState().Gamepad.LeftTrigger > 0) InputSimulator.SimulateTextEntry(Button.LT);
			if (Button.RT != "" && Global.xinputController.GetState().Gamepad.RightTrigger > 0) InputSimulator.SimulateTextEntry(Button.RT);

			// LTS, RTS
			if (Button.LTS != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.LeftThumb) InputSimulator.SimulateTextEntry(Button.LTS);
			if (Button.RTS != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.RightThumb) InputSimulator.SimulateTextEntry(Button.RTS);

			// Back, Start
			if (Button.Back != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.Back) InputSimulator.SimulateTextEntry(Button.Back);
			if (Button.Start != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.Start) InputSimulator.SimulateTextEntry(Button.Start);

			// DPad
			if (Button.DPadUp != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.DPadUp) InputSimulator.SimulateTextEntry(Button.DPadUp);
			if (Button.DPadDown != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.DPadDown) InputSimulator.SimulateTextEntry(Button.DPadDown);
			if (Button.DPadLeft != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.DPadLeft) InputSimulator.SimulateTextEntry(Button.DPadLeft);
			if (Button.DPadRight != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.DPadRight) InputSimulator.SimulateTextEntry(Button.DPadRight);
		}

		private static void ButtonEventsEnter()
		{
			// A, B, X, Y
			if (Button.A != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.A) { InputSimulator.SimulateTextEntry(Button.A); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }
			if (Button.B != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.B) { InputSimulator.SimulateTextEntry(Button.B); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }
			if (Button.X != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.X) { InputSimulator.SimulateTextEntry(Button.X); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }
			if (Button.Y != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.Y) { InputSimulator.SimulateTextEntry(Button.Y); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }

			// LB, RB
			if (Button.LB != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.LeftShoulder) { InputSimulator.SimulateTextEntry(Button.LB); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }
			if (Button.RB != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.RightShoulder) { InputSimulator.SimulateTextEntry(Button.RB); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }

			// LT, RT
			if (Button.LT != "" && Global.xinputController.GetState().Gamepad.LeftTrigger > 0) { InputSimulator.SimulateTextEntry(Button.LT); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }
			if (Button.RT != "" && Global.xinputController.GetState().Gamepad.RightTrigger > 0) { InputSimulator.SimulateTextEntry(Button.RT); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }

			// LTS, RTS
			if (Button.LTS != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.LeftThumb) { InputSimulator.SimulateTextEntry(Button.LTS); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }
			if (Button.RTS != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.RightThumb) { InputSimulator.SimulateTextEntry(Button.RTS); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }

			// Back, Start
			if (Button.Back != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.Back) { InputSimulator.SimulateTextEntry(Button.Back); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }
			if (Button.Start != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.Start) { InputSimulator.SimulateTextEntry(Button.Start); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }

			// DPad
			if (Button.DPadUp != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.DPadUp) { InputSimulator.SimulateTextEntry(Button.DPadUp); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }
			if (Button.DPadDown != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.DPadDown) { InputSimulator.SimulateTextEntry(Button.DPadDown); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }
			if (Button.DPadLeft != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.DPadLeft) { InputSimulator.SimulateTextEntry(Button.DPadLeft); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }
			if (Button.DPadRight != "" && Global.xinputController.GetState().Gamepad.Buttons == GamepadButtonFlags.DPadRight) { InputSimulator.SimulateTextEntry(Button.DPadRight); InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); }
		}
	}
}
