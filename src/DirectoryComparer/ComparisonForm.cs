using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace hk.DirectoryComparer
{
    public partial class ComparisonForm : Form
    {
        private BackgroundWorker _backgroundWorker;
        private Comparer _comparer;
        private DataTable _table;

        public ComparisonForm()
        {
            InitializeComponent();

            InitialiseDefaultView();

            InitialiseComponentListeners();
        }

        private void InitialiseDefaultView()
        {
            btnCompare.Enabled = false;
            
            WindowState = FormWindowState.Maximized;
        }

        private void InitialiseComponentListeners()
        {
            btnBrowseFolder1.Click += (s, e) => BrowseDirectory(textBoxDir1);
            btnBrowseFolder2.Click += (s, e) => BrowseDirectory(textBoxDir2);
            btnCompare.Click += (s, e) => StartComparisonThread();
            dataGridView.CellFormatting += (s, e) => SetColors(e);

            if (_backgroundWorker == null)
            {
                _backgroundWorker = new BackgroundWorker
                                        {
                                            WorkerReportsProgress = true,
                                            WorkerSupportsCancellation = true
                                        };
            }

            _backgroundWorker.DoWork += (s, e) => DoWork();
            _backgroundWorker.ProgressChanged += (s, e) => progressBar.Value = e.ProgressPercentage;
            _backgroundWorker.RunWorkerCompleted += (s, e) => BindDataToGrid();
        }

        private void BrowseDirectory(TextBox textBox)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = dialog.SelectedPath;

                btnCompare.Enabled = Directory.Exists(textBoxDir1.Text) && Directory.Exists(textBoxDir2.Text);
            }
        }

        private void StartComparisonThread()
        {
            if (!_backgroundWorker.IsBusy)
            {
                _backgroundWorker.RunWorkerAsync();
            }
        }

        private void SetColors(DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;

            if (dataGridView.Columns[e.ColumnIndex].Name.Equals("Files", StringComparison.OrdinalIgnoreCase))
            {
                if (!string.IsNullOrEmpty(dataGridView.Rows[e.RowIndex].Cells["Full path in original directory"].Value.ToString()) &&
                    !string.IsNullOrEmpty(dataGridView.Rows[e.RowIndex].Cells["Full path in modified directory"].Value.ToString()))
                {
                    e.CellStyle.BackColor = Color.LightSkyBlue;
                }
            }
        }

        private void DoWork()
        {
            DoComparison();

            LoadResults();

            _backgroundWorker.ReportProgress(100);
        }

        private void DoComparison()
        {
            if (_comparer == null)
            {
                _comparer = new Comparer
                {
                    DirectoryPath1 = textBoxDir1.Text,
                    DirectoryPath2 = textBoxDir2.Text
                };
            }

            _comparer.Compare();
        }

        private void LoadResults()
        {
            if (null != _comparer.Files)
            {
                if (_table == null)
                {
                    _table = new DataTable();
                }

                _table.Columns.Add("Files");
                _table.Columns.Add("Full path in original directory");
                _table.Columns.Add("Full path in modified directory");

                foreach (var item in _comparer.Files)
                {
                    _table.Rows.Add(new object[]
                                        {
                                            Path.GetFileName(item.LatestFile),
                                            item.FileNameInDirectory1,
                                            item.FileNameInDirectory2
                                        });
                }
            }
        }

        private void BindDataToGrid()
        {
            if (dataGridView.InvokeRequired)
            {
                Action action = BindDataToGrid;
                dataGridView.BeginInvoke(action);

                return;
            }

            dataGridView.DataSource = _table;

            dataGridView.AutoResizeColumns();
        }
    }
}
