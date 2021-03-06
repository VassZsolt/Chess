
namespace Chess
{
    partial class ChessStart
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
            this.Local = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.b_Online = new System.Windows.Forms.Button();
            this.Version = new System.Windows.Forms.Label();
            this.textbox_Portnumber = new System.Windows.Forms.TextBox();
            this.textbox_EnemyURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Local
            // 
            this.Local.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Local.Location = new System.Drawing.Point(517, 295);
            this.Local.Name = "Local";
            this.Local.Size = new System.Drawing.Size(166, 46);
            this.Local.TabIndex = 0;
            this.Local.Text = "Play Local";
            this.Local.UseVisualStyleBackColor = true;
            this.Local.Click += new System.EventHandler(this.Local_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe Arabic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(299, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(556, 104);
            this.label2.TabIndex = 3;
            this.label2.Text = "\r\n╔═╗--┬--┬--┌─┐--┌─┐--┌─┐----╔═╗----┌─┐--┌┬┐--┌─┐\r\n║----   ├─┤--├┤----└─┐--└─┐--" +
    "   ║--╦ --  ├─┤--│││--├┤-\r\n╚═╝--┴--┴--└─┘--└─┘--└─┘----╚═╝----┴--┴--┴   ┴--└─┘";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // b_Online
            // 
            this.b_Online.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.b_Online.Location = new System.Drawing.Point(517, 378);
            this.b_Online.Name = "b_Online";
            this.b_Online.Size = new System.Drawing.Size(166, 46);
            this.b_Online.TabIndex = 4;
            this.b_Online.Text = "Play Online";
            this.b_Online.UseVisualStyleBackColor = true;
            this.b_Online.Click += new System.EventHandler(this.b_Online_Click);
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Version.Location = new System.Drawing.Point(12, 724);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(45, 21);
            this.Version.TabIndex = 5;
            this.Version.Text = "V 1.0";
            // 
            // textbox_Portnumber
            // 
            this.textbox_Portnumber.Location = new System.Drawing.Point(583, 454);
            this.textbox_Portnumber.Name = "textbox_Portnumber";
            this.textbox_Portnumber.Size = new System.Drawing.Size(100, 23);
            this.textbox_Portnumber.TabIndex = 6;
            // 
            // textbox_EnemyURL
            // 
            this.textbox_EnemyURL.Location = new System.Drawing.Point(583, 502);
            this.textbox_EnemyURL.Name = "textbox_EnemyURL";
            this.textbox_EnemyURL.Size = new System.Drawing.Size(256, 23);
            this.textbox_EnemyURL.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(517, 462);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Self_Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 505);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Enemy_URL";
            // 
            // ChessStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textbox_EnemyURL);
            this.Controls.Add(this.textbox_Portnumber);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.b_Online);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Local);
            this.Name = "ChessStart";
            this.Text = "Home_page";
            this.Load += new System.EventHandler(this.ChessStart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Local;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_Online;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.TextBox textbox_Portnumber;
        private System.Windows.Forms.TextBox textbox_EnemyURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}