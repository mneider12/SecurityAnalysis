using SecurityAnalysis.Core.Database;
using SecurityAnalysis.Core.FileSystem;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SecurityAnalysis.Core.Transaction
{
    public class Transaction
    {

        public Transaction(DateTime date, string ticker, int shares, decimal totalCost)
        {
            ID = NextId;
            Date = date;
            Ticker = ticker;
            NumberOfShares = shares;
            TotalCost = totalCost;
        }

        public bool commit()
        {
            if (validate())
            {
                return insert();
            }
            else
            {
                return false;
            }
        }

        private bool insert()
        {
            string insertTransactionSql = "INSERT INTO " + TransactionsTable.NAME +
                                          " VALUES (" +
                                                    ID +
                                                    ",'" + Date.Ticks + "'" +
                                                    ",'" + Ticker + "'" +
                                                    ",'" + NumberOfShares + "'" +
                                                    ",'" + TotalCost + "'" +
                                                   ")";

            using (SQLiteConnection databaseConnection = DatabaseHelper.open())
            {
                using (SQLiteCommand insertTransactionCommand = new SQLiteCommand(insertTransactionSql, databaseConnection))
                {
                    return insertTransactionCommand.ExecuteNonQuery() == 1; // one row should be inserted
                }
            }
        }

        #region validation functions
        private bool validate()
        {
            if (!validateDate())
            {
                return false;
            }
            
            if (!validateShares())
            {
                return false;
            }

            if (!validateTicker())
            {
                return false;
            }

            if (!validateCost())
            {
                return false;
            }

            return true;
        }
        private bool validateDate()
        {
            if (Date == null || Date > DateTime.Today)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validateTicker()
        {
            if (string.IsNullOrWhiteSpace(Ticker))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validateShares()
        {
            if (NumberOfShares > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool validateCost()
        {
            if (TotalCost > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  

        #region public properties
        public int ID { get; private set; }
        public DateTime Date { get; set; }
        public string Ticker { get; set; }
        public int NumberOfShares { get; set; }
        public decimal TotalCost { get; set; }
        #endregion

        private int lastId;
        private int NextId
        {
            get
            {
                if (lastId == 0)
                {
                    loadLastId();
                }
                lastId = lastId + 1;

                saveLastId();
                return lastId;
            }
        }

        private void loadLastId()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(int));
            try
            {
                using (Stream idCountFileStream = File.Open(getIdCounterFilePath(), FileMode.Open))
                {
                    lastId = (int)serializer.Deserialize(idCountFileStream);
                }
            }
            catch (FileNotFoundException)
            {
                lastId = 1; // not established yet
            }
        }

        private void saveLastId()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(int));
            using (Stream idCountFile = File.Open(getIdCounterFilePath(), FileMode.Create))
            {
                serializer.Serialize(idCountFile, lastId);
            }
        }

        private string getIdCounterFilePath()
        {
            return Path.Combine(FileSystemHelper.getDataDirectory(), ID_COUNTER_FILE);
        }

        private const string ID_COUNTER_FILE = "id_counter.xml";
    }
}