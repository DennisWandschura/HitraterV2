namespace Gui
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
            this.numericUpDownSpread = new NumericUpDownFix();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownSpreadInc = new NumericUpDownFix();
            this.numericUpDownMaxSpread = new NumericUpDownFix();
            this.numericUpDownAimX = new NumericUpDownFix();
            this.numericUpDownAimY = new NumericUpDownFix();
            this.numericUpDownDistance = new NumericUpDownFix();
            this.numericUpDownRecoilX = new NumericUpDownFix();
            this.numericUpDownBustLength = new NumericUpDownFix();
            this.numericUpDownIterations = new NumericUpDownFix();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDownRecoilY = new NumericUpDownFix();
            this.treeViewBody = new System.Windows.Forms.TreeView();
            this.treeViewHead = new System.Windows.Forms.TreeView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelSumBody = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelSumHead = new System.Windows.Forms.Label();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpreadInc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAimX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAimY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecoilX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBustLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecoilY)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel9.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel10.SuspendLayout();
            this.flowLayoutPanel11.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDownSpread
            // 
            this.numericUpDownSpread.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownSpread.DecimalPlaces = 6;
            this.numericUpDownSpread.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownSpread.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownSpread.Name = "numericUpDownSpread";
            this.numericUpDownSpread.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSpread.TabIndex = 0;
            this.numericUpDownSpread.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Spread:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Spread Increase:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(3, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Aim:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(3, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Max Spread:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(3, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Distance:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(3, 81);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Recoil:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(3, 159);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Iterations:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(3, 185);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Burst Length:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownSpreadInc
            // 
            this.numericUpDownSpreadInc.DecimalPlaces = 6;
            this.numericUpDownSpreadInc.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownSpreadInc.Location = new System.Drawing.Point(3, 55);
            this.numericUpDownSpreadInc.Name = "numericUpDownSpreadInc";
            this.numericUpDownSpreadInc.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSpreadInc.TabIndex = 9;
            this.numericUpDownSpreadInc.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numericUpDownMaxSpread
            // 
            this.numericUpDownMaxSpread.DecimalPlaces = 6;
            this.numericUpDownMaxSpread.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownMaxSpread.Location = new System.Drawing.Point(3, 29);
            this.numericUpDownMaxSpread.Name = "numericUpDownMaxSpread";
            this.numericUpDownMaxSpread.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMaxSpread.TabIndex = 10;
            this.numericUpDownMaxSpread.Value = new decimal(new int[] {
            17,
            0,
            0,
            65536});
            // 
            // numericUpDownAimX
            // 
            this.numericUpDownAimX.DecimalPlaces = 4;
            this.numericUpDownAimX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownAimX.Location = new System.Drawing.Point(0, 0);
            this.numericUpDownAimX.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.numericUpDownAimX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownAimX.Name = "numericUpDownAimX";
            this.numericUpDownAimX.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownAimX.TabIndex = 11;
            // 
            // numericUpDownAimY
            // 
            this.numericUpDownAimY.DecimalPlaces = 4;
            this.numericUpDownAimY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownAimY.Location = new System.Drawing.Point(126, 0);
            this.numericUpDownAimY.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.numericUpDownAimY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownAimY.Name = "numericUpDownAimY";
            this.numericUpDownAimY.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownAimY.TabIndex = 12;
            // 
            // numericUpDownDistance
            // 
            this.numericUpDownDistance.DecimalPlaces = 2;
            this.numericUpDownDistance.Location = new System.Drawing.Point(3, 133);
            this.numericUpDownDistance.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownDistance.Name = "numericUpDownDistance";
            this.numericUpDownDistance.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDistance.TabIndex = 13;
            this.numericUpDownDistance.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownRecoilX
            // 
            this.numericUpDownRecoilX.DecimalPlaces = 6;
            this.numericUpDownRecoilX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownRecoilX.Location = new System.Drawing.Point(0, 0);
            this.numericUpDownRecoilX.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.numericUpDownRecoilX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownRecoilX.Name = "numericUpDownRecoilX";
            this.numericUpDownRecoilX.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRecoilX.TabIndex = 14;
            this.numericUpDownRecoilX.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147418112});
            // 
            // numericUpDownBustLength
            // 
            this.numericUpDownBustLength.Location = new System.Drawing.Point(3, 185);
            this.numericUpDownBustLength.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownBustLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBustLength.Name = "numericUpDownBustLength";
            this.numericUpDownBustLength.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownBustLength.TabIndex = 15;
            this.numericUpDownBustLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownIterations
            // 
            this.numericUpDownIterations.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownIterations.Location = new System.Drawing.Point(3, 159);
            this.numericUpDownIterations.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.numericUpDownIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownIterations.Name = "numericUpDownIterations";
            this.numericUpDownIterations.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownIterations.TabIndex = 16;
            this.numericUpDownIterations.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDownRecoilY
            // 
            this.numericUpDownRecoilY.DecimalPlaces = 6;
            this.numericUpDownRecoilY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownRecoilY.Location = new System.Drawing.Point(126, 0);
            this.numericUpDownRecoilY.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.numericUpDownRecoilY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownRecoilY.Name = "numericUpDownRecoilY";
            this.numericUpDownRecoilY.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRecoilY.TabIndex = 18;
            this.numericUpDownRecoilY.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // treeViewBody
            // 
            this.treeViewBody.Location = new System.Drawing.Point(5, 3);
            this.treeViewBody.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.treeViewBody.Name = "treeViewBody";
            this.treeViewBody.Size = new System.Drawing.Size(150, 175);
            this.treeViewBody.TabIndex = 19;
            // 
            // treeViewHead
            // 
            this.treeViewHead.Location = new System.Drawing.Point(161, 3);
            this.treeViewHead.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.treeViewHead.Name = "treeViewHead";
            this.treeViewHead.Size = new System.Drawing.Size(150, 175);
            this.treeViewHead.TabIndex = 20;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 281);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(63, 17);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Old Dist";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.numericUpDownRecoilX);
            this.flowLayoutPanel4.Controls.Add(this.numericUpDownRecoilY);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 81);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(261, 20);
            this.flowLayoutPanel4.TabIndex = 26;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.numericUpDownAimX);
            this.flowLayoutPanel5.Controls.Add(this.numericUpDownAimY);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 107);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(261, 20);
            this.flowLayoutPanel5.TabIndex = 27;
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.Controls.Add(this.treeViewBody);
            this.flowLayoutPanel9.Controls.Add(this.treeViewHead);
            this.flowLayoutPanel9.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel9.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel9.Location = new System.Drawing.Point(15, 355);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(316, 228);
            this.flowLayoutPanel9.TabIndex = 31;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.labelSumBody);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 184);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(152, 30);
            this.flowLayoutPanel2.TabIndex = 23;
            // 
            // labelSumBody
            // 
            this.labelSumBody.AutoSize = true;
            this.labelSumBody.Location = new System.Drawing.Point(3, 0);
            this.labelSumBody.Name = "labelSumBody";
            this.labelSumBody.Size = new System.Drawing.Size(24, 13);
            this.labelSumBody.TabIndex = 21;
            this.labelSumBody.Text = "0 %";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.labelSumHead);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(161, 184);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(150, 30);
            this.flowLayoutPanel3.TabIndex = 24;
            // 
            // labelSumHead
            // 
            this.labelSumHead.AutoSize = true;
            this.labelSumHead.Location = new System.Drawing.Point(3, 0);
            this.labelSumHead.Name = "labelSumHead";
            this.labelSumHead.Size = new System.Drawing.Size(24, 13);
            this.labelSumHead.TabIndex = 22;
            this.labelSumHead.Text = "0 %";
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.Controls.Add(this.label1);
            this.flowLayoutPanel10.Controls.Add(this.label4);
            this.flowLayoutPanel10.Controls.Add(this.label2);
            this.flowLayoutPanel10.Controls.Add(this.label6);
            this.flowLayoutPanel10.Controls.Add(this.label3);
            this.flowLayoutPanel10.Controls.Add(this.label5);
            this.flowLayoutPanel10.Controls.Add(this.label7);
            this.flowLayoutPanel10.Controls.Add(this.label8);
            this.flowLayoutPanel10.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(96, 215);
            this.flowLayoutPanel10.TabIndex = 32;
            // 
            // flowLayoutPanel11
            // 
            this.flowLayoutPanel11.Controls.Add(this.numericUpDownSpread);
            this.flowLayoutPanel11.Controls.Add(this.numericUpDownMaxSpread);
            this.flowLayoutPanel11.Controls.Add(this.numericUpDownSpreadInc);
            this.flowLayoutPanel11.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel11.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel11.Controls.Add(this.numericUpDownDistance);
            this.flowLayoutPanel11.Controls.Add(this.numericUpDownIterations);
            this.flowLayoutPanel11.Controls.Add(this.numericUpDownBustLength);
            this.flowLayoutPanel11.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel11.Location = new System.Drawing.Point(105, 3);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Size = new System.Drawing.Size(272, 215);
            this.flowLayoutPanel11.TabIndex = 33;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel10);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel11);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 49);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(382, 226);
            this.flowLayoutPanel1.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 620);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel9);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Hitrater";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpreadInc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAimX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAimY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecoilX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBustLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecoilY)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel10.ResumeLayout(false);
            this.flowLayoutPanel11.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownSpread;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownSpreadInc;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxSpread;
        private System.Windows.Forms.NumericUpDown numericUpDownAimX;
        private System.Windows.Forms.NumericUpDown numericUpDownAimY;
        private System.Windows.Forms.NumericUpDown numericUpDownDistance;
        private System.Windows.Forms.NumericUpDown numericUpDownRecoilX;
        private System.Windows.Forms.NumericUpDown numericUpDownBustLength;
        private System.Windows.Forms.NumericUpDown numericUpDownIterations;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDownRecoilY;
        private System.Windows.Forms.TreeView treeViewBody;
        private System.Windows.Forms.TreeView treeViewHead;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelSumBody;
        private System.Windows.Forms.Label labelSumHead;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

