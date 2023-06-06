namespace DrawingPolygons
{
    partial class Form1
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rtxtOut = new System.Windows.Forms.RichTextBox();
            this.btnOut = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_zin = new System.Windows.Forms.Button();
            this.btn_zout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // rtxtOut
            // 
            this.rtxtOut.BackColor = System.Drawing.SystemColors.Info;
            this.rtxtOut.Location = new System.Drawing.Point(0, 49);
            this.rtxtOut.Name = "rtxtOut";
            this.rtxtOut.ReadOnly = true;
            this.rtxtOut.Size = new System.Drawing.Size(327, 158);
            this.rtxtOut.TabIndex = 2;
            this.rtxtOut.Text = "";
            // 
            // btnOut
            // 
            this.btnOut.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOut.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnOut.Location = new System.Drawing.Point(0, 0);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(328, 52);
            this.btnOut.TabIndex = 3;
            this.btnOut.Text = "Show Information";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(987, 17);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(126, 27);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "Delete Newest";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_zin
            // 
            this.btn_zin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_zin.Location = new System.Drawing.Point(987, 50);
            this.btn_zin.Name = "btn_zin";
            this.btn_zin.Size = new System.Drawing.Size(126, 27);
            this.btn_zin.TabIndex = 5;
            this.btn_zin.Text = "Zoom in";
            this.btn_zin.UseVisualStyleBackColor = true;
            this.btn_zin.Click += new System.EventHandler(this.btn_zin_Click);
            // 
            // btn_zout
            // 
            this.btn_zout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_zout.Location = new System.Drawing.Point(987, 83);
            this.btn_zout.Name = "btn_zout";
            this.btn_zout.Size = new System.Drawing.Size(126, 27);
            this.btn_zout.TabIndex = 6;
            this.btn_zout.Text = "Zoom out";
            this.btn_zout.UseVisualStyleBackColor = true;
            this.btn_zout.Click += new System.EventHandler(this.btn_zout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 450);
            this.Controls.Add(this.btn_zout);
            this.Controls.Add(this.btn_zin);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.rtxtOut);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox rtxtOut;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_zin;
        private System.Windows.Forms.Button btn_zout;
    }
}

