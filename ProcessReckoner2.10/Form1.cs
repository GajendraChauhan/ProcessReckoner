using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Drawing;

namespace Reckoner_App
{
    public partial class Reckoner : Form
    {
        Repository repository = new Repository();
        public static int Count = 0;

        public Reckoner()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var dname = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            // this.projectsTableAdapter.Fill(this.projects._Projects);
            // TODO: This line of code loads data into the 'projects._Projects' table. You can move, or remove it, as needed.
        }

        public void BindProjects()
        {
            comboBox1.Enabled = false;
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
                        dr["ProjectName"] = result[i]["ProjectId"];
                        dr["ProjectId"] = result[i]["ProjectName"];
                        dt.Rows.Add(dr);
                    }
                    //ProjectsBox.Items.Insert(0, "--Select--");
                    ProjectsBox.DataSource = dt;
                    ProjectsBox.DisplayMember = "ProjectId";
                    ProjectsBox.ValueMember = "ProjectName";
                }
            }
            this.Show();
        }

        private void Bindings()
        {
            //string s = comboBox1.SelectedValue.ToString();
            if (comboBox1.SelectedValue != null)
            {
                DataSet ds = repository.GetProjects();
                var ticketId = comboBox1.SelectedValue;
                int selectedIndex = comboBox1.SelectedIndex;
                DataView dv = new DataView(ds.Tables[0]);
                dv.RowFilter = "TicketTypeID='" + ticketId + "'";

                Btxt.Text = dv[0][6].ToString();
                Atxt.Text = dv[0][7].ToString();
                Aptxt.Text = dv[0][8].ToString();

                Rtxt.Text = dv[0][14].ToString();
                Ttxt.Text = dv[0][15].ToString();
                Rftxt.Text = dv[0][10].ToString();
                Drtxt.Text = dv[0][12].ToString();
                Albl.Text = dv[0][16].ToString();
                Datelbl.Text = dv[0][11].ToString();


                string str = dv[0][9].ToString();
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
        }

        private void ClearallFields()
        {
            dataGridView1.DataSource = null;
            Btxt.Text = @"--";
            Atxt.Text = @"--";
            Aptxt.Text = @"--";
            Rtxt.Text = @"--";
            Ttxt.Text = @"--";
            Drtxt.Text = @"--";
            Rftxt.Text = @"--";
            Albl.Text = @"--";
            Datelbl.Text = @"--";
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Bindings();
        }

        private void ProjectsBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int s = 0;
            comboBox1.Enabled = false;
            DataSet ds = repository.GetProjects();
            var projectId = ProjectsBox.SelectedValue;
            int selectedIndex = ProjectsBox.SelectedIndex;
            DataView dv = new DataView(ds.Tables[0].DefaultView.ToTable(true, "ProjectId", "ModuleId", "ModuleName"));
            dv.RowFilter = "ProjectId = '" + projectId + "' AND ModuleId <> '" + s + "'";
            //DataView dv1 = new DataView(dv.ToTable(true, "ProjectId", "ModuleId", "ModuleName"));
            //dv1.RowFilter = "ProjectId = '" + projectId + "' AND ModuleId <> '" + s + "'";

            listBox1.DataSource = dv;
            listBox1.DisplayMember = "ModuleName";
            listBox1.ValueMember = "ModuleId";
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue != null)
            {
                int s = 0;
                comboBox1.Enabled = true;
                DataSet ds = repository.GetProjects();
                var moduleId = listBox1.SelectedValue;
                int selectedIndex = listBox1.SelectedIndex;
                DataView dv = new DataView(ds.Tables[0].DefaultView.ToTable(true, "ModuleId", "TicketTypeID", "TicketType"));
                dv.RowFilter = "ModuleId ='" + moduleId + "' AND TicketTypeID <> '"+ s +"'";

                comboBox1.DataSource = dv;
                comboBox1.DisplayMember = "TicketType";
                comboBox1.ValueMember = "TicketTypeID";
                Bindings();
            }
        }

        private void Reckoner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Count == 0)
            {
                if (
                    MessageBox.Show(@"This will close down the whole application. Confirm?", @"Close Application",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Count++;
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

        private void label11_Click(object sender, EventArgs e)
        {
            var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
            if (windowsIdentity != null)
                MessageBox.Show(@"Thank You " + windowsIdentity.Name);
        }

        private void AddNewTicket_Click(object sender, EventArgs e)
        {
            var projectId = ProjectsBox.SelectedValue.ToString();
            var projectName = ProjectsBox.Text;
            var mId = listBox1.SelectedIndex;
            var status = repository.CheckUser();
            if (projectId != null && mId >= 0)
            {
                if (status)
                {
                    var moduleId = listBox1.SelectedValue.ToString();
                    this.Hide();
                    var newForm = new NewTicket();
                    newForm.Show();
                    newForm.BindProjectsInNewForm(projectId, moduleId, projectName);
                }
                else
                {
                    MessageBox.Show(@"Sorry! You are Not Authorised");
                }
            }
            else
            {
                MessageBox.Show(@"Please select the Project & Module ");
            }
        }

        private void EditTicket_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                string ticketId = comboBox1.SelectedValue.ToString();
                var dr = repository.Get(ticketId);

                this.Hide();
                var editForm = new Edit();
                editForm.Show();
                editForm.BindingDetailsInEditForm(ticketId, dr);
            }
            else
            {
                MessageBox.Show(@"Please select the Ticket");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newProjectForm = new AddNewPeoject();
            newProjectForm.Show();
            newProjectForm.BindProjects();
        }
    }
}

