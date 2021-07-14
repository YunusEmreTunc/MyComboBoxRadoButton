
namespace MyComboBoxRadioButton
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComboBox1 = new MyComboBoxRadioButton.ComboBox();
            this.MyRadioButton1 = new MyComboBoxRadioButton.MyRadioButton();
            this.MyRadioButton2 = new MyComboBoxRadioButton.MyRadioButton();
            this.MyRadioButton3 = new MyComboBoxRadioButton.MyRadioButton();
           
            this.SuspendLayout();
            // 
            // ComboBox1
            // 
            this.ComboBox1.Items.Add(this.MyRadioButton1);
            this.ComboBox1.Items.Add(this.MyRadioButton2);
            this.ComboBox1.Items.Add(this.MyRadioButton3);
            this.ComboBox1.Location = new System.Drawing.Point(166, 60);
            this.ComboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(132, 28);
            this.ComboBox1.TabIndex = 1;
            this.ComboBox1.Text = "ComboBox1";
            // 
            // MyRadioButton1
            // 
            this.MyRadioButton1.AutoSize = true;
            this.MyRadioButton1.BackColor = System.Drawing.SystemColors.Window;
            this.MyRadioButton1.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.MyRadioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MyRadioButton1.Location = new System.Drawing.Point(1, 3);
            this.MyRadioButton1.MinimumSize = new System.Drawing.Size(121, 24);
            this.MyRadioButton1.Name = "MyRadioButton1";
            this.MyRadioButton1.Size = new System.Drawing.Size(121, 24);
            this.MyRadioButton1.TabIndex = 0;
            this.MyRadioButton1.Text = "A";
            this.MyRadioButton1.UnCheckedColor = System.Drawing.Color.Gray;
            this.MyRadioButton1.UseVisualStyleBackColor = false;
            // 
            // MyRadioButton2
            // 
            this.MyRadioButton2.AutoSize = true;
            this.MyRadioButton2.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.MyRadioButton2.Location = new System.Drawing.Point(1, 30);
            this.MyRadioButton2.MinimumSize = new System.Drawing.Size(121, 24);
            this.MyRadioButton2.Name = "MyRadioButton2";
            this.MyRadioButton2.Size = new System.Drawing.Size(121, 24);
            this.MyRadioButton2.TabIndex = 0;
            this.MyRadioButton2.Text = "B";
            this.MyRadioButton2.UnCheckedColor = System.Drawing.Color.Gray;
            this.MyRadioButton2.UseVisualStyleBackColor = true;
            // 
            // MyRadioButton3
            // 
            this.MyRadioButton3.AutoSize = true;
            this.MyRadioButton3.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.MyRadioButton3.Location = new System.Drawing.Point(1, 57);
            this.MyRadioButton3.MinimumSize = new System.Drawing.Size(123, 24);
            this.MyRadioButton3.Name = "MyRadioButton3";
            this.MyRadioButton3.Size = new System.Drawing.Size(123, 24);
            this.MyRadioButton3.TabIndex = 0;
            this.MyRadioButton3.Text = "C";
            this.MyRadioButton3.UnCheckedColor = System.Drawing.Color.Gray;
            this.MyRadioButton3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 329);
            this.Controls.Add(this.ComboBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private ComboBox ComboBox1;
        private MyRadioButton MyRadioButton1;
        private MyRadioButton MyRadioButton2;
        private MyRadioButton MyRadioButton3;
       
    }
}

