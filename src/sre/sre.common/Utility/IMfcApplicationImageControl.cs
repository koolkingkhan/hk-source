// ***********************************************************************
// Assembly         : Common
// Author           : bethunro
// Created          : 10-08-2013
//
// Last Modified By : bethunro
// Last Modified On : 10-08-2013
// ***********************************************************************
// <copyright file="IMfcApplicationImageControl.cs" company="UBS AG">
//     Copyright (c) UBS AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;
using System.Windows.Forms;

namespace Ubs.Collateral.Sre.Common.Utility
{
    /// <summary>
    /// Interface IMfcApplicationImageControl
    /// </summary>
    public interface IMfcApplicationImageControl
    {
        /// <summary>
        /// All images in the imageList control
        /// </summary>
        /// <value>The application images24.</value>
        ImageList ApplicationImages24 { get; }

        /// <summary>
        /// Gets the application images16.
        /// </summary>
        /// <value>The application images16.</value>
        ImageList ApplicationImages16 { get; }

        /// <summary>
        /// String representations of keys are defined here if necessary
        /// </summary>
        /// <value>The magic wand image16 string.</value>
        string MagicWandImage16String { get; }

        /// <summary>
        /// Gets the flag yellow image16 string.
        /// </summary>
        /// <value>The flag yellow image16 string.</value>
        string FlagYellowImage16String { get; }

        /// <summary>
        /// Gets the flag red image16 string.
        /// </summary>
        /// <value>The flag red image16 string.</value>
        string FlagRedImage16String { get; }

        /// <summary>
        /// Gets the flag green image16 string.
        /// </summary>
        /// <value>The flag green image16 string.</value>
        string FlagGreenImage16String { get; }

        /// <summary>
        /// Gets the brush image16 string.
        /// </summary>
        /// <value>The brush image16 string.</value>
        string BrushImage16String { get; }

        /// <summary>
        /// Gets the save image16 string.
        /// </summary>
        /// <value>The save image16 string.</value>
        string SaveImage16String { get; }

        /// <summary>
        /// Gets the lock image16 string.
        /// </summary>
        /// <value>The lock image16 string.</value>
        string LockImage16String { get; }

        /// <summary>
        /// Gets the unlock image16 string.
        /// </summary>
        /// <value>The unlock image16 string.</value>
        string UnlockImage16String { get; }

        /// <summary>
        /// Gets the lock partial image16 string.
        /// </summary>
        /// <value>The lock partial image16 string.</value>
        string LockPartialImage16String { get; }

        /// <summary>
        /// Gets the mail image16 string.
        /// </summary>
        /// <value>The mail image16 string.</value>
        string MailImage16String { get; }

        /// <summary>
        /// Gets the mail in image16 string.
        /// </summary>
        /// <value>The mail in image16 string.</value>
        string MailInImage16String { get; }

        /// <summary>
        /// Gets the mail out image16 string.
        /// </summary>
        /// <value>The mail out image16 string.</value>
        string MailOutImage16String { get; }

        /// <summary>
        /// Gets the trades snapshot image16 string.
        /// </summary>
        /// <value>The trades snapshot image16 string.</value>
        string TradesSnapshotImage16String { get; }

        /// <summary>
        /// Gets the trades snapshot image24 string.
        /// </summary>
        /// <value>The trades snapshot image24 string.</value>
        string TradesSnapshotImage24String { get; }

        /// <summary>
        /// Gets the arrow up image16 string.
        /// </summary>
        /// <value>The arrow up image16 string.</value>
        string ArrowUpImage16String { get; }

        /// <summary>
        /// Gets the arrow down image16 string.
        /// </summary>
        /// <value>The arrow down image16 string.</value>
        string ArrowDownImage16String { get; }

        /// <summary>
        /// Gets the trades image16 string.
        /// </summary>
        /// <value>The trades image16 string.</value>
        string TradesImage16String { get; }

        /// <summary>
        /// Gets the grid image16 string.
        /// </summary>
        /// <value>The grid image16 string.</value>
        string GridImage16String { get; }

        /// <summary>
        /// Gets the general image16 string.
        /// </summary>
        /// <value>The general image16 string.</value>
        string GeneralImage16String { get; }

        /// <summary>
        /// Gets the status bar image16 string.
        /// </summary>
        /// <value>The status bar image16 string.</value>
        string StatusBarImage16String { get; }

        /// <summary>
        /// Gets the matrix image16 string.
        /// </summary>
        /// <value>The matrix image16 string.</value>
        string MatrixImage16String { get; }

        /// <summary>
        /// Gets the bug image16 string.
        /// </summary>
        /// <value>The bug image16 string.</value>
        string BugImage16String { get; }

        /// <summary>
        /// Gets the balance sheet image16 string.
        /// </summary>
        /// <value>The balance sheet image16 string.</value>
        string BalanceSheetImage16String { get; }

        /// <summary>
        /// Gets the excel square image16 string.
        /// </summary>
        /// <value>The excel square image16 string.</value>
        string ExcelSquareImage16String { get; }

        /// <summary>
        /// Gets the excel image16 string.
        /// </summary>
        /// <value>The excel image16 string.</value>
        string ExcelImage16String { get; }

        /// <summary>
        /// Gets the job image16 string.
        /// </summary>
        /// <value>The job image16 string.</value>
        string JobImage16String { get; }

        /// <summary>
        /// Gets the line chart image16 string.
        /// </summary>
        /// <value>The line chart image16 string.</value>
        string LineChartImage16String { get; }

        /// <summary>
        /// Gets the green tick image16 string.
        /// </summary>
        /// <value>The green tick image16 string.</value>
        string GreenTickImage16String { get; }

        /// <summary>
        /// Gets the red cross image16 string.
        /// </summary>
        /// <value>The red cross image16 string.</value>
        string RedCrossImage16String { get; }

        /// <summary>
        /// Gets the small tick1 image16 string.
        /// </summary>
        /// <value>The small tick1 image16 string.</value>
        string SmallTick1Image16String { get; }

        /// <summary>
        /// Gets the small tick2 image16 string.
        /// </summary>
        /// <value>The small tick2 image16 string.</value>
        string SmallTick2Image16String { get; }

        /// <summary>
        /// Gets the email image16 string.
        /// </summary>
        /// <value>The email image16 string.</value>
        string EmailImage16String { get; }

        /// <summary>
        /// Gets the email image24 string.
        /// </summary>
        /// <value>The email image24 string.</value>
        string EmailImage24String { get; }

        /// <summary>
        /// Gets the inbox email image24 string.
        /// </summary>
        /// <value>The inbox email image24 string.</value>
        string InboxEmailImage24String { get; }

        /// <summary>
        /// Gets the advanced filterl image16 string.
        /// </summary>
        /// <value>The advanced filterl image16 string.</value>
        string AdvancedFilterlImage16String { get; }

        /// <summary>
        /// Define images here
        /// </summary>
        /// <value>The pin green image16.</value>
        Image PinGreenImage16 { get; }

        /// <summary>
        /// Gets the pin red image16.
        /// </summary>
        /// <value>The pin red image16.</value>
        Image PinRedImage16 { get; }

        /// <summary>
        /// Gets the magic wand image16.
        /// </summary>
        /// <value>The magic wand image16.</value>
        Image MagicWandImage16 { get; }

        /// <summary>
        /// Gets the legend image16.
        /// </summary>
        /// <value>The legend image16.</value>
        Image LegendImage16 { get; }

        /// <summary>
        /// Gets the email management image16.
        /// </summary>
        /// <value>The email management image16.</value>
        Image EmailManagementImage16 { get; }

        /// <summary>
        /// Gets the analytics image16.
        /// </summary>
        /// <value>The analytics image16.</value>
        Image AnalyticsImage16 { get; }

        /// <summary>
        /// Gets the batch emails image16.
        /// </summary>
        /// <value>The batch emails image16.</value>
        Image BatchEmailsImage16 { get; }

        /// <summary>
        /// Gets the message image16.
        /// </summary>
        /// <value>The message image16.</value>
        Image MessageImage16 { get; }

        /// <summary>
        /// Gets the batch conversation image16.
        /// </summary>
        /// <value>The batch conversation image16.</value>
        Image BatchConversationImage16 { get; }

        /// <summary>
        /// Gets the detailed info image16.
        /// </summary>
        /// <value>The detailed info image16.</value>
        Image DetailedInfoImage16 { get; }

        /// <summary>
        /// Gets the order negotiation image16.
        /// </summary>
        /// <value>The order negotiation image16.</value>
        Image OrderNegotiationImage16 { get; }

        /// <summary>
        /// Gets the row selection16.
        /// </summary>
        /// <value>The row selection16.</value>
        Image RowSelection16 { get; }

        /// <summary>
        /// Gets the window vertical image16.
        /// </summary>
        /// <value>The window vertical image16.</value>
        Image WindowVerticalImage16 { get; }

        /// <summary>
        /// Gets the window horizontal image16.
        /// </summary>
        /// <value>The window horizontal image16.</value>
        Image WindowHorizontalImage16 { get; }

        /// <summary>
        /// Gets the window legend image16.
        /// </summary>
        /// <value>The window legend image16.</value>
        Image WindowLegendImage16 { get; }

        /// <summary>
        /// Gets the window load image16.
        /// </summary>
        /// <value>The window load image16.</value>
        Image WindowLoadImage16 { get; }

        /// <summary>
        /// Gets the window save image16.
        /// </summary>
        /// <value>The window save image16.</value>
        Image WindowSaveImage16 { get; }

        /// <summary>
        /// Gets the window order image16.
        /// </summary>
        /// <value>The window order image16.</value>
        Image WindowOrderImage16 { get; }

        /// <summary>
        /// Gets the mail image16.
        /// </summary>
        /// <value>The mail image16.</value>
        Image MailImage16 { get; }

        /// <summary>
        /// Gets the mail in image16.
        /// </summary>
        /// <value>The mail in image16.</value>
        Image MailInImage16 { get; }

        /// <summary>
        /// Gets the mail out image16.
        /// </summary>
        /// <value>The mail out image16.</value>
        Image MailOutImage16 { get; }

        /// <summary>
        /// Gets the arrow up image16.
        /// </summary>
        /// <value>The arrow up image16.</value>
        Image ArrowUpImage16 { get; }

        /// <summary>
        /// Gets the arrow down image16.
        /// </summary>
        /// <value>The arrow down image16.</value>
        Image ArrowDownImage16 { get; }

        /// <summary>
        /// Gets the email image16.
        /// </summary>
        /// <value>The email image16.</value>
        Image EmailImage16 { get; }

        /// <summary>
        /// Gets the reply image16.
        /// </summary>
        /// <value>The reply image16.</value>
        Image ReplyImage16 { get; }

        /// <summary>
        /// Gets the green tick arrow image16.
        /// </summary>
        /// <value>The green tick arrow image16.</value>
        Image GreenTickArrowImage16 { get; }

        /// <summary>
        /// Gets the small tick1 arrow image16.
        /// </summary>
        /// <value>The small tick1 arrow image16.</value>
        Image SmallTick1ArrowImage16 { get; }

        /// <summary>
        /// Gets the small tick2 arrow image16.
        /// </summary>
        /// <value>The small tick2 arrow image16.</value>
        Image SmallTick2ArrowImage16 { get; }

        /// <summary>
        /// Gets the refresh job image16.
        /// </summary>
        /// <value>The refresh job image16.</value>
        Image RefreshJobImage16 { get; }

        /// <summary>
        /// Gets the pencil image16.
        /// </summary>
        /// <value>The pencil image16.</value>
        Image PencilImage16 { get; }

        /// <summary>
        /// Gets the window colours image16.
        /// </summary>
        /// <value>The window colours image16.</value>
        Image WindowColoursImage16 { get; }

        /// <summary>
        /// Gets the books image16.
        /// </summary>
        /// <value>The books image16.</value>
        Image BooksImage16 { get; }

        /// <summary>
        /// Gets the run job image16.
        /// </summary>
        /// <value>The run job image16.</value>
        Image RunJobImage16 { get; }

        /// <summary>
        /// Gets the line chart image16.
        /// </summary>
        /// <value>The line chart image16.</value>
        Image LineChartImage16 { get; }

        /// <summary>
        /// Gets the folder open image16.
        /// </summary>
        /// <value>The folder open image16.</value>
        Image FolderOpenImage16 { get; }

        /// <summary>
        /// Gets the job image16.
        /// </summary>
        /// <value>The job image16.</value>
        Image JobImage16 { get; }

        /// <summary>
        /// Gets the cockpit image16.
        /// </summary>
        /// <value>The cockpit image16.</value>
        Image CockpitImage16 { get; }

        /// <summary>
        /// Gets the money bag image16.
        /// </summary>
        /// <value>The money bag image16.</value>
        Image MoneyBagImage16 { get; }

        /// <summary>
        /// Gets the new portfolio image16.
        /// </summary>
        /// <value>The new portfolio image16.</value>
        Image NewPortfolioImage16 { get; }

        /// <summary>
        /// Gets the delete portfolio image16.
        /// </summary>
        /// <value>The delete portfolio image16.</value>
        Image DeletePortfolioImage16 { get; }

        /// <summary>
        /// Gets the view portfolio image16.
        /// </summary>
        /// <value>The view portfolio image16.</value>
        Image ViewPortfolioImage16 { get; }

        /// <summary>
        /// Gets the money bag dollar image16.
        /// </summary>
        /// <value>The money bag dollar image16.</value>
        Image MoneyBagDollarImage16 { get; }

        /// <summary>
        /// Gets the copy risk image16.
        /// </summary>
        /// <value>The copy risk image16.</value>
        Image CopyRiskImage16 { get; }

        /// <summary>
        /// Gets the new pricing image16.
        /// </summary>
        /// <value>The new pricing image16.</value>
        Image NewPricingImage16 { get; }

        /// <summary>
        /// Gets the new risk image16.
        /// </summary>
        /// <value>The new risk image16.</value>
        Image NewRiskImage16 { get; }

        /// <summary>
        /// Gets the edit risk image16.
        /// </summary>
        /// <value>The edit risk image16.</value>
        Image EditRiskImage16 { get; }

        /// <summary>
        /// Gets the delete risk image16.
        /// </summary>
        /// <value>The delete risk image16.</value>
        Image DeleteRiskImage16 { get; }

        /// <summary>
        /// Gets up minus image16.
        /// </summary>
        /// <value>Up minus image16.</value>
        Image UpMinusImage16 { get; }

        /// <summary>
        /// Gets up plus image16.
        /// </summary>
        /// <value>Up plus image16.</value>
        Image UpPlusImage16 { get; }

        /// <summary>
        /// Gets the select all image16.
        /// </summary>
        /// <value>The select all image16.</value>
        Image SelectAllImage16 { get; }

        /// <summary>
        /// Gets the edit image16.
        /// </summary>
        /// <value>The edit image16.</value>
        Image EditImage16 { get; }

        /// <summary>
        /// Gets the heartbeat on image16.
        /// </summary>
        /// <value>The heartbeat on image16.</value>
        Image HeartbeatOnImage16 { get; }

        /// <summary>
        /// Gets the heartbeat off image16.
        /// </summary>
        /// <value>The heartbeat off image16.</value>
        Image HeartbeatOffImage16 { get; }

        /// <summary>
        /// Gets the available image16.
        /// </summary>
        /// <value>The available image16.</value>
        Image AvailableImage16 { get; }

        /// <summary>
        /// Gets the UN available image16.
        /// </summary>
        /// <value>The UN available image16.</value>
        Image UNAvailableImage16 { get; }

        /// <summary>
        /// Gets the unknown image16.
        /// </summary>
        /// <value>The unknown image16.</value>
        Image UnknownImage16 { get; }

        /// <summary>
        /// Gets the brush image16.
        /// </summary>
        /// <value>The brush image16.</value>
        Image BrushImage16 { get; }

        /// <summary>
        /// Gets the evaluate image16.
        /// </summary>
        /// <value>The evaluate image16.</value>
        Image EvaluateImage16 { get; }

        /// <summary>
        /// Gets the trader image16.
        /// </summary>
        /// <value>The trader image16.</value>
        Image TraderImage16 { get; }

        /// <summary>
        /// Gets the support image16.
        /// </summary>
        /// <value>The support image16.</value>
        Image SupportImage16 { get; }

        /// <summary>
        /// Gets the lock image16.
        /// </summary>
        /// <value>The lock image16.</value>
        Image LockImage16 { get; }

        /// <summary>
        /// Gets the lock all image16.
        /// </summary>
        /// <value>The lock all image16.</value>
        Image LockAllImage16 { get; }

        /// <summary>
        /// Gets the unlock image16.
        /// </summary>
        /// <value>The unlock image16.</value>
        Image UnlockImage16 { get; }

        /// <summary>
        /// Gets the lock partial image16.
        /// </summary>
        /// <value>The lock partial image16.</value>
        Image LockPartialImage16 { get; }

        /// <summary>
        /// Gets the copy image16.
        /// </summary>
        /// <value>The copy image16.</value>
        Image CopyImage16 { get; }

        /// <summary>
        /// Gets the copy all image16.
        /// </summary>
        /// <value>The copy all image16.</value>
        Image CopyAllImage16 { get; }

        /// <summary>
        /// Gets the paste image16.
        /// </summary>
        /// <value>The paste image16.</value>
        Image PasteImage16 { get; }

        /// <summary>
        /// Gets the add image16.
        /// </summary>
        /// <value>The add image16.</value>
        Image AddImage16 { get; }

        /// <summary>
        /// Gets the delete image16.
        /// </summary>
        /// <value>The delete image16.</value>
        Image DeleteImage16 { get; }

        /// <summary>
        /// Gets the send image16.
        /// </summary>
        /// <value>The send image16.</value>
        Image SendImage16 { get; }

        /// <summary>
        /// Gets the send all image16.
        /// </summary>
        /// <value>The send all image16.</value>
        Image SendAllImage16 { get; }

        /// <summary>
        /// Gets the data explorers image16.
        /// </summary>
        /// <value>The data explorers image16.</value>
        Image DataExplorersImage16 { get; }

        /// <summary>
        /// Gets the B and L image16.
        /// </summary>
        /// <value>The B and L image16.</value>
        Image BAndLImage16 { get; }

        /// <summary>
        /// Gets the hand stop image16.
        /// </summary>
        /// <value>The hand stop image16.</value>
        Image HandStopImage16 { get; }

        /// <summary>
        /// Gets the balance sheet image16.
        /// </summary>
        /// <value>The balance sheet image16.</value>
        Image BalanceSheetImage16 { get; }

        /// <summary>
        /// Gets the document clear image16.
        /// </summary>
        /// <value>The document clear image16.</value>
        Image DocumentClearImage16 { get; }

        /// <summary>
        /// Gets the print image16.
        /// </summary>
        /// <value>The print image16.</value>
        Image PrintImage16 { get; }

        /// <summary>
        /// Gets the print preview image16.
        /// </summary>
        /// <value>The print preview image16.</value>
        Image PrintPreviewImage16 { get; }

        /// <summary>
        /// Gets the bug image16.
        /// </summary>
        /// <value>The bug image16.</value>
        Image BugImage16 { get; }

        /// <summary>
        /// Gets the grid image16.
        /// </summary>
        /// <value>The grid image16.</value>
        Image GridImage16 { get; }

        /// <summary>
        /// Gets the status bar image16.
        /// </summary>
        /// <value>The status bar image16.</value>
        Image StatusBarImage16 { get; }

        /// <summary>
        /// Gets the selection image16.
        /// </summary>
        /// <value>The selection image16.</value>
        Image SelectionImage16 { get; }

        /// <summary>
        /// Gets the flag yellow image16.
        /// </summary>
        /// <value>The flag yellow image16.</value>
        Image FlagYellowImage16 { get; }

        /// <summary>
        /// Gets the flag red image16.
        /// </summary>
        /// <value>The flag red image16.</value>
        Image FlagRedImage16 { get; }

        /// <summary>
        /// Gets the flag green image16.
        /// </summary>
        /// <value>The flag green image16.</value>
        Image FlagGreenImage16 { get; }

        /// <summary>
        /// Gets the trades snapshot image16.
        /// </summary>
        /// <value>The trades snapshot image16.</value>
        Image TradesSnapshotImage16 { get; }

        /// <summary>
        /// Gets the trades image16.
        /// </summary>
        /// <value>The trades image16.</value>
        Image TradesImage16 { get; }

        /// <summary>
        /// Gets the matrix image16.
        /// </summary>
        /// <value>The matrix image16.</value>
        Image MatrixImage16 { get; }

        /// <summary>
        /// Gets the excel image16.
        /// </summary>
        /// <value>The excel image16.</value>
        Image ExcelImage16 { get; }

        /// <summary>
        /// Gets the excel circle image16.
        /// </summary>
        /// <value>The excel circle image16.</value>
        Image ExcelCircleImage16 { get; }

        /// <summary>
        /// Gets the excel square image16.
        /// </summary>
        /// <value>The excel square image16.</value>
        Image ExcelSquareImage16 { get; }

        /// <summary>
        /// Gets the client measurement image16.
        /// </summary>
        /// <value>The client measurement image16.</value>
        Image ClientMeasurementImage16 { get; }

        /// <summary>
        /// Gets the cleanup image16.
        /// </summary>
        /// <value>The cleanup image16.</value>
        Image CleanupImage16 { get; }

        /// <summary>
        /// Gets the find next image16.
        /// </summary>
        /// <value>The find next image16.</value>
        Image FindNextImage16 { get; }

        /// <summary>
        /// Gets the find image16.
        /// </summary>
        /// <value>The find image16.</value>
        Image FindImage16 { get; }

        /// <summary>
        /// Gets the find all image16.
        /// </summary>
        /// <value>The find all image16.</value>
        Image FindAllImage16 { get; }

        /// <summary>
        /// Gets the clear image16.
        /// </summary>
        /// <value>The clear image16.</value>
        Image ClearImage16 { get; }

        /// <summary>
        /// Gets the close image16.
        /// </summary>
        /// <value>The close image16.</value>
        Image CloseImage16 { get; }

        /// <summary>
        /// Gets the save view image16.
        /// </summary>
        /// <value>The save view image16.</value>
        Image SaveViewImage16 { get; }

        /// <summary>
        /// Gets the load view image16.
        /// </summary>
        /// <value>The load view image16.</value>
        Image LoadViewImage16 { get; }

        /// <summary>
        /// Gets the price image16.
        /// </summary>
        /// <value>The price image16.</value>
        Image PriceImage16 { get; }

        /// <summary>
        /// Gets the cancel image16.
        /// </summary>
        /// <value>The cancel image16.</value>
        Image CancelImage16 { get; }

        /// <summary>
        /// Gets the ok image16.
        /// </summary>
        /// <value>The ok image16.</value>
        Image OkImage16 { get; }

        /// <summary>
        /// Gets the save image16.
        /// </summary>
        /// <value>The save image16.</value>
        Image SaveImage16 { get; }

        /// <summary>
        /// Gets the sort image16.
        /// </summary>
        /// <value>The sort image16.</value>
        Image SortImage16 { get; }

        /// <summary>
        /// Gets the top arrow image16.
        /// </summary>
        /// <value>The top arrow image16.</value>
        Image TopArrowImage16 { get; }

        /// <summary>
        /// Gets the bottom arrow image16.
        /// </summary>
        /// <value>The bottom arrow image16.</value>
        Image BottomArrowImage16 { get; }

        /// <summary>
        /// Gets up arrow image16.
        /// </summary>
        /// <value>Up arrow image16.</value>
        Image UpArrowImage16 { get; }

        /// <summary>
        /// Gets down arrow image16.
        /// </summary>
        /// <value>Down arrow image16.</value>
        Image DownArrowImage16 { get; }

        /// <summary>
        /// Gets the left arrow image16.
        /// </summary>
        /// <value>The left arrow image16.</value>
        Image LeftArrowImage16 { get; }

        /// <summary>
        /// Gets the left arrow all image16.
        /// </summary>
        /// <value>The left arrow all image16.</value>
        Image LeftArrowAllImage16 { get; }

        /// <summary>
        /// Gets the right arrow image16.
        /// </summary>
        /// <value>The right arrow image16.</value>
        Image RightArrowImage16 { get; }

        /// <summary>
        /// Gets the right arrow all image16.
        /// </summary>
        /// <value>The right arrow all image16.</value>
        Image RightArrowAllImage16 { get; }

        /// <summary>
        /// Gets the upload image16.
        /// </summary>
        /// <value>The upload image16.</value>
        Image UploadImage16 { get; }

        /// <summary>
        /// Gets the exit image16.
        /// </summary>
        /// <value>The exit image16.</value>
        Image ExitImage16 { get; }

        /// <summary>
        /// Gets the customize image16.
        /// </summary>
        /// <value>The customize image16.</value>
        Image CustomizeImage16 { get; }

        /// <summary>
        /// Gets the clear filter image16.
        /// </summary>
        /// <value>The clear filter image16.</value>
        Image ClearFilterImage16 { get; }

        /// <summary>
        /// Gets the advanced filter image16.
        /// </summary>
        /// <value>The advanced filter image16.</value>
        Image AdvancedFilterImage16 { get; }

        /// <summary>
        /// Gets the export image16.
        /// </summary>
        /// <value>The export image16.</value>
        Image ExportImage16 { get; }

        /// <summary>
        /// Gets the help image16.
        /// </summary>
        /// <value>The help image16.</value>
        Image HelpImage16 { get; }

        /// <summary>
        /// Gets the column image16.
        /// </summary>
        /// <value>The column image16.</value>
        Image ColumnImage16 { get; }

        /// <summary>
        /// Gets the window vertical image24.
        /// </summary>
        /// <value>The window vertical image24.</value>
        Image WindowVerticalImage24 { get; }

        /// <summary>
        /// Gets the window horizontal image24.
        /// </summary>
        /// <value>The window horizontal image24.</value>
        Image WindowHorizontalImage24 { get; }

        /// <summary>
        /// Gets the window legend image24.
        /// </summary>
        /// <value>The window legend image24.</value>
        Image WindowLegendImage24 { get; }

        /// <summary>
        /// Gets the window load image24.
        /// </summary>
        /// <value>The window load image24.</value>
        Image WindowLoadImage24 { get; }

        /// <summary>
        /// Gets the window save image24.
        /// </summary>
        /// <value>The window save image24.</value>
        Image WindowSaveImage24 { get; }

        /// <summary>
        /// Gets the window order image24.
        /// </summary>
        /// <value>The window order image24.</value>
        Image WindowOrderImage24 { get; }

        /// <summary>
        /// Gets the analytics image24.
        /// </summary>
        /// <value>The analytics image24.</value>
        Image AnalyticsImage24 { get; }

        /// <summary>
        /// Gets the save image24.
        /// </summary>
        /// <value>The save image24.</value>
        Image SaveImage24 { get; }

        /// <summary>
        /// Gets the brush image24.
        /// </summary>
        /// <value>The brush image24.</value>
        Image BrushImage24 { get; }

        /// <summary>
        /// Gets the mail image24.
        /// </summary>
        /// <value>The mail image24.</value>
        Image MailImage24 { get; }

        /// <summary>
        /// Gets the mail in image24.
        /// </summary>
        /// <value>The mail in image24.</value>
        Image MailInImage24 { get; }

        /// <summary>
        /// Gets the B and L image24.
        /// </summary>
        /// <value>The B and L image24.</value>
        Image BAndLImage24 { get; }

        /// <summary>
        /// Gets the lock all image24.
        /// </summary>
        /// <value>The lock all image24.</value>
        Image LockAllImage24 { get; }

        /// <summary>
        /// Gets the send image24.
        /// </summary>
        /// <value>The send image24.</value>
        Image SendImage24 { get; }

        /// <summary>
        /// Gets the send all image24.
        /// </summary>
        /// <value>The send all image24.</value>
        Image SendAllImage24 { get; }

        /// <summary>
        /// Gets the RE evaluate image24.
        /// </summary>
        /// <value>The RE evaluate image24.</value>
        Image REEvaluateImage24 { get; }

        /// <summary>
        /// Gets the data explorers image24.
        /// </summary>
        /// <value>The data explorers image24.</value>
        Image DataExplorersImage24 { get; }

        /// <summary>
        /// Gets the add image24.
        /// </summary>
        /// <value>The add image24.</value>
        Image AddImage24 { get; }

        /// <summary>
        /// Gets the trader image24.
        /// </summary>
        /// <value>The trader image24.</value>
        Image TraderImage24 { get; }

        /// <summary>
        /// Gets the support image24.
        /// </summary>
        /// <value>The support image24.</value>
        Image SupportImage24 { get; }

        /// <summary>
        /// Gets the unlock image24.
        /// </summary>
        /// <value>The unlock image24.</value>
        Image UnlockImage24 { get; }

        /// <summary>
        /// Gets the lock image24.
        /// </summary>
        /// <value>The lock image24.</value>
        Image LockImage24 { get; }

        /// <summary>
        /// Gets the delete image24.
        /// </summary>
        /// <value>The delete image24.</value>
        Image DeleteImage24 { get; }

        /// <summary>
        /// Gets the evaluate image24.
        /// </summary>
        /// <value>The evaluate image24.</value>
        Image EvaluateImage24 { get; }

        /// <summary>
        /// Gets the reply image24.
        /// </summary>
        /// <value>The reply image24.</value>
        Image ReplyImage24 { get; }

        /// <summary>
        /// Gets the new portfolio image24.
        /// </summary>
        /// <value>The new portfolio image24.</value>
        Image NewPortfolioImage24 { get; }

        /// <summary>
        /// Gets the delete portfolio image24.
        /// </summary>
        /// <value>The delete portfolio image24.</value>
        Image DeletePortfolioImage24 { get; }

        /// <summary>
        /// Gets the view portfolio image24.
        /// </summary>
        /// <value>The view portfolio image24.</value>
        Image ViewPortfolioImage24 { get; }

        /// <summary>
        /// Gets the new risk image24.
        /// </summary>
        /// <value>The new risk image24.</value>
        Image NewRiskImage24 { get; }

        /// <summary>
        /// Gets the edit risk image24.
        /// </summary>
        /// <value>The edit risk image24.</value>
        Image EditRiskImage24 { get; }

        /// <summary>
        /// Gets the delete risk image24.
        /// </summary>
        /// <value>The delete risk image24.</value>
        Image DeleteRiskImage24 { get; }

        /// <summary>
        /// Gets the new pricing image24.
        /// </summary>
        /// <value>The new pricing image24.</value>
        Image NewPricingImage24 { get; }

        /// <summary>
        /// Gets the success image24.
        /// </summary>
        /// <value>The success image24.</value>
        Image SuccessImage24 { get; }

        /// <summary>
        /// Gets the print image24.
        /// </summary>
        /// <value>The print image24.</value>
        Image PrintImage24 { get; }

        /// <summary>
        /// Gets the logging console image24.
        /// </summary>
        /// <value>The logging console image24.</value>
        Image LoggingConsoleImage24 { get; }

        /// <summary>
        /// Gets the print preview image24.
        /// </summary>
        /// <value>The print preview image24.</value>
        Image PrintPreviewImage24 { get; }

        /// <summary>
        /// Gets the trades snapshot image24.
        /// </summary>
        /// <value>The trades snapshot image24.</value>
        Image TradesSnapshotImage24 { get; }

        /// <summary>
        /// Gets the load view image24.
        /// </summary>
        /// <value>The load view image24.</value>
        Image LoadViewImage24 { get; }

        /// <summary>
        /// Gets the save view image24.
        /// </summary>
        /// <value>The save view image24.</value>
        Image SaveViewImage24 { get; }

        /// <summary>
        /// Gets the column image24.
        /// </summary>
        /// <value>The column image24.</value>
        Image ColumnImage24 { get; }

        /// <summary>
        /// Gets the upload image24.
        /// </summary>
        /// <value>The upload image24.</value>
        Image UploadImage24 { get; }

        /// <summary>
        /// Gets the exit image24.
        /// </summary>
        /// <value>The exit image24.</value>
        Image ExitImage24 { get; }

        /// <summary>
        /// Gets the customize image24.
        /// </summary>
        /// <value>The customize image24.</value>
        Image CustomizeImage24 { get; }

        /// <summary>
        /// Gets the find image24.
        /// </summary>
        /// <value>The find image24.</value>
        Image FindImage24 { get; }

        /// <summary>
        /// Gets the clear filter image24.
        /// </summary>
        /// <value>The clear filter image24.</value>
        Image ClearFilterImage24 { get; }

        /// <summary>
        /// Gets the excel circle image24.
        /// </summary>
        /// <value>The excel circle image24.</value>
        Image ExcelCircleImage24 { get; }

        /// <summary>
        /// Gets the excel square image24.
        /// </summary>
        /// <value>The excel square image24.</value>
        Image ExcelSquareImage24 { get; }

        /// <summary>
        /// Gets the advanced filter image24.
        /// </summary>
        /// <value>The advanced filter image24.</value>
        Image AdvancedFilterImage24 { get; }

        /// <summary>
        /// Gets the export image24.
        /// </summary>
        /// <value>The export image24.</value>
        Image ExportImage24 { get; }

        /// <summary>
        /// Gets the help image24.
        /// </summary>
        /// <value>The help image24.</value>
        Image HelpImage24 { get; }

        /// <summary>
        /// Gets the filter icon24.
        /// </summary>
        /// <value>The filter icon24.</value>
        Image FilterIcon24 { get; }

        /// <summary>
        /// Gets the hand stop image24.
        /// </summary>
        /// <value>The hand stop image24.</value>
        Image HandStopImage24 { get; }

        /// <summary>
        /// Gets the Icon from an Image
        /// </summary>
        /// <param name="theImage">The image.</param>
        /// <returns>Icon.</returns>
        Icon GetIcon(Image theImage);

        /// <summary>
        /// Sets up a Tolltip button and Menuitem button if supplied
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="tooltip">The tooltip.</param>
        /// <param name="image24">The image24.</param>
        /// <param name="image16">The image16.</param>
        /// <param name="mi">The mi.</param>
        void SetupToolbarButton(ToolStripButton button, string tooltip, Image image24, Image image16, ToolStripMenuItem mi);
    }
}