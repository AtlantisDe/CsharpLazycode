using System;
using System.Drawing;
using System.Windows.Forms;

namespace LogsDataGridView
{

    public class Entity
    {
        public class Logitem
        {
            public Logitem()
            {
                Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff");
            }

            public string Time { get; set; }
            public string Message { get; set; }

        }
        public class LogUIitem
        {
            public DataGridView DataGridView { get; set; }
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
        public LogsDataGridView.Entity.LogUIitem Root = new Entity.LogUIitem();

        public DgvLog(DataGridView dataGridView, UserControl Control)
        {
            Root.DataGridView = dataGridView;
            Root.Control = Control;

            ColumnsInit();
        }

        public bool ColumnsInit()
        {
            Root.DataGridView.Columns.Add(new DataGridViewTextBoxColumn() { Name = "obj", HeaderText = "对象", Width = 0 });
            Root.DataGridView.Columns.Add(new DataGridViewTextBoxColumn() { Name = "logid", HeaderText = "日志编号", Width = 80 });
            Root.DataGridView.Columns.Add(new DataGridViewTextBoxColumn() { Name = "time", HeaderText = "时间", Width = 160 });
            Root.DataGridView.Columns.Add(new DataGridViewTextBoxColumn() { Name = "message", HeaderText = "日志内容", Width = 800 });
            Root.DataGridView.Columns[0].Visible = false;
            Root.DataGridView.AllowUserToAddRows = false;
            Root.DataGridView.BackgroundColor = Color.White;

            return true;

        }


        public bool LimitDisplayClear()
        {

            Root.Control.Invoke((EventHandler)delegate
            {
                Application.DoEvents();

                if (Root.DataGridView.Rows.Count >= Root.LimitDisplay)
                {
                    Root.DataGridView.Rows.Clear();
                }
            });

            return true;

        }

        public bool Insert(LogsDataGridView.Entity.Logitem logitem)
        {

            Root.Control.Invoke((EventHandler)delegate
            {
                Application.DoEvents();

                Root.DataGridView.Rows.Insert(0, logitem, (Root.DataGridView.Rows.Count + 1).ToString("D5"), logitem.Time, logitem.Message);
            });

            return true;

        }

    }


}
