using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Linq;
namespace cypos
{
    public class DirectPrint
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        public static bool Print(LocalReport report,string strPrinter=null, bool print = true)
        {
            bool rValue = false;
            string deviceInfo =
             @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>3.1in</PageWidth>
                <PageHeight>11.0in</PageHeight>
                <MarginTop>0.2in</MarginTop>
                <MarginLeft>0.1in</MarginLeft>
                <MarginRight>0.1in</MarginRight>
                <MarginBottom>0.1in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

            if (print)
            {
                rValue= PrintFile(strPrinter);
            }
            return rValue;
        }

        public static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        public static bool PrintFile(string printer)
        {
            bool isPrinted = false;
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                if (PrinterExists(printer))
                {
                    printDoc.PrinterSettings.PrinterName = printer;
                }
                printDoc.Print();              
                isPrinted = true;                  
            }
            return isPrinted;
        }

        public static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
            Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public static void DisposePrint()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        public static bool PrinterExists(string printerName)
        {
            if (String.IsNullOrEmpty(printerName)) { throw new ArgumentNullException("printerName"); }
            return PrinterSettings.InstalledPrinters.Cast<string>().Any(name => printerName.ToUpper().Trim() == name.ToUpper().Trim());
        }

        public static string GetDefaultPrinter() 
        { 
            PrinterSettings settings = new PrinterSettings(); 
            foreach (string printer in PrinterSettings.InstalledPrinters) 
            { 
                settings.PrinterName = printer; 
                if (settings.IsDefaultPrinter) 
                    return printer; 
            } 
            return string.Empty; 
        }
    }
}
