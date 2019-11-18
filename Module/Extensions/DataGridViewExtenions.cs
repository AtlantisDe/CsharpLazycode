using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CsharpLazycode.Module.Extensions
{ 
}


public static class DataGridViewExtenions
{

    public static bool SetConfigOften(this DataGridView dataGridView)
    {

        try
        { 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.BackgroundColor = Color.White;

        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }

        return true;
    }


    public static bool Columns_add_simple(this DataGridView dataGridView, string name = "obj", string HeaderText = "对象", int Width = 0, bool Visible = true)
    {

        try
        {
            var col = new DataGridViewTextBoxColumn() { Name = name, HeaderText = HeaderText, Width = Width };
            col.Visible = Visible; 
            dataGridView.Columns.Add(col);

        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }

        return true;
    }



}

