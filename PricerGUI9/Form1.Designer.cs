namespace PricerGUI9
{
    partial class Form1
    {
      
        private System.ComponentModel.IContainer components = null;

       
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


        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonIncreaseBid = new System.Windows.Forms.Button();
            this.buttonDecreaseBid = new System.Windows.Forms.Button();
            this.buttonIncreaseAsk = new System.Windows.Forms.Button();
            this.buttonDecreaseAsk = new System.Windows.Forms.Button();
            this.buttonSimulateRecordInsertion = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // Main top left grid where various FX instruments are displayed
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(43, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1069, 428);
            this.dataGridView1.TabIndex = 0;
            // 
            // top right table with USD interest rate data
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1146, 219);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(468, 148);
            this.dataGridView2.TabIndex = 2;
            // 
            // bottom right table with GBP interest rate data
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(1146, 643);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(468, 150);
            this.dataGridView3.TabIndex = 4;
            // 
            // top right chart
            // 
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(1146, 47);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart1.Series.Add(series7);
            this.chart1.Size = new System.Drawing.Size(468, 164);
            this.chart1.TabIndex = 3;
            // 
            // bottom right chart
            // 
            chartArea8.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart2.Legends.Add(legend8);
            this.chart2.Location = new System.Drawing.Point(1146, 424);
            this.chart2.Name = "chart2";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chart2.Series.Add(series8);
            this.chart2.Size = new System.Drawing.Size(468, 182);
            this.chart2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1348, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "USD Interest Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1349, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "GBP Interest Rate";
            // 
            // buttonIncreaseBid
            // 
            this.buttonIncreaseBid.Location = new System.Drawing.Point(43, 481);
            this.buttonIncreaseBid.Name = "buttonIncreaseBid";
            this.buttonIncreaseBid.Size = new System.Drawing.Size(100, 30);
            this.buttonIncreaseBid.TabIndex = 8;
            this.buttonIncreaseBid.Text = "Increase Bid";
            this.buttonIncreaseBid.UseVisualStyleBackColor = true;
            this.buttonIncreaseBid.Click += new System.EventHandler(this.IncreaseBidButton_Click);
            // 
            // buttonDecreaseBid
            // 
            this.buttonDecreaseBid.Location = new System.Drawing.Point(149, 481);
            this.buttonDecreaseBid.Name = "buttonDecreaseBid";
            this.buttonDecreaseBid.Size = new System.Drawing.Size(100, 30);
            this.buttonDecreaseBid.TabIndex = 9;
            this.buttonDecreaseBid.Text = "Decrease Bid";
            this.buttonDecreaseBid.UseVisualStyleBackColor = true;
            this.buttonDecreaseBid.Click += new System.EventHandler(this.DecreaseBidButton_Click);
            // 
            // buttonIncreaseAsk
            // 
            this.buttonIncreaseAsk.Location = new System.Drawing.Point(255, 481);
            this.buttonIncreaseAsk.Name = "buttonIncreaseAsk";
            this.buttonIncreaseAsk.Size = new System.Drawing.Size(100, 30);
            this.buttonIncreaseAsk.TabIndex = 10;
            this.buttonIncreaseAsk.Text = "Increase Ask";
            this.buttonIncreaseAsk.UseVisualStyleBackColor = true;
            this.buttonIncreaseAsk.Click += new System.EventHandler(this.IncreaseAskButton_Click);
            // 
            // buttonDecreaseAsk
            // 
            this.buttonDecreaseAsk.Location = new System.Drawing.Point(373, 481);
            this.buttonDecreaseAsk.Name = "buttonDecreaseAsk";
            this.buttonDecreaseAsk.Size = new System.Drawing.Size(100, 30);
            this.buttonDecreaseAsk.TabIndex = 11;
            this.buttonDecreaseAsk.Text = "Decrease Ask";
            this.buttonDecreaseAsk.UseVisualStyleBackColor = true;
            this.buttonDecreaseAsk.Click += new System.EventHandler(this.DecreaseAskButton_Click);
            // 
            // buttonSimulateRecordInsertion
            // 
            this.buttonSimulateRecordInsertion.Location = new System.Drawing.Point(532, 481);
            this.buttonSimulateRecordInsertion.Name = "buttonSimulateRecordInsertion";
            this.buttonSimulateRecordInsertion.Size = new System.Drawing.Size(200, 30);
            this.buttonSimulateRecordInsertion.TabIndex = 12;
            this.buttonSimulateRecordInsertion.Text = "Simulate Record Insertion";
            this.buttonSimulateRecordInsertion.UseVisualStyleBackColor = true;
            this.buttonSimulateRecordInsertion.Click += new System.EventHandler(this.SimulateRecordInsertionButton_Click);
            // 
            // API data grid view
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(43, 548);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(1069, 245);
            this.dataGridView4.TabIndex = 13;
            // 
            // Pull Market Data button
            // 
            this.button1.Location = new System.Drawing.Point(43, 815);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Pull Market Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Ticker text box
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 818);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 20);
            this.textBox1.TabIndex = 15;
            // 
            // Ticker label
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 802);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Ticker";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Start time label
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(301, 802);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Start Time";
            // 
            // end time label
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 802);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "End Time";
            // 
            // ensuring users only put in valid date formats for start time
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(277, 818);
            this.maskedTextBox1.Mask = "0000-00-00 00:00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 22;
            // 
            // ensuring users only put in valid date formats for end time
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(384, 818);
            this.maskedTextBox2.Mask = "0000-00-00 00:00";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox2.TabIndex = 23;
            // 
            // perform lengthy compute button - meant to simulate 30sec of compute time
            // 
            this.button2.Location = new System.Drawing.Point(946, 481);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 30);
            this.button2.TabIndex = 24;
            this.button2.Text = "Perform Computation";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // progress bar for the lengthy compute function 
            // 
            this.progressBar1.Location = new System.Drawing.Point(946, 518);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(166, 23);
            this.progressBar1.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1622, 850);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.buttonSimulateRecordInsertion);
            this.Controls.Add(this.buttonDecreaseAsk);
            this.Controls.Add(this.buttonIncreaseAsk);
            this.Controls.Add(this.buttonDecreaseBid);
            this.Controls.Add(this.buttonIncreaseBid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Pricer GUI";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonIncreaseBid;
        private System.Windows.Forms.Button buttonDecreaseBid;
        private System.Windows.Forms.Button buttonIncreaseAsk;
        private System.Windows.Forms.Button buttonDecreaseAsk;
        private System.Windows.Forms.Button buttonSimulateRecordInsertion;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
