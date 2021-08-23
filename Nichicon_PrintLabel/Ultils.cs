using Microsoft.Win32;
using Nichicon_PrintLabel.DAL;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nichicon_PrintLabel
{
    public static class Ultils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetRunningVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public static void Write(string path, string content)
        {
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(content);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="line_del"></param>
        public static void RemoveLine(string path, string line_del)
        {
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(path))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != line_del)
                        sw.WriteLine(line);
                }
            }
            File.Delete(path);
            File.Move(tempFile, path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        public static void CreateFolder(string path, string fileName)
        {
            bool exists = Directory.Exists(path);
            if (!exists)
            {
                Directory.CreateDirectory(path);
                string fullPath = $@"{path}\{fileName}.txt";
                if (!File.Exists(fileName))
                    File.Create(fullPath).Dispose();
            }
            else
            {
                string fullPath = $@"{path}\{fileName}.txt";
                if (!File.Exists(fileName))
                    File.Create(fullPath).Dispose();
            }
        }

        public static List<string> ReadAllLines(string path, Encoding encoding)
        {
            List<string> lines = new List<string>();
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        lines.Add(line);
                    }
                    reader.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return lines;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        /// <param name="newline"></param>
        /// <returns></returns>
        public static string ReadLastLine(string path, Encoding encoding, string newline)
        {
            string line = null;
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (reader.Peek() == -1)
                    {
                        return line;
                    }
                }
                reader.Close();
            }
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int CountLine(string path)
        {
            int count = 0;
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(file))
            {
                while (reader.ReadLine() != null)
                {
                    count++;
                }
                reader.Close();
                return count;
            }
        }
        public static string GetLine(string path, int line)
        {
            string value;
            using (var sr = new StreamReader(path))
            {
                for (int i = 1; i < line; i++)
                {
                    sr.ReadLine();
                }
                value = sr.ReadLine();
                sr.Dispose();
                return value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridIn"></param>
        /// <param name="outputFile"></param>
        public static void WriteCSV(DataGridView gridIn, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(outputFile, true, Encoding.ASCII);

                ////write header rows to csv
                //for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                //{
                //    if (i > 0)
                //    {
                //        swOut.Write(",");
                //    }
                //    swOut.Write(gridIn.Columns[i].HeaderText);
                //}

                //swOut.WriteLine();

                //write DataGridView rows to csv
                for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = gridIn.Rows[j];

                    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");
                        swOut.Write(value);
                    }
                }
                swOut.WriteLine();
                swOut.Close();
            }
        }

        public static void WriteAppendCSV(DataGridView gridIn, bool append, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                // FileMode.Create => ghi đè
                // FileMode.Append => ghi tiếp dòng tiếp theo
                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (StreamWriter swOut = new StreamWriter(fs))
                {
                    //write DataGridView rows to csv
                    for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
                    {
                        if (j > 0)
                        {
                            swOut.WriteLine();
                        }

                        dr = gridIn.Rows[j];

                        for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                        {
                            if (i > 0)
                            {
                                swOut.Write(",");
                            }

                            value = dr.Cells[i].Value.ToString();
                            //replace comma's with spaces
                            value = value.Replace(',', ' ');
                            //replace embedded newlines with spaces
                            value = value.Replace(Environment.NewLine, " ");
                            swOut.Write(value);
                        }
                    }
                    swOut.WriteLine();
                    swOut.Close();
                }
            }
        }
        public static void WriteTxtFromDataGridView(DataGridView gridIn, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(outputFile, false, Encoding.ASCII);
                //write DataGridView rows to csv
                for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }
                    dr = gridIn.Rows[j];
                    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");
                        swOut.Write(value);
                    }
                }
                swOut.WriteLine();
                swOut.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="content"></param>
        public static void WriteRegistry(string rootKey, string keyName, string content)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{rootKey}");
            if (!string.IsNullOrEmpty(keyName) && !string.IsNullOrEmpty(content))
            {
                key.SetValue(keyName, content);
                key.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="content"></param>
        public static void WriteRegistryArray(string rootKey, string keyName, string content)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{rootKey}");
            if (!string.IsNullOrEmpty(keyName) && !string.IsNullOrEmpty(content))
            {
                string exitsValue = GetValueRegistryKey(rootKey, keyName);
                if (exitsValue != null)
                {
                    exitsValue += content + ";";
                    key.SetValue(keyName, exitsValue);
                }
                else
                {
                    key.SetValue(keyName, content + ";");
                }
                key.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetValueRegistryKey(string rootKey, string keyName)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{rootKey}");
            string value = null;
            if (key != null)
            {
                if (key.GetValue(keyName) != null)
                {
                    value = key.GetValue(keyName).ToString();
                    key.Close();
                    return value;
                }
            }

            return null;
        }
        public static List<Nichicon_HistoriesSerial1> GenericSerial1(Nichicon_model model, string startNo, int qty, Dictionary<string, int> dic, string month)
        {

            List<Nichicon_HistoriesSerial1> result = new List<Nichicon_HistoriesSerial1>();
            PvsService.PVSWebServiceSoapClient _pvs_service = new PvsService.PVSWebServiceSoapClient();
            DateTime now = _pvs_service.GetDateTime();
            string z = startNo.Substring(startNo.Length - 5, 1);
            string y = startNo.Substring(startNo.Length - 4, 4);

            var special = model.Model_Name;
            for (int i = 1; i <= qty; i++)
            {
                int start = Convert.ToInt32($"{dic[z]}{y}") + i;
                var a = start.ToString().Substring(start.ToString().Length - 6, 2);
                string symbol = dic.SingleOrDefault(x => x.Value.ToString() == a).Key;
                var b = start.ToString().Substring(start.ToString().Length - 4, 4);

                if (model.Model_Name.ToUpper().Equals("MPH7747"))
                {
                    result.Add(new Nichicon_HistoriesSerial1()
                    {

                        QR_Code = $"{model.Model_Name}{"   "}{Constant.LOCATION}{Constant.CODE_FACTORY}{now.Year.ToString().Substring((now.Year.ToString()).Length - 1)}{month}{symbol}{start.ToString().Substring(start.ToString().Length - 4, 4)}{" "}",
                        Product_Customer = model.Product_ManagerName,
                        Model = model.Model_Name,
                        Serial = $"{ Constant.LOCATION }{ Constant.CODE_FACTORY }{ now.Year.ToString().Substring((now.Year.ToString()).Length - 1) }{ month }{ symbol }{ start.ToString().Substring(start.ToString().Length - 4, 4) }{ " " }",
                        Country = "MADE IN VIETNAM"
                    });
                    start++;
                }
                else
                {
                    result.Add(new Nichicon_HistoriesSerial1()
                    {
                        QR_Code = $"{model.Model_Name}{"  "}{Constant.LOCATION}{Constant.CODE_FACTORY}{now.Year.ToString().Substring((now.Year.ToString()).Length - 1)}{month}{symbol}{start.ToString().Substring(start.ToString().Length - 4, 4)}{" "}",
                        Product_Customer = model.Product_ManagerName,
                        Model = model.Model_Name,
                        Serial = $"{ Constant.LOCATION }{ Constant.CODE_FACTORY }{ now.Year.ToString().Substring((now.Year.ToString()).Length - 1) }{ month }{ symbol }{ start.ToString().Substring(start.ToString().Length - 4, 4) }{ " " }",
                        Country = "MADE IN VIETNAM"
                    });
                    start++;
                }

            }
            return result;
        }
        public static List<Nichicon_HistoriesSerial2> GenericSerial2(Nichicon_model model, string startNo, int qty, Dictionary<string, int> dic, string month)
        {

            List<Nichicon_HistoriesSerial2> result = new List<Nichicon_HistoriesSerial2>();
            PvsService.PVSWebServiceSoapClient _pvs_service = new PvsService.PVSWebServiceSoapClient();
            DateTime now = _pvs_service.GetDateTime();
            string z = startNo.Substring(startNo.Length - 5, 1);
            string y = startNo.Substring(startNo.Length - 4, 4);

            var special = model.Model_Name;
            for (int i = 1; i <= qty; i++)
            {
                int start = Convert.ToInt32($"{dic[z]}{y}") + i;
                var a = start.ToString().Substring(start.ToString().Length - 6, 2);
                string symbol = dic.SingleOrDefault(x => x.Value.ToString() == a).Key;
                var b = start.ToString().Substring(start.ToString().Length - 4, 4);
                result.Add(new Nichicon_HistoriesSerial2()
                {

                    QR_Code = $"{model.Code_productcustomer}{now.Year.ToString().Substring((now.Year.ToString()).Length - 1)}{month}{symbol}{start.ToString().Substring(start.ToString().Length - 4, 4)}",
                    Product_Customer = model.Product_ManagerName,
                    Model= model.Model_Name,
                    Product_Name= model.Product_Name,
                    Code_productcustomer= model.Code_productcustomer
                });
                start++;
            }
            return result;
        }
        public static string GetNumberStart(string startNo, Dictionary<string, int> dic)
        {
            int start = Convert.ToInt32($"{dic[startNo.PadLeft(1)]}{startNo.PadRight(4)}");
            start++;
            var head = start.ToString().PadLeft(2);
            string symbol = dic.FirstOrDefault(x => x.Value.ToString() == head).Key;
            return $"{ symbol}{start.ToString().PadRight(4)}";
        }


    }
}
