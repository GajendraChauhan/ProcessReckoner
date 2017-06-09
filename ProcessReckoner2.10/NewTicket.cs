using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Reckoner_App
{
    public partial class NewTicket : Form
    {
        private string _projectId = "";
        private string _moduleId = "";
        private string _projectName = "";
        string strFileName = "Project.xml";
        Repository repository = new Repository();

        public NewTicket()
        {
            InitializeComponent();
        }

        private void AddStep_Click(object sender, EventArgs e)
        {
            if (NStxt.Text.Trim().Count() != 0)
            {
                int rowIndex = 0;
                dataGridView1.Rows.Add();
                rowIndex = dataGridView1.Rows.Count - 2;
                // insert values from textboxe to DataGridView
                dataGridView1[0, rowIndex].Value = NStxt.Text;
                dataGridView1.Refresh();
                // Clear textboxes and focus for new entry
                NStxt.Text = "";
                NStxt.Focus();
            }
        }

        private void NewBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var home = new Reckoner();
            home.BindProjects();
        }

        private void SaveTicket_Click(object sender, EventArgs e)
        {
            var item = PrjBox.SelectedValue.ToString();
            var moduleName = PrjBox.Text;
            var steps = GetSteps();
            var ttcount = NTTtxt.Text.Trim().Count();
            var nacount = NAtxt.Text.Trim().Count();
            var apcount = NAPtxt.Text.Trim().Count();
            var stepcount = steps.Trim().Count();
            var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();

            if (item != null && (ttcount != 0) && (nacount != 0) && (apcount != 0) && (stepcount != 0))
            {
                try
                {
                    // Checking if the file exist
                    if (!File.Exists(strFileName))
                    {
                        // If file does not exist in the database path, create and store an empty Addresss Book node
                        XmlTextWriter textWritter = new XmlTextWriter(strFileName, null);
                        textWritter.WriteStartDocument();
                        textWritter.WriteStartElement("Datas");
                        textWritter.WriteEndElement();
                        textWritter.Close();
                    }

                    // Create the XML docment by loading the file
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(strFileName);

                    //
                    string projectId = _projectId;

                    // Creating row node
                    XmlElement subNode = xmlDoc.CreateElement("row");

                    // Getting the maximum Id based on the XML data already stored
                    string ticketTypeID = repository.GetMaxValue(xmlDoc, "Datas" + "/" + "row" + "/" + "TicketTypeID").ToString();

                    // Adding Id column. Auto generated column
                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "ProjectId", projectId));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "ProjectName", _projectName));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "ModuleId", item));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "ModuleName", moduleName));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "TicketTypeID", ticketTypeID));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "TicketType", NTTtxt.Text));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Business", NBtxt.Text));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Analysis", NAtxt.Text));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Approach", NAPtxt.Text));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Steps", steps));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Reference", NRFtxt.Text));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "LastUpdate", DateTime.Now.ToString("dd/MM/yyyy")));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "DocumentReference", NDRtxt.Text));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "ProcessAuthor", Environment.UserName));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Review", NRtxt.Text));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Testing", NTtxt.Text));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Author", Environment.UserName));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "SystemName", windowsIdentity.Name));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    // Saving the file after adding the new employee node
                    xmlDoc.Save(strFileName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                MessageBox.Show(@"New Ticket Created Successfully");
                ClearallFields();
            }
            else
            {
                MessageBox.Show(@"Please Fill all the Mandatory Fields");
            }
        }

        private void ClearallFields()
        {
            PrjBox.SelectedIndex = 0;
            NTTtxt.Text = string.Empty;
            NBtxt.Text = string.Empty;
            NAtxt.Text = string.Empty;
            NAPtxt.Text = string.Empty;
            NStxt.Text = string.Empty;
            NRtxt.Text = string.Empty;
            NTtxt.Text = string.Empty;
            NDRtxt.Text = string.Empty;
            NRFtxt.Text = string.Empty;
            dataGridView1.Rows.Clear();
        }

        private String GetSteps()
        {
            String steps = string.Empty;
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
            return steps;
        }

        private void NewTicket_FormClosing(object sender, FormClosingEventArgs e)
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
            TextBox t = ((TextBox)sender);
            t.ScrollBars = ScrollBars.None;
            //t.BackColor = Color.Black;
            //t.ForeColor = Color.White;
        }

        private new void Enter(object sender, EventArgs e)
        {
            TextBox t = ((TextBox)sender);
            var a = t.Text.Length;
            if (a > 95)
            {
                t.ScrollBars = ScrollBars.Both;
            }
            //t.BackColor = Color.Black;
            //t.ForeColor = Color.White;
        }

        internal void BindProjectsInNewForm(string projectId, string moduleId, string projectName)
        {
            _projectId = projectId;
            _moduleId = moduleId;
            _projectName = projectName;
            DataSet ds = repository.GetProjects();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt1 = ds.Tables[0].DefaultView.ToTable(true, "ProjectId", "ModuleId", "ModuleName");
                DataRow[] result = dt1.Select("ProjectId = '" + _projectId + "' AND ModuleId <> '"+ string.Empty +"'");
                if (result.Length > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ModuleId", typeof(string));
                    dt.Columns.Add("ModuleName", typeof(string));
                    DataRow dr;

                    for (int i = 0; i < result.Length; i++)
                    {
                        dr = dt.NewRow();
                        dr["ModuleName"] = result[i]["ModuleName"];
                        dr["ModuleId"] = result[i]["ModuleId"];
                        dt.Rows.Add(dr);
                    }
                    PrjBox.DataSource = dt;
                    PrjBox.DisplayMember = "ModuleName";
                    PrjBox.ValueMember = "ModuleId";
                    PrjBox.SelectedValue = _moduleId;
                }
            }
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

}
