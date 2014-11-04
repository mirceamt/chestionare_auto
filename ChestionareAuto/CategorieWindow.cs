using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlServerCe;

namespace ChestionareAuto
{
    public partial class CategorieWindow : Form
    {
        public CategorieWindow()
        {
            InitializeComponent();
            //InsertDatabase();
        }

        #region NU UMBLA!
        private string categories = "ABCDER";

        private string GetConnectionString()
        {
            return "Data source = " + Directory.GetCurrentDirectory() + "\\ChestionareAuto.sdf";
        }

        private void InsertDatabase()
        {
            for (int i = 0; i < 6; ++i)
            {
                string connString = GetConnectionString();
                string letter = categories[i].ToString();
                SqlCeConnection conexiune = new SqlCeConnection(connString);
                conexiune.Open();
                StreamReader fin = new StreamReader("appFiles\\" + letter + "\\data.txt");
                while (fin.ReadLine() != null)
                {
                    int id = Convert.ToInt32(fin.ReadLine());
                    string question = fin.ReadLine();
                    string ansA = fin.ReadLine();
                    string ansB = fin.ReadLine();
                    string ansC = fin.ReadLine();
                    string ansCorrect = fin.ReadLine();
                    bool existaPhoto = fin.ReadLine() == "True";
                    string query = "INSERT INTO " + letter + "(question, ansA, ansB, ansC, ansCorrect, photoPath) VALUES (@question, @ansA, @ansB, @ansC, @ansCorrect, @photoPath)";
                    SqlCeCommand comanda = new SqlCeCommand(query, conexiune);
                    comanda.Parameters.AddWithValue("@question", question);
                    comanda.Parameters.AddWithValue("@ansA", ansA);
                    comanda.Parameters.AddWithValue("@ansB", ansB);
                    comanda.Parameters.AddWithValue("@ansC", ansC);
                    comanda.Parameters.AddWithValue("@ansCorrect", ansCorrect);
                    comanda.Parameters.AddWithValue("@photoPath", existaPhoto ? "appFiles\\" + letter + "\\" + id + ".jpg" : "");
                    comanda.ExecuteNonQuery();
                }
                fin.Close();
                conexiune.Close();
            }
        }
        #endregion

        private void startChestionarButton_Click(object sender, EventArgs e)
        {
            string categorie = String.Empty;
            if (radioA.Checked) categorie = "A";
            if (radioB.Checked) categorie = "B";
            if (radioC.Checked) categorie = "C";
            if (radioD.Checked) categorie = "D";
            if (radioE.Checked) categorie = "E";
            if (radioR.Checked) categorie = "R";

            this.Hide();

            ChestionarWindow cw = new ChestionarWindow(this, categorie);
            cw.ShowDialog();
            if (cw.CloseApp)
            {
                Application.Exit();
            }
            if (cw.IsClosed)
            {
                cw.Dispose();
                cw = null;
            }
        }
    }
}
