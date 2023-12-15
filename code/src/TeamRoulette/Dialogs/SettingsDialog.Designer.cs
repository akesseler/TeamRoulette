/*
 * MIT License
 * 
 * Copyright (c) 2023 plexdata.de
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using Plexdata.TeamRoulette.Controls;
using Plexdata.TeamRoulette.Settings;

namespace Plexdata.TeamRoulette.Dialogs
{
    partial class SettingsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            btCancel = new Button();
            btAccept = new Button();
            this.pvTeams = new EntityEditor<Team>();
            this.pvMembers = new EntityEditor<Member>();
            tpContent = new TableLayoutPanel();
            tpContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            btCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btCancel.DialogResult = DialogResult.Cancel;
            btCancel.Location = new Point(397, 326);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(75, 23);
            btCancel.TabIndex = 0;
            btCancel.Text = "&Cancel";
            btCancel.UseVisualStyleBackColor = true;
            // 
            // btAccept
            // 
            btAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btAccept.DialogResult = DialogResult.OK;
            btAccept.Location = new Point(316, 326);
            btAccept.Name = "btAccept";
            btAccept.Size = new Size(75, 23);
            btAccept.TabIndex = 1;
            btAccept.Text = "&Accept";
            btAccept.UseVisualStyleBackColor = true;
            // 
            // pvTeams
            // 
            this.pvTeams.Dock = DockStyle.Fill;
            this.pvTeams.Heading = "Teams";
            this.pvTeams.Location = new Point(3, 3);
            this.pvTeams.Name = "pvTeams";
            this.pvTeams.Size = new Size(224, 302);
            this.pvTeams.TabIndex = 0;
            this.pvTeams.Text = "Form1";
            // 
            // pvMembers
            // 
            this.pvMembers.Dock = DockStyle.Fill;
            this.pvMembers.Heading = "Members";
            this.pvMembers.Location = new Point(233, 3);
            this.pvMembers.Name = "pvMembers";
            this.pvMembers.Size = new Size(224, 302);
            this.pvMembers.TabIndex = 0;
            // 
            // tpContent
            // 
            tpContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tpContent.ColumnCount = 2;
            tpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tpContent.Controls.Add(this.pvTeams, 0, 0);
            tpContent.Controls.Add(this.pvMembers, 1, 0);
            tpContent.Location = new Point(12, 12);
            tpContent.Name = "tpContent";
            tpContent.RowCount = 1;
            tpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tpContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tpContent.Size = new Size(460, 308);
            tpContent.TabIndex = 2;
            // 
            // SettingsDialog
            // 
            this.AcceptButton = btAccept;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = btCancel;
            this.ClientSize = new Size(484, 361);
            this.Controls.Add(tpContent);
            this.Controls.Add(btAccept);
            this.Controls.Add(btCancel);
            this.DoubleBuffered = true;
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Show;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Settings";
            tpContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Button btCancel;
        private Button btAccept;
        private EntityEditor<Team> pvTeams;
        private EntityEditor<Member> pvMembers;
        private TableLayoutPanel tpContent;
    }
}