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

using Plexdata.TeamRoulette.Events;
using Plexdata.TeamRoulette.Settings;
using System.Collections;
using System.ComponentModel;

namespace Plexdata.TeamRoulette.Controls
{
    public class EntityEditor<TEntity> : Panel where TEntity : Entity
    {
        #region Public Events

        public event EventHandler<SelectedEntityChangedEventArgs> SelectedEntityChanged;

        #endregion

        #region Private Fields

        private Panel pnHeading;
        private Panel pnContent;
        private Label lbHeading;
        private DataGridView dgContent;
        private BindingList<TEntity> bindings = null;

        #endregion

        #region Construction

        public EntityEditor()
            : base()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Properties

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public String Heading
        {
            get
            {
                return this.lbHeading.Text;
            }
            set
            {
                this.lbHeading.Text = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<TEntity> Entities
        {
            get
            {
                return this.bindings;
            }
            set
            {
                this.bindings = new BindingList<TEntity>(value);

                this.dgContent.DataSource = new BindingSource(this.bindings, null);

                this.dgContent.Columns[nameof(Entity.Active)].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dgContent.Columns[nameof(Entity.Active)].DisplayIndex = 0;
                this.dgContent.Columns[nameof(Entity.Name)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgContent.Columns[nameof(Entity.Name)].DisplayIndex = 1;
            }
        }

        #endregion

        #region Event Handling

        private void OnDataGridContentSelectionChanged(Object? sender, EventArgs args)
        {
            if (this.dgContent.SelectedCells.Count > 0)
            {
                Int32 index = this.dgContent.SelectedCells[0].RowIndex;
                IList items = ((BindingSource)this.dgContent.DataSource).List;

                if (index >= 0 && index < items.Count && items[index] is Entity entity)
                {
                    this.SelectedEntityChanged?.Invoke(this, new SelectedEntityChangedEventArgs(entity));
                }
            }
        }

        #endregion

        #region Private Methods

        private void InitializeComponent()
        {
            this.pnHeading = new Panel();
            this.pnContent = new Panel();
            this.lbHeading = new Label();
            this.dgContent = new DataGridView();

            this.SuspendLayout();
            this.pnContent.SuspendLayout();
            this.pnHeading.SuspendLayout();
            ((ISupportInitialize)this.dgContent).BeginInit();

            this.pnHeading.Dock = DockStyle.Top;
            this.pnHeading.Size = new Size(0, 29);
            this.pnHeading.BackColor = Color.WhiteSmoke;
            this.pnHeading.TabIndex = 0;

            this.lbHeading.Dock = DockStyle.Fill;
            this.lbHeading.AutoSize = false;
            this.lbHeading.Text = "Heading";
            this.lbHeading.TextAlign = ContentAlignment.MiddleLeft;

            this.pnHeading.Controls.Add(this.lbHeading);

            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.pnHeading);

            this.pnContent.Dock = DockStyle.Fill;
            this.pnContent.Controls.Add(this.dgContent);

            this.dgContent.BackgroundColor = Color.White;
            this.dgContent.BorderStyle = BorderStyle.None;
            this.dgContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgContent.Dock = DockStyle.Fill;
            this.dgContent.RowTemplate.Height = 25;
            this.dgContent.TabStop = true;
            this.dgContent.TabIndex = 0;
            this.dgContent.Margin = new Padding(0);
            this.dgContent.Visible = true;
            this.dgContent.SelectionChanged += this.OnDataGridContentSelectionChanged;

            this.ResumeLayout(false);
            this.PerformLayout();
            ((ISupportInitialize)this.dgContent).EndInit();
            this.pnContent.ResumeLayout(false);
            this.pnContent.PerformLayout();
            this.pnHeading.ResumeLayout(false);
            this.pnHeading.PerformLayout();
        }

        #endregion
    }
}
