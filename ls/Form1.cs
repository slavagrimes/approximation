using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Accord.Statistics;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ls
{
    public partial class Form1 : Form
    {
        private double[] result;
        private double[,] xyTable, matrix;
        public Form1()
        {
            InitializeComponent();
            Table();

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа позволяет выполнить аппроксимацию полиномом 2-5 степени.",
                "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void Table()
        {
            dataGridTable.RowCount = Convert.ToInt32(quantity.Value);
            dataGridTable.ColumnCount = Convert.ToInt32(numericUpDown1.Value);
            for (int a = 0; a < dataGridTable.ColumnCount; a++)
            {
                for (int i = 0; i < dataGridTable.RowCount; i++)
                {
                    dataGridTable[a, i].ValueType = System.Type.GetType("System.Double");
                    if (Convert.ToString(dataGridTable[a, i].Value) == "")
                        dataGridTable[a, i].Value = 0;
                }
            }
            foreach (DataGridViewColumn column in dataGridTable.Columns)
            {
                if (column.Index < dataGridTable.ColumnCount - 1)
                    column.HeaderText = $"X{column.Index + 1}";
                else column.HeaderText = $"Y";
            }
        }
        
        private double[] Gauss(double[,] matrix, int rowCount, int colCount)
        {
            int i;
            int[] mask = new int[colCount - 1];
            for (i = 0; i < colCount - 1; i++) mask[i] = i;
            if (GaussDirectPass(ref matrix, ref mask, colCount, rowCount))
            {
                double[] answer = GaussReversePass(ref matrix, mask, colCount, rowCount);
                return answer;
            }
            else return null;
        }
        
        private bool GaussDirectPass(ref double[,] matrix, ref int[] mask, int colCount, int rowCount)
        {
            int i, j, k, maxId, tmpInt;
            double maxVal, tempDouble;
            for (i = 0; i < rowCount; i++)
            {
                maxId = i;
                maxVal = matrix[i, i];
                for (j = i + 1; j < colCount - 1; j++)
                    if (Math.Abs(maxVal) < Math.Abs(matrix[i, j]))
                    {
                        maxVal = matrix[i, j];
                        maxId = j;
                    }
                if (maxVal == 0) return false;
                if (i != maxId)
                {
                    for (j = 0; j < rowCount; j++)
                    {
                        tempDouble = matrix[j, i];
                        matrix[j, i] = matrix[j, maxId];
                        matrix[j, maxId] = tempDouble;
                    }
                    tmpInt = mask[i];
                    mask[i] = mask[maxId];
                    mask[maxId] = tmpInt;
                }
                for (j = 0; j < colCount; j++) matrix[i, j] /= maxVal;
                for (j = i + 1; j < rowCount; j++)
                {
                    double tempMn = matrix[j, i];
                    for (k = 0; k < colCount; k++)
                        matrix[j, k] -= matrix[i, k] * tempMn;
                }
            }
            return true;
        }
        
        private double[] GaussReversePass(ref double[,] matrix, int[] mask, int colCount, int rowCount)
        {
            int i, j, k;
            for (i = rowCount - 1; i >= 0; i--)
                for (j = i - 1; j >= 0; j--)
                {
                    double tempMn = matrix[j, i];
                    for (k = 0; k < colCount; k++)
                        matrix[j, k] -= matrix[i, k] * tempMn;
                }
            double[] answer = new double[rowCount];
            for (i = 0; i < rowCount; i++) answer[mask[i]] = matrix[i, colCount - 1];
            return answer;
        }
        
        private double[,] MakeSystem(double[,] xyTable, int degree)
        {
            richTextBoxResult.Text += "Матрица корреляции\n";
            double[,] corr = Measures.Correlation(Transp(xyTable));
            double[,] matrix = new double[degree, degree + 1];
            for (int i = 0; i < degree; i++)
            {
                for (int j = 0; j < degree; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            for (int i = 0; i < degree; i++)
            {
                for (int j = 0; j < degree; j++)
                {
                    double sumA = 0, sumB = 0;
                    for (int k = 0; k < dataGridTable.RowCount * 75 / 100; k++)
                    {
                        sumA += Math.Pow(xyTable[0, k], i) * Math.Pow(xyTable[0, k], j);
                        sumB += xyTable[1, k] * Math.Pow(xyTable[0, k], i);
                    }
                    matrix[i, j] = sumA;
                    matrix[i, degree] = sumB;
                }
            }
            for (int i = 0; i < corr.GetLength(0); i++)
            {
                for (int j = 0; j < corr.GetLength(1); j++)
                {
                    double number = corr[i, j];
                    richTextBoxResult.Text += $"{Math.Round(number, 5)}; ";
                }
                richTextBoxResult.Text += "\n";
            }
            richTextBoxResult.Text += "\n";
            return matrix;
        }

        double[,] Transp(double[,] oldMatrix)
        {
            double[,] newMatrix = new double[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }

        void AddedDataTable(int rowCount)
        {
            for (int a = 0; a < rowCount; a++)
            {
                for (int i = 0; i < dataGridTable.ColumnCount; i++)
                {
                    try
                    {
                        xyTable[i, a] = Convert.ToDouble(dataGridTable[i, a].Value);
                    }
                    catch
                    {
                        double[] column = Enumerable.Range(0, rowCount).Select(j => Convert.ToDouble(xyTable[i, j])).ToArray();
                        Array.Sort(column);
                        if (dataGridTable.RowCount % 2 == 0)
                        {
                            dataGridTable[i, a].Value = (column[dataGridTable.RowCount / 2 - 1] + column[dataGridTable.RowCount / 2]) / 2;
                        }
                        else
                        {
                            dataGridTable[i, a].Value = column[dataGridTable.RowCount / 2];
                        }
                    }
                }
            }
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            int rowCount = dataGridTable.RowCount * 80 / 100;
            xyTable = new double[dataGridTable.ColumnCount, rowCount];
            richTextBoxResult.Clear();
            AddedDataTable(rowCount);
            for (int a = 0; a < dataGridTable.ColumnCount; a++)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    xyTable[a, i] = Convert.ToDouble(dataGridTable[a, i].Value);
                }
            }
            xyTable = OutBurstData(xyTable, dataGridTable.ColumnCount, rowCount);
            int degree = 5;
            matrix = MakeSystem(xyTable, degree);
            for (int i = 0; i < degree; i++)
            {
                for (int j = 0; j < degree; j++)
                {
                    richTextBoxResult.Text += ((matrix[i, j] > 0) ? "+" : "") +
                        Math.Round(matrix[i, j], 3).ToString() + "*a" + j.ToString() + " ";
                }
                richTextBoxResult.Text += " = " + matrix[i, degree] + "\n";
            }
            result = Gauss(matrix, degree, degree + 1);
            if (result == null)
            {
                richTextBoxResult.Text += "\nДанная система решений не имеет\n";
                richTextBoxResult.Select();
                SendKeys.Send("^{END}");
                return;
            }            
            richTextBoxResult.Text += "\nРешение системы уравнений:\n";
            for (int i = 0; i < degree; i++)
            {
                richTextBoxResult.Text += "a" + i.ToString() + " = " + Math.Round(result[i], 3).ToString() + "\n";
            }
            richTextBoxResult.Text += "\nАппроксимирующая функция:\ny = ";
            string testString = "";
            for (int i = 0; i < degree; i++)
            {
                for (int j = 1; j < numericUpDown1.Value; j++)
                {
                    if (Math.Round(result[i], 3) != 0)
                    {
                        double num = Math.Round(Math.Pow(Math.Round(result[i], 3), j), 3);
                        if (i == 0)
                        {
                            richTextBoxResult.Text += ((result[i] > 0 || num > 0) ? "+" : "") + num.ToString() + $"*x{j}";
                            testString += ((result[i] > 0 || num > 0) ? "+" : "") + num.ToString() + $"*x{j}";
                        }
                        else
                        {
                            richTextBoxResult.Text += ((result[i] > 0 || num > 0) ? "+" : "") + num.ToString() + $"*x{j}^{i + 1}";
                            testString += ((result[i] > 0 || num > 0) ? "+" : "") + num.ToString() + $"*x{j}^{i + 1}";
                        }
                    }
                }
            }
            richTextBoxResult.Text += "\n\n";
            richTextBoxResult.Select();
            List<(decimal, decimal)> valueY = new List<(decimal, decimal)>();
            double[,] newMatrix = TranslateOfMeanings(xyTable, result);
            for (int i = 0; i < result.Length; i++)
            {
                string test = testString;
                if (testString[0] == '+')
                {
                    test = $"0{testString}";
                }
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                {
                    for (int a = 2; a < 6; a++)
                    {
                        var re = Math.Round(Math.Pow(newMatrix[i, j], a), 5);
                        test = test.Replace($"x{j + 1}^{a}", $"{re}");
                    }
                    test = test.Replace($"x{j + 1}", newMatrix[i, j].ToString());                    
                }                
                string pattern = @"([\d\.,]+)E[\+-](\d+)";
                string patternZero = @"[\d\.]*\*[\d\.]+E[\+-]\d+\*0";
                string zeroPattern = @"0\*[\d\.]+E[\+-]\d+\*[\d\.]*";
                test = Regex.Replace(test, patternZero, "");
                test = Regex.Replace(test, zeroPattern, "");
                foreach (Match match in Regex.Matches(test, pattern)) 
                {
                    var x = Math.Round(Convert.ToDouble(match.Groups[1].Value.Replace('.', ',')), 5);
                    var exp = Convert.ToDouble(match.Groups[2].Value.Replace('.', ','));
                    decimal pow = Convert.ToDecimal(Math.Round(Math.Pow(x, exp), 5));
                    test = test.Replace(match.Groups[0].Value, Convert.ToString(pow));
                }
                test = test.Replace(",", ".");
                decimal resultMatrix = 0; 
                foreach (var item in test.Split('+'))
                {
                    resultMatrix += Convert.ToDecimal(new DataTable().Compute(item, null));
                }                
                valueY.Add((Convert.ToDecimal(result[i]), resultMatrix));
                richTextBoxResult.Text += $"{i + 1}) y = {test} = {resultMatrix}\n\n";
            }
            try
            {
                decimal sum = 0;
                foreach (var item in valueY)
                {
                    sum += (item.Item1 + item.Item2) / item.Item1;
                }
                decimal MAPE = Convert.ToDecimal((1.0f / valueY.Count) * Convert.ToDouble(sum) * 100);
                if (MAPE < 0 || MAPE > 10)
                {
                    richTextBoxResult.Text += $"MAPE = {MAPE} - точность не удовлетворяет условию";
                }
                else
                {
                    richTextBoxResult.Text += $"MAPE = {MAPE}";
                }
            }
            catch
            {
                richTextBoxResult.Text += $"Невозможно вывести точность.";
            }
            SendKeys.Send("^{END}");
        }

        double[,] TranslateOfMeanings(double[,] array, double[] y)
        {           
            List<double> AvgX = new List<double>();
            List<double> Sx = new List<double>();
            double AvgY = y.Sum()/y.Length;
            double sumY = 0;
            for (int i = 0; i < y.Length; i++)
            {
                sumY += Math.Pow(y[i] - AvgY, 2);
            }
            double Sy = Math.Sqrt(sumY / y.Length - 1);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += Math.Round(array[i, j], 3);   
                }
                AvgX.Add(sum/ array.GetLength(0));
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += Math.Pow(Math.Round(array[i, j], 3) - AvgX[i], 2);
                }
                Sx.Add(Math.Sqrt(sum / array.GetLength(0) - 1));
            }
            double[,] newArray = new double[array.GetLength(0) + 1, array.GetLength(1)];
            double aad = array.GetLength(1);
            double aard = array.GetLength(0);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (i == 0)
                {
                    double dop = 0;
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        dop -= Math.Round(array[i, j], 3) * AvgX[j];
                    }
                    newArray[i, 0] = Math.Round(AvgY + dop, 3);
                }
                else
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        newArray[i, j] = Math.Round(Math.Round(array[i, j], 3) * Sy / Sx[i - 1], 3);
                    }
                }
            }
            return newArray;
        }

        double[,] OutBurstData(double[,] xyTable, int columnCount, int rowCount)
        {
            richTextBoxResult.Text += "Выброс данных\n";
            double m = 0, q1 = 0, q2 = 0;
            for (int i = 0; i < columnCount; i++)
            {
                double[] column = Enumerable.Range(0, rowCount)
                      .Select(j => xyTable[i, j])
                      .ToArray();
                Array.Sort(column);

                if (rowCount % 2 == 0)
                {
                    m = (column[rowCount / 2 - 1] + column[rowCount / 2]) / 2;
                }
                else
                {
                    m = column[rowCount / 2];
                }

                int mid = column.Length / 2;
                double[] left = column.Take(mid).ToArray();
                double[] right = column.Reverse().Take(mid).ToArray();

                if (left.Length <= 2 && right.Length <= 2)
                {
                    q1 = left[left.Length / 2];
                    q2 = right[right.Length / 2];
                }
                else
                {
                    q1 = left[left.Length / 2 + 1];
                    q2 = right[right.Length / 2 + 1];
                }
                double d = Math.Abs(q1 - q2);
                double g1 = q1 - 3 * d;
                double g2 = q2 + 3 * d;

                for (int j = 0; j < rowCount; j++)
                {
                    if (xyTable[i,j] < g1 || xyTable[i,j] > g2)
                    {
                        richTextBoxResult.Text += $"В X{i + 1} найден выброс {xyTable[i, j]},который был поменен на медиану {m}\n";
                        xyTable[i, j] = m;
                    }
                }
            }
            richTextBoxResult.Text += "\n";
            return xyTable;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < dataGridTable.ColumnCount; a++)
            {
                for (int i = 0; i < dataGridTable.RowCount; i++)
                {
                    dataGridTable[a, i].Value = 0;
                }
            }
            matrix = null;
            result = null;
            xyTable = null;
        }

        private void numericUpDownCount_ValueChanged(object sender, EventArgs e)
        {
            Table();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int a = 0; a < dataGridTable.ColumnCount; a++)
            {
                for (int i = 0; i < dataGridTable.RowCount; i++)
                {
                    dataGridTable[a, i].Value = random.Next(-100, 100);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                filePath = file.FileName;
                fileExt = Path.GetExtension(filePath);
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
                    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Excel.Range xlRange = xlWorksheet.UsedRange;

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;
                    dataGridTable.ColumnCount = colCount;
                    dataGridTable.RowCount = rowCount;
                    foreach (DataGridViewRow x in dataGridTable.Rows)
                    {
                        x.MinimumHeight = 30;
                    }


                    for (int i = 1; i <= rowCount; i++)
                    {
                        for (int j = 1; j <= colCount; j++)
                        {
                            if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                                dataGridTable[j - 1, i - 1].Value = xlRange.Cells[i, j].Value2;
                        }
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Marshal.ReleaseComObject(xlRange);
                    Marshal.ReleaseComObject(xlWorksheet);

                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);

                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);

                    foreach (DataGridViewColumn column in dataGridTable.Columns)
                    {
                        if (column.Index < dataGridTable.ColumnCount - 1)
                            column.HeaderText = $"X{column.Index + 1}";
                        else column.HeaderText = $"Y";
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали файл с расширением .xls или .xlsx.", "Warning", MessageBoxButtons.OK);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Table();
        }
    }
}
