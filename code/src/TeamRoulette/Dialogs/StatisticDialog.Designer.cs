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

namespace Plexdata.TeamRoulette.Dialogs
{
    partial class StatisticDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticDialog));
            btAccept = new Button();
            btCancel = new Button();
            btClear = new Button();
            dgContent = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgContent).BeginInit();
            this.SuspendLayout();
            // 
            // btAccept
            // 
            btAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btAccept.DialogResult = DialogResult.OK;
            btAccept.Location = new Point(316, 226);
            btAccept.Name = "btAccept";
            btAccept.Size = new Size(75, 23);
            btAccept.TabIndex = 3;
            btAccept.Text = "&Accept";
            btAccept.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            btCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btCancel.DialogResult = DialogResult.Cancel;
            btCancel.Location = new Point(397, 226);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(75, 23);
            btCancel.TabIndex = 2;
            btCancel.Text = "&Cancel";
            btCancel.UseVisualStyleBackColor = true;
            // 
            // btClear
            // 
            btClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btClear.Location = new Point(12, 226);
            btClear.Name = "btClear";
            btClear.Size = new Size(75, 23);
            btClear.TabIndex = 4;
            btClear.Text = "Cl&ear";
            btClear.UseVisualStyleBackColor = true;
            btClear.Click += this.OnButtonClearClicked;
            // 
            // dgContent
            // 
            dgContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgContent.BackgroundColor = Color.White;
            dgContent.BorderStyle = BorderStyle.None;
            dgContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgContent.Location = new Point(12, 12);
            dgContent.Name = "dgContent";
            dgContent.RowTemplate.Height = 25;
            dgContent.Size = new Size(460, 208);
            dgContent.TabIndex = 5;
            // 
            // StatisticDialog
            // 
            this.AcceptButton = btAccept;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = btCancel;
            this.ClientSize = new Size(484, 261);
            this.Controls.Add(dgContent);
            this.Controls.Add(btClear);
            this.Controls.Add(btAccept);
            this.Controls.Add(btCancel);
            this.DoubleBuffered = true;
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatisticDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Show;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Statistics";
            ((System.ComponentModel.ISupportInitialize)dgContent).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Button btAccept;
        private Button btCancel;
        private Button btClear;
        private DataGridView dgContent;
    }
}