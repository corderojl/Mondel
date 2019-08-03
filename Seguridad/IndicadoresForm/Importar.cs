using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;

namespace IndicadoresForm
{
    public class Importar
    {
        OleDbConnection conn;
        OleDbDataAdapter MyDataAdapter;
        DataTable dt;

        public DataTable traerExcel(String nombreHoja)
        {
            String extension = "", ruta = "";
            try
            {
                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "Excel Files xlsx |*.xlsx|Excel File xls |*.xls";
                openfile1.Title = "Seleccione el archivo de Excel";
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openfile1.FileName.Equals("") == false)
                    {
                        ruta = openfile1.FileName;
                        extension = Path.GetExtension(ruta);
                    }
                }
                //if (extension == "xmls")
                //{
                    conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + ruta + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'");
                    MyDataAdapter = new OleDbDataAdapter("Select * from [" + nombreHoja + "$]", conn);
                    dt = new DataTable();
                    MyDataAdapter.Fill(dt);

                    // return dt;
                //}
                //else
                //    dt = TraerXML(ruta);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }       
    }
}
