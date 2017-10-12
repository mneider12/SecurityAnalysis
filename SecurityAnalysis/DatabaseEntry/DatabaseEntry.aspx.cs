using SecurityAnalysis.Core.Transaction;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SecurityAnalysis
{
    public partial class DatabaseViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            DateTime date;
            string ticker;
            int numberOfShares;
            Decimal totalCost;

            if (parseInputs(out date, out ticker, out numberOfShares, out totalCost))
            {
                Transaction transaction = new Transaction(date, ticker, numberOfShares, totalCost);
                if (!transaction.commit())
                {
                    commitFailed();
                }
            }
            else
            {
                commitFailed();
            }
           
        }

        private bool parseInputs(out DateTime date, out string ticker, out int numberOfShares, out Decimal totalCost)
        {
            bool parseFailed = false;
            if (!DateTime.TryParse(txtDate.Text, out date))
            {
                parseFailed = true;
            }
            else
            {
                date = date.Date;   // make sure we don't store dates with times.
            }

            ticker = txtTicker.Text;    // no validation currently

            if (!int.TryParse(txtNumberOfShares.Text, out numberOfShares))
            {
                parseFailed = true;
            }

            if (!Decimal.TryParse(txtTotalCost.Text, out totalCost))
            {
                parseFailed = true;
            }

            return !parseFailed;

        }

        private void commitFailed()
        {

        }
    }
}