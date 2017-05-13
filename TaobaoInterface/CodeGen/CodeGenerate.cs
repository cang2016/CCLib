using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using DataBase;

namespace CodeGen
{
    public partial class CodeGenerate : Form
    {
        CodeGenerateControl codeGenerate = null;
        public CodeGenerate()
        {
            InitializeComponent();
        }

        private void CodeGenerate_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        private void BindControls()
        {
            codeGenerate = new CodeGenerateControl();
            this.lblCurrentServerValue.Text = codeGenerate.GetServerName();

            BindDatabases(codeGenerate);

            //codeGenerate.GetTablesInDatabase();
        }

        private void BindDatabases(CodeGenerateControl codeGenerate)
        {
            this.cmbDatabase.ValueMember = "Id";
            this.cmbDatabase.DisplayMember = "Name";
            this.cmbDatabase.DataSource = codeGenerate.GetDatabases();
        }

        private void BindListBox(CodeGenerateControl codeGenerate, string dataBaseName)
        {
            List<string> tableNameList = codeGenerate.GetTableNamesInDatabase(dataBaseName);
            if (this.ltbSourceTable.Items.Count > 0 || this.ltbSelTables.Items.Count > 0)
            {
                this.ltbSourceTable.Items.Clear();
                this.ltbSelTables.Items.Clear();
            }

            tableNameList.ForEach(each => this.ltbSourceTable.Items.Add(each));
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            CodeGenerateControl codeGenerate = new CodeGenerateControl();
            BindListBox(codeGenerate, this.cmbDatabase.Text);
        }

        private void btnSelAll_Click(object sender, EventArgs e)
        {
            SelectTableName(ltbSourceTable, ltbSelTables, false);
        }

        private void SelectTableName(ListBox firstListBox, ListBox secondListBox, bool notAllItems = true)
        {
            if (notAllItems)
            {
                for (int itemIndex = firstListBox.SelectedItems.Count - 1; itemIndex > -1; itemIndex--)
                {
                    if (!secondListBox.Items.Contains(firstListBox.SelectedItems[itemIndex]))
                    {
                        secondListBox.Items.Add(firstListBox.SelectedItems[itemIndex]);
                    }

                    firstListBox.Items.Remove(firstListBox.SelectedItems[itemIndex]);
                }
            }
            else
            {
                for (int itemIndex = firstListBox.Items.Count - 1; itemIndex > -1; itemIndex--)
                {
                    if (!secondListBox.Items.Contains(firstListBox.Items[itemIndex]))
                    {
                        secondListBox.Items.Add(firstListBox.Items[itemIndex]);
                    }

                    firstListBox.Items.RemoveAt(itemIndex);
                }

            }
        }

        private void btnSelOne_Click(object sender, EventArgs e)
        {
            SelectTableName(ltbSourceTable, ltbSelTables);
        }

        private void btnReSelAll_Click(object sender, EventArgs e)
        {
            SelectTableName(ltbSelTables, ltbSourceTable, false);
        }

        private void btnReSel_Click(object sender, EventArgs e)
        {
            SelectTableName(ltbSelTables, ltbSourceTable);
        }

        private void btnSelFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            if (!string.IsNullOrWhiteSpace(txtFolder.Text))
            {
                folderDlg.SelectedPath = this.txtFolder.Text;
            }

            if (folderDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFolder.Text = folderDlg.SelectedPath;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            bool ret = false;
            DialogResult dlg = MessageBox.Show("确定要生成代码吗?", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (DialogResult.OK == dlg)
            {
                string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                if (!connStr.Contains(this.cmbDatabase.SelectedItem.ToString()))
                {
                    System.Data.SqlClient.SqlConnectionStringBuilder sqlConnBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                    var conns = connStr.Split(new char[] { ';' }).ToDictionary(k => k.Split(new char[] { '=' })[0].Trim(), v => v);
                    sqlConnBuilder.DataSource = conns["Data Source"].Split(new char[] { '=' })[1].Trim();
                    sqlConnBuilder.InitialCatalog = this.cmbDatabase.SelectedItem.ToString();
                    sqlConnBuilder.UserID = conns["User ID"].Split(new char[] { '=' })[1];
                    sqlConnBuilder.Password = conns["Password"].Split(new char[] { '=' })[1].Trim();

                    IDbConnection conn = new System.Data.SqlClient.SqlConnection(sqlConnBuilder.ToString());

                    codeGenerate.database = new Database(conn, DataBase.Database.DBType.SqlServer);
                }


                GenerateCode gc = new GenerateCode();
                //codeGenerate = new CodeGenerateControl();
                List<DataTable> tableList = codeGenerate.GetTablesInDatabase(GetTableNameList());



                if (string.IsNullOrWhiteSpace(txtFolder.Text) || string.IsNullOrWhiteSpace(txtNameSpace.Text))
                {
                    MessageBox.Show("文件夹或命名空间不能为空");
                    return;
                }

                ret = gc.GenerateClassCode(tableList, txtNameSpace.Text, txtFolder.Text, txtClassName.Text.Trim());
            }

            if (ret)
            {
                MessageBox.Show("生成成功", "信息提示");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private List<string> GetTableNameList()
        {
            List<string> tableNameList = new List<string>();
            if (ltbSelTables.Items.Count > 0)
            {
                foreach (var item in ltbSelTables.Items)
                {
                    tableNameList.Add(item.ToString());
                }
            }

            return tableNameList;
        }
    }
}
