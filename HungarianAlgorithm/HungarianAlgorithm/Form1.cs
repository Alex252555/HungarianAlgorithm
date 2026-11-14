using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HungarianAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeCustomSettings();
        }

        private void InitializeCustomSettings()
        {
            comboBoxTests.Items.Add("Test 1 (3x3)");
            comboBoxTests.Items.Add("Test 2 (4x4)");
            comboBoxTests.Items.Add("Test 3 (5x5)");
            comboBoxTests.SelectedIndex = 0;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersWidth = 70;

            LoadTestCase(0);
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Resize button clicked.");
            int size = (int)nudSize.Value;
            SetupEmptyMatrix(size);
        }

        private void SetupEmptyMatrix(int size)
        {
            dataGridView1.ColumnCount = size;
            dataGridView1.RowCount = size;

            for (int i = 0; i < size; i++)
            {
                dataGridView1.Columns[i].Name = $"З {i + 1}";
                dataGridView1.Columns[i].Width = 60;
                dataGridView1.Rows[i].HeaderCell.Value = $"Р {i + 1}";

                for (int j = 0; j < size; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 0;
                }
            }
            nudSize.Value = size;
        }

        private void comboBoxTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTestCase(comboBoxTests.SelectedIndex);
        }

        private void LoadTestCase(int index)
        {
            int[,] matrix;

            if (index == 0) // 3x3
            {
                matrix = new int[,] {
                    { 9, 2, 7 },
                    { 6, 4, 3 },
                    { 5, 8, 1 }
                };
            }
            else if (index == 1) // 4x4
            {
                matrix = new int[,] {
                    { 82, 83, 69, 92 },
                    { 77, 37, 49, 92 },
                    { 11, 69,  5, 86 },
                    {  8,  9, 98, 23 }
                };
            }
            else // 5x5
            {
                matrix = new int[,] {
                    { 10, 19, 8, 15, 12 },
                    { 10, 18, 7, 17, 15 },
                    { 13, 16, 9, 14, 11 },
                    { 12, 19, 8, 18, 15 },
                    { 14, 17, 10, 19, 13 }
                };
            }

            int n = matrix.GetLength(0);
            nudSize.Value = n;
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = n;

            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].Name = $"З {i + 1}";
                dataGridView1.Columns[i].Width = 60;
                dataGridView1.Rows[i].HeaderCell.Value = $"Р {i + 1}";

                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                int n = dataGridView1.RowCount;
                int[,] costMatrix = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value == null ||
                            !int.TryParse(dataGridView1.Rows[i].Cells[j].Value.ToString(), out costMatrix[i, j]))
                        {
                            MessageBox.Show($"Please enter a valid number at {i + 1}, column {j + 1}.", "Error with entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                HungarianAlgorithm solver = new HungarianAlgorithm(costMatrix);
                int[] assignment = solver.Run();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("=== OPTIMAL ASSIGNMENT ===");
                int totalCost = 0;

                for (int i = 0; i < n; i++)
                {
                    int task = assignment[i];
                    int cost = costMatrix[i, task];
                    totalCost += cost;
                    sb.AppendLine($"Worker {i + 1} -> Task {task + 1} (Cost: {cost})");
                }

                sb.AppendLine($"Total cost: {totalCost}");
                txtLog.Text = sb.ToString();

                HighlightOptimalCells(assignment);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during execution: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HighlightOptimalCells(int[] assignment)
        {

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }

            for (int i = 0; i < assignment.Length; i++)
            {
                int j = assignment[i];
                if (j >= 0 && j < dataGridView1.ColumnCount)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                }
            }
        }
    }


    public class HungarianAlgorithm
    {
        private readonly int[,] costMatrix;
        private readonly int dim;

        public HungarianAlgorithm(int[,] matrix)
        {
            dim = matrix.GetLength(0);
            costMatrix = new int[dim, dim];
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    costMatrix[i, j] = matrix[i, j];
                }
            }
        }

        public int[] Run()
        {
            int[] u = new int[dim + 1];
            int[] v = new int[dim + 1];
            int[] p = new int[dim + 1];
            int[] way = new int[dim + 1];

            for (int i = 1; i <= dim; ++i)
            {
                p[0] = i;
                int j0 = 0;
                int[] minv = new int[dim + 1];
                for (int j = 1; j <= dim; ++j) minv[j] = int.MaxValue;
                bool[] inked = new bool[dim + 1];

                do
                {
                    inked[j0] = true;
                    int i0 = p[j0], delta = int.MaxValue, j1 = 0;

                    for (int j = 1; j <= dim; ++j)
                    {
                        if (!inked[j])
                        {
                            int cur = costMatrix[i0 - 1, j - 1] - u[i0] - v[j];
                            if (cur < minv[j])
                            {
                                minv[j] = cur;
                                way[j] = j0;
                            }
                            if (minv[j] < delta)
                            {
                                delta = minv[j];
                                j1 = j;
                            }
                        }
                    }

                    for (int j = 0; j <= dim; ++j)
                    {
                        if (inked[j])
                        {
                            u[p[j]] += delta;
                            v[j] -= delta;
                        }
                        else
                        {
                            minv[j] -= delta;
                        }
                    }
                    j0 = j1;
                } while (p[j0] != 0);

                do
                {
                    int j1 = way[j0];
                    p[j0] = p[j1];
                    j0 = j1;
                } while (j0 != 0);
            }

            int[] assignment = new int[dim];
            for (int j = 1; j <= dim; ++j)
            {
                if (p[j] > 0)
                {
                    assignment[p[j] - 1] = j - 1;
                }
            }

            return assignment;
        }
    }
}