
namespace dattnt
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
            this.txtbox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.boxChon = new System.Windows.Forms.ComboBox();
            this.btngiai = new System.Windows.Forms.Button();
            this.txtbox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnpause = new System.Windows.Forms.Button();
            this.txttime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbox1
            // 
            this.txtbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox1.Location = new System.Drawing.Point(10, 182);
            this.txtbox1.Multiline = true;
            this.txtbox1.Name = "txtbox1";
            this.txtbox1.Size = new System.Drawing.Size(344, 256);
            this.txtbox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn thuật toán H:";
            // 
            // boxChon
            // 
            this.boxChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxChon.FormattingEnabled = true;
            this.boxChon.Location = new System.Drawing.Point(207, 9);
            this.boxChon.Name = "boxChon";
            this.boxChon.Size = new System.Drawing.Size(185, 28);
            this.boxChon.TabIndex = 2;
            this.boxChon.SelectedIndexChanged += new System.EventHandler(this.boxChon_SelectedIndexChanged);
            // 
            // btngiai
            // 
            this.btngiai.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngiai.Location = new System.Drawing.Point(10, 53);
            this.btngiai.Name = "btngiai";
            this.btngiai.Size = new System.Drawing.Size(171, 48);
            this.btngiai.TabIndex = 3;
            this.btngiai.Text = "Giải";
            this.btngiai.UseVisualStyleBackColor = true;
            this.btngiai.Click += new System.EventHandler(this.btngiai_Click);
            // 
            // txtbox2
            // 
            this.txtbox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox2.Location = new System.Drawing.Point(444, 182);
            this.txtbox2.Multiline = true;
            this.txtbox2.Name = "txtbox2";
            this.txtbox2.Size = new System.Drawing.Size(344, 256);
            this.txtbox2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(1, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 339);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(540, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nhập dữ liệu đầu ra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nhập đề bài đầu vào";
            // 
            // btnpause
            // 
            this.btnpause.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpause.Location = new System.Drawing.Point(221, 53);
            this.btnpause.Name = "btnpause";
            this.btnpause.Size = new System.Drawing.Size(171, 48);
            this.btnpause.TabIndex = 6;
            this.btnpause.Text = "Thoát";
            this.btnpause.UseVisualStyleBackColor = true;
            this.btnpause.Click += new System.EventHandler(this.btnpause_Click);
            // 
            // txttime
            // 
            this.txttime.AutoSize = true;
            this.txttime.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttime.Location = new System.Drawing.Point(486, 42);
            this.txttime.Name = "txttime";
            this.txttime.Size = new System.Drawing.Size(277, 33);
            this.txttime.TabIndex = 7;
            this.txttime.Text = "Giải Taci game AKT";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txttime);
            this.Controls.Add(this.btnpause);
            this.Controls.Add(this.txtbox2);
            this.Controls.Add(this.btngiai);
            this.Controls.Add(this.boxChon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbox1);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "Taci";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxChon;
        private System.Windows.Forms.Button btngiai;
        private System.Windows.Forms.TextBox txtbox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnpause;
        private System.Windows.Forms.Label txttime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}

