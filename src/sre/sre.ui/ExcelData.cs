using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using Excel;

namespace sre.ui
{
    public class ExcelData
    {
        public static IEnumerable<DataRow> GetData(string path, bool isFirstRowAsColumnNames = true, params string[] workSheets)
        {
            var rows = new List<DataRow>();
            try
            {
                foreach (DataTable worksheet in GetExcelWorkSheets(path, isFirstRowAsColumnNames, workSheets))
                {
                    rows.AddRange(worksheet.Rows.Cast<DataRow>());
                }
            }
            catch (IOException)
            {
                MessageBox.Show(string.Format("Please close the file:{0}", Path.GetFileName(path)));
            }
            return rows;
        }

        private static IEnumerable<DataTable> GetExcelWorkSheets(string path, bool isFirstRowAsColumnNames, params string[] workSheets)
        {
            DataSet dataSet = GetExcelDataAsDataSet(path, isFirstRowAsColumnNames);
            if (dataSet.Tables.Count == 0)
            {
                throw new Exception("No sheets exist");
            }

            var tables = new List<DataTable>();

            tables.AddRange(workSheets.Length == 0
                                ? dataSet.Tables.Cast<DataTable>()
                                : dataSet.Tables.Cast<DataTable>().Where(dataTable => workSheets.Contains(dataTable.TableName.Trim())));
            return tables;
        }

        private static DataSet GetExcelDataAsDataSet(string path, bool isFirstRowAsColumnNames)
        {
            return GetExcelDataReader(path, isFirstRowAsColumnNames).AsDataSet();
        }

        private static IExcelDataReader GetExcelDataReader(string path, bool isFirstRowAsColumnNames)
        {
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader dataReader;

                if (path.EndsWith(".xls"))
                {
                    dataReader = ExcelReaderFactory.CreateBinaryReader(fileStream);
                }
                else if (path.EndsWith(".xlsx"))
                {
                    dataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
                }
                else
                {
                    //Throw exception for things you cannot correct
                    throw new Exception("The file to be processed is not an Excel file");
                }

                dataReader.IsFirstRowAsColumnNames = isFirstRowAsColumnNames;

                return dataReader;
            }
        }
    }
}