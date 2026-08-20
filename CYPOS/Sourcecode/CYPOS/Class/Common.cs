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
        public static int ItemsPerPage
        {
            get
            {
                string strSQL = "SELECT TOP 1 items_per_page FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                int iValue = int.Parse(dtSettings.Rows[0]["items_per_page"].ToString());
                return iValue;
            }
        }

        public static bool AskTable
        {
            get
            {
                string strSQL = "SELECT TOP 1 ask_table FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool bValue = bool.Parse(dtSettings.Rows[0]["ask_table"].ToString());
                return bValue;
            }
        }

        public static bool AskGuestCount
        {
            get
            {
                string strSQL = "SELECT TOP 1 ask_guest_count FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool bValue = bool.Parse(dtSettings.Rows[0]["ask_guest_count"].ToString());
                return bValue;
            }
        }

        public static bool AskWaiter
        {
            get
            {
                string strSQL = "SELECT TOP 1 ask_waiter FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool bValue = bool.Parse(dtSettings.Rows[0]["ask_waiter"].ToString());
                return bValue;
            }
        }

        public static bool AutoHoldId
        {
            get
            {
                string strSQL = "SELECT TOP 1 auto_hold_id FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool bValue = bool.Parse(dtSettings.Rows[0]["auto_hold_id"].ToString());
                return bValue;
            }
        }

        public static int DefaultDiscount
        {
            get
            {
                string strSQL = "SELECT TOP 1 default_discount_rate FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                int iValue = int.Parse(dtSettings.Rows[0]["default_discount_rate"].ToString());
                return iValue;
            }
        }

        public static int DefaultOrderType
        {
            get
            {
                string strSQL = "SELECT TOP 1 default_order_type FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                int iValue = int.Parse(dtSettings.Rows[0]["default_order_type"].ToString());
                return iValue;
            }
        }

        public static bool EnableServiceCharge
        {
            get
            {
                string strSQL = "SELECT TOP 1 enable_sc FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["enable_sc"].ToString());
                return Value;
            }
        }

        public static double ServiceChargeRate
        {
            get
            {
                string strSQL = "SELECT TOP 1 sc_rate FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                double dblValue = double.Parse(dtSettings.Rows[0]["sc_rate"].ToString());
                return dblValue;
            }
        }

        public static bool CustomerAfterDO
        {
            get
            {
                string strSQL = "SELECT TOP 1 customer_after_do FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["customer_after_do"].ToString());
                return Value;
            }
        }

        public static bool AutoItemNo
        {
            get
            {
                string strSQL = "SELECT TOP 1 auto_item_no FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["auto_item_no"].ToString());
                return Value;
            }
        }

        public static bool CustomerAfterPO
        {
            get
            {
                string strSQL = "SELECT TOP 1 customer_after_po FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["customer_after_po"].ToString());
                return Value;
            }
        }

        public static bool PreviewBeforePrint
        {
            get
            {
                string strSQL = "SELECT TOP 1 preview_before_print FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["preview_before_print"].ToString());
                return Value;
            }
        }

        public static bool ShowOtAfterBill
        {
            get
            {
                string strSQL = "SELECT TOP 1 show_ot_after FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["show_ot_after"].ToString());
                return Value;
            }
        }
        //Invoice No
        public static string InvoiceNoPrefix
        {
            get
            {
                string strSQL = "SELECT TOP 1 invoice_no_prefix FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                string Value = dtSettings.Rows[0]["invoice_no_prefix"].ToString();
                return Value;
            }
        }

        public static bool ShowLeadingZeros
        {
            get
            {
                string strSQL = "SELECT TOP 1 show_leading_zeros FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["show_leading_zeros"].ToString());
                return Value;
            }
        }

        public static int LeadingZerosCount
        {
            get
            {
                string strSQL = "SELECT TOP 1 zeros_count FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["zeros_count"].ToString());
                return Value;
            }
        }

        public static int StartingInvoiceNo
        {
            get
            {
                string strSQL = "SELECT TOP 1 starting_invoice_no FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["starting_invoice_no"].ToString());
                return Value;
            }
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
                string strValue = string.Empty;
                string strSQL = "SELECT TOP 1 invoice_no FROM tbl_InvoiceNo ORDER BY auto_id DESC"; 
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                if (dtSettings.Rows.Count != 0)
                {
                    strValue = dtSettings.Rows[0]["invoice_no"].ToString();
                }
                return strValue;
            }
        }

        //Kot No

        public static string KotNoPrefix
        {
            get
            {
                string strSQL = "SELECT TOP 1 kot_no_prefix FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                string Value = dtSettings.Rows[0]["kot_no_prefix"].ToString();
                return Value;
            }
        }

        public static bool KotLeadingZeros
        {
            get
            {
                string strSQL = "SELECT TOP 1 kot_leading_zeros FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["kot_leading_zeros"].ToString());
                return Value;
            }
        }

        public static int KotZerosCount
        {
            get
            {
                string strSQL = "SELECT TOP 1 kot_zeros_count FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["kot_zeros_count"].ToString());
                return Value;
            }
        }

        public static int StartingKotNo
        {
            get
            {
                string strSQL = "SELECT TOP 1 kot_starting_no FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["kot_starting_no"].ToString());
                return Value;
            }
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
            get
            {
                string strSQL = "SELECT invoice_printer FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                string strValue = dtSettings.Rows[0]["invoice_printer"].ToString();
                return strValue;
            }
        }

        public static string KotPrinter
        {
            get
            {
                string strSQL = "SELECT kot_printer FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                string strValue = dtSettings.Rows[0]["kot_printer"].ToString();
                return strValue;
            }
        }

        public static bool PrintKotAfterHold
        {
            get
            {
                string strSQL = "SELECT TOP 1 print_kot_after_hold FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["print_kot_after_hold"].ToString());
                return Value;
            }
        }

        public static bool ViewKotB4Print
        {
            get
            {
                string strSQL = "SELECT TOP 1 kot_view_before_print FROM tbl_Settings";
                DataTable dtSettings = SecureDataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["kot_view_before_print"].ToString());
                return Value;
            }
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
