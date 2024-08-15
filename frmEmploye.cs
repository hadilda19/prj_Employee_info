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

namespace prjFinalPOO
{
    public partial class frmEmploye : Form
    {
        public frmEmploye()
        {
            InitializeComponent();
        }
        struct Employe
        {
            public string Numero;
            public string Nom;
            public string Fonction;
            public Int32 Salaire;
        }
        List<Employe> tabEmplyoyes = new List<Employe>();

        private void frmEmploye_Load(object sender, EventArgs e)
        {
            StreamReader eFichier = new StreamReader("Compagnie.txt");
            while (eFichier.EndOfStream == false)
            {
                Employe unemp;
                unemp.Numero = eFichier.ReadLine();
                unemp.Nom = eFichier.ReadLine();
                unemp.Fonction = eFichier.ReadLine();
                unemp.Salaire = Convert.ToInt32(eFichier.ReadLine());
                tabEmplyoyes.Add(unemp);
            }
            eFichier.Close();
            foreach (Employe q in tabEmplyoyes)
            {

                listBox1.Items.Add(q.Numero);
            }

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {

            Employe un;
            un.Numero = txtNum.Text;
            un.Nom = txtNom.Text;
            un.Salaire = Convert.ToInt32(txtSalaire.Text);
            un.Fonction = txtFonction.Text;
            tabEmplyoyes.Add(un);
            listBox1.Items.Add(un.Numero);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string empchoisi = listBox1.SelectedItem.ToString();
            for (int i = 0; i < tabEmplyoyes.Count; i++)
            {
                if (empchoisi == tabEmplyoyes[i].Numero)
                {
                    lblNumero.Text = tabEmplyoyes[i].Numero;
                    lblNom.Text = tabEmplyoyes[i].Nom;
                    lblFonction.Text = tabEmplyoyes[i].Fonction;
                    lblSalaire.Text = tabEmplyoyes[i].Salaire.ToString();
                }
            }
        }

        private void btnSuppr_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
