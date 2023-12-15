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
    partial class AboutDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            picLogo = new PictureBox();
            lblProduct = new Label();
            lblVersion = new Label();
            lblCopyright = new Label();
            txtDescription = new TextBox();
            btnClose = new Button();
            ttpHelper = new ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            resources.ApplyResources(picLogo, "picLogo");
            picLogo.Cursor = Cursors.Hand;
            picLogo.Name = "picLogo";
            picLogo.TabStop = false;
            ttpHelper.SetToolTip(picLogo, resources.GetString("picLogo.ToolTip"));
            picLogo.Click += this.OnLogoClicked;
            // 
            // lblProduct
            // 
            resources.ApplyResources(lblProduct, "lblProduct");
            lblProduct.Name = "lblProduct";
            // 
            // lblVersion
            // 
            resources.ApplyResources(lblVersion, "lblVersion");
            lblVersion.Name = "lblVersion";
            // 
            // lblCopyright
            // 
            resources.ApplyResources(lblCopyright, "lblCopyright");
            lblCopyright.Name = "lblCopyright";
            // 
            // txtDescription
            // 
            resources.ApplyResources(txtDescription, "txtDescription");
            txtDescription.BackColor = Color.White;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.TabStop = false;
            // 
            // btnClose
            // 
            resources.ApplyResources(btnClose, "btnClose");
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Name = "btnClose";
            btnClose.Click += this.OnCloseButtonClicked;
            // 
            // ttpHelper
            // 
            ttpHelper.ShowAlways = true;
            // 
            // AboutDialog
            // 
            this.AcceptButton = btnClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = btnClose;
            this.Controls.Add(btnClose);
            this.Controls.Add(lblProduct);
            this.Controls.Add(picLogo);
            this.Controls.Add(lblVersion);
            this.Controls.Add(lblCopyright);
            this.Controls.Add(txtDescription);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Show;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private PictureBox picLogo;
        private Label lblProduct;
        private Label lblVersion;
        private Label lblCopyright;
        private TextBox txtDescription;
        private Button btnClose;
        private ToolTip ttpHelper;
    }
}
