
namespace FamilyTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.create = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFather = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IsSon = new System.Windows.Forms.CheckBox();
            this.saveFather = new System.Windows.Forms.Button();
            this.textBoxSon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveSon = new System.Windows.Forms.Button();
            this.image = new System.Windows.Forms.PictureBox();
            this.btn_upload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // create
            // 
            this.create.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.create.ForeColor = System.Drawing.Color.Green;
            this.create.Location = new System.Drawing.Point(176, 443);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(116, 44);
            this.create.TabIndex = 1;
            this.create.Text = "Go back";
            this.create.UseVisualStyleBackColor = true;
            this.create.UseWaitCursor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(863, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.UseWaitCursor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Father or mather name:";
            // 
            // textBoxFather
            // 
            this.textBoxFather.Location = new System.Drawing.Point(355, 79);
            this.textBoxFather.Name = "textBoxFather";
            this.textBoxFather.Size = new System.Drawing.Size(185, 27);
            this.textBoxFather.TabIndex = 4;
            this.textBoxFather.TextChanged += new System.EventHandler(this.textBoxFather_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 5;
            // 
            // IsSon
            // 
            this.IsSon.AutoSize = true;
            this.IsSon.Location = new System.Drawing.Point(176, 153);
            this.IsSon.Name = "IsSon";
            this.IsSon.Size = new System.Drawing.Size(357, 24);
            this.IsSon.TabIndex = 6;
            this.IsSon.Text = "Does this father or mother have son or dougther?";
            this.IsSon.UseVisualStyleBackColor = true;
            this.IsSon.CheckedChanged += new System.EventHandler(this.IsSon_CheckedChanged);
            // 
            // saveFather
            // 
            this.saveFather.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveFather.ForeColor = System.Drawing.Color.Green;
            this.saveFather.Location = new System.Drawing.Point(557, 79);
            this.saveFather.Name = "saveFather";
            this.saveFather.Size = new System.Drawing.Size(53, 29);
            this.saveFather.TabIndex = 7;
            this.saveFather.Text = "save";
            this.saveFather.UseVisualStyleBackColor = true;
            this.saveFather.Click += new System.EventHandler(this.saveFather_Click);
            // 
            // textBoxSon
            // 
            this.textBoxSon.Location = new System.Drawing.Point(355, 244);
            this.textBoxSon.Name = "textBoxSon";
            this.textBoxSon.Size = new System.Drawing.Size(185, 27);
            this.textBoxSon.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Son or dougther´s name:\r\n";
            // 
            // saveSon
            // 
            this.saveSon.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveSon.ForeColor = System.Drawing.Color.Green;
            this.saveSon.Location = new System.Drawing.Point(557, 244);
            this.saveSon.Name = "saveSon";
            this.saveSon.Size = new System.Drawing.Size(53, 27);
            this.saveSon.TabIndex = 10;
            this.saveSon.Text = "save";
            this.saveSon.UseVisualStyleBackColor = true;
            this.saveSon.Click += new System.EventHandler(this.saveSon_Click);
            // 
            // image
            // 
            this.image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image.Location = new System.Drawing.Point(781, 55);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(198, 159);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 11;
            this.image.TabStop = false;
            // 
            // btn_upload
            // 
            this.btn_upload.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_upload.ForeColor = System.Drawing.Color.Green;
            this.btn_upload.Location = new System.Drawing.Point(781, 244);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(198, 26);
            this.btn_upload.TabIndex = 12;
            this.btn_upload.Text = "Upload";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 553);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.image);
            this.Controls.Add(this.saveSon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSon);
            this.Controls.Add(this.saveFather);
            this.Controls.Add(this.IsSon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFather);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.create);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Family tree | Insert Data";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFather;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox IsSon;
        private System.Windows.Forms.Button saveFather;
        private System.Windows.Forms.TextBox textBoxSon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveSon;
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.Button btn_upload;
    }
}