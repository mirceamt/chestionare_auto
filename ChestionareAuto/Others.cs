using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlServerCe;
using System.Drawing;

namespace ChestionareAuto
{
    public class DatabaseQuestions
    {
        private string GetConnectionString()
        {
            return "Data source = " + Directory.GetCurrentDirectory() + "\\ChestionareAuto.sdf";
        }

        private Dictionary<char, List<QuestionClass>> L;
        public  DatabaseQuestions()
        {
            L = new Dictionary<char, List<QuestionClass>>();
            string categorie = "ABCDER";
            List<QuestionClass> nowList;
            SqlCeConnection conexiune = new SqlCeConnection(GetConnectionString());
            conexiune.Open();

            SqlCeCommand comanda = null;
            SqlCeDataReader reader = null;

            foreach (char ch in categorie)
            {
                nowList = new List<QuestionClass>();
                nowList.Add(new QuestionClass());
                string letter = ch.ToString();
                string query = "SELECT * FROM " + letter;
                comanda = new SqlCeCommand(query, conexiune);
                reader = comanda.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"].ToString());
                    string question = reader["question"].ToString();
                    string ansA = reader["ansA"].ToString();
                    string ansB = reader["ansB"].ToString();
                    string ansC = reader["ansC"].ToString();
                    string ansCorrect = reader["ansCorrect"].ToString();
                    string photoPath = reader["photoPath"].ToString();
                    if (photoPath == String.Empty)
                        nowList.Add(new QuestionClass(id, question, ansA, ansB, ansC, ansCorrect, false));
                    else
                        nowList.Add(new QuestionClass(id, question, ansA, ansB, ansC, ansCorrect, true, "appFiles//" + letter + "//" + id + ".jpg"));
                }
                reader.Close();
                L[ch] = nowList;
                nowList = null;
            }
            conexiune.Close();
            conexiune.Dispose();
            reader.Dispose();
        }
        public QuestionClass this[char categ, int i]
        {
            get { return L[categ][i]; }
            set { L[categ][i] = value; }
        }
        public void Dispose()
        {
            string categ = "ABCDER";
            foreach (char ch in categ)
            {
                L[ch].Clear();
                L[ch] = null;
            }
            L.Clear();
            L = null;
            System.GC.Collect();
        }
    }
}