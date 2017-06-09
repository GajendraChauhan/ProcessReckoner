using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Reckoner_App
{
    public partial class AddNewPeoject : Form
    {
        string strFileName = "Project.xml";
        public static int Count = 0;
        Repository repository = new Repository();

        public AddNewPeoject()
        {
            InitializeComponent();
        }

        private void NewBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var home = new Reckoner();
            home.BindProjects();
        }
        
        //    DataSet ds = repository.GetProjects();
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //    }

        private void AddNewProject_Click(object sender, EventArgs e)
        {
            if (ProjectTxt.Text.Trim().Count() != 0)
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

                    // Creating row node
                    XmlElement subNode = xmlDoc.CreateElement("row");

                    // Getting the maximum Id based on the XML data already stored
                    string projectId = repository.GetMaxValue(xmlDoc, "Datas" + "/" + "row" + "/" + "ProjectId").ToString();

                    // Adding Id column. Auto generated column
                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "ProjectId", projectId));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "ProjectName", ProjectTxt.Text));
                    xmlDoc.DocumentElement.AppendChild(subNode);
                
                // Saving the file after adding the new employee node
                    xmlDoc.Save(strFileName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //MessageBox.Show(@"New Project Created Successfully");
                //this.Hide();
                //var home = new Reckoner();
                //home.BindProjects();
                ProjectTxt.Text = string.Empty;
                ProjectTxt.Focus();
                BindProjects();
            }
            else
            {
                MessageBox.Show(@"Please Fill the Project Name");
            }
        }

        internal void BindProjects()
        {
            DataSet ds = repository.GetProjects();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt1 = ds.Tables[0].DefaultView.ToTable(true, "ProjectId", "ProjectName");
                DataRow[] result = dt1.Select("ProjectId >= 0");
                if (result.Length > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ProjectId", typeof(string));
                    dt.Columns.Add("ProjectName", typeof(string));
                    DataRow dr;

                    for (int i = 0; i < result.Length; i++)
                    {
                        dr = dt.NewRow();
                        dr["ProjectId"] = result[i]["ProjectId"];
                        dr["ProjectName"] = result[i]["ProjectName"];
                        dt.Rows.Add(dr);
                    }
                    //ProjectsBox.Items.Insert(0, "--Select--");
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "ProjectName";
                    comboBox1.ValueMember = "ProjectId";
                }
            }
            this.Show();
        }

        private void AddModule_Click(object sender, EventArgs e)
        {
            var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();

            if (comboBox1.SelectedValue != null && moduleTxt.Text.Trim().Count() != 0)
            {
                try
                {
                    // Retrieve Project Id and Project Name
                    DataSet ds = repository.GetProjects();
                    var projectId = comboBox1.SelectedValue.ToString();
                    DataView dv = new DataView(ds.Tables[0].DefaultView.ToTable(true, "ProjectId", "ProjectName"));
                    dv.RowFilter = "ProjectId='" + projectId + "'";
                    var projectName = dv[0][1].ToString();

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

                    // Creating row node
                    XmlElement subNode = xmlDoc.CreateElement("row");

                    // Getting the maximum Id based on the XML data already stored
                    string moduleId = repository.GetMaxValue(xmlDoc, "Datas" + "/" + "row" + "/" + "ModuleId").ToString();
                    //string ticketTypeID = repository.GetMaxValue(xmlDoc, "Datas" + "/" + "row" + "/" + "TicketTypeID").ToString();
                    int ttId = 0;
                    // Adding Id column. Auto generated column
                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "ProjectId", projectId));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "ProjectName", projectName));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "ModuleId", moduleId));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "ModuleName", moduleTxt.Text));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "TicketTypeID", ttId.ToString()));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "TicketType", "--- Select Ticket Type ---"));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Business", ""));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Analysis", ""));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Approach", ""));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Steps", ""));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Reference", ""));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "LastUpdate", DateTime.Now.ToString("dd/MM/yyyy")));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "DocumentReference", ""));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "ProcessAuthor", Environment.UserName));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Review", ""));
                    xmlDoc.DocumentElement.AppendChild(subNode);

                    subNode.AppendChild(repository.CreateXMLElement(xmlDoc, "Testing", ""));
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
                MessageBox.Show(@"New Module Created Successfully");
                moduleTxt.Text = string.Empty;
                comboBox1.Focus();
            }
            else
            {
                MessageBox.Show(@"Please Fill Module Name");
            }
        }

        private void AddNewPeoject_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

    }
}
