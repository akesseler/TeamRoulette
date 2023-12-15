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

using Plexdata.TeamRoulette.Dialogs;
using Plexdata.TeamRoulette.Extensions;
using Plexdata.TeamRoulette.Settings;
using Plexdata.Utilities.Settings;
using System.ComponentModel;

namespace Plexdata.TeamRoulette
{
    public partial class MainForm : Form
    {
        #region Private Fields

        private Boolean initialize = false;
        private ApplicationSettings settings = null;
        private readonly ISettingsOptions options = SettingsFactory.Create<ISettingsOptions>(
            SettingsPattern.JsonPattern, StorageLocation.ExecutableFolder, "test"
        );

        #endregion

        #region Construction

        public MainForm()
            : base()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Overrides

        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);

            ISettingsReader<ApplicationSettings> reader = SettingsFactory.Create<ISettingsReader<ApplicationSettings>>();

            if (!reader.TryRead(this.options, this.GetSettingsFilename(), out ApplicationSettings settings))
            {
                settings = new ApplicationSettings();
                this.initialize = true;
            }

            this.settings = settings;

            this.tsRoulette.Duration = this.settings.Shuffler.Duration;
            this.tsRoulette.BorderColor = this.settings.Shuffler.BorderColor;
            this.tsRoulette.BorderThickness = this.settings.Shuffler.BorderThickness;
            this.tsRoulette.InlayColor = this.settings.Shuffler.InlayColor;
            this.tsRoulette.ForeColor = this.settings.Shuffler.TextColor;

            this.UpdateControls();
        }

        protected override void OnClosing(CancelEventArgs args)
        {
            if (this.tsRoulette.IsValid)
            {
                this.settings.Statistics.Add(new Statistic(this.tsRoulette.Result, this.settings.Roulette.Team));
            }

            ISettingsWriter<ApplicationSettings> writer = SettingsFactory.Create<ISettingsWriter<ApplicationSettings>>();

            writer.TryWrite(this.options, this.GetSettingsFilename(), this.settings);

            base.OnClosing(args);
        }

        protected override void OnShown(EventArgs args)
        {
            base.OnShown(args);

            if (this.initialize || this.settings.Roulette.Teams.Count == 0)
            {
                this.btSettings.PerformClick();
            }
        }

        #endregion

        #region Event Handling

        private void OnButtonExitClicked(Object sender, EventArgs args)
        {
            this.Close();
        }

        private void OnTeamsItemCheckedChanged(Object? sender, EventArgs args)
        {
            if (sender is ToolStripMenuItem)
            {
                slTeam.Text = (sender as ToolStripMenuItem).Text;

                this.settings.Roulette.Team = slTeam.Text;
            }
        }

        private void OnTeamsItemClicked(Object? sender, EventArgs args)
        {
            foreach (ToolStripItem current in this.btTeams.DropDownItems)
            {
                if (current is ToolStripMenuItem)
                {
                    (current as ToolStripMenuItem).Checked = false;
                }
            }

            if (sender is ToolStripMenuItem)
            {
                (sender as ToolStripMenuItem).Checked = true;
            }
        }

        private void OnButtonPlayClicked(Object sender, EventArgs args)
        {
            if (this.tsRoulette.IsPlaying)
            {
                return;
            }

            foreach (Object current in this.btTeams.DropDownItems)
            {
                if (current is ToolStripMenuItem item && item.Checked && item.Tag is Team team && team.Active)
                {
                    List<String> members = team.Members.Where(x => x.Active).Select(m => m.Name).ToList();

                    if (members.Count > 0)
                    {
                        this.tsRoulette.Values = members;
                        this.tsRoulette.Play();
                    }

                    return;
                }
            }
        }

        private void OnButtonSettingsClicked(Object sender, EventArgs args)
        {
            SettingsDialog dialog = new SettingsDialog();

            dialog.Settings = this.settings;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.settings = dialog.Settings;

                this.settings.Dump();

                this.UpdateControls();
            }
        }

        private void OnMenuItemStatisticClicked(Object sender, EventArgs args)
        {
            StatisticDialog dialog = new StatisticDialog();

            dialog.Values = this.settings.Statistics;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.settings.Statistics = dialog.Values;
            }
        }

        private void OnMenuItemAboutClicked(Object sender, EventArgs args)
        {
            AboutDialog dialog = new AboutDialog();
            dialog.ShowDialog();
        }

        private void OnRoulettePlayingStarted(Object sender, EventArgs args)
        {
            this.Cursor = Cursors.AppStarting;
            this.btPlay.Enabled = false;
            this.btTeams.Enabled = false;
            this.btSettings.Enabled = false;
        }

        private void OnRoulettePlayingStopped(Object sender, EventArgs args)
        {
            this.Cursor = Cursors.Default;
            this.btPlay.Enabled = true;
            this.btTeams.Enabled = true;
            this.btSettings.Enabled = true;
        }

        #endregion

        #region Private Methods

        private void UpdateControls()
        {
            this.slTeam.Text = String.Empty;
            this.btTeams.DropDownItems.Clear();
            this.btTeams.Enabled = this.settings.Roulette.Teams.Any(x => x.Active);
            this.btPlay.Enabled = this.btTeams.Enabled;

            foreach (Team team in this.settings.Roulette.Teams)
            {
                if (team.Active)
                {
                    ToolStripMenuItem button = new ToolStripMenuItem()
                    {
                        Tag = team,
                        Text = team.Name,
                        Checked = team.Active && team == this.settings.Roulette.Team,
                        Enabled = team.Active
                    };

                    if (button.Checked)
                    {
                        this.slTeam.Text = team.Name;
                    }

                    button.Click += this.OnTeamsItemClicked;
                    button.CheckedChanged += this.OnTeamsItemCheckedChanged;

                    this.btTeams.DropDownItems.Add(button);
                }
            }

            // HACK: No status text set yet? Just set "checked" the very first item.
            if (String.IsNullOrWhiteSpace(this.slTeam.Text) && this.btTeams.Enabled && this.btTeams.DropDownItems.Count > 0)
            {
                ((ToolStripMenuItem)this.btTeams.DropDownItems[0]).Checked = true;
            }
        }

        private String GetSettingsFilename()
        {
            return Path.ChangeExtension(Path.Combine(Application.LocalUserAppDataPath, Application.ProductName), "settings");
        }

        #endregion
    }
}