using System;
using System.Drawing;
using System.Windows.Forms;

namespace LogsDataGridView
{

    public class Entity
    {
        public class logitem
        {
            public logitem()
            {
                time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff");
            }

            public string time { get; set; }
            public string message { get; set; }

        }
        public class logUIitem
        {
            public DataGridView dataGridView { get; set; }
            public int LimitDisplay { get; set; }
            public System.Windows.Forms.ContainerControl Control { get; set; }

        }

    }

    public class Ui
    {
        public class Columns
        {


        }
        public class Load
        {

        }

        public class Const
        {



        }


    }


    public class DgvLog
    {
        public LogsDataGridView.Entity.logUIitem Root = new Entity.logUIitem();

        public DgvLog(DataGridView dataGridView, UserControl Control)
        {
            Root.dataGridView = dataGridView;
            Root.Control = Control;

            ColumnsInit();
        }

        public bool ColumnsInit()
        {
            Root.dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { Name = "obj", HeaderText = "对象", Width = 0 });
            Root.dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { Name = "logid", HeaderText = "日志编号", Width = 80 });
            Root.dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { Name = "time", HeaderText = "时间", Width = 160 });
            Root.dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { Name = "message", HeaderText = "日志内容", Width = 800 });
            Root.dataGridView.Columns[0].Visible = false;
            Root.dataGridView.AllowUserToAddRows = false;
            Root.dataGridView.BackgroundColor = Color.White;

            return true;

        }


        public bool LimitDisplayClear()
        {

            Root.Control.Invoke((EventHandler)delegate
            {
                Application.DoEvents();

                if (Root.dataGridView.Rows.Count >= Root.LimitDisplay)
                {
                    Root.dataGridView.Rows.Clear();
                }
            });

            return true;

        }

        public bool Insert(LogsDataGridView.Entity.logitem logitem)
        {

            Root.Control.Invoke((EventHandler)delegate
            {
                Application.DoEvents();

                Root.dataGridView.Rows.Insert(0, logitem, (Root.dataGridView.Rows.Count + 1).ToString("D5"), logitem.time, logitem.message);
            });

            return true;

        }

    }


}
