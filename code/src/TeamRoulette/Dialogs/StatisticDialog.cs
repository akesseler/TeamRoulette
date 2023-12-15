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

using Plexdata.TeamRoulette.Settings;
using System.ComponentModel;

namespace Plexdata.TeamRoulette.Dialogs
{
    public partial class StatisticDialog : Form
    {
        #region Private Fields

        private BindingList<Statistic> bindings = null;

        #endregion

        #region Construction

        public StatisticDialog()
            : base()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Properties

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal IList<Statistic> Values
        {
            get
            {
                return this.bindings;
            }
            set
            {
                List<Statistic> statistics = new List<Statistic>();

                if (value != null)
                {
                    foreach (Statistic statistic in value)
                    {
                        statistics.Add((Statistic)statistic.Clone());
                    }
                }

                this.bindings = new BindingList<Statistic>(statistics);

                this.dgContent.DataSource = new BindingSource(this.bindings, null);
            }
        }

        #endregion

        #region Overrides

        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);

            this.dgContent.Columns[nameof(Statistic.Week)].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgContent.Columns[nameof(Statistic.Week)].DisplayIndex = 0;
            this.dgContent.Columns[nameof(Statistic.Date)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgContent.Columns[nameof(Statistic.Date)].DisplayIndex = 1;
            this.dgContent.Columns[nameof(Statistic.Name)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgContent.Columns[nameof(Statistic.Name)].DisplayIndex = 2;
            this.dgContent.Columns[nameof(Statistic.Team)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgContent.Columns[nameof(Statistic.Team)].DisplayIndex = 3;

            this.dgContent.Rows[0].Selected = false;

            this.dgContent.AllowUserToAddRows = false;
            this.dgContent.AllowUserToDeleteRows = false;
            this.dgContent.AllowUserToResizeColumns = true;
            this.dgContent.AllowUserToResizeRows = false;

            this.btAccept.Enabled = false;
            this.btClear.Enabled = this.bindings.Count > 0;
        }

        #endregion

        #region Event Handling

        private void OnButtonClearClicked(Object? sender, EventArgs args)
        {
            this.bindings.Clear();
            this.btAccept.Enabled = true;
            this.btClear.Enabled = false;
        }

        #endregion
    }
}
