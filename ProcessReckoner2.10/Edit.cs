using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

namespace Reckoner_App
{
    public partial class Edit : Form
    {
        private string _ticketId = "";
        string strFileName = "Project.xml";

        public Edit()
        {
            InitializeComponent();
        }

        internal void BindingDetailsInEditForm(string ticketId, Project project)
        {
            _ticketId = ticketId;
            ETTtxt.Text = project.TicketType;
            EBtxt.Text = project.Business;
            EAtxt.Text = project.Analysis;
            EAptxt.Text = project.Approach;
            ERtxt.Text = project.Review;
            ETtxt.Text = project.Testing;
            EDRtxt.Text = project.DocReference;
            ERFtxt.Text = project.TicketTeference;

            string str = project.Steps;
            DataTable dt = new DataTable();
            dt.Columns.Add("steps");
            string[] str1 = str.Split(':');

            foreach (var item in str1)
            {
                var step = string.Empty;
                if (item.Contains("Step"))
                {
                    var st = item.LastIndexOf("Step");
                    step = item.Remove(st, 6);
                }
                else { step = item; }
                if (step.Trim().Length > 0)
                {
                    dt.Rows.Add(step);
                }
            }
            dataGridView1.DataSource = dt;
        }

        private void UpdateTicket_Click(object sender, EventArgs e)
        {
            var ticketId = _ticketId;
            var steps = string.Empty;
            var count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    if (row.Index == 0)
                        steps = "Step 1: " + row.Cells[0].Value.ToString();
                    else if (row.Index == dataGridView1.Rows.Count - 1)
                        continue;
                    else
                        steps = steps + "  Step " + (count + 1) + ": " + row.Cells[0].Value.ToString();
                    count++;
                }
            }

            var ttcount = ETTtxt.Text.Trim().Count();
            var eacount = EAtxt.Text.Trim().Count();
            var eapcount = EAptxt.Text.Trim().Count();
            var stepcount = steps.Trim().Count();
            if ((ttcount != 0) && (eacount != 0) && (eapcount != 0) && (stepcount != 0))
            {
                if (File.Exists(strFileName))
                {
                    XmlDocument objXmlDocument = new XmlDocument();
                    objXmlDocument.Load(strFileName);

                    // Getting a particular Employee by selecting using Xpath query
                    XmlNode node = objXmlDocument.SelectSingleNode("//row[TicketTypeID='" + ticketId + "']");

                    if (node != null)
                    {
                        // Assigining all the values
                        node.SelectNodes("TicketType").Item(0).InnerText = ETTtxt.Text;
                        node.SelectNodes("Business").Item(0).InnerText = EBtxt.Text;
                        node.SelectNodes("Analysis").Item(0).InnerText = EAtxt.Text;
                        node.SelectNodes("Approach").Item(0).InnerText = EAptxt.Text;
                        node.SelectNodes("Steps").Item(0).InnerText = steps;
                        node.SelectNodes("Review").Item(0).InnerText = ERtxt.Text;
                        node.SelectNodes("Testing").Item(0).InnerText = ETtxt.Text;
                        node.SelectNodes("LastUpdate").Item(0).InnerText = DateTime.Now.ToString("dd/MM/yyyy");
                        node.SelectNodes("Reference").Item(0).InnerText = ERFtxt.Text;
                        node.SelectNodes("DocumentReference").Item(0).InnerText = EDRtxt.Text;
                        //if (EDRtxt.Text.Trim().Length > 0)
                        //{
                        //    node.SelectNodes("DocumentReference").Item(0).FirstChild.InnerText = EDRtxt.Text;
                        //}
                    }
                    //Saving the file
                    objXmlDocument.Save(strFileName);
                }
                else
                {
                    Exception ex = new Exception("Database file does not exist in the folder");
                    throw ex;
                }
                MessageBox.Show(@"Details Updated Successfully");
                this.Hide();
                var home = new Reckoner();
                home.BindProjects();
            }
            else
            {
                MessageBox.Show(@"Please Fill all the Mandatory Fields");
            }
        }

        private void EditBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var home = new Reckoner();
            home.BindProjects();
        }

        private void Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Reckoner.Count == 0)
            {
                if (
                    MessageBox.Show(@"This will close down the whole application. Confirm?", @"Close Application",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Reckoner.Count++;
                    MessageBox.Show(@"The application has been closed successfully.", @"Application Closed!",
                     MessageBoxButtons.OK);
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                    this.Activate();
                }
            }
        }

        private new void Leave(object sender, EventArgs e)
        {
            var t = ((TextBox)sender);
            t.ScrollBars = ScrollBars.None;
        }

        private new void Enter(object sender, EventArgs e)
        {
            var t = ((TextBox)sender);
            var a = t.Text.Length;
            if (a > 95)
            {
                t.ScrollBars = ScrollBars.Both;
            }
        }

    }
}
