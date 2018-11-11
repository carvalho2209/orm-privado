using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.UI
{

    public enum eAppType
    {
        Nothing = 0,
        WinForms,
        SAPForms
    }

    public enum eShowTextCombo
    {
        eAll,
        eValue,
        eName
    }

    public enum eValueAlign
    {
        eLeft,
        eRight
    }

    public enum eFormCommand
    {
        Insert,
        Clear,
        Search,
        ExecuteSearch,
        Move,
        Save,
        Cancel,
        Remove
    }

    public enum BoMenuSystemID
    {
        ID_Save = 516,
        ID_PrintPreview = 519,
        ID_Print = 520,
        ID_SendEmail = 6657,
        ID_SendSMS = 6658,
        ID_SendFax = 6659,
        ID_ExportMSExcel = 7169,
        ID_ExportMSWord = 7170,
        ID_LaunchApplication = 523,
        ID_LockScreen = 524,
        ID_Find = 1281,
        ID_Add = 1282,
        ID_FirstDataRecord = 1290,
        ID_PreviousRecord = 1289,
        ID_NextRecord = 1288,
        ID_LastDataRecord = 1291,
        ID_DocumentEditing = 5895,
        ID_TransactionJournal = 5894,
        ID_PaymentMeans = 5892,
        ID_GrossProfit = 5891,
        ID_VolumeWeightCalculation = 5893,
        ID_BaseDocument = 5898,
        ID_TargetDocument = 5899,
        ID_Settings = 5890,
        ID_SortTable = 4869,
        ID_SavedQueries = 4865,
        ID_InsertLine = 1292,
        ID_DeleteLine = 1293,
        ID_CloseLine = 1299,
        ID_CopyDueSaldo = 5915,
        ID_AdvancedMenu = 43572,
        ID_Delete = 1283,
        ID_Cancel = 1284
    }

    public enum EnumPos
    {
        Right,
        Botton,
        Left,
        Top,
        Equal
    }

    public enum eCompanyType
    {
        SAP2005,
        SAP2007
    }

    public enum BoSystemForm
    {
        BusinessPartnerForm = 134,
        InventoryForm = 150,
        OrderForm = 139,
        OrderFormUserFields = -139,
        InvoiceForm = 133,
        MainMenuForm = 169,
        ChooseFromListUDO = 9999
    }

    public enum BoTextStyle
    {
        ts_PLAIN_FONT = 0,
        ts_BOLD = 1,
        ts_ITALIC = 2,
        ts_UNDERLINE = 4,
        ts_STRIKE_OUT = 8,
        ts_SHADOW = 16,
        ts_CONDENSE = 32,
        ts_EXTEND = 64,
    }

    public enum BoValidValueDefaults
    {
        vvd_AddNewValue = 2,
        vvd_EmptyValue = 4,
    }

    public enum BoEventTypes
    {
        et_ALL_EVENTS = 0,
        et_ITEM_PRESSED = 1,
        et_KEY_DOWN = 2,
        et_GOT_FOCUS = 3,
        et_LOST_FOCUS = 4,
        et_COMBO_SELECT = 5,
        et_CLICK = 6,
        et_DOUBLE_CLICK = 7,
        et_MATRIX_LINK_PRESSED = 8,
        et_MATRIX_COLLAPSE_PRESSED = 9,
        et_VALIDATE = 10,
        et_MATRIX_LOAD = 11,
        et_DATASOURCE_LOAD = 12,
        et_FORM_LOAD = 16,
        et_FORM_UNLOAD = 17,
        et_FORM_ACTIVATE = 18,
        et_FORM_DEACTIVATE = 19,
        et_FORM_CLOSE = 20,
        et_FORM_RESIZE = 21,
        et_FORM_KEY_DOWN = 22,
        et_FORM_MENU_HILIGHT = 23,
        et_PRINT = 24,
        et_PRINT_DATA = 25,
        et_EDIT_REPORT = 26,
        et_CHOOSE_FROM_LIST = 27,
        et_RIGHT_CLICK = 28,
        et_MENU_CLICK = 32,
        et_FORM_DATA_ADD = 33,
        et_FORM_DATA_UPDATE = 34,
        et_FORM_DATA_DELETE = 35,
        et_FORM_DATA_LOAD = 36,
        et_PICKER_CLICKED = 37,
    }

    public enum BoFormStateEnum
    {
        fs_Minimized = 1,
        fs_Maximized = 2,
        fs_Restore = 3,
    }

    public enum BoWallpaperDisplayTypes
    {
        wdt_Centralization = 1,
        wdt_FullScreen = 2,
        wdt_Tile = 3,
    }

    public enum BoMessageTime
    {
        bmt_Short = 5,
        bmt_Medium = 20,
        bmt_Long = 50,
    }

    public enum BoStatusBarMessageType
    {
        smt_Warning = 1,
        smt_Error = 2,
        smt_Success = 3,
        smt_None = -1,
    }

    public enum BoLicenseStatus
    {
        ls_DenyLicense = 0,
        ls_ReadLicense = 1,
        ls_FullLicense = 2,
    }

    public enum BoConditionOperation
    {
        co_NONE = 0,
        co_EQUAL = 1,
        co_GRATER_THAN = 2,
        co_LESS_THAN = 3,
        co_GRATER_EQUAL = 4,
        co_LESS_EQUAL = 5,
        co_NOT_EQUAL = 6,
        co_CONTAIN = 7,
        co_NOT_CONTAIN = 8,
        co_START = 9,
        co_END = 10,
        co_BETWEEN = 11,
        co_NOT_BETWEEN = 12,
        co_IS_NULL = 13,
        co_NOT_NULL = 14,
    }

    public enum BoConditionRelationship
    {
        cr_NONE = 0,
        cr_AND = 98,
        cr_OR = 99,
    }

    public enum BoFieldsType
    {
        ft_NotDefined = 0,
        ft_AlphaNumeric = 1,
        ft_Integer = 2,
        ft_Text = 3,
        ft_Date = 4,
        ft_Float = 5,
    }

    public enum BoDataType
    {
        dt_LONG_NUMBER = 0,
        dt_SHORT_NUMBER = 1,
        dt_QUANTITY = 2,
        dt_PRICE = 3,
        dt_RATE = 4,
        dt_MEASURE = 5,
        dt_SUM = 6,
        dt_PERCENT = 7,
        dt_LONG_TEXT = 8,
        dt_SHORT_TEXT = 9,
        dt_DATE = 10
    }

    public enum BoSearchKey
    {
        psk_ByValue = 0,
        psk_ByDescription = 1,
        psk_Index = 2,
    }

    public enum BoSeriesMode
    {
        sf_Add = 1,
        sf_View = 2,
    }

    public enum BoScrollBars
    {
        sb_None = 0,
        sb_Vertical = 2,
    }

    public enum BoPickerType
    {
        pt_None = 0,
        pt_Date = 1,
        pt_Cfl = 2,
        pt_Calc = 3,
        pt_Search = 4,
        pt_TransEmpty = 5,
        pt_TransFull = 6,
    }

    public enum BoCellClickType
    {
        ct_Regular = 0,
        ct_Double = 1,
        ct_Linked = 2,
        ct_Collapsed = 3,
    }

    public enum BoFormItemTypes
    {
        it_BUTTON = 4,
        it_STATIC = 8,
        it_EDIT = 16,
        it_FOLDER = 99,
        it_RECTANGLE = 100,
        it_ACTIVE_X = 102,
        it_PANE_COMBO_BOX = 104,
        it_COMBO_BOX = 113,
        it_LINKED_BUTTON = 116,
        it_PICTURE = 117,
        it_EXTEDIT = 118,
        it_CHECK_BOX = 121,
        it_OPTION_BUTTON = 122,
        it_MATRIX = 127,
        it_GRID = 128,
    }

    public enum BoMatrixSelect
    {
        ms_None = 0,
        ms_Auto = 1,
        ms_Single = 2,
        ms_NotSupported = 3,
    }

    public enum BoOrderType
    {
        ot_SelectionOrder = 0,
        ot_RowOrder = 1,
    }

    public enum BoMatrixLayoutType
    {
        mlt_Normal = 0,
        mlt_Vertical = 1,
        mlt_VerticalStaticTitle = 2,
    }

    public enum BoMatrixXmlSelect
    {
        mxs_All = 0,
        mxs_MetaData = 1,
    }

    public enum BoAutoManagedAttr
    {
        ama_Visible = 1,
        ama_Editable = 2,
    }

    public enum BoAutoFormMode
    {
        afm_Ok = 1,
        afm_Add = 2,
        afm_Find = 4,
        afm_View = 8,
        afm_All = -1,
    }

    public enum BoModeVisualBehavior
    {
        mvb_False = 0,
        mvb_True = 1,
        mvb_Default = 2,
    }

    public enum BoFormMode
    {
        fm_FIND_MODE = 0,
        fm_OK_MODE = 1,
        fm_UPDATE_MODE = 2,
        fm_ADD_MODE = 3,
        fm_VIEW_MODE = 4,
        fm_PRINT_MODE = 5,
        fm_EDIT_MODE = 6,
    }

    public enum BoMenuType
    {
        mt_STRING = 1,
        mt_POPUP = 2,
        mt_SEPERATOR = 3,
    }

    public enum BoFormBorderStyle
    {
        fbs_Sizable = 0,
        fbs_FixedNoTitle = 3,
        fbs_Fixed = 4,
        fbs_Floating = 6,
    }

    public enum BoFormTypes
    {
        ft_Sizable = 0,
        ft_FixedNoTitle = 3,
        ft_Fixed = 4,
        ft_Floating = 6,
    }

    public enum BoLinkedObject
    {
        lf_UserDefinedObject = 0,
        lf_GLAccounts = 1,
        lf_BusinessPartner = 2,
        lf_DiscountCodes = 3,
        lf_Items = 4,
        lf_VatGroup = 5,
        lf_SpecialPrices = 7,
        lf_User = 12,
        lf_Invoice = 13,
        lf_InvoiceCreditMemo = 14,
        lf_DeliveryNotes = 15,
        lf_DeliveryNotesReturns = 16,
        lf_Order = 17,
        lf_PurchaseInvoice = 18,
        lf_PurchaseInvoiceCreditMemo = 19,
        lf_GoodsReceiptPO = 20,
        lf_GoodsReturns = 21,
        lf_PurchaseOrder = 22,
        lf_Quotation = 23,
        lf_Receipt = 24,
        lf_Deposit = 25,
        lf_JournalVoucher = 28,
        lf_JournalPosting = 30,
        lf_ContactWithCustAndVend = 33,
        lf_RecurringTransactions = 34,
        lf_CreditCards = 36,
        lf_PaymentTermsTypes = 40,
        lf_VendorPayment = 46,
        lf_DeliveryTypes = 49,
        lf_ItemGroups = 52,
        lf_SalesEmployee = 53,
        lf_TransactionTemplates = 55,
        lf_CheckForPayment = 57,
        lf_GoodsReceipt = 59,
        lf_GoodsIssue = 60,
        lf_ProfitCenter = 61,
        lf_LoadingFactors = 62,
        lf_ProjectCodes = 63,
        lf_Warehouses = 64,
        lf_ProductTree = 66,
        lf_StockTransfers = 67,
        lf_WorkInstructions = 68,
        lf_ImportFile = 69,
        lf_DueDates = 71,
        lf_CustomerVendorCatalogNumber = 73,
        lf_PredatedDeposit = 76,
        lf_BudgetSystem = 78,
        lf_AlertsTemplate = 80,
        lf_SpecialPricesForGroups = 85,
        lf_RunExternalsApplications = 86,
        lf_UserDefaults = 93,
        lf_SerialNumbersForItems = 94,
        lf_SalesOpportunity = 97,
        lf_ItemBatchNumbers = 106,
        lf_UserValidValues = 110,
        lf_FinancePeriod = 111,
        lf_Drafts = 112,
        lf_AddressFormats = 113,
        lf_UserDisplayCategories = 114,
        lf_ConfirmationLevel = 120,
        lf_ConfirmationTemplates = 121,
        lf_ConfirmationDocumnets = 122,
        lf_ExpensesDefinition = 125,
        lf_SalesTaxAuthorities = 126,
        lf_SalesTaxCodes = 128,
        lf_AddressFormat = 131,
        lf_CorrectionInvoice = 132,
        lf_CashDiscount = 133,
        lf_VatIndicator = 135,
        lf_Indicator = 138,
        lf_GoodsShipment = 139,
        lf_AccountSegmentationCode = 143,
        lf_PaymentMethod = 147,
        lf_PickList = 156,
        lf_PaymentBlock = 159,
        lf_CentralBankIndicator = 161,
        lf_StockRevaluation = 162,
        lf_ContractTemplete = 170,
        lf_Employee = 171,
        lf_InstallBase = 176,
        lf_AgentPerson = 177,
        lf_WithHoldingTax = 178,
        lf_BillOfExchange = 181,
        lf_BillOfExchangeTransaction = 182,
        lf_FileFormat = 183,
        lf_PeriodIndicator = 184,
        lf_HolidaysTable = 186,
        lf_BPBankAccount = 187,
        lf_ServiceCallSolution = 189,
        lf_ServiceContract = 190,
        lf_ServiceCall = 191,
        lf_DunningTerms = 196,
        lf_SalesForecast = 198,
        lf_Territory = 200,
        lf_ProductionOrder = 202,
        lf_PackageType = 206,
        lf_PredefinedText = 215,
        lf_None = -1,
    }

    public enum BoLanguages
    {
        ln_Hebrew = 1,
        ln_Spanish_Ar = 2,
        ln_English = 3,
        ln_Polish = 5,
        ln_English_Sg = 6,
        ln_Spanish_Pa = 7,
        ln_English_Gb = 8,
        ln_German = 9,
        ln_Serbian = 10,
        ln_Danish = 11,
        ln_Norwegian = 12,
        ln_Italian = 13,
        ln_Hungarian = 14,
        ln_Chinese = 15,
        ln_Dutch = 16,
        ln_Finnish = 17,
        ln_Greek = 18,
        ln_Portuguese = 19,
        ln_Swedish = 20,
        ln_English_Cy = 21,
        ln_French = 22,
        ln_Spanish = 23,
        ln_Russian = 24,
        ln_Spanish_La = 25,
        ln_Czech_Cz = 26,
        ln_Slovak_Sk = 27,
        ln_Korean_Kr = 28,
        ln_Portuguese_Br = 29,
        ln_Japanese_Jp = 30,
        ln_Turkish_Tr = 31,
        ln_TrdtnlChinese_Hk = 35,
    }

    public enum BoCreatableObjectType
    {
        cot_MenuCreationParams = 0,
        cot_FormCreationParams = 1,
        cot_Conditions = 2,
        cot_ChooseFromListCreationParams = 3,
    }

    public enum BoModifiersEnum
    {
        mt_None = 0,
        mt_SHIFT = 512,
        mt_ALT = 2048,
        mt_CTRL = 4096,
    }

    public enum BoAppEventTypes
    {
        aet_ShutDown = 64,
        aet_CompanyChanged = 65,
        aet_LanguageChanged = 66,
        aet_ServerTerminition = 67,
    }

    public enum BoProgressBarEventTypes
    {
        pbet_ProgressBarCreated = 69,
        pbet_ProgressBarStopped = 70,
        pbet_ProgressBarReleased = 71,
    }

    public enum BoPrintEventTypes
    {
        pet_Print = 90,
        pet_PrintPreview = 91,
    }

    public enum BoButtonTypes
    {
        bt_Caption = 0,
        bt_Image = 1,
    }

    public enum BoGridColumnType
    {
        gct_EditText = 16,
        gct_ComboBox = 113,
        gct_Picture = 117,
        gct_CheckBox = 121,
    }

    public enum BoComboDisplayType
    {
        cdt_Value = 0,
        cdt_Description = 1,
        cdt_both = 2,
    }

    public struct MenuID
    {
        public const string cBoUIADM = "3328";
        public const string cBoUIADMInicialziacao = "8192";
        public const string cBoUIModulesMenu = "43520";
        public const string cBoUIModulesMenuVendas = "2048";
        public const string cBoUIToolsMenu = "4864";
        public const string cBoUIBank = "43537";
        public const string cBoUIBankContasReceber = "2816";
        public const string cBoUIBankContasPagar = "43538";
        public const string cBoUIBankDeposito = "14592";
        public const string cBoUIAdminConfig = "43525";

        public const string ID_Save = "516";
        public const string ID_PrintPreview = "519";
        public const string ID_Print = "520";
        public const string ID_SendEmail = "6657";
        public const string ID_SendSMS = "6658";
        public const string ID_SendFax = "6659";
        public const string ID_ExportMSExcel = "7169";
        public const string ID_ExportMSWord = "7170";
        public const string ID_LaunchApplication = "523";
        public const string ID_LockScreen = "524";
        public const string ID_Find = "1281";
        public const string ID_Add = "1282";
        public const string ID_FirstDataRecord = "1290";
        public const string ID_PreviousRecord = "1289";
        public const string ID_NextRecord = "1288";
        public const string ID_LastDataRecord = "1291";
        public const string ID_DocumentEditing = "5895";
        public const string ID_TransactionJournal = "5894";
        public const string ID_PaymentMeans = "5892";
        public const string ID_GrossProfit = "5891";
        public const string ID_VolumeWeightCalculation = "5893";
        public const string ID_BaseDocument = "5898";
        public const string ID_TargetDocument = "5899";
        public const string ID_Settings = "5890";
        public const string ID_SortTable = "4869";
        public const string ID_SavedQueries = "4865";
        public const string ID_InsertLine = "1292";
        public const string ID_DeleteLine = "1293";
        public const string ID_CloseLine = "1299";
        public const string ID_CopyDueSaldo = "5915";
        public const string ID_AdvancedMenu = "43572";
        public const string ID_Delete = "1283";
        public const string ID_Cancel = "1284";

    }

}
