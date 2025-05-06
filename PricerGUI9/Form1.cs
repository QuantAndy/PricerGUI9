using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace PricerGUI9
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=PricerDB;Trusted_Connection=True;";
        private DataTable dataTable;
        private SqlDataAdapter dataAdapter;
        private DateTime lastCheckedTime = DateTime.MinValue;
        private System.Timers.Timer timer;
        private CancellationTokenSource _cts;

        public Form1()
        {
            InitializeComponent();
            LoadDataFromDatabase("PricingData");
            LoadDataFromDatabase2("USDIRData");
            LoadDataFromDatabase3("GBPIRData");
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.UserAddedRow += DataGridView1_UserAddedRow;
            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);


            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

        }

        //lengthy compute button
        private void button2_Click(object sender, EventArgs e)
        {

            button2.Enabled = false;
            progressBar1.Value = 0;


            if (_cts != null)
                _cts.Cancel();


            _cts = new CancellationTokenSource();
            var token = _cts.Token;


            Task.Run(() => PerformLengthyComputation(token), token);
        }

        // simulates lengthy computation that is done asynchronously
        private async void PerformLengthyComputation(CancellationToken token)
        {
            
            int totalSteps = 100000;
            int largeFactorialStart = 5000;


            button2.Enabled = false;


            for (int i = 1; i <= totalSteps; i++)
            {

                long result = await Task.Run(() => ComputeFactorial(largeFactorialStart + i), token);

                if (token.IsCancellationRequested)
                {
                    MessageBox.Show("Computation was cancelled.");
                    return;
                }

                UpdateProgress(i, totalSteps);
            }

            MessageBox.Show("Computation completed successfully!");

            button2.Invoke((Action)(() => button2.Enabled = true));
            
        }


        private long ComputeFactorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        // updating progress bar based on compute so far
        private void UpdateProgress(int currentStep, int totalSteps)
        {
            if (progressBar1.InvokeRequired)
            {

                // InvokeRequired checks if the call is from a different thread
                progressBar1.Invoke((Action)(() => progressBar1.Value = (currentStep * 100) / totalSteps));
            }
            else
            {
                // If already on the UI thread, update directly
                progressBar1.Value = (currentStep * 100) / totalSteps;
            }
        }


        private void LoadDataFromDatabase(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM dbo.{tableName}";
                dataAdapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                chart1.Refresh();
                chart2.Refresh();
            }
        }
        private void LoadDataFromDatabase2(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM dbo.{tableName}";
                dataAdapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;

                // Add data to chart1
                chart1.Series["Series1"].Points.Clear();
                foreach (DataRow row in dataTable.Rows)
                {

                    chart1.Series["Series1"].Points.AddXY(row["Date"], row["ExpectedIR"]);
                }

                chart1.Refresh();
                chart2.Refresh();
            }
        }

        private void LoadDataFromDatabase3(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM dbo.{tableName}";
                dataAdapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView3.DataSource = dataTable;


                chart2.Series["Series1"].Points.Clear();  
                foreach (DataRow row in dataTable.Rows)
                {

                    chart2.Series["Series1"].Points.AddXY(row["Date"], row["ExpectedIR"]);
                }

                chart1.Refresh();
                chart2.Refresh();
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;


                if (columnName == "Bid" || columnName == "Ask")
                {
                    string tableName = "PricingData";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = $"UPDATE dbo.{tableName} SET " +
                                       $"{columnName} = @Value " +
                                       "WHERE TransactionID = @ID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@Value", dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                            cmd.Parameters.AddWithValue("@ID", dataGridView1.Rows[e.RowIndex].Cells["TransactionID"].Value);  // Updated here as well
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void DataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = e.Row;
                string tableName = "PricingData";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"INSERT INTO dbo.{tableName} (SecName, Tenor, Date, Bid, Ask, Mid, BaseCountry, QuoteCountry, BaseCountryIR, QuoteCountryIR, CurrencyPairSpotRate_MID, ForwardPoints) " +
                                   "VALUES (@SecName, @Tenor, @Date, @Bid, @Ask, @Mid, @BaseCountry, @QuoteCountry, @BaseCountryIR, @QuoteCountryIR, @SpotRate, @ForwardPoints)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SecName", row.Cells["SecName"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Tenor", row.Cells["Tenor"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Date", row.Cells["Date"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Bid", row.Cells["Bid"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Ask", row.Cells["Ask"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Mid", row.Cells["Mid"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@BaseCountry", row.Cells["BaseCountry"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@QuoteCountry", row.Cells["QuoteCountry"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@BaseCountryIR", row.Cells["BaseCountryIR"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@QuoteCountryIR", row.Cells["QuoteCountryIR"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@SpotRate", row.Cells["CurrencyPairSpotRate_MID"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ForwardPoints", row.Cells["ForwardPoints"].Value ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadDataFromDatabase(tableName);
            }
        }

        private void IncreaseBidButton_Click(object sender, EventArgs e) => ModifyBid(0.01);
        private void DecreaseBidButton_Click(object sender, EventArgs e) => ModifyBid(-0.01);
        private void IncreaseAskButton_Click(object sender, EventArgs e) => ModifyAsk(0.01);
        private void DecreaseAskButton_Click(object sender, EventArgs e) => ModifyAsk(-0.01);

        private void ModifyBid(double amount)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                {

                    double currentBid = Convert.ToDouble(row.Cells["Bid"].Value);


                    double newBid = currentBid + amount;


                    row.Cells["Bid"].Value = newBid;


                    int transactionID = Convert.ToInt32(row.Cells["TransactionID"].Value);


                    string query = "UPDATE dbo.PricingData SET Bid = @Value WHERE TransactionID = @ID";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Value", newBid);
                            cmd.Parameters.AddWithValue("@ID", transactionID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }


            dataGridView1.Refresh();
        }

        private void ModifyAsk(double amount)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                {

                    double currentAsk = Convert.ToDouble(row.Cells["Ask"].Value);


                    double newAsk = currentAsk + amount;


                    row.Cells["Ask"].Value = newAsk;


                    int transactionID = Convert.ToInt32(row.Cells["TransactionID"].Value);


                    string query = "UPDATE dbo.PricingData SET Ask = @Value WHERE TransactionID = @ID";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Value", newAsk);
                            cmd.Parameters.AddWithValue("@ID", transactionID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }


            dataGridView1.Refresh();
        }


        // simulates record insert into top left table. Values are all random within certain constraints for demo purposes
        private void SimulateRecordInsertionButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                for (int i = 0; i < 50; i++)
                {
                    string secName = $"Security_{i + 1}";
                    int tenor = random.Next(30, 365); // Random tenor between 30 and 365 days
                    DateTime date = DateTime.Today.AddDays(random.Next(1, 365)); // Random date within the last year
                    double bid = random.NextDouble() * 2 + 1; // Random bid between 1 and 3
                    double ask = bid + random.NextDouble(); // Random ask slightly higher than bid
                    double mid = (bid + ask) / 2; // Mid price
                    string baseCountry = "EUR";
                    string quoteCountry = "USD";
                    double baseIR = random.NextDouble() * 0.1; // Random base IR between 0 and 0.1
                    double quoteIR = random.NextDouble() * 0.1; // Random quote IR between 0 and 0.1
                    double spotRate = mid; // Assumes spot rate is at the mid price
                    int forwardPoints = 0;


                    string query = "INSERT INTO dbo.PricingData (SecName, Tenor, Date, Bid, Ask, Mid, BaseCountry, QuoteCountry, BaseCountryIR, QuoteCountryIR, CurrencyPairSpotRate_MID, ForwardPoints) " +
                                   "VALUES (@SecName, @Tenor, @Date, @Bid, @Ask, @Mid, @BaseCountry, @QuoteCountry, @BaseCountryIR, @QuoteCountryIR, @CurrencyPairSpotRate_MID, @ForwardPoints)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@SecName", secName);
                        cmd.Parameters.AddWithValue("@Tenor", tenor);
                        cmd.Parameters.AddWithValue("@Date", date);
                        cmd.Parameters.AddWithValue("@Bid", bid);
                        cmd.Parameters.AddWithValue("@Ask", ask);
                        cmd.Parameters.AddWithValue("@Mid", mid);
                        cmd.Parameters.AddWithValue("@BaseCountry", baseCountry);
                        cmd.Parameters.AddWithValue("@QuoteCountry", quoteCountry);
                        cmd.Parameters.AddWithValue("@BaseCountryIR", baseIR);
                        cmd.Parameters.AddWithValue("@QuoteCountryIR", quoteIR);
                        cmd.Parameters.AddWithValue("@CurrencyPairSpotRate_MID", spotRate);
                        cmd.Parameters.AddWithValue("@ForwardPoints", forwardPoints);


                        cmd.ExecuteNonQuery();
                    }
                }
            }

            LoadDataFromDatabase("PricingData");
        }

        // cliking this button will make a request to polygon via microservice. This functionality is async. microservice must be running already
        private async void button1_Click(object sender, EventArgs e)
        {
            string ticker = textBox1.Text.Trim();
            string startTime = maskedTextBox1.Text.Trim();
            string endTime = maskedTextBox2.Text.Trim();

            if (string.IsNullOrEmpty(ticker) || string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(endTime))
            {
                MessageBox.Show("Please enter all fields.");
                return;
            }

            // adding try catch block in case there is some error with the request
            try
            {
                string jsonOutput = await FetchMarketData(ticker, startTime, endTime);
                List<MarketData> marketDataList = JsonConvert.DeserializeObject<List<MarketData>>(jsonOutput);
                DisplayData(marketDataList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // makes a GET request to the flask microservice to fetch market data
        private async Task<string> FetchMarketData(string symbol, string start, string end)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"http://localhost:8000/fetch_data?symbol={symbol}&start={Uri.EscapeDataString(start)}&end={Uri.EscapeDataString(end)}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"HTTP error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }

                return await response.Content.ReadAsStringAsync();
            }
        }


        private void DisplayData(List<MarketData> marketDataList)
        {

            dataGridView4.DataSource = marketDataList;
        }

        
        public class MarketData
        {
            public string Timestamp { get; set; }
            public double Open { get; set; }
            public double High { get; set; }
            public double Low { get; set; }
            public double Close { get; set; }
            public double Volume { get; set; }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
