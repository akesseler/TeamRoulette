﻿/*
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

using Plexdata.TeamRoulette.Settings;
using System.ComponentModel;

namespace Plexdata.TeamRoulette.Dialogs
{
    public partial class SettingsDialog : Form
    {
        #region Private Fields

        private ApplicationSettings settings = null;

        #endregion

        #region Construction

        public SettingsDialog()
            : base()
        {
            this.InitializeComponent();

            this.pvTeams.SelectedEntityChanged += this.OnTeamsViewSelectedEntityChanged;
        }

        #endregion

        #region Properties

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ApplicationSettings Settings
        {
            get
            {
                return this.settings;
            }
            set
            {
                this.settings = (ApplicationSettings)value?.Clone() ?? new ApplicationSettings();

                this.UpdateControls();
            }
        }

        #endregion

        #region Event Handling

        private void OnTeamsViewSelectedEntityChanged(Object? sender, Events.SelectedEntityChangedEventArgs args)
        {
            if (args.Value is Team team)
            {
                this.pvMembers.Entities = team.Members;
            }
        }

        #endregion

        #region Private Methods

        private void UpdateControls()
        {
            this.pvTeams.Entities = this.settings.Roulette.Teams;
        }

        #endregion
    }
}
