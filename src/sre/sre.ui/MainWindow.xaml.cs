using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using Excel;
using Syncfusion.Windows.Tools.Controls;
using Ubs.Collateral.Sre.Common.Spring;
using Ubs.Collateral.Sre.Common.Utility;
using System.Xml;
using System.Xml.Serialization;
using sre.model;

namespace sre.ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MfcDirectoryWatcher _watcher = new MfcDirectoryWatcher();
        private readonly Dictionary<string, MfcEmailContent> _emails = new Dictionary<string, MfcEmailContent>();
        private readonly Dictionary<string, HashSet<AverageMisData>> _misAveragesData = new Dictionary<string, HashSet<AverageMisData>>();
        private readonly Dictionary<string, Counterparty> _counterpartyMappings = new Dictionary<string, Counterparty>();
        private readonly Dictionary<string, Country> _countries = new Dictionary<string, Country>();
        private readonly HashSet<Security> _securities = new HashSet<Security>();
        private bool _generateEquityXml = true;

        private const string FolderPath = @"..\..\..\TestResources\";
        private const string PoolHealthcheckFilePath = FolderPath + "PoolMaelstromHealthcheck.xls";
        private const string RepoHealthcheckFilePath = FolderPath + "RepoMaelstromHealthcheck.xls";

        private const string EqDailyMisReportFilePath = FolderPath + "Daily_MIS_Equity_Report.20140915.xls";
        private const string FiDailyMisReportFilePath = FolderPath + "Daily_MIS_FI_Report.20140915.xlsx";

        private string _dailyMisReportFilePath;
        private bool _counterpartyMappingsInitialised;
        private bool _tradeAveragesDataInitialised;
        private bool _countriesDataInitialised;
        private int _days;

        private const string TradeAveragesFilePath = FolderPath + "EQMIS_ClsTrds_6MAvg_20140829.xls";
        private const string CptyMappingsFilePath = FolderPath + "counterpartyMapings.xls";
        private const string CountriesFilePath = FolderPath + "countries.xls";

        //Maelstrom
        private const string MaelstromTestCasesWorksheetName = " Mealstrom Test Cases";
        private const string ContentColumn = "Content";
        private const string EmailAddressColumn = "Email address";
        private const string CounterpartyColumn = "CounterpartyName";
        private const string SecurityIdColumn = "Security ID";
        private const string SecurityTypeColumn = "Security Type";
        private const string QuantityColumn = "Quantity";
        private const string StartDateColumn = "Start Date (T+? Bus days / date)";
        private const string EndDateColumn = "End Date (T+? Bus days / date / tenor)";
        private const string CollatoralTypeColumn = "Collatoral Type";
        private const string BidColumn = "Bid";
        private const string LowDivColumn = "Low div";
        private const string DiBreakColumn = "Di Break";
        private const string FinalStatusColumn = "Final Status";
        private const string TestcaseColumn = "TEST CASE";

        private const string CtasEvaluationMessage = "Using CTAS Rules Engine";
        private const string DroolsEvaluationMessage = "Using Drools";

        //MIS Report
        private const string NidColumn = "NID";
        private const string TidColumn = "TID";
        private const string TypeColumn = "Type";
        private const string PreviousTypeColumn = "Prev Type";
        private const string SystemColumn = "System";
        private const string SecurityCodeColumn = "Security Code";
        private const string BillCcyColumn = "Bill CCY";
        private const string TradeDateColumn = "Trade Date";
        private const string SettlementTypeColumn = "Settlement Type";
        private const string DescriptionColumn = "Description";
        private const string Description1Column = "Description1";
        private const string Description2Column = "Description2";
        private const string Description3Column = "Description3";
        private const string Description4Column = "Description4";
        private const string Description5Column = "Description5";
        private const string PriceColumn = "Price";
        private const string CollCcyColumn = "Coll. CCY";
        private const string LenderFeeAmountColumn = "LENDER_FEE_AMOUNT";
        private const string LenderRateAmountColumn = "LENDER_RATE_AMOUNT";
        private const string BorrowerFeeAmountColumn = "BORROWER_FEE_AMOUNT";
        private const string ExternalTraderColumn = "External Trader";
        private const string UbsTraderColumn = "UBS Trader";
        private const string StpActionColumn = "STP Action";
        private const string TimeStampColumn = "TIME_STAMP";
        private const string ProductColumn = "Product";
        private const string MisCounterpartyColumn = "Counterparty";
        private const string RuleRankColumn = "RANK";
        private const string RuleNameColumn = "NAME";
        private const string RuleDescriptionColumn = "DESCRIPTION_1";
        private const string CashRateColumn = "CASH_RATE";
        private const string MinimumFeeColumn = "MINIMUM_FEE";
        private const string BorrowerSettlementModeColumn = "BORROWER_SETTLEMENT_MODE";

        //Avergae Trade Report
        private const string AvgCounterpartyColumn = "Counterparty";
        private const string AvgSModeColumn = "SMODE";
        private const string AvgTradeCatColumn = "TradeCat";
        private const string AvgTradeDurationColumn = "Average of Duration";
        private const string AvgSettlementColumn = "Average of Settlements";
        private const string AvgSettFeeUsdColumn = "Average of SettFeeUSD";
        private const string AvgInitLnvalUsdColumn = "Average of INIT_LNVAL_USD";
        private const string AvgEarningAfterSettCostColumn = "Average of EarningAfterSettCost";

        private const double DefaultEquilendAverageTradeDuration = 30;
        private const double DefaultOtherAverageTradeDuration = 30;

        //Country Report
        private const string CnCountryCodeColumn = "CountryCode";
        private const string CnNameColumn = "Name";
        private const string CnCurrencyColumn = "Currency";
        private const string CnAssetClassColumn = "AssetClass";

        //Counterparty Mappings
        private const string CptyShortCodeColumn = "SHORTCODE";
        private const string CptyNameColumn = "CPTYNAME";
        private const string CptyGl1ZhColumn = "GL1ZH";
        private const string CptyParentColumn = "PARENT";

        public MainWindow()
        {
            _dailyMisReportFilePath = GetDailyMisReportFilePath();
            _days = -20;

            //TODO: Need to watch output directory to email
            //_watcher.Initialise(Path.GetDirectoryName(_dailyMisReportFilePath));

            InitializeComponent();
            new Bootstrap();

            Loaded += MainWindow_Loaded;
            btnPoolHealthCheck.Click += (s, e) => LoadSpreadsheet(PoolHealthcheckFilePath);
            btnRepoHealthCheck.Click += (s, e) => LoadSpreadsheet(RepoHealthcheckFilePath);
            btnMIS.Click += (s, e) => LoadMisFromSpreadsheet(_dailyMisReportFilePath);
            btnGenerateXML.Click += (s, e) =>
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    int negotionsCount;
                    if (GenerateXml(out negotionsCount))
                    {
                        sw.Stop();
                        MessageBox.Show(string.Format("Successfully generated {0} orders in {1} milliseconds", negotionsCount, sw.ElapsedMilliseconds));
                    }
                    else
                    {
                        sw.Stop();
                        MessageBox.Show(("Failed to generate orders.xml"));
                    }
                };
            btnEmailUsingSpreadsheet.Click += (s, e) => SendEmails();
            rbEquity.Click += (s, e) => SetOutputType(true);
            rbFixedIncome.Click += (s, e) => SetOutputType(false);
            tbDays.TextChanged += (s, e) => { if (tbDays.Text != null) UpdateDays(tbDays.Text); };
        }

        private void UpdateDays(string days)
        {
            int daysActual;
            _days = int.TryParse(days, out daysActual) ? daysActual : _days;
        }

        private void SetOutputType(bool value)
        {
            _generateEquityXml = value;
            _dailyMisReportFilePath = GetDailyMisReportFilePath();
        }

        private string GetDailyMisReportFilePath()
        {
            return _generateEquityXml ? Path.GetFullPath(EqDailyMisReportFilePath) : Path.GetFullPath(FiDailyMisReportFilePath);
        }

        private void SendEmails()
        {
            if (SpreadsheetControl.ExcelProperties.FileName != null)
            {
                var contentColumn = this.SpreadsheetControl.ExcelProperties.WorkBook.Worksheets[MaelstromTestCasesWorksheetName].Columns.FirstOrDefault(c => c.DisplayText.Equals(ContentColumn, StringComparison.OrdinalIgnoreCase));
                var securityIdColumn = this.SpreadsheetControl.ExcelProperties.WorkBook.Worksheets[MaelstromTestCasesWorksheetName].Columns.FirstOrDefault(c => c.DisplayText.Equals(SecurityIdColumn, StringComparison.OrdinalIgnoreCase));
                var securityTypeColumn = this.SpreadsheetControl.ExcelProperties.WorkBook.Worksheets[MaelstromTestCasesWorksheetName].Columns.FirstOrDefault(c => c.DisplayText.Equals(SecurityTypeColumn, StringComparison.OrdinalIgnoreCase));

                if (contentColumn != null && securityIdColumn != null && securityTypeColumn != null)
                {
                    foreach (var cell in contentColumn.Cells)
                    {
                        //Ignore empty and header cells
                        if (string.IsNullOrWhiteSpace(cell.Value) || cell.Value.Equals(contentColumn.DisplayText))
                        {
                            continue;
                        }

                        Console.WriteLine(cell.Value);
                        string key = Guid.NewGuid().ToString();
                        bool usingDrools = rbDrools.IsChecked.HasValue && rbDrools.IsChecked.Value;
                        string evaluationMessage = usingDrools ? DroolsEvaluationMessage : CtasEvaluationMessage;
                        var email = new MfcEmailContent
                        {
                            Subject = string.Format("Test {0} - {1}", evaluationMessage, key),
                            Body = string.Format("{0}\n\n[{1} Evaluation Method]", cell.Value, evaluationMessage),
                            Recipients = new List<string> { "sh-ap-maelstrom-uat@ubs.com" },
                            Sender = UserPrincipal.Current.EmailAddress,
                            DisplayName = UserPrincipal.Current.Surname
                        };
                        _emails.Add(key, email);

                        //MfcSpringManager.SendCustomEmail(email);
                    }
                }
            }
        }


        private bool LoadSpreadsheet(string filename)
        {
            try
            {
                var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                SpreadsheetControl.ImportFromExcel(fileStream);

                return true;
            }
            catch (IOException)
            {
                MessageBox.Show(string.Format("The file '{0}' is currently in use, please close to update the generated XML", Path.GetFileName(filename)));
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool LoadMisFromSpreadsheet(string fileName)
        {
            return LoadSpreadsheet(fileName);
        }

        private bool GenerateXml(out int negotionsCount)
        {
            Negotiations negotiations = new Negotiations
            {
                Items = new List<Negotiation>()
            };

            LoadCounterpartyMappings();

            LoadTradeAveragesData();

            LoadCountries();

            return PopulateNegotiations(negotiations, out negotionsCount) && Serialize(negotiations, Path.Combine(Path.GetTempPath(), "orders.xml"));
        }

        private void LoadCounterpartyMappings()
        {
            if (_counterpartyMappingsInitialised)
            {
                return;
            }

            string cptyMappings = Path.GetFullPath(CptyMappingsFilePath);
            if (!File.Exists(cptyMappings))
            {
                return;
            }

            foreach (DataRow dataRow in ExcelData.GetData(cptyMappings))
            {
                var cptyGl1ZhColumn = GetCellValue(dataRow,CptyGl1ZhColumn);

                if (!string.IsNullOrEmpty(cptyGl1ZhColumn) && !_counterpartyMappings.ContainsKey(cptyGl1ZhColumn))
                {
                    _counterpartyMappings.Add(cptyGl1ZhColumn, new Counterparty
                        {
                            ShortCode = GetCellValue(dataRow, CptyShortCodeColumn),
                            CptyName = GetCellValue(dataRow, CptyNameColumn),
                            Gl1Zh = cptyGl1ZhColumn,
                            Parent = GetCellValue(dataRow, CptyParentColumn)
                        });
                }
            }

            _counterpartyMappingsInitialised = true;
        }

        private void LoadTradeAveragesData()
        {
            if (_tradeAveragesDataInitialised)
            {
                return;
            }

            string averageDataFilePath = Path.GetFullPath(TradeAveragesFilePath);
            if (!File.Exists(averageDataFilePath))
            {
                return;
            }

            foreach (DataRow dataRow in ExcelData.GetData(averageDataFilePath))
            {
                string sMode = GetCellValue(dataRow,AvgSModeColumn);
                //Skip blank settlement modes
                if (string.IsNullOrWhiteSpace(sMode))
                {
                    continue;
                }

                string cptyId =  GetCellValue(dataRow,AvgCounterpartyColumn);
                if (cptyId != null)
                {
                    HashSet<AverageMisData> data;
                    if (_misAveragesData.TryGetValue(cptyId, out data))
                    {
                        data.Add(GetAveragesDataItem(cptyId, sMode, dataRow));
                    }
                    else
                    {
                        _misAveragesData.Add(cptyId, new HashSet<AverageMisData>
                            {
                                GetAveragesDataItem(cptyId, sMode, dataRow)
                            });
                    }
                }
            }

            _tradeAveragesDataInitialised = true;
        }

        private void LoadCountries()
        {
            if (_countriesDataInitialised)
            {
                return;
            }

            string countriesPath = Path.GetFullPath(CountriesFilePath);

            if (!File.Exists(countriesPath))
            {
                return;
            }

            foreach (DataRow dataRow in ExcelData.GetData(countriesPath))
            {
                string countryCode = GetCellValue(dataRow, CnCountryCodeColumn);
                if (string.IsNullOrWhiteSpace(countryCode))
                {
                    continue;
                }

                Country data;
                if (!_countries.TryGetValue(countryCode, out data))
                {
                    _countries.Add(countryCode, new Country
                    {
                        CountryCode = countryCode,
                        Currency = GetCellValue(dataRow, CnCurrencyColumn),
                        Name = GetCellValue(dataRow, CnNameColumn),
                        AssetClass = GetCellValue(dataRow, CnAssetClassColumn)
                    });
                }
            }

            _countriesDataInitialised = true;
        }

        private bool PopulateNegotiations(Negotiations negotiations, out int negotiationsCount)
        {
            foreach (string file in GetFilesToProcess())
            {
                if (!File.Exists(file))
                {
                    Console.WriteLine("Nothing loaded for {0}", Path.GetFileName(file));
                    continue;
                }

                foreach (DataRow dataRow in ExcelData.GetData(file, true, "Daily_MIS_Equity_Report_Traded", "Daily_MIS_Equity_Report_Reject"))
                {
                    var reasonCodes = new List<string>();

                    string securityCode = GetCellValue(dataRow, SecurityCodeColumn);

                    var temp = new Security(securityCode);
                    var security = _securities.FirstOrDefault(s => s.SecurityCode.Equals(temp.SecurityCode, StringComparison.OrdinalIgnoreCase));
                    if (security == null)
                    {
                        temp.SecurityTypeDisplayText = GetCellValue(dataRow, SecurityTypeColumn);
                        security = temp;
                        _securities.Add(security);
                    }

                    var currentOrder = new Order
                    {
                        ContractPrice = TryConvert<decimal?>(dataRow, PriceColumn),
                        Offer = TryConvert<double?>(dataRow, LenderFeeAmountColumn),
                        TotalQuantity = TryConvert<decimal?>(dataRow, QuantityColumn),
                        CashRate = TryConvert<double?>(dataRow, CashRateColumn),
                        OrderStateDisplayText = GetCellValue(dataRow, TypeColumn),
                        Bid = TryConvert<double?>(dataRow, BorrowerFeeAmountColumn),
                        MinFee = TryConvert<double?>(dataRow, MinimumFeeColumn),
                        SettlementModeDisplayText = GetCellValue(dataRow, BorrowerSettlementModeColumn),
                        BillingCcy = GetCellValue(dataRow, BillCcyColumn)
                    };

                    var nego = new Negotiation
                    {
                        Security = security,
                        SecurityCode = security.SecurityCode,
                        SecurityTypeDisplayText = security.SecurityTypeDisplayText,
                        OriginatingSystemDisplayText = GetCellValue(dataRow, SystemColumn),
                        ProductTypeDisplayText = GetCellValue(dataRow, ProductColumn),
                        AssetClassDisplayText = GetCellValue(dataRow, Description5Column),
                        QuotationCurrencyDisplayText = GetCellValue(dataRow, CollCcyColumn),
                        ExistingStpAction = GetCellValue(dataRow, StpActionColumn),
                        ExistingRuleName = GetCellValue(dataRow, RuleDescriptionColumn),
                        ExistingRuleRank = TryConvert<double?>(dataRow, RuleRankColumn),
                        CurrentOrder = currentOrder,
                        PreviousOrder = new Order()
                    };

                    decimal nid;
                    double actualNid = (double)dataRow[NidColumn];
                    string nidCellValue = actualNid.ToString("R");
                    if (decimal.TryParse(nidCellValue, NumberStyles.Any, CultureInfo.InvariantCulture, out nid))
                    {
                        nego.NegotiationId = nid;
                    }

                    Counterparty cpty;
                    string counterpartyName = GetCellValue(dataRow, MisCounterpartyColumn);
                    nego.CounterpartyName = _counterpartyMappings.TryGetValue(counterpartyName, out cpty) ? cpty.ShortCode : counterpartyName;

                    nego.PreviousOrder.OrderStateDisplayText = nego.OriginatingSystem != OriginatingSystem.Equilend
                                                                   ?  GetCellValue(dataRow,PreviousTypeColumn)
                                                                   : String.Empty;

                    if (nego.CurrentOrder.OrderState == OrderState.Cancelled || nego.CurrentOrder.OrderState == OrderState.Trade)
                    {
                        nego.CurrentOrder.OrderState = nego.PreviousOrder.OrderState != OrderState.Default
                                                           ? nego.PreviousOrder.OrderState
                                                           : MfcEnumUtility.ParseByDescription<OrderState>(GetCellValue(dataRow, PreviousTypeColumn));
                    }
                    if (nego.OriginatingSystem == OriginatingSystem.UbsMaelstrom)
                    {
                        nego.OriginatingSystemDisplayText = OriginatingSystem.Maelstrom.Description();
                    }
                    if (nego.ExistingRuleNameSpecified)
                    {
                        if (nego.ExistingRuleName.Equals("reject no holdings", StringComparison.OrdinalIgnoreCase))
                        {
                            reasonCodes.Add("evaluation.noSecurityHolding");
                        }
                        if (nego.ExistingRuleName.Equals("maelstrom send all to di", StringComparison.OrdinalIgnoreCase))
                        {
                            nego.StraightToDi = true;
                        }
                        if (nego.ExistingRuleName.IndexOf("not in reef", StringComparison.OrdinalIgnoreCase) != -1)
                        {
                            reasonCodes.Add("secStatic.securityNotFound");
                        }
                        if (nego.ExistingRuleName.IndexOf("special", StringComparison.OrdinalIgnoreCase) != -1)
                        {
                            nego.IsSpecial = true;
                        }
                        if ((!nego.QuotationCountryDisplayTextSpecified || nego.QuotationCountryDisplayText.Equals("XS", StringComparison.OrdinalIgnoreCase)) && nego.OriginatingSystem == OriginatingSystem.Maelstrom && nego.ExistingRuleName.Equals("Maelstrom auto-reject if no allocation", StringComparison.OrdinalIgnoreCase))
                        {
                            switch (nego.AssetClass)
                            {
                                case AssetClass.Europe:
                                    nego.QuotationCountryDisplayText = "AT";
                                    break;
                                case AssetClass.Asia:
                                    nego.QuotationCountryDisplayText = "JP";
                                    break;
                                case AssetClass.Americas:
                                    nego.QuotationCountryDisplayText = "CA";
                                    break;
                            }
                        }
                    }
                    if (!nego.QuotationCountryDisplayTextSpecified && nego.QuotationCurrencyDisplayTextSpecified && nego.AssetClassDisplayTextSpecified)
                    {
                        Country country = _countries.Values.FirstOrDefault(a => nego.QuotationCurrencyDisplayText.Equals(a.Currency) && nego.AssetClassDisplayText.Equals(a.AssetClass));
                        if (country != null)
                        {
                            nego.QuotationCountryDisplayText = country.CountryCode;
                        }
                    }

                    nego.ReasonCodes = string.Join(",", reasonCodes);
                    SetAverageTradeDuration(nego);

                    //TEMP: Only adding Equilend Orders for now, with Rule 302
                    //double ruleRank;
                    //if (nego.OriginatingSystem == OriginatingSystem.Equilend)
                    //&& double.TryParse(row.Columns[columnMappings[RuleRankColumn]].DisplayText, out ruleRank) && ruleRank.CompareTo(302) == 0)
                    //if (nego.ExistingRuleName.IndexOf("special", StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        negotiations.Items.Add(nego);
                    }
                }
            }

            return (negotiationsCount = negotiations.Items.Count) > 0;
        }

        private IEnumerable<string> GetFilesToProcess()
        {
            var files = _generateEquityXml ? Directory.GetFiles(Path.GetFullPath(FolderPath), "Daily_MIS_Equity_Report*") : Directory.GetFiles(Path.GetFullPath(FolderPath), "Daily_MIS_FI_Report*");

            //List<string> filesToProcess = (from file in files let dt = File.GetCreationTime(file) where dt > DateTime.Now.AddDays(-5) select file).ToList();
            var filesToProcess = new List<string>();
            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    continue;
                }
                string dateAsString = fileName.Replace("Daily_MIS_Equity_Report",string.Empty).Replace(".",string.Empty).Trim();
                try
                {
                    DateTime fileCreationDate = DateTime.ParseExact(dateAsString, "yyyyMMdd", CultureInfo.InvariantCulture);
                    //TODO: Revert
                    //if (fileCreationDate > DateTime.Now.AddDays(_days))
                    {
                        filesToProcess.Add(file);
                    }
                }
                catch (FormatException)
                {
                        
                }
            }

            //filesToProcess.Sort();

            string info = Path.Combine(Path.GetTempPath(), "ordersInfo.txt");

            using (StreamWriter sw = File.CreateText(info))
            {
                foreach (string file in filesToProcess)
                {
                    sw.WriteLine(Path.GetFileNameWithoutExtension(file).Replace(" ", "."));
                }
            }

            return filesToProcess;
        }

        private void SetAverageTradeDuration(Negotiation nego)
        {
            //nego.AverageTradeDuration = double.NaN;
            nego.AverageTradeDuration = nego.OriginatingSystem == OriginatingSystem.Equilend
                                ? DefaultEquilendAverageTradeDuration
                                : DefaultOtherAverageTradeDuration;

            HashSet<AverageMisData> data;
            KeyValuePair<string, Counterparty> cpty = _counterpartyMappings.FirstOrDefault(c => c.Value.ShortCode.Equals(nego.CounterpartyName));
            string g1CptyMappingValue = cpty.Key != null ? cpty.Value.Gl1Zh : nego.CounterpartyName;
            if (_misAveragesData.TryGetValue(g1CptyMappingValue, out data))
            {
                var item =
                    data.FirstOrDefault(
                        c =>
                        c.SettlementMode.Equals(nego.CurrentOrder.SettlementModeDisplayText, StringComparison.OrdinalIgnoreCase) &&
                        ((c.TradeCategory.Equals("eql", StringComparison.OrdinalIgnoreCase) &&
                          nego.OriginatingSystem == OriginatingSystem.Equilend) || (c.TradeCategory.Equals("none", StringComparison.OrdinalIgnoreCase) &&
                          nego.OriginatingSystem != OriginatingSystem.Equilend))
                        );


                //if (item.Count > 1)
                //{
                //    throw new Exception("Found duplicate settlement modes for a single cpty!!");
                //}

                //var firstOrDefault = item.FirstOrDefault();
                if (item != null)
                {
                    nego.AverageTradeDuration = item.AverageTradeDuration;
                }
            }

            //if (nego.AverageTradeDuration.CompareTo(double.NaN) == 0)
            //{
            //    nego.AverageTradeDuration = nego.OriginatingSystem == OriginatingSystem.Equilend
            //                                    ? DefaultEquilendAverageTradeDuration
            //                                    : DefaultOtherAverageTradeDuration;
            //}
        }

        private static AverageMisData GetAveragesDataItem(string cptyId, string sMode, DataRow row)
        {
            return new AverageMisData
            {
                CounterpartyId = cptyId,
                SettlementMode = sMode,
                TradeCategory =  GetCellValue(row,AvgTradeCatColumn),
                AverageTradeDuration = TryConvert<double>(row, AvgTradeDurationColumn),
                AverageSettlement = TryConvert<double>(row, AvgSettlementColumn),
                AverageSettlementFeeUsd = TryConvert<double>(row, AvgSettFeeUsdColumn),
                AverageInitialLnvalUsd = TryConvert<double>(row, AvgInitLnvalUsdColumn),
                AverageEarningAfterSettlementCost = TryConvert<double>(row, AvgEarningAfterSettCostColumn)
            };
        }

        private static T TryConvert<T>(DataRow row, string columnName)
        {
            T value = default(T);

            var s = row[columnName];
            if (s != null)
            {
                string textValue = Convert.ToString(s).Replace(",", String.Empty);
                if (!string.IsNullOrWhiteSpace(textValue))
                {
                    try
                    {
                        value = (T)ChangeType(typeof(T), textValue);
                    }
                    catch
                    {
                        Console.WriteLine(@"Can't convert given string '{0}' to type '{1}'", textValue, value.GetType());
                    }
                }
            }

            return value;
        }

        public static object ChangeType(Type t, object value)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(t);
            return tc.ConvertFrom(value);

        }

        private static string GetCellValue(DataRow row, string columnName)
        {
            string value = row.Table.Columns.Contains(columnName) ? Convert.ToString(row[columnName]) : null;

            return value != null ? value.Trim() : null;
        }


        private bool Serialize(Negotiations negotiations, string fileName)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(negotiations.GetType());
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                using (TextWriter writer = new StreamWriter(fileName))
                {
                    serializer.Serialize(writer, negotiations, ns);
                }

                return true;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //MfcSpringManager.SendCustomEmail("Test", "Test", new List<string> { "sh-ap-maelstrom-uat@ubs.com" }, "Hussain.Khan@ubs.com", "Khan");
            //MfcSpringManager.SendCustomEmail("Test", "Test", new List<string> { "Hussain.Khan@ubs.com" }, UserPrincipal.Current.EmailAddress, UserPrincipal.Current.Surname);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            MfcSpringManager.ExitApplication();
            base.OnClosing(e);
        }
    }
}
