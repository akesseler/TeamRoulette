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

namespace Plexdata.TeamRoulette
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tsMain = new ToolStrip();
            btExit = new ToolStripButton();
            btTeams = new ToolStripDropDownButton();
            btPlay = new ToolStripButton();
            btSettings = new ToolStripButton();
            btHelp = new ToolStripDropDownButton();
            miStatistic = new ToolStripMenuItem();
            tsSeparator1 = new ToolStripSeparator();
            miAbout = new ToolStripMenuItem();
            sbMain = new StatusStrip();
            slTeam = new ToolStripStatusLabel();
            tsRoulette = new TextShuffler();
            tsMain.SuspendLayout();
            sbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            tsMain.Items.AddRange(new ToolStripItem[] { btExit, btTeams, btPlay, btSettings, btHelp });
            tsMain.Location = new Point(0, 0);
            tsMain.Name = "tsMain";
            tsMain.Size = new Size(784, 39);
            tsMain.TabIndex = 0;
            tsMain.Text = "tsMain";
            // 
            // btExit
            // 
            btExit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btExit.Image = (Image)resources.GetObject("btExit.Image");
            btExit.ImageScaling = ToolStripItemImageScaling.None;
            btExit.ImageTransparentColor = Color.Magenta;
            btExit.Name = "btExit";
            btExit.Size = new Size(36, 36);
            btExit.Text = "Exit";
            btExit.Click += this.OnButtonExitClicked;
            // 
            // btTeams
            // 
            btTeams.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btTeams.Image = (Image)resources.GetObject("btTeams.Image");
            btTeams.ImageScaling = ToolStripItemImageScaling.None;
            btTeams.ImageTransparentColor = Color.Magenta;
            btTeams.Name = "btTeams";
            btTeams.Size = new Size(46, 36);
            btTeams.Text = "Teams";
            // 
            // btPlay
            // 
            btPlay.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btPlay.Image = (Image)resources.GetObject("btPlay.Image");
            btPlay.ImageScaling = ToolStripItemImageScaling.None;
            btPlay.ImageTransparentColor = Color.Magenta;
            btPlay.Name = "btPlay";
            btPlay.Size = new Size(36, 36);
            btPlay.Text = "Play";
            btPlay.Click += this.OnButtonPlayClicked;
            // 
            // btSettings
            // 
            btSettings.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSettings.Image = (Image)resources.GetObject("btSettings.Image");
            btSettings.ImageScaling = ToolStripItemImageScaling.None;
            btSettings.ImageTransparentColor = Color.Magenta;
            btSettings.Name = "btSettings";
            btSettings.Size = new Size(36, 36);
            btSettings.Text = "Settings";
            btSettings.Click += this.OnButtonSettingsClicked;
            // 
            // btHelp
            // 
            btHelp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btHelp.DropDownItems.AddRange(new ToolStripItem[] { miStatistic, tsSeparator1, miAbout });
            btHelp.Image = (Image)resources.GetObject("btHelp.Image");
            btHelp.ImageScaling = ToolStripItemImageScaling.None;
            btHelp.ImageTransparentColor = Color.Magenta;
            btHelp.Name = "btHelp";
            btHelp.Size = new Size(45, 36);
            btHelp.Text = "Help";
            // 
            // miStatistic
            // 
            miStatistic.Name = "miStatistic";
            miStatistic.Size = new Size(115, 22);
            miStatistic.Text = "&Statistic";
            miStatistic.Click += this.OnMenuItemStatisticClicked;
            // 
            // tsSeparator1
            // 
            tsSeparator1.Name = "tsSeparator1";
            tsSeparator1.Size = new Size(112, 6);
            // 
            // miAbout
            // 
            miAbout.Name = "miAbout";
            miAbout.Size = new Size(115, 22);
            miAbout.Text = "&About";
            miAbout.Click += this.OnMenuItemAboutClicked;
            // 
            // sbMain
            // 
            sbMain.Items.AddRange(new ToolStripItem[] { slTeam });
            sbMain.Location = new Point(0, 239);
            sbMain.Name = "sbMain";
            sbMain.Size = new Size(784, 22);
            sbMain.TabIndex = 1;
            // 
            // slTeam
            // 
            slTeam.BackColor = Color.Transparent;
            slTeam.Name = "slTeam";
            slTeam.Size = new Size(22, 17);
            slTeam.Text = "???";
            // 
            // tsRoulette
            // 
            tsRoulette.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tsRoulette.BackColor = Color.Transparent;
            tsRoulette.Duration = 3;
            tsRoulette.ForeColor = Color.DarkGreen;
            tsRoulette.Location = new Point(29, 59);
            tsRoulette.Margin = new Padding(20);
            tsRoulette.Name = "tsRoulette";
            tsRoulette.Size = new Size(726, 160);
            tsRoulette.TabIndex = 2;
            tsRoulette.Text = "slotMachine1";
            tsRoulette.PlayingStarted += this.OnRoulettePlayingStarted;
            tsRoulette.PlayingStopped += this.OnRoulettePlayingStopped;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(784, 261);
            this.Controls.Add(tsRoulette);
            this.Controls.Add(sbMain);
            this.Controls.Add(tsMain);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Team Roulette";
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            sbMain.ResumeLayout(false);
            sbMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private ToolStrip tsMain;
        private ToolStripButton btExit;
        private ToolStripButton btPlay;
        private ToolStripButton btSettings;
        private ToolStripDropDownButton btTeams;
        private StatusStrip sbMain;
        private ToolStripStatusLabel slTeam;
        private TextShuffler tsRoulette;
        private ToolStripDropDownButton btHelp;
        private ToolStripMenuItem miAbout;
        private ToolStripMenuItem miStatistic;
        private ToolStripSeparator tsSeparator1;
    }
}