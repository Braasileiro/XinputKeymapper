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
 *	Form.TypeSpeed.Designer.cs
 *	Author: Lucas Cota (BrasileiroGamer)
 *	Description: XinputKeymapper TypeSpeed Control Form Designer.
 *  Date: 2016-07-24
 */

namespace XinputKeymapper
{
	partial class TypeSpeed
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypeSpeed));
			this.radioGaming = new System.Windows.Forms.RadioButton();
			this.radioNormal = new System.Windows.Forms.RadioButton();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.checkEnter = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// radioGaming
			// 
			this.radioGaming.AutoSize = true;
			this.radioGaming.Location = new System.Drawing.Point(12, 12);
			this.radioGaming.Name = "radioGaming";
			this.radioGaming.Size = new System.Drawing.Size(142, 17);
			this.radioGaming.TabIndex = 0;
			this.radioGaming.TabStop = true;
			this.radioGaming.Text = "Gaming (Recommended)";
			this.radioGaming.UseVisualStyleBackColor = true;
			this.radioGaming.CheckedChanged += new System.EventHandler(this.radioGaming_CheckedChanged);
			// 
			// radioNormal
			// 
			this.radioNormal.AutoSize = true;
			this.radioNormal.Location = new System.Drawing.Point(12, 35);
			this.radioNormal.Name = "radioNormal";
			this.radioNormal.Size = new System.Drawing.Size(88, 17);
			this.radioNormal.TabIndex = 1;
			this.radioNormal.TabStop = true;
			this.radioNormal.Text = "Normal Delay";
			this.radioNormal.UseVisualStyleBackColor = true;
			this.radioNormal.CheckedChanged += new System.EventHandler(this.radioNormal_CheckedChanged);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(172, 81);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(91, 81);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// checkEnter
			// 
			this.checkEnter.AutoSize = true;
			this.checkEnter.Location = new System.Drawing.Point(12, 58);
			this.checkEnter.Name = "checkEnter";
			this.checkEnter.Size = new System.Drawing.Size(87, 17);
			this.checkEnter.TabIndex = 5;
			this.checkEnter.Text = "Enable Enter";
			this.checkEnter.UseVisualStyleBackColor = true;
			this.checkEnter.CheckedChanged += new System.EventHandler(this.checkEnter_CheckedChanged);
			// 
			// TypeSpeed
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(259, 106);
			this.Controls.Add(this.checkEnter);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.radioNormal);
			this.Controls.Add(this.radioGaming);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TypeSpeed";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TypeSpeed Control";
			this.Load += new System.EventHandler(this.TypeSpeed_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton radioGaming;
		private System.Windows.Forms.RadioButton radioNormal;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.CheckBox checkEnter;
	}
}
