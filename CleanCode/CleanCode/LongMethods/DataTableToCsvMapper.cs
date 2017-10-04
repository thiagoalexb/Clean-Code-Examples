using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.LongMethods
{
    class DataTableToCsvMapper
    {
        public System.IO.MemoryStream Map()
        {
            MemoryStream ReturnStream = new MemoryStream();

            DataTable dt = TableReader.GetDataTable();

            StreamWriter sw = new StreamWriter(ReturnStream);

            WriteColumnNames(dt, sw);

            WriteRows(dt, sw);

            sw.Flush();
            sw.Close();

            return ReturnStream;
        }

        private static void WriteColumnNames(DataTable dt, StreamWriter sw)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < dt.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.WriteLine();
        }

        private static void WriteRows(DataTable dt, StreamWriter sw)
        {
            foreach (DataRow dr in dt.Rows)
            {
                
                sw.WriteLine();
            }
        }

        private static void WriteRow(DataTable dt, StreamWriter sw, DataRow dr)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                WriteCell(dt, sw, dr, i);
                WriteSeparetorIfRequired(dt, sw, dr, i);
            }
        }

        private static void WriteCell(DataTable dt, StreamWriter sw, DataRow dr, int i)
        {
            if (!Convert.IsDBNull(dr[i]))
            {
                string str = String.Format("\"{0:c}\"", dr[i].ToString()).Replace("\r\n", " ");
                sw.Write(str);
            }
            else
            {
                sw.Write("");
            }
        }

        private static void WriteSeparetorIfRequired(DataTable dt, StreamWriter sw, DataRow dr, int i)
        {
            if (i < dt.Columns.Count - 1)
            {
                sw.Write(",");
            }
        }
    }
}
