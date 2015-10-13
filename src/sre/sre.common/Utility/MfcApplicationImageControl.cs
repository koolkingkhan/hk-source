// ***********************************************************************
// Assembly         : Common
// Author           : bethunro
// Created          : 07-04-2013
//
// Last Modified By : bethunro
// Last Modified On : 07-04-2013
// ***********************************************************************
// <copyright file="MfcApplicationImageControl.cs" company="UBS AG">
//     Copyright (c) UBS AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace Ubs.Collateral.Sre.Common.Utility
{
    /// <summary>
    /// Class MfcApplicationImageControl
    /// </summary>
    public partial class MfcApplicationImageControl : UserControl, IMfcApplicationImageControl
    {
        /// <summary>
        /// All images in the imageList control
        /// </summary>
        /// <value>The application images24.</value>
        public ImageList ApplicationImages24
        {
            get
            {
                return imageList24;
            }
        }

        /// <summary>
        /// Gets the application images16.
        /// </summary>
        /// <value>The application images16.</value>
        public ImageList ApplicationImages16
        {
            get
            {
                return imageList16;
            }
        }

        /// <summary>
        /// String representations of keys are defined here if necessary
        /// </summary>
        /// <value>The magic wand image16 string.</value>
        public string MagicWandImage16String
        {
            get
            {
                return "magicWand16";
            }
        }

        /// <summary>
        /// Gets the flag yellow image16 string.
        /// </summary>
        /// <value>The flag yellow image16 string.</value>
        public string FlagYellowImage16String
        {
            get
            {
                return "flagYellow16";
            }
        }

        /// <summary>
        /// Gets the flag red image16 string.
        /// </summary>
        /// <value>The flag red image16 string.</value>
        public string FlagRedImage16String
        {
            get
            {
                return "flagRed16";
            }
        }

        /// <summary>
        /// Gets the flag green image16 string.
        /// </summary>
        /// <value>The flag green image16 string.</value>
        public string FlagGreenImage16String
        {
            get
            {
                return "flagGreen16";
            }
        }

        /// <summary>
        /// Gets the brush image16 string.
        /// </summary>
        /// <value>The brush image16 string.</value>
        public string BrushImage16String
        {
            get
            {
                return "brush16";
            }
        }

        /// <summary>
        /// Gets the save image16 string.
        /// </summary>
        /// <value>The save image16 string.</value>
        public string SaveImage16String
        {
            get
            {
                return "save16";
            }
        }

        /// <summary>
        /// Gets the lock image16 string.
        /// </summary>
        /// <value>The lock image16 string.</value>
        public string LockImage16String
        {
            get
            {
                return "lock16";
            }
        }

        /// <summary>
        /// Gets the unlock image16 string.
        /// </summary>
        /// <value>The unlock image16 string.</value>
        public string UnlockImage16String
        {
            get
            {
                return "unlock16";
            }
        }

        /// <summary>
        /// Gets the lock partial image16 string.
        /// </summary>
        /// <value>The lock partial image16 string.</value>
        public string LockPartialImage16String
        {
            get
            {
                return "lockPartial16";
            }
        }

        /// <summary>
        /// Gets the mail image16 string.
        /// </summary>
        /// <value>The mail image16 string.</value>
        public string MailImage16String
        {
            get
            {
                return "mail16";
            }
        }

        /// <summary>
        /// Gets the mail in image16 string.
        /// </summary>
        /// <value>The mail in image16 string.</value>
        public string MailInImage16String
        {
            get
            {
                return "mailIn16";
            }
        }

        /// <summary>
        /// Gets the mail out image16 string.
        /// </summary>
        /// <value>The mail out image16 string.</value>
        public string MailOutImage16String
        {
            get
            {
                return "mailOut16";
            }
        }

        /// <summary>
        /// Gets the trades snapshot image16 string.
        /// </summary>
        /// <value>The trades snapshot image16 string.</value>
        public string TradesSnapshotImage16String
        {
            get
            {
                return "tradeSnapshot16";
            }
        }

        /// <summary>
        /// Gets the trades snapshot image24 string.
        /// </summary>
        /// <value>The trades snapshot image24 string.</value>
        public string TradesSnapshotImage24String
        {
            get
            {
                return "tradeSnapshot24";
            }
        }

        /// <summary>
        /// Gets the arrow up image16 string.
        /// </summary>
        /// <value>The arrow up image16 string.</value>
        public string ArrowUpImage16String
        {
            get
            {
                return "arrowUp16";
            }
        }

        /// <summary>
        /// Gets the arrow down image16 string.
        /// </summary>
        /// <value>The arrow down image16 string.</value>
        public string ArrowDownImage16String
        {
            get
            {
                return "arrowDown16";
            }
        }

        /// <summary>
        /// Gets the trades image16 string.
        /// </summary>
        /// <value>The trades image16 string.</value>
        public string TradesImage16String
        {
            get
            {
                return "trades16";
            }
        }

        /// <summary>
        /// Gets the grid image16 string.
        /// </summary>
        /// <value>The grid image16 string.</value>
        public string GridImage16String
        {
            get
            {
                return "grid16";
            }
        }

        /// <summary>
        /// Gets the general image16 string.
        /// </summary>
        /// <value>The general image16 string.</value>
        public string GeneralImage16String
        {
            get
            {
                return "cm16";
            }
        }

        /// <summary>
        /// Gets the status bar image16 string.
        /// </summary>
        /// <value>The status bar image16 string.</value>
        public string StatusBarImage16String
        {
            get
            {
                return "status16";
            }
        }

        /// <summary>
        /// Gets the matrix image16 string.
        /// </summary>
        /// <value>The matrix image16 string.</value>
        public string MatrixImage16String
        {
            get
            {
                return "matrix16";
            }
        }

        /// <summary>
        /// Gets the bug image16 string.
        /// </summary>
        /// <value>The bug image16 string.</value>
        public string BugImage16String
        {
            get
            {
                return "bug16";
            }
        }

        /// <summary>
        /// Gets the balance sheet image16 string.
        /// </summary>
        /// <value>The balance sheet image16 string.</value>
        public string BalanceSheetImage16String
        {
            get
            {
                return "balanceSheet16";
            }
        }

        /// <summary>
        /// Gets the excel square image16 string.
        /// </summary>
        /// <value>The excel square image16 string.</value>
        public string ExcelSquareImage16String
        {
            get
            {
                return "excelSquare16";
            }
        }

        /// <summary>
        /// Gets the excel image16 string.
        /// </summary>
        /// <value>The excel image16 string.</value>
        public string ExcelImage16String
        {
            get
            {
                return "excel16";
            }
        }

        /// <summary>
        /// Gets the job image16 string.
        /// </summary>
        /// <value>The job image16 string.</value>
        public string JobImage16String
        {
            get
            {
                return "jobImage16";
            }
        }

        /// <summary>
        /// Gets the line chart image16 string.
        /// </summary>
        /// <value>The line chart image16 string.</value>
        public string LineChartImage16String
        {
            get
            {
                return "lineChart16";
            }
        }

        /// <summary>
        /// Gets the green tick image16 string.
        /// </summary>
        /// <value>The green tick image16 string.</value>
        public string GreenTickImage16String
        {
            get
            {
                return "greenTickArrow16";
            }
        }

        /// <summary>
        /// Gets the red cross image16 string.
        /// </summary>
        /// <value>The red cross image16 string.</value>
        public string RedCrossImage16String
        {
            get
            {
                return "delete16";
            }
        }

        /// <summary>
        /// Gets the small tick1 image16 string.
        /// </summary>
        /// <value>The small tick1 image16 string.</value>
        public string SmallTick1Image16String
        {
            get
            {
                return "smallTick1Arrow16";
            }
        }

        /// <summary>
        /// Gets the small tick2 image16 string.
        /// </summary>
        /// <value>The small tick2 image16 string.</value>
        public string SmallTick2Image16String
        {
            get
            {
                return "smallTick2Arrow16";
            }
        }

        /// <summary>
        /// Gets the email image16 string.
        /// </summary>
        /// <value>The email image16 string.</value>
        public string EmailImage16String
        {
            get
            {
                return "email16";
            }
        }

        /// <summary>
        /// Gets the email image24 string.
        /// </summary>
        /// <value>The email image24 string.</value>
        public string EmailImage24String
        {
            get
            {
                return "mail24";
            }
        }

        /// <summary>
        /// Gets the inbox email image24 string.
        /// </summary>
        /// <value>The inbox email image24 string.</value>
        public string InboxEmailImage24String
        {
            get
            {
                return "mailIn24";
            }
        }

        /// <summary>
        /// Gets the advanced filterl image16 string.
        /// </summary>
        /// <value>The advanced filterl image16 string.</value>
        public string AdvancedFilterlImage16String
        {
            get
            {
                return "advancedFilter16";
            }
        }

        /// <summary>
        /// Define images here
        /// </summary>
        /// <value>The pin green image16.</value>
        public Image PinGreenImage16
        {
            get
            {
                return ApplicationImages16.Images["pinGreen16"];
            }
        }

        /// <summary>
        /// Gets the pin red image16.
        /// </summary>
        /// <value>The pin red image16.</value>
        public Image PinRedImage16
        {
            get
            {
                return ApplicationImages16.Images["pinRed16"];
            }
        }

        /// <summary>
        /// Gets the magic wand image16.
        /// </summary>
        /// <value>The magic wand image16.</value>
        public Image MagicWandImage16
        {
            get
            {
                return ApplicationImages16.Images["magicWand16"];
            }
        }

        /// <summary>
        /// Gets the legend image16.
        /// </summary>
        /// <value>The legend image16.</value>
        public Image LegendImage16
        {
            get
            {
                return ApplicationImages16.Images["legend16"];
            }
        }

        /// <summary>
        /// Gets the email management image16.
        /// </summary>
        /// <value>The email management image16.</value>
        public Image EmailManagementImage16
        {
            get
            {
                return ApplicationImages16.Images["emailManagement16"];
            }
        }

        /// <summary>
        /// Gets the analytics image16.
        /// </summary>
        /// <value>The analytics image16.</value>
        public Image AnalyticsImage16
        {
            get
            {
                return ApplicationImages16.Images["analytics16"];
            }
        }

        /// <summary>
        /// Gets the batch emails image16.
        /// </summary>
        /// <value>The batch emails image16.</value>
        public Image BatchEmailsImage16
        {
            get
            {
                return ApplicationImages16.Images["batchEmails16"];
            }
        }

        /// <summary>
        /// Gets the message image16.
        /// </summary>
        /// <value>The message image16.</value>
        public Image MessageImage16
        {
            get
            {
                return ApplicationImages16.Images["message16"];
            }
        }

        /// <summary>
        /// Gets the batch conversation image16.
        /// </summary>
        /// <value>The batch conversation image16.</value>
        public Image BatchConversationImage16
        {
            get
            {
                return ApplicationImages16.Images["batchConversations16"];
            }
        }

        /// <summary>
        /// Gets the detailed info image16.
        /// </summary>
        /// <value>The detailed info image16.</value>
        public Image DetailedInfoImage16
        {
            get
            {
                return ApplicationImages16.Images["detailedInfo16"];
            }
        }

        /// <summary>
        /// Gets the order negotiation image16.
        /// </summary>
        /// <value>The order negotiation image16.</value>
        public Image OrderNegotiationImage16
        {
            get
            {
                return ApplicationImages16.Images["orderNegotiations16"];
            }
        }

        /// <summary>
        /// Gets the row selection16.
        /// </summary>
        /// <value>The row selection16.</value>
        public Image RowSelection16
        {
            get
            {
                return ApplicationImages16.Images["rowSelection16"];
            }
        }

        /// <summary>
        /// Gets the window vertical image16.
        /// </summary>
        /// <value>The window vertical image16.</value>
        public Image WindowVerticalImage16
        {
            get
            {
                return ApplicationImages16.Images["windowVertical16"];
            }
        }

        /// <summary>
        /// Gets the window horizontal image16.
        /// </summary>
        /// <value>The window horizontal image16.</value>
        public Image WindowHorizontalImage16
        {
            get
            {
                return ApplicationImages16.Images["windowHorizontal16"];
            }
        }

        /// <summary>
        /// Gets the window legend image16.
        /// </summary>
        /// <value>The window legend image16.</value>
        public Image WindowLegendImage16
        {
            get
            {
                return ApplicationImages16.Images["windowLegend16"];
            }
        }

        /// <summary>
        /// Gets the window load image16.
        /// </summary>
        /// <value>The window load image16.</value>
        public Image WindowLoadImage16
        {
            get
            {
                return ApplicationImages16.Images["windowLoad16"];
            }
        }

        /// <summary>
        /// Gets the window save image16.
        /// </summary>
        /// <value>The window save image16.</value>
        public Image WindowSaveImage16
        {
            get
            {
                return ApplicationImages16.Images["windowSave16"];
            }
        }

        /// <summary>
        /// Gets the window order image16.
        /// </summary>
        /// <value>The window order image16.</value>
        public Image WindowOrderImage16
        {
            get
            {
                return ApplicationImages16.Images["windowOrder16"];
            }
        }

        /// <summary>
        /// Gets the mail image16.
        /// </summary>
        /// <value>The mail image16.</value>
        public Image MailImage16
        {
            get
            {
                return ApplicationImages16.Images["mail16"];
            }
        }

        /// <summary>
        /// Gets the mail in image16.
        /// </summary>
        /// <value>The mail in image16.</value>
        public Image MailInImage16
        {
            get
            {
                return ApplicationImages16.Images["mailIn16"];
            }
        }

        /// <summary>
        /// Gets the mail out image16.
        /// </summary>
        /// <value>The mail out image16.</value>
        public Image MailOutImage16
        {
            get
            {
                return ApplicationImages16.Images["mailOut16"];
            }
        }

        /// <summary>
        /// Gets the arrow up image16.
        /// </summary>
        /// <value>The arrow up image16.</value>
        public Image ArrowUpImage16
        {
            get
            {
                return ApplicationImages16.Images["arrowUp16"];
            }
        }

        /// <summary>
        /// Gets the arrow down image16.
        /// </summary>
        /// <value>The arrow down image16.</value>
        public Image ArrowDownImage16
        {
            get
            {
                return ApplicationImages16.Images["arrowDown16"];
            }
        }

        /// <summary>
        /// Gets the email image16.
        /// </summary>
        /// <value>The email image16.</value>
        public Image EmailImage16
        {
            get
            {
                return ApplicationImages16.Images["email16"];
            }
        }

        /// <summary>
        /// Gets the reply image16.
        /// </summary>
        /// <value>The reply image16.</value>
        public Image ReplyImage16
        {
            get
            {
                return ApplicationImages16.Images["reply16"];
            }
        }

        /// <summary>
        /// Gets the green tick arrow image16.
        /// </summary>
        /// <value>The green tick arrow image16.</value>
        public Image GreenTickArrowImage16
        {
            get
            {
                return ApplicationImages16.Images["greenTickArrow16"];
            }
        }

        /// <summary>
        /// Gets the small tick1 arrow image16.
        /// </summary>
        /// <value>The small tick1 arrow image16.</value>
        public Image SmallTick1ArrowImage16
        {
            get
            {
                return ApplicationImages16.Images["smallTick1Arrow16"];
            }
        }

        /// <summary>
        /// Gets the small tick2 arrow image16.
        /// </summary>
        /// <value>The small tick2 arrow image16.</value>
        public Image SmallTick2ArrowImage16
        {
            get
            {
                return ApplicationImages16.Images["smallTick2Arrow16"];
            }
        }

        /// <summary>
        /// Gets the refresh job image16.
        /// </summary>
        /// <value>The refresh job image16.</value>
        public Image RefreshJobImage16
        {
            get
            {
                return ApplicationImages16.Images["refreshJob16"];
            }
        }

        /// <summary>
        /// Gets the pencil image16.
        /// </summary>
        /// <value>The pencil image16.</value>
        public Image PencilImage16
        {
            get
            {
                return ApplicationImages16.Images["pencilImage16"];
            }
        }

        /// <summary>
        /// Gets the window colours image16.
        /// </summary>
        /// <value>The window colours image16.</value>
        public Image WindowColoursImage16
        {
            get
            {
                return ApplicationImages16.Images["windowColours16"];
            }
        }

        /// <summary>
        /// Gets the books image16.
        /// </summary>
        /// <value>The books image16.</value>
        public Image BooksImage16
        {
            get
            {
                return ApplicationImages16.Images["books16"];
            }
        }

        /// <summary>
        /// Gets the run job image16.
        /// </summary>
        /// <value>The run job image16.</value>
        public Image RunJobImage16
        {
            get
            {
                return ApplicationImages16.Images["runJob16"];
            }
        }

        /// <summary>
        /// Gets the line chart image16.
        /// </summary>
        /// <value>The line chart image16.</value>
        public Image LineChartImage16
        {
            get
            {
                return ApplicationImages16.Images["lineChart16"];
            }
        }

        /// <summary>
        /// Gets the folder open image16.
        /// </summary>
        /// <value>The folder open image16.</value>
        public Image FolderOpenImage16
        {
            get
            {
                return ApplicationImages16.Images["folderOpen16"];
            }
        }

        /// <summary>
        /// Gets the job image16.
        /// </summary>
        /// <value>The job image16.</value>
        public Image JobImage16
        {
            get
            {
                return ApplicationImages16.Images["jobImage16"];
            }
        }

        /// <summary>
        /// Gets the cockpit image16.
        /// </summary>
        /// <value>The cockpit image16.</value>
        public Image CockpitImage16
        {
            get
            {
                return ApplicationImages16.Images["cockpitImage16"];
            }
        }

        /// <summary>
        /// Gets the money bag image16.
        /// </summary>
        /// <value>The money bag image16.</value>
        public Image MoneyBagImage16
        {
            get
            {
                return ApplicationImages16.Images["moneyBag16"];
            }
        }

        /// <summary>
        /// Gets the new portfolio image16.
        /// </summary>
        /// <value>The new portfolio image16.</value>
        public Image NewPortfolioImage16
        {
            get
            {
                return ApplicationImages16.Images["newPortfolio16"];
            }
        }

        /// <summary>
        /// Gets the delete portfolio image16.
        /// </summary>
        /// <value>The delete portfolio image16.</value>
        public Image DeletePortfolioImage16
        {
            get
            {
                return ApplicationImages16.Images["deletePortfolio16"];
            }
        }

        /// <summary>
        /// Gets the view portfolio image16.
        /// </summary>
        /// <value>The view portfolio image16.</value>
        public Image ViewPortfolioImage16
        {
            get
            {
                return ApplicationImages16.Images["viewPortfolio16"];
            }
        }

        /// <summary>
        /// Gets the money bag dollar image16.
        /// </summary>
        /// <value>The money bag dollar image16.</value>
        public Image MoneyBagDollarImage16
        {
            get
            {
                return ApplicationImages16.Images["moneybagDollar16"];
            }
        }

        /// <summary>
        /// Gets the copy risk image16.
        /// </summary>
        /// <value>The copy risk image16.</value>
        public Image CopyRiskImage16
        {
            get
            {
                return ApplicationImages16.Images["copyRiskTemplate16"];
            }
        }

        /// <summary>
        /// Gets the new pricing image16.
        /// </summary>
        /// <value>The new pricing image16.</value>
        public Image NewPricingImage16
        {
            get
            {
                return ApplicationImages16.Images["newPricing16"];
            }
        }

        /// <summary>
        /// Gets the new risk image16.
        /// </summary>
        /// <value>The new risk image16.</value>
        public Image NewRiskImage16
        {
            get
            {
                return ApplicationImages16.Images["newRiskTemplate16"];
            }
        }

        /// <summary>
        /// Gets the edit risk image16.
        /// </summary>
        /// <value>The edit risk image16.</value>
        public Image EditRiskImage16
        {
            get
            {
                return ApplicationImages16.Images["editRiskTemplate16"];
            }
        }

        /// <summary>
        /// Gets the delete risk image16.
        /// </summary>
        /// <value>The delete risk image16.</value>
        public Image DeleteRiskImage16
        {
            get
            {
                return ApplicationImages16.Images["deleteRiskTemplate16"];
            }
        }

        /// <summary>
        /// Gets up minus image16.
        /// </summary>
        /// <value>Up minus image16.</value>
        public Image UpMinusImage16
        {
            get
            {
                return ApplicationImages16.Images["up_minus16"];
            }
        }

        /// <summary>
        /// Gets up plus image16.
        /// </summary>
        /// <value>Up plus image16.</value>
        public Image UpPlusImage16
        {
            get
            {
                return ApplicationImages16.Images["up_plus16"];
            }
        }

        /// <summary>
        /// Gets the select all image16.
        /// </summary>
        /// <value>The select all image16.</value>
        public Image SelectAllImage16
        {
            get
            {
                return ApplicationImages16.Images["selectAll16"];
            }
        }

        /// <summary>
        /// Gets the edit image16.
        /// </summary>
        /// <value>The edit image16.</value>
        public Image EditImage16
        {
            get
            {
                return ApplicationImages16.Images["edit16"];
            }
        }

        /// <summary>
        /// Gets the heartbeat on image16.
        /// </summary>
        /// <value>The heartbeat on image16.</value>
        public Image HeartbeatOnImage16
        {
            get
            {
                return ApplicationImages16.Images["heartBeatOn16"];
            }
        }

        /// <summary>
        /// Gets the heartbeat off image16.
        /// </summary>
        /// <value>The heartbeat off image16.</value>
        public Image HeartbeatOffImage16
        {
            get
            {
                return ApplicationImages16.Images["heartBeatOn16"];
            }
        }

        /// <summary>
        /// Gets the available image16.
        /// </summary>
        /// <value>The available image16.</value>
        public Image AvailableImage16
        {
            get
            {
                return ApplicationImages16.Images["available16"];
            }
        }

        /// <summary>
        /// Gets the UN available image16.
        /// </summary>
        /// <value>The UN available image16.</value>
        public Image UNAvailableImage16
        {
            get
            {
                return ApplicationImages16.Images["unavailable16"];
            }
        }

        /// <summary>
        /// Gets the unknown image16.
        /// </summary>
        /// <value>The unknown image16.</value>
        public Image UnknownImage16
        {
            get
            {
                return ApplicationImages16.Images["unknown16"];
            }
        }

        /// <summary>
        /// Gets the brush image16.
        /// </summary>
        /// <value>The brush image16.</value>
        public Image BrushImage16
        {
            get
            {
                return ApplicationImages16.Images["brush16"];
            }
        }

        /// <summary>
        /// Gets the evaluate image16.
        /// </summary>
        /// <value>The evaluate image16.</value>
        public Image EvaluateImage16
        {
            get
            {
                return ApplicationImages16.Images["evaluate16"];
            }
        }

        /// <summary>
        /// Gets the trader image16.
        /// </summary>
        /// <value>The trader image16.</value>
        public Image TraderImage16
        {
            get
            {
                return ApplicationImages16.Images["trader16"];
            }
        }

        /// <summary>
        /// Gets the support image16.
        /// </summary>
        /// <value>The support image16.</value>
        public Image SupportImage16
        {
            get
            {
                return ApplicationImages16.Images["support16"];
            }
        }

        /// <summary>
        /// Gets the lock image16.
        /// </summary>
        /// <value>The lock image16.</value>
        public Image LockImage16
        {
            get
            {
                return ApplicationImages16.Images["lock16"];
            }
        }

        /// <summary>
        /// Gets the lock all image16.
        /// </summary>
        /// <value>The lock all image16.</value>
        public Image LockAllImage16
        {
            get
            {
                return ApplicationImages16.Images["lockAll16"];
            }
        }

        /// <summary>
        /// Gets the unlock image16.
        /// </summary>
        /// <value>The unlock image16.</value>
        public Image UnlockImage16
        {
            get
            {
                return ApplicationImages16.Images["unlock16"];
            }
        }

        /// <summary>
        /// Gets the lock partial image16.
        /// </summary>
        /// <value>The lock partial image16.</value>
        public Image LockPartialImage16
        {
            get
            {
                return ApplicationImages16.Images["lockPartial16"];
            }
        }

        /// <summary>
        /// Gets the copy image16.
        /// </summary>
        /// <value>The copy image16.</value>
        public Image CopyImage16
        {
            get
            {
                return ApplicationImages16.Images["copy16"];
            }
        }

        /// <summary>
        /// Gets the copy all image16.
        /// </summary>
        /// <value>The copy all image16.</value>
        public Image CopyAllImage16
        {
            get
            {
                return ApplicationImages16.Images["copyAll16"];
            }
        }

        /// <summary>
        /// Gets the paste image16.
        /// </summary>
        /// <value>The paste image16.</value>
        public Image PasteImage16
        {
            get
            {
                return ApplicationImages16.Images["paste16"];
            }
        }

        /// <summary>
        /// Gets the add image16.
        /// </summary>
        /// <value>The add image16.</value>
        public Image AddImage16
        {
            get
            {
                return ApplicationImages16.Images["add16"];
            }
        }

        /// <summary>
        /// Gets the delete image16.
        /// </summary>
        /// <value>The delete image16.</value>
        public Image DeleteImage16
        {
            get
            {
                return ApplicationImages16.Images["delete16"];
            }
        }

        /// <summary>
        /// Gets the send image16.
        /// </summary>
        /// <value>The send image16.</value>
        public Image SendImage16
        {
            get
            {
                return ApplicationImages16.Images["send16"];
            }
        }

        /// <summary>
        /// Gets the send all image16.
        /// </summary>
        /// <value>The send all image16.</value>
        public Image SendAllImage16
        {
            get
            {
                return ApplicationImages16.Images["sendAll16"];
            }
        }

        /// <summary>
        /// Gets the data explorers image16.
        /// </summary>
        /// <value>The data explorers image16.</value>
        public Image DataExplorersImage16
        {
            get
            {
                return ApplicationImages16.Images["dataExplorers16"];
            }
        }

        /// <summary>
        /// Gets the B and L image16.
        /// </summary>
        /// <value>The B and L image16.</value>
        public Image BAndLImage16
        {
            get
            {
                return ApplicationImages16.Images["BAndL16"];
            }
        }

        /// <summary>
        /// Gets the hand stop image16.
        /// </summary>
        /// <value>The hand stop image16.</value>
        public Image HandStopImage16
        {
            get
            {
                return ApplicationImages16.Images["handStop16"];
            }
        }

        /// <summary>
        /// Gets the balance sheet image16.
        /// </summary>
        /// <value>The balance sheet image16.</value>
        public Image BalanceSheetImage16
        {
            get
            {
                return ApplicationImages16.Images[BalanceSheetImage16String];
            }
        }

        /// <summary>
        /// Gets the document clear image16.
        /// </summary>
        /// <value>The document clear image16.</value>
        public Image DocumentClearImage16
        {
            get
            {
                return ApplicationImages16.Images["documentClear16"];
            }
        }

        /// <summary>
        /// Gets the print image16.
        /// </summary>
        /// <value>The print image16.</value>
        public Image PrintImage16
        {
            get
            {
                return ApplicationImages16.Images["print16"];
            }
        }

        /// <summary>
        /// Gets the print preview image16.
        /// </summary>
        /// <value>The print preview image16.</value>
        public Image PrintPreviewImage16
        {
            get
            {
                return ApplicationImages16.Images["printPreview16"];
            }
        }

        /// <summary>
        /// Gets the bug image16.
        /// </summary>
        /// <value>The bug image16.</value>
        public Image BugImage16
        {
            get
            {
                return ApplicationImages16.Images[BugImage16String];
            }
        }

        /// <summary>
        /// Gets the grid image16.
        /// </summary>
        /// <value>The grid image16.</value>
        public Image GridImage16
        {
            get
            {
                return ApplicationImages16.Images[GridImage16String];
            }
        }

        /// <summary>
        /// Gets the status bar image16.
        /// </summary>
        /// <value>The status bar image16.</value>
        public Image StatusBarImage16
        {
            get
            {
                return ApplicationImages16.Images[StatusBarImage16String];
            }
        }

        /// <summary>
        /// Gets the selection image16.
        /// </summary>
        /// <value>The selection image16.</value>
        public Image SelectionImage16
        {
            get
            {
                return ApplicationImages16.Images["selection16"];
            }
        }

        /// <summary>
        /// Gets the flag yellow image16.
        /// </summary>
        /// <value>The flag yellow image16.</value>
        public Image FlagYellowImage16
        {
            get
            {
                return ApplicationImages16.Images["flagYellow16"];
            }
        }

        /// <summary>
        /// Gets the flag red image16.
        /// </summary>
        /// <value>The flag red image16.</value>
        public Image FlagRedImage16
        {
            get
            {
                return ApplicationImages16.Images["flagRed16"];
            }
        }

        /// <summary>
        /// Gets the flag green image16.
        /// </summary>
        /// <value>The flag green image16.</value>
        public Image FlagGreenImage16
        {
            get
            {
                return ApplicationImages16.Images["flagGreen16"];
            }
        }

        /// <summary>
        /// Gets the trades snapshot image16.
        /// </summary>
        /// <value>The trades snapshot image16.</value>
        public Image TradesSnapshotImage16
        {
            get
            {
                return ApplicationImages16.Images[TradesSnapshotImage16String];
            }
        }

        /// <summary>
        /// Gets the trades image16.
        /// </summary>
        /// <value>The trades image16.</value>
        public Image TradesImage16
        {
            get
            {
                return ApplicationImages16.Images[TradesImage16String];
            }
        }

        /// <summary>
        /// Gets the matrix image16.
        /// </summary>
        /// <value>The matrix image16.</value>
        public Image MatrixImage16
        {
            get
            {
                return ApplicationImages16.Images[MatrixImage16String];
            }
        }

        /// <summary>
        /// Gets the excel image16.
        /// </summary>
        /// <value>The excel image16.</value>
        public Image ExcelImage16
        {
            get
            {
                return ApplicationImages16.Images["excel16"];
            }
        }

        /// <summary>
        /// Gets the excel circle image16.
        /// </summary>
        /// <value>The excel circle image16.</value>
        public Image ExcelCircleImage16
        {
            get
            {
                return ApplicationImages16.Images["excelCircle16"];
            }
        }

        /// <summary>
        /// Gets the excel square image16.
        /// </summary>
        /// <value>The excel square image16.</value>
        public Image ExcelSquareImage16
        {
            get
            {
                return ApplicationImages16.Images["excelSquare16"];
            }
        }

        /// <summary>
        /// Gets the client measurement image16.
        /// </summary>
        /// <value>The client measurement image16.</value>
        public Image ClientMeasurementImage16
        {
            get
            {
                return ApplicationImages16.Images[GeneralImage16String];
            }
        }

        /// <summary>
        /// Gets the cleanup image16.
        /// </summary>
        /// <value>The cleanup image16.</value>
        public Image CleanupImage16
        {
            get
            {
                return ApplicationImages16.Images["cleanup16"];
            }
        }

        /// <summary>
        /// Gets the find next image16.
        /// </summary>
        /// <value>The find next image16.</value>
        public Image FindNextImage16
        {
            get
            {
                return ApplicationImages16.Images["findNext16"];
            }
        }

        /// <summary>
        /// Gets the find image16.
        /// </summary>
        /// <value>The find image16.</value>
        public Image FindImage16
        {
            get
            {
                return ApplicationImages16.Images["find16"];
            }
        }

        /// <summary>
        /// Gets the find all image16.
        /// </summary>
        /// <value>The find all image16.</value>
        public Image FindAllImage16
        {
            get
            {
                return ApplicationImages16.Images["findAll16"];
            }
        }

        /// <summary>
        /// Gets the clear image16.
        /// </summary>
        /// <value>The clear image16.</value>
        public Image ClearImage16
        {
            get
            {
                return ApplicationImages16.Images["clear16"];
            }
        }

        /// <summary>
        /// Gets the close image16.
        /// </summary>
        /// <value>The close image16.</value>
        public Image CloseImage16
        {
            get
            {
                return ApplicationImages16.Images["close16"];
            }
        }

        /// <summary>
        /// Gets the save view image16.
        /// </summary>
        /// <value>The save view image16.</value>
        public Image SaveViewImage16
        {
            get
            {
                return ApplicationImages16.Images["saveView16"];
            }
        }

        /// <summary>
        /// Gets the load view image16.
        /// </summary>
        /// <value>The load view image16.</value>
        public Image LoadViewImage16
        {
            get
            {
                return ApplicationImages16.Images["loadView16"];
            }
        }

        /// <summary>
        /// Gets the price image16.
        /// </summary>
        /// <value>The price image16.</value>
        public Image PriceImage16
        {
            get
            {
                return ApplicationImages16.Images["priceImage16"];
            }
        }

        /// <summary>
        /// Gets the cancel image16.
        /// </summary>
        /// <value>The cancel image16.</value>
        public Image CancelImage16
        {
            get
            {
                return ApplicationImages16.Images["cancel16"];
            }
        }

        /// <summary>
        /// Gets the ok image16.
        /// </summary>
        /// <value>The ok image16.</value>
        public Image OkImage16
        {
            get
            {
                return ApplicationImages16.Images["ok16"];
            }
        }

        /// <summary>
        /// Gets the save image16.
        /// </summary>
        /// <value>The save image16.</value>
        public Image SaveImage16
        {
            get
            {
                return ApplicationImages16.Images["save16"];
            }
        }

        /// <summary>
        /// Gets the sort image16.
        /// </summary>
        /// <value>The sort image16.</value>
        public Image SortImage16
        {
            get
            {
                return ApplicationImages16.Images["sort16"];
            }
        }

        /// <summary>
        /// Gets the top arrow image16.
        /// </summary>
        /// <value>The top arrow image16.</value>
        public Image TopArrowImage16
        {
            get
            {
                return ApplicationImages16.Images["top16"];
            }
        }

        /// <summary>
        /// Gets the bottom arrow image16.
        /// </summary>
        /// <value>The bottom arrow image16.</value>
        public Image BottomArrowImage16
        {
            get
            {
                return ApplicationImages16.Images["bottom16"];
            }
        }

        /// <summary>
        /// Gets up arrow image16.
        /// </summary>
        /// <value>Up arrow image16.</value>
        public Image UpArrowImage16
        {
            get
            {
                return ApplicationImages16.Images["upArrow16"];
            }
        }

        /// <summary>
        /// Gets down arrow image16.
        /// </summary>
        /// <value>Down arrow image16.</value>
        public Image DownArrowImage16
        {
            get
            {
                return ApplicationImages16.Images["downArrow16"];
            }
        }

        /// <summary>
        /// Gets the left arrow image16.
        /// </summary>
        /// <value>The left arrow image16.</value>
        public Image LeftArrowImage16
        {
            get
            {
                return ApplicationImages16.Images["leftArrow16"];
            }
        }

        /// <summary>
        /// Gets the left arrow all image16.
        /// </summary>
        /// <value>The left arrow all image16.</value>
        public Image LeftArrowAllImage16
        {
            get
            {
                return ApplicationImages16.Images["leftArrowAll16"];
            }
        }

        /// <summary>
        /// Gets the right arrow image16.
        /// </summary>
        /// <value>The right arrow image16.</value>
        public Image RightArrowImage16
        {
            get
            {
                return ApplicationImages16.Images["rightArrow16"];
            }
        }

        /// <summary>
        /// Gets the right arrow all image16.
        /// </summary>
        /// <value>The right arrow all image16.</value>
        public Image RightArrowAllImage16
        {
            get
            {
                return ApplicationImages16.Images["rightArrowAll16"];
            }
        }

        /// <summary>
        /// Gets the upload image16.
        /// </summary>
        /// <value>The upload image16.</value>
        public Image UploadImage16
        {
            get
            {
                return ApplicationImages16.Images["upload16"];
            }
        }

        /// <summary>
        /// Gets the exit image16.
        /// </summary>
        /// <value>The exit image16.</value>
        public Image ExitImage16
        {
            get
            {
                return ApplicationImages16.Images["exit16"];
            }
        }

        /// <summary>
        /// Gets the customize image16.
        /// </summary>
        /// <value>The customize image16.</value>
        public Image CustomizeImage16
        {
            get
            {
                return ApplicationImages16.Images["customize16"];
            }
        }

        /// <summary>
        /// Gets the clear filter image16.
        /// </summary>
        /// <value>The clear filter image16.</value>
        public Image ClearFilterImage16
        {
            get
            {
                return ApplicationImages16.Images["clearFilter16"];
            }
        }

        /// <summary>
        /// Gets the advanced filter image16.
        /// </summary>
        /// <value>The advanced filter image16.</value>
        public Image AdvancedFilterImage16
        {
            get
            {
                return ApplicationImages16.Images["advancedFilter16"];
            }
        }

        /// <summary>
        /// Gets the export image16.
        /// </summary>
        /// <value>The export image16.</value>
        public Image ExportImage16
        {
            get
            {
                return ApplicationImages16.Images["export16"];
            }
        }

        /// <summary>
        /// Gets the help image16.
        /// </summary>
        /// <value>The help image16.</value>
        public Image HelpImage16
        {
            get
            {
                return ApplicationImages16.Images["help16"];
            }
        }

        /// <summary>
        /// Gets the column image16.
        /// </summary>
        /// <value>The column image16.</value>
        public Image ColumnImage16
        {
            get
            {
                return ApplicationImages16.Images["columnAdd16"];
            }
        }

        // 24,24 definitions

        /// <summary>
        /// Gets the window vertical image24.
        /// </summary>
        /// <value>The window vertical image24.</value>
        public Image WindowVerticalImage24
        {
            get
            {
                return ApplicationImages24.Images["windowVertical24"];
            }
        }

        /// <summary>
        /// Gets the window horizontal image24.
        /// </summary>
        /// <value>The window horizontal image24.</value>
        public Image WindowHorizontalImage24
        {
            get
            {
                return ApplicationImages24.Images["windowHorizontal24"];
            }
        }

        /// <summary>
        /// Gets the window legend image24.
        /// </summary>
        /// <value>The window legend image24.</value>
        public Image WindowLegendImage24
        {
            get
            {
                return ApplicationImages24.Images["windowLegend24"];
            }
        }

        /// <summary>
        /// Gets the window load image24.
        /// </summary>
        /// <value>The window load image24.</value>
        public Image WindowLoadImage24
        {
            get
            {
                return ApplicationImages24.Images["windowLoad24"];
            }
        }

        /// <summary>
        /// Gets the window save image24.
        /// </summary>
        /// <value>The window save image24.</value>
        public Image WindowSaveImage24
        {
            get
            {
                return ApplicationImages24.Images["windowSave24"];
            }
        }

        /// <summary>
        /// Gets the window order image24.
        /// </summary>
        /// <value>The window order image24.</value>
        public Image WindowOrderImage24
        {
            get
            {
                return ApplicationImages24.Images["windowOrder24"];
            }
        }

        /// <summary>
        /// Gets the analytics image24.
        /// </summary>
        /// <value>The analytics image24.</value>
        public Image AnalyticsImage24
        {
            get
            {
                return ApplicationImages24.Images["analytics24"];
            }
        }

        /// <summary>
        /// Gets the save image24.
        /// </summary>
        /// <value>The save image24.</value>
        public Image SaveImage24
        {
            get
            {
                return ApplicationImages24.Images["save24"];
            }
        }

        /// <summary>
        /// Gets the brush image24.
        /// </summary>
        /// <value>The brush image24.</value>
        public Image BrushImage24
        {
            get
            {
                return ApplicationImages24.Images["brush24"];
            }
        }

        /// <summary>
        /// Gets the mail image24.
        /// </summary>
        /// <value>The mail image24.</value>
        public Image MailImage24
        {
            get
            {
                return ApplicationImages24.Images["mail24"];
            }
        }

        /// <summary>
        /// Gets the mail in image24.
        /// </summary>
        /// <value>The mail in image24.</value>
        public Image MailInImage24
        {
            get
            {
                return ApplicationImages24.Images["mailIn24"];
            }
        }

        /// <summary>
        /// Gets the B and L image24.
        /// </summary>
        /// <value>The B and L image24.</value>
        public Image BAndLImage24
        {
            get
            {
                return ApplicationImages24.Images["BAndL24"];
            }
        }

        /// <summary>
        /// Gets the lock all image24.
        /// </summary>
        /// <value>The lock all image24.</value>
        public Image LockAllImage24
        {
            get
            {
                return ApplicationImages24.Images["lockAll24"];
            }
        }

        /// <summary>
        /// Gets the send image24.
        /// </summary>
        /// <value>The send image24.</value>
        public Image SendImage24
        {
            get
            {
                return ApplicationImages24.Images["send24"];
            }
        }

        /// <summary>
        /// Gets the send all image24.
        /// </summary>
        /// <value>The send all image24.</value>
        public Image SendAllImage24
        {
            get
            {
                return ApplicationImages24.Images["sendAll24"];
            }
        }

        /// <summary>
        /// Gets the RE evaluate image24.
        /// </summary>
        /// <value>The RE evaluate image24.</value>
        public Image REEvaluateImage24
        {
            get
            {
                return ApplicationImages24.Images["reEvaluate24"];
            }
        }

        /// <summary>
        /// Gets the data explorers image24.
        /// </summary>
        /// <value>The data explorers image24.</value>
        public Image DataExplorersImage24
        {
            get
            {
                return ApplicationImages24.Images["dataExplorers24"];
            }
        }

        /// <summary>
        /// Gets the add image24.
        /// </summary>
        /// <value>The add image24.</value>
        public Image AddImage24
        {
            get
            {
                return ApplicationImages24.Images["add24"];
            }
        }

        /// <summary>
        /// Gets the trader image24.
        /// </summary>
        /// <value>The trader image24.</value>
        public Image TraderImage24
        {
            get
            {
                return ApplicationImages24.Images["trader24"];
            }
        }

        /// <summary>
        /// Gets the support image24.
        /// </summary>
        /// <value>The support image24.</value>
        public Image SupportImage24
        {
            get
            {
                return ApplicationImages24.Images["support24"];
            }
        }

        /// <summary>
        /// Gets the unlock image24.
        /// </summary>
        /// <value>The unlock image24.</value>
        public Image UnlockImage24
        {
            get
            {
                return ApplicationImages24.Images["unlock24"];
            }
        }

        /// <summary>
        /// Gets the lock image24.
        /// </summary>
        /// <value>The lock image24.</value>
        public Image LockImage24
        {
            get
            {
                return ApplicationImages24.Images["lock24"];
            }
        }

        /// <summary>
        /// Gets the delete image24.
        /// </summary>
        /// <value>The delete image24.</value>
        public Image DeleteImage24
        {
            get
            {
                return ApplicationImages24.Images["delete24"];
            }
        }

        /// <summary>
        /// Gets the evaluate image24.
        /// </summary>
        /// <value>The evaluate image24.</value>
        public Image EvaluateImage24
        {
            get
            {
                return ApplicationImages24.Images["evaluate24"];
            }
        }

        /// <summary>
        /// Gets the reply image24.
        /// </summary>
        /// <value>The reply image24.</value>
        public Image ReplyImage24
        {
            get
            {
                return ApplicationImages24.Images["reply24"];
            }
        }

        /// <summary>
        /// Gets the new portfolio image24.
        /// </summary>
        /// <value>The new portfolio image24.</value>
        public Image NewPortfolioImage24
        {
            get
            {
                return ApplicationImages24.Images["newPortfolio24"];
            }
        }

        /// <summary>
        /// Gets the delete portfolio image24.
        /// </summary>
        /// <value>The delete portfolio image24.</value>
        public Image DeletePortfolioImage24
        {
            get
            {
                return ApplicationImages24.Images["deletePortfolio24"];
            }
        }

        /// <summary>
        /// Gets the view portfolio image24.
        /// </summary>
        /// <value>The view portfolio image24.</value>
        public Image ViewPortfolioImage24
        {
            get
            {
                return ApplicationImages24.Images["viewPortfolio24"];
            }
        }

        /// <summary>
        /// Gets the new risk image24.
        /// </summary>
        /// <value>The new risk image24.</value>
        public Image NewRiskImage24
        {
            get
            {
                return ApplicationImages24.Images["newRiskTemplate24"];
            }
        }

        /// <summary>
        /// Gets the edit risk image24.
        /// </summary>
        /// <value>The edit risk image24.</value>
        public Image EditRiskImage24
        {
            get
            {
                return ApplicationImages24.Images["editRiskTemplate24"];
            }
        }

        /// <summary>
        /// Gets the delete risk image24.
        /// </summary>
        /// <value>The delete risk image24.</value>
        public Image DeleteRiskImage24
        {
            get
            {
                return ApplicationImages24.Images["deleteRiskTemplate24"];
            }
        }

        /// <summary>
        /// Gets the new pricing image24.
        /// </summary>
        /// <value>The new pricing image24.</value>
        public Image NewPricingImage24
        {
            get
            {
                return ApplicationImages24.Images["newPricing24"];
            }
        }

        /// <summary>
        /// Gets the success image24.
        /// </summary>
        /// <value>The success image24.</value>
        public Image SuccessImage24
        {
            get
            {
                return ApplicationImages24.Images["cleanTick24"];
            }
        }

        /// <summary>
        /// Gets the print image24.
        /// </summary>
        /// <value>The print image24.</value>
        public Image PrintImage24
        {
            get
            {
                return ApplicationImages24.Images["print24"];
            }
        }

        /// <summary>
        /// Gets the logging console image24.
        /// </summary>
        /// <value>The logging console image24.</value>
        public Image LoggingConsoleImage24
        {
            get
            {
                return ApplicationImages24.Images["loggingConsole24"];
            }
        }

        /// <summary>
        /// Gets the print preview image24.
        /// </summary>
        /// <value>The print preview image24.</value>
        public Image PrintPreviewImage24
        {
            get
            {
                return ApplicationImages24.Images["printPreview24"];
            }
        }

        /// <summary>
        /// Gets the trades snapshot image24.
        /// </summary>
        /// <value>The trades snapshot image24.</value>
        public Image TradesSnapshotImage24
        {
            get
            {
                return ApplicationImages24.Images[TradesSnapshotImage24String];
            }
        }

        /// <summary>
        /// Gets the load view image24.
        /// </summary>
        /// <value>The load view image24.</value>
        public Image LoadViewImage24
        {
            get
            {
                return ApplicationImages24.Images["loadView24"];
            }
        }

        /// <summary>
        /// Gets the save view image24.
        /// </summary>
        /// <value>The save view image24.</value>
        public Image SaveViewImage24
        {
            get
            {
                return ApplicationImages24.Images["saveView24"];
            }
        }

        /// <summary>
        /// Gets the column image24.
        /// </summary>
        /// <value>The column image24.</value>
        public Image ColumnImage24
        {
            get
            {
                return ApplicationImages24.Images["columnAdd24"];
            }
        }

        /// <summary>
        /// Gets the upload image24.
        /// </summary>
        /// <value>The upload image24.</value>
        public Image UploadImage24
        {
            get
            {
                return ApplicationImages24.Images["upload24"];
            }
        }

        /// <summary>
        /// Gets the exit image24.
        /// </summary>
        /// <value>The exit image24.</value>
        public Image ExitImage24
        {
            get
            {
                return ApplicationImages24.Images["exit24"];
            }
        }

        /// <summary>
        /// Gets the customize image24.
        /// </summary>
        /// <value>The customize image24.</value>
        public Image CustomizeImage24
        {
            get
            {
                return ApplicationImages24.Images["customize24"];
            }
        }

        /// <summary>
        /// Gets the find image24.
        /// </summary>
        /// <value>The find image24.</value>
        public Image FindImage24
        {
            get
            {
                return ApplicationImages24.Images["find24"];
            }
        }

        /// <summary>
        /// Gets the clear filter image24.
        /// </summary>
        /// <value>The clear filter image24.</value>
        public Image ClearFilterImage24
        {
            get
            {
                return ApplicationImages24.Images["clearFilter24"];
            }
        }

        /// <summary>
        /// Gets the excel circle image24.
        /// </summary>
        /// <value>The excel circle image24.</value>
        public Image ExcelCircleImage24
        {
            get
            {
                return ApplicationImages24.Images["excelCircle24"];
            }
        }

        /// <summary>
        /// Gets the excel square image24.
        /// </summary>
        /// <value>The excel square image24.</value>
        public Image ExcelSquareImage24
        {
            get
            {
                return ApplicationImages24.Images["excelSquare24"];
            }
        }

        /// <summary>
        /// Gets the advanced filter image24.
        /// </summary>
        /// <value>The advanced filter image24.</value>
        public Image AdvancedFilterImage24
        {
            get
            {
                return ApplicationImages24.Images["advancedFilter24"];
            }
        }

        /// <summary>
        /// Gets the export image24.
        /// </summary>
        /// <value>The export image24.</value>
        public Image ExportImage24
        {
            get
            {
                return ApplicationImages24.Images["export24"];
            }
        }

        /// <summary>
        /// Gets the help image24.
        /// </summary>
        /// <value>The help image24.</value>
        public Image HelpImage24
        {
            get
            {
                return ApplicationImages24.Images["help24"];
            }
        }

        /// <summary>
        /// Gets the filter icon24.
        /// </summary>
        /// <value>The filter icon24.</value>
        public Image FilterIcon24
        {
            get
            {
                return ApplicationImages24.Images["filterIcon24"];
            }
        }

        /// <summary>
        /// Gets the hand stop image24.
        /// </summary>
        /// <value>The hand stop image24.</value>
        public Image HandStopImage24
        {
            get
            {
                return ApplicationImages24.Images["handStop24"];
            }
        }

        /// <summary>
        /// Gets the Icon from an Image
        /// </summary>
        /// <param name="theImage">The image.</param>
        /// <returns>Icon.</returns>
        public Icon GetIcon(Image theImage)
        {
            return Icon.FromHandle(((Bitmap)theImage).GetHicon());
        }

        #region Gets an instance of this class
        /// <summary>
        /// Prevents a default instance of the <see cref="MfcApplicationImageControl"/> class from being created.
        /// </summary>
        private MfcApplicationImageControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Class ApplicationImageControlCreator
        /// </summary>
        private static class ApplicationImageControlCreator
        {
            /// <summary>
            /// Initializes static members of the <see cref="ApplicationImageControlCreator"/> class.
            /// </summary>
            static ApplicationImageControlCreator() { }
            /// <summary>
            /// The instance
            /// </summary>
            internal static readonly MfcApplicationImageControl instance = new MfcApplicationImageControl();
        }
        /// <summary>
        /// Gets the new instance.
        /// </summary>
        /// <value>The new instance.</value>
        public static MfcApplicationImageControl NewInstance
        {
            get
            {
                return ApplicationImageControlCreator.instance;
            }
        }
        
        #endregion

        /// <summary>
        /// Sets up a Tolltip button and Menuitem button if supplied
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="tooltip">The tooltip.</param>
        /// <param name="image24">The image24.</param>
        /// <param name="image16">The image16.</param>
        /// <param name="mi">The mi.</param>
        public void SetupToolbarButton(ToolStripButton button, string tooltip, Image image24, Image image16, ToolStripMenuItem mi)
        {
            ToolTipInfo info = new ToolTipInfo();
            info.Header.Text = tooltip;

            if (button != null)
            {
                button.Image = image24;
                button.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                superToolTip.SetToolTip(button, info);
            }

            if (mi != null)
            {
                mi.Image = image16;
                mi.ImageScaling = ToolStripItemImageScaling.None;
                superToolTip.SetToolTip(mi, info);
            }
        }
    }
}
