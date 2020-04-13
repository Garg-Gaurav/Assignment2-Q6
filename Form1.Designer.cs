namespace DSAssignment
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
            this.createProcess = new System.Windows.Forms.Button();
            this.NoOfProcess = new System.Windows.Forms.Label();
            this.noOfProcesses = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createProcess
            // 
            this.createProcess.Location = new System.Drawing.Point(27, 122);
            this.createProcess.Name = "createProcess";
            this.createProcess.Size = new System.Drawing.Size(107, 41);
            this.createProcess.TabIndex = 0;
            this.createProcess.Text = "Create";
            this.createProcess.UseVisualStyleBackColor = true;
            this.createProcess.Click += new System.EventHandler(this.createProcess_click);
            // 
            // NoOfProcess
            // 
            this.NoOfProcess.AutoSize = true;
            this.NoOfProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoOfProcess.Location = new System.Drawing.Point(23, 75);
            this.NoOfProcess.Name = "NoOfProcess";
            this.NoOfProcess.Size = new System.Drawing.Size(155, 20);
            this.NoOfProcess.TabIndex = 1;
            this.NoOfProcess.Text = "No of Processes:";
            // 
            // noOfProcesses
            // 
            this.noOfProcesses.Location = new System.Drawing.Point(184, 73);
            this.noOfProcesses.Name = "noOfProcesses";
            this.noOfProcesses.Size = new System.Drawing.Size(100, 22);
            this.noOfProcesses.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 64);
            this.button1.TabIndex = 3;
            this.button1.Text = "Calculate\r\n Vector";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.calculateCoordinates_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 698);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.noOfProcesses);
            this.Controls.Add(this.NoOfProcess);
            this.Controls.Add(this.createProcess);
            this.Name = "Form1";
            this.Text = "Distributed System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createProcess;
        private System.Windows.Forms.Label NoOfProcess;
        private System.Windows.Forms.TextBox noOfProcesses;
        private System.Windows.Forms.Button button1;
    }
}

