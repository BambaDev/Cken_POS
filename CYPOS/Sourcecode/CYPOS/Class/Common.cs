using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
namespace cypos
{
    public static class Global
    {
        public static string ERROR_WRITE_PATH = Application.StartupPath + @"\Errors\";
    }


    class OpenedForms
    {
        public static bool Close()
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "frmLogin" & f.Name != "frmMain")
                   f.Close();
            }
            return true;
        }
    }

    class ThisForm
    {
        public static bool Close()
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name == "frmKeyboard" || f.Name == "frmNumberboard" || f.Name == "frmCurrencyboard")
                    f.Close();
            }
            return true;
        }
    }

    public static class ReportValue
    {
        public static string StartDate { get; set; }
        public static string EndDate { get; set; }
        public static string emp { get; set; }
        public static string Terminal { get; set; }
    }

    public static class TaxValue
    {
        public static string TaxType
        {
            get
            {
                string strSQL = "SELECT TOP 1 tax_type FROM tbl_Company";
                DataTable dtTaxType = SecureDataAccess.GetDataTable(strSQL);
                string strValue = dtTaxType.Rows[0].ItemArray[0].ToString();
                return strValue;
            }
        }


        public static string Tax1Name
        {
            get
            {
                string strSQL = "SELECT TOP 1 tax1_name FROM tbl_Company";
                DataTable dtTax1 = SecureDataAccess.GetDataTable(strSQL);
                string strValue = dtTax1.Rows[0].ItemArray[0].ToString();
                return strValue;
            }
        }

        public static string Tax1Rate
        {
            get
            {
                string strSQL = "SELECT TOP 1 tax1_rate FROM tbl_Company";
                DataTable dtTax1 = SecureDataAccess.GetDataTable(strSQL);
                string strValue = dtTax1.Rows[0].ItemArray[0].ToString();
                return strValue;
            }
        }

        public static string Tax2Name
        {
            get
            {
                string strSQL = "SELECT TOP 1 tax2_name FROM tbl_Company";
                DataTable dtTax2 = SecureDataAccess.GetDataTable(strSQL);
                string strValue = dtTax2.Rows[0].ItemArray[0].ToString();
                return strValue;
            }
        }

        public static string Tax2Rate
        {
            get
            {
                string strSQL = "SELECT TOP 1 tax2_rate FROM tbl_Company";
                DataTable dtTax2 = SecureDataAccess.GetDataTable(strSQL);
                string strValue = dtTax2.Rows[0].ItemArray[0].ToString();
                return strValue;
            }
        }

        public static int CalMethod
        {
            get
            {
                string strSQL = "SELECT TOP 1 cal_method FROM tbl_Company";
                DataTable dtCalMethod = SecureDataAccess.GetDataTable(strSQL);
                int iValue =int.Parse(dtCalMethod.Rows[0].ItemArray[0].ToString());
                return iValue;
            }
        }

    }


    public static class Settings
    {
        private static DataRow _cache;
        private static DateTime _cacheTime = DateTime.MinValue;
        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(5);

        private static DataRow GetSettings()
        {
            if (_cache == null || (DateTime.Now - _cacheTime) > CacheDuration)
            {
                string strSQL = "SELECT TOP 1 * FROM tbl_Settings";
                DataTable dt = SecureDataAccess.GetDataTable(strSQL);
                if (dt.Rows.Count > 0)
                {
                    _cache = dt.Rows[0];
                    _cacheTime = DateTime.Now;
                }
            }
            return _cache;
        }

        public static void RefreshCache()
        {
            _cache = null;
            _cacheTime = DateTime.MinValue;
        }

        public static int ItemsPerPage
        {
            get { return int.Parse(GetSettings()["items_per_page"].ToString()); }
        }

        public static bool AskTable
        {
            get { return bool.Parse(GetSettings()["ask_table"].ToString()); }
        }

        public static bool AskGuestCount
        {
            get { return bool.Parse(GetSettings()["ask_guest_count"].ToString()); }
        }

        public static bool AskWaiter
        {
            get { return bool.Parse(GetSettings()["ask_waiter"].ToString()); }
        }

        public static bool AutoHoldId
        {
            get { return bool.Parse(GetSettings()["auto_hold_id"].ToString()); }
        }

        public static int DefaultDiscount
        {
            get { return int.Parse(GetSettings()["default_discount_rate"].ToString()); }
        }

        public static int DefaultOrderType
        {
            get { return int.Parse(GetSettings()["default_order_type"].ToString()); }
        }

        public static bool EnableServiceCharge
        {
            get { return bool.Parse(GetSettings()["enable_sc"].ToString()); }
        }

        public static double ServiceChargeRate
        {
            get { return double.Parse(GetSettings()["sc_rate"].ToString()); }
        }

        public static bool CustomerAfterDO
        {
            get { return bool.Parse(GetSettings()["customer_after_do"].ToString()); }
        }

        public static bool AutoItemNo
        {
            get { return bool.Parse(GetSettings()["auto_item_no"].ToString()); }
        }

        public static bool CustomerAfterPO
        {
            get { return bool.Parse(GetSettings()["customer_after_po"].ToString()); }
        }

        public static bool PreviewBeforePrint
        {
            get { return bool.Parse(GetSettings()["preview_before_print"].ToString()); }
        }

        public static bool ShowOtAfterBill
        {
            get { return bool.Parse(GetSettings()["show_ot_after"].ToString()); }
        }

        public static string InvoiceNoPrefix
        {
            get { return GetSettings()["invoice_no_prefix"].ToString(); }
        }

        public static bool ShowLeadingZeros
        {
            get { return bool.Parse(GetSettings()["show_leading_zeros"].ToString()); }
        }

        public static int LeadingZerosCount
        {
            get { return int.Parse(GetSettings()["zeros_count"].ToString()); }
        }

        public static int StartingInvoiceNo
        {
            get { return int.Parse(GetSettings()["starting_invoice_no"].ToString()); }
        }

        public static int LastInvoiceAutoNo
        {
            get
            {
                string strSQL = "SELECT ISNULL(MAX(auto_id),'0') AS auto_id FROM tbl_InvoiceNo";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["auto_id"].ToString());
                return Value;
            }
        }

        public static string LastInvoiceNo
        {
            get
            {
                string strSQL = "SELECT TOP 1 invoice_no FROM tbl_InvoiceNo ORDER BY auto_id DESC";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                if (dtSettings.Rows.Count != 0)
                    return dtSettings.Rows[0]["invoice_no"].ToString();
                return string.Empty;
            }
        }

        public static string KotNoPrefix
        {
            get { return GetSettings()["kot_no_prefix"].ToString(); }
        }

        public static bool KotLeadingZeros
        {
            get { return bool.Parse(GetSettings()["kot_leading_zeros"].ToString()); }
        }

        public static int KotZerosCount
        {
            get { return int.Parse(GetSettings()["kot_zeros_count"].ToString()); }
        }

        public static int StartingKotNo
        {
            get { return int.Parse(GetSettings()["kot_starting_no"].ToString()); }
        }

        public static int LastKotAutoNo
        {
            get
            {
                string strSQL = "SELECT ISNULL(MAX(auto_id),'0') AS auto_id FROM tbl_KotNo";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["auto_id"].ToString());
                return Value;
            }
        }

        public static int LastHoldAutoNo
        {
            get
            {
                string strSQL = "SELECT ISNULL(MAX(auto_id),'0') AS auto_id FROM tbl_HoldNo";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["auto_id"].ToString());
                return Value;
            }
        }

        public static int LastItemAutoNo
        {
            get
            {
                string strSQL = "SELECT ISNULL(MAX(auto_id),'0') AS auto_id FROM tbl_ItemNo";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["auto_id"].ToString());
                return Value;
            }
        }

        public static string InvoicePrinter
        {
            get { return GetSettings()["invoice_printer"].ToString(); }
        }

        public static string KotPrinter
        {
            get { return GetSettings()["kot_printer"].ToString(); }
        }

        public static bool PrintKotAfterHold
        {
            get { return bool.Parse(GetSettings()["print_kot_after_hold"].ToString()); }
        }

        public static bool ViewKotB4Print
        {
            get { return bool.Parse(GetSettings()["kot_view_before_print"].ToString()); }
        }

    }

    public static class Company
    {
        public static string Logo
        {
            get
            {
                string strSQL = "SELECT TOP 1 logo FROM tbl_Company";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                string strLogo = dtSettings.Rows[0]["logo"].ToString();
                return strLogo;
            }
        }
    }

    public static class Currency
    {
        /// <summary>
        /// Formate un montant en Francs CFA sans décimales
        /// </summary>
        /// <param name="amount">Montant à formater</param>
        /// <returns>Format: "5 000 FCFA" avec espace comme séparateur de milliers</returns>
        public static string Format(decimal amount)
        {
            // Arrondir au Franc le plus proche (pas de centimes en FCFA)
            decimal rounded = Math.Round(amount, 0, MidpointRounding.AwayFromZero);
            // Format avec espace comme séparateur de milliers (N0 = pas de décimales)
            return rounded.ToString("N0") + " FCFA";
        }

        /// <summary>
        /// Formate un montant double en Francs CFA sans décimales
        /// </summary>
        public static string Format(double amount)
        {
            return Format(Convert.ToDecimal(amount));
        }

        /// <summary>
        /// Parse une chaîne en decimal avec arrondi automatique
        /// Supporte formats français (virgule) et anglais (point)
        /// </summary>
        /// <param name="text">Texte à parser (ex: "5000,50" ou "5000.50" ou "5 000 FCFA")</param>
        /// <returns>Decimal arrondi (ex: 5001)</returns>
        public static decimal Parse(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            // Enlever "FCFA" et espaces multiples
            text = text.Replace("FCFA", "").Replace("F CFA", "").Trim();
            // Enlever les espaces (séparateurs de milliers)
            text = text.Replace(" ", "");

            decimal result = 0;
            // Essayer de parser avec la culture courante (supporte virgule ET point)
            if (decimal.TryParse(text, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.CurrentCulture, out result))
            {
                // Arrondir au Franc le plus proche
                return Math.Round(result, 0, MidpointRounding.AwayFromZero);
            }

            // Si échec avec CurrentCulture, essayer InvariantCulture (point décimal)
            if (decimal.TryParse(text, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out result))
            {
                return Math.Round(result, 0, MidpointRounding.AwayFromZero);
            }

            return 0;
        }

        /// <summary>
        /// Formate un montant sans le suffixe FCFA (pour TextBox pendant saisie)
        /// </summary>
        public static string FormatInput(decimal amount)
        {
            decimal rounded = Math.Round(amount, 0, MidpointRounding.AwayFromZero);
            return rounded.ToString("N0");
        }
    }
}
