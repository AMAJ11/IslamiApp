namespace islami
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.SuspendLayout();
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.CheckedState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.CustomImages.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.FillColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.HoverState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Image = global::islami.Properties.Resources.Delete_80_icon_icons_com_57340;
            this.guna2CircleButton1.Location = new System.Drawing.Point(1049, 0);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.ShadowDecoration.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Size = new System.Drawing.Size(31, 16);
            this.guna2CircleButton1.TabIndex = 0;
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.AllowCommentFiltering = false;
            this.pdfViewer1.AllowCommentReplies = false;
            this.pdfViewer1.AllowCommentSorting = false;
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.NavigationPaneWidth = 183;
            this.pdfViewer1.ReadOnly = true;
            this.pdfViewer1.ShowPrintStatusDialog = false;
            this.pdfViewer1.Size = new System.Drawing.Size(1100, 664);
            this.pdfViewer1.TabIndex = 4;
            this.pdfViewer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.pdfViewer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.pdfViewer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 664);
            this.Controls.Add(this.guna2CircleButton1);
            this.Controls.Add(this.pdfViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "quraan";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
    }
}