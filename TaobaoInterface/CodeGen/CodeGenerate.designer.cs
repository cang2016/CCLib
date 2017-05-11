namespace CodeGen
{
    partial class CodeGenerate
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gpbDatabase = new System.Windows.Forms.GroupBox();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblCurrentServerValue = new System.Windows.Forms.Label();
            this.lblCurrentServer = new System.Windows.Forms.Label();
            this.gpbTable = new System.Windows.Forms.GroupBox();
            this.ltbSelTables = new System.Windows.Forms.ListBox();
            this.btnReSel = new System.Windows.Forms.Button();
            this.btnReSelAll = new System.Windows.Forms.Button();
            this.btnSelOne = new System.Windows.Forms.Button();
            this.btnSelAll = new System.Windows.Forms.Button();
            this.ltbSourceTable = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbGenerate = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.lblClassName = new System.Windows.Forms.Label();
            this.btnSelFolder = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.lblNameSpace = new System.Windows.Forms.Label();
            this.gpbDatabase.SuspendLayout();
            this.gpbTable.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbDatabase
            // 
            this.gpbDatabase.Controls.Add(this.cmbDatabase);
            this.gpbDatabase.Controls.Add(this.lblDatabase);
            this.gpbDatabase.Controls.Add(this.lblCurrentServerValue);
            this.gpbDatabase.Controls.Add(this.lblCurrentServer);
            this.gpbDatabase.Location = new System.Drawing.Point(0, 31);
            this.gpbDatabase.Name = "gpbDatabase";
            this.gpbDatabase.Size = new System.Drawing.Size(770, 74);
            this.gpbDatabase.TabIndex = 0;
            this.gpbDatabase.TabStop = false;
            this.gpbDatabase.Text = "选择数据库";
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(529, 29);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(150, 20);
            this.cmbDatabase.TabIndex = 3;
            this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(452, 32);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(71, 12);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "选择数据库:";
            // 
            // lblCurrentServerValue
            // 
            this.lblCurrentServerValue.Location = new System.Drawing.Point(168, 32);
            this.lblCurrentServerValue.Name = "lblCurrentServerValue";
            this.lblCurrentServerValue.Size = new System.Drawing.Size(134, 23);
            this.lblCurrentServerValue.TabIndex = 1;
            // 
            // lblCurrentServer
            // 
            this.lblCurrentServer.AutoSize = true;
            this.lblCurrentServer.Location = new System.Drawing.Point(91, 32);
            this.lblCurrentServer.Name = "lblCurrentServer";
            this.lblCurrentServer.Size = new System.Drawing.Size(71, 12);
            this.lblCurrentServer.TabIndex = 0;
            this.lblCurrentServer.Text = "当前服务器:";
            // 
            // gpbTable
            // 
            this.gpbTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbTable.Controls.Add(this.ltbSelTables);
            this.gpbTable.Controls.Add(this.btnReSel);
            this.gpbTable.Controls.Add(this.btnReSelAll);
            this.gpbTable.Controls.Add(this.btnSelOne);
            this.gpbTable.Controls.Add(this.btnSelAll);
            this.gpbTable.Controls.Add(this.ltbSourceTable);
            this.gpbTable.Location = new System.Drawing.Point(0, 111);
            this.gpbTable.Name = "gpbTable";
            this.gpbTable.Size = new System.Drawing.Size(771, 287);
            this.gpbTable.TabIndex = 1;
            this.gpbTable.TabStop = false;
            this.gpbTable.Text = "选择表";
            // 
            // ltbSelTables
            // 
            this.ltbSelTables.FormattingEnabled = true;
            this.ltbSelTables.ItemHeight = 12;
            this.ltbSelTables.Location = new System.Drawing.Point(455, 15);
            this.ltbSelTables.Name = "ltbSelTables";
            this.ltbSelTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ltbSelTables.Size = new System.Drawing.Size(315, 268);
            this.ltbSelTables.TabIndex = 5;
            // 
            // btnReSel
            // 
            this.btnReSel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReSel.Location = new System.Drawing.Point(348, 214);
            this.btnReSel.Name = "btnReSel";
            this.btnReSel.Size = new System.Drawing.Size(75, 23);
            this.btnReSel.TabIndex = 4;
            this.btnReSel.Text = "<";
            this.btnReSel.UseVisualStyleBackColor = true;
            this.btnReSel.Click += new System.EventHandler(this.btnReSel_Click);
            // 
            // btnReSelAll
            // 
            this.btnReSelAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReSelAll.Location = new System.Drawing.Point(348, 166);
            this.btnReSelAll.Name = "btnReSelAll";
            this.btnReSelAll.Size = new System.Drawing.Size(75, 23);
            this.btnReSelAll.TabIndex = 3;
            this.btnReSelAll.Text = "<<";
            this.btnReSelAll.UseVisualStyleBackColor = true;
            this.btnReSelAll.Click += new System.EventHandler(this.btnReSelAll_Click);
            // 
            // btnSelOne
            // 
            this.btnSelOne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelOne.Location = new System.Drawing.Point(348, 118);
            this.btnSelOne.Name = "btnSelOne";
            this.btnSelOne.Size = new System.Drawing.Size(75, 23);
            this.btnSelOne.TabIndex = 2;
            this.btnSelOne.Text = ">";
            this.btnSelOne.UseVisualStyleBackColor = true;
            this.btnSelOne.Click += new System.EventHandler(this.btnSelOne_Click);
            // 
            // btnSelAll
            // 
            this.btnSelAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelAll.Location = new System.Drawing.Point(348, 70);
            this.btnSelAll.Name = "btnSelAll";
            this.btnSelAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelAll.TabIndex = 1;
            this.btnSelAll.Text = ">>";
            this.btnSelAll.UseVisualStyleBackColor = true;
            this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
            // 
            // ltbSourceTable
            // 
            this.ltbSourceTable.FormattingEnabled = true;
            this.ltbSourceTable.ItemHeight = 12;
            this.ltbSourceTable.Location = new System.Drawing.Point(0, 15);
            this.ltbSourceTable.Name = "ltbSourceTable";
            this.ltbSourceTable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ltbSourceTable.Size = new System.Drawing.Size(315, 268);
            this.ltbSourceTable.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbGenerate);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnGenerate);
            this.groupBox3.Controls.Add(this.txtClassName);
            this.groupBox3.Controls.Add(this.lblClassName);
            this.groupBox3.Controls.Add(this.btnSelFolder);
            this.groupBox3.Controls.Add(this.txtFolder);
            this.groupBox3.Controls.Add(this.lblFolder);
            this.groupBox3.Controls.Add(this.txtNameSpace);
            this.groupBox3.Controls.Add(this.lblNameSpace);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 404);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(771, 240);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "参数设定";
            // 
            // pbGenerate
            // 
            this.pbGenerate.Location = new System.Drawing.Point(93, 159);
            this.pbGenerate.Name = "pbGenerate";
            this.pbGenerate.Size = new System.Drawing.Size(418, 18);
            this.pbGenerate.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(639, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerate.ForeColor = System.Drawing.Color.Red;
            this.btnGenerate.Location = new System.Drawing.Point(542, 154);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "生成代码";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(157, 83);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(132, 21);
            this.txtClassName.TabIndex = 6;
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Location = new System.Drawing.Point(91, 86);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(59, 12);
            this.lblClassName.TabIndex = 5;
            this.lblClassName.Text = "特性名称:";
            // 
            // btnSelFolder
            // 
            this.btnSelFolder.Location = new System.Drawing.Point(680, 32);
            this.btnSelFolder.Name = "btnSelFolder";
            this.btnSelFolder.Size = new System.Drawing.Size(31, 23);
            this.btnSelFolder.TabIndex = 4;
            this.btnSelFolder.Text = "...";
            this.btnSelFolder.UseVisualStyleBackColor = true;
            this.btnSelFolder.Click += new System.EventHandler(this.btnSelFolder_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(517, 34);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(162, 21);
            this.txtFolder.TabIndex = 3;
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(452, 37);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(59, 12);
            this.lblFolder.TabIndex = 2;
            this.lblFolder.Text = "输出路径:";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(157, 34);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(132, 21);
            this.txtNameSpace.TabIndex = 1;
            // 
            // lblNameSpace
            // 
            this.lblNameSpace.AutoSize = true;
            this.lblNameSpace.Location = new System.Drawing.Point(91, 37);
            this.lblNameSpace.Name = "lblNameSpace";
            this.lblNameSpace.Size = new System.Drawing.Size(59, 12);
            this.lblNameSpace.TabIndex = 0;
            this.lblNameSpace.Text = "命名空间:";
            // 
            // CodeGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 644);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gpbTable);
            this.Controls.Add(this.gpbDatabase);
            this.Name = "CodeGenerate";
            this.Text = "代码生成器";
            this.Load += new System.EventHandler(this.CodeGenerate_Load);
            this.gpbDatabase.ResumeLayout(false);
            this.gpbDatabase.PerformLayout();
            this.gpbTable.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbDatabase;
        private System.Windows.Forms.GroupBox gpbTable;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblCurrentServerValue;
        private System.Windows.Forms.Label lblCurrentServer;
        private System.Windows.Forms.ListBox ltbSelTables;
        private System.Windows.Forms.Button btnReSel;
        private System.Windows.Forms.Button btnReSelAll;
        private System.Windows.Forms.Button btnSelOne;
        private System.Windows.Forms.Button btnSelAll;
        private System.Windows.Forms.ListBox ltbSourceTable;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Button btnSelFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label lblNameSpace;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ProgressBar pbGenerate;
    }
}

