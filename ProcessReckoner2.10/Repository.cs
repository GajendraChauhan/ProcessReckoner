using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace Reckoner_App
{
    class Repository
    {
        string strFileName = "Project.xml";
        //public static string Author = "";

        //This Method is used to read the xml file
        public DataSet GetProjects()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(strFileName);
            return ds;
        }

        /// <summary>
        /// This method is used to fetch a particular employee details
        /// </summary>
        /// <param name="id">Id of the employee</param>
        /// <returns>Employee object</returns>
        public Project Get(string id)
        {
            try
            {
                if (File.Exists(strFileName))
                {
                    Project objProject = new Project();

                    XPathDocument doc = new XPathDocument(strFileName);
                    XPathNavigator nav = doc.CreateNavigator();
                    XPathNodeIterator iterator;

                    iterator = nav.Select("//row[TicketTypeID='" + id + "']");

                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();

                        objProject.TicketTypeID = nav2.Select("//row").Current.SelectSingleNode("TicketTypeID").InnerXml;
                        objProject.TicketType = nav2.Select("//row").Current.SelectSingleNode("TicketType").InnerXml;
                        objProject.Business = nav2.Select("//row").Current.SelectSingleNode("Business").InnerXml;
                        objProject.Analysis = nav2.Select("//row").Current.SelectSingleNode("Analysis").InnerXml;
                        objProject.Approach = nav2.Select("//row").Current.SelectSingleNode("Approach").InnerXml;
                        objProject.Steps = nav2.Select("//row").Current.SelectSingleNode("Steps").InnerXml;
                        objProject.Review = nav2.Select("//row").Current.SelectSingleNode("Review").InnerXml;
                        objProject.Testing = nav2.Select("//row").Current.SelectSingleNode("Testing").InnerXml;
                        objProject.DocReference = nav2.Select("//row").Current.SelectSingleNode("DocumentReference").InnerXml;
                        objProject.TicketTeference = nav2.Select("//row").Current.SelectSingleNode("Reference").InnerXml;
                    }
                    return objProject;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public bool CheckUser()
        {
            var status = false;
            var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
            if (windowsIdentity != null)
            {
                var pname = windowsIdentity.Name;
                status = true;
            }
            return status;
        }

        public int GetMaxValue(XmlDocument xmlDoc, string nodeNameToSearch)
        {
            int intMaxValue = 0;
            XmlNodeList nodelist = xmlDoc.SelectNodes(nodeNameToSearch);
            foreach (XmlNode node in nodelist)
            {
                if (Convert.ToInt32(node.InnerText) > intMaxValue)
                {
                    intMaxValue = Convert.ToInt32(node.InnerText);
                }
            }
            return (intMaxValue + 1);
        }

        public XmlElement CreateXMLElement(XmlDocument xmlDoc, string name, string value)
        {
            XmlElement xmlElement = xmlDoc.CreateElement(name);
            XmlText xmlText = xmlDoc.CreateTextNode(value);
            xmlElement.AppendChild(xmlText);
            return xmlElement;
        }

        //internal bool CheckUser()
        //{
        //    _connection.Close();
        //    var status = false;
        //    var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
        //    if (windowsIdentity != null)
        //    {
        //        var pname = windowsIdentity.Name;
        //        const string sysname = "select [Author],[SystemName] from [UserNames]";
        //        var nameCommand = new SqlCommand(sysname, _connection);
        //        _connection.Open();
        //        var dir = nameCommand.ExecuteReader();
        //        while (dir.Read())
        //        {
        //            if ((string.Compare(dir["SystemName"].ToString().Replace("\\\\", ""), pname.Replace("\\", ""), StringComparison.OrdinalIgnoreCase) == 0))
        //            {
        //                status = true;
        //                Author = dir["Author"].ToString();
        //            }
        //        }
        //    }
        //    _connection.Close();
        //    return status;
        //}

        //internal DataSet GetModulesByProject(string p)
        //{
        //    _connection.Close();

        //    var cmd =
        //        new SqlCommand(
        //            "select [ModuleId],[ModuleName] from modules where projectid=" + p,
        //            _connection);
        //    _connection.Open();
        //    var sda = new SqlDataAdapter(cmd.CommandText, _connection);
        //    var ds = new DataSet();
        //    sda.Fill(ds, "Projects");
        //    ds.Tables[0].Rows.Add(0, "---Modules---");
        //    ds.Tables[0].DefaultView.Sort = "ModuleId asc";
        //    return ds;
        //}

        //internal DataSet GetTicketsByModule(object moduleId)
        //{
        //    _connection.Close();

        //    var cmd =
        //        new SqlCommand(
        //            "select tt.TicketTypeID as TID,TicketType from TicketTypes tt join ProjectTickets pt on tt.TicketTypeID=pt.TicketTypeID where pt.ModuleId=" +
        //            moduleId, _connection);
        //    _connection.Open();
        //    var sda = new SqlDataAdapter(cmd.CommandText, _connection);
        //    var ticketDs = new DataSet();
        //    sda.Fill(ticketDs, "tickets");
        //    return ticketDs;
        //}

        //internal IDataReader GetProjects()
        //{
        //    _connection.Open();
        //    var cmd = new SqlCommand("SELECT ProjectID,ProjectName FROM Projects", _connection);
        //    var dr = cmd.ExecuteReader();
        //    return dr;
        //}

        //internal IDataReader FetchDetails(int ticketid)
        //{
        //    _connection.Close();

        //    IDataReader dr = null;
        //    if (ticketid != 0)
        //    {
        //        var query =
        //            "SELECT [TicketTypeID],[TicketType],[SubType],[Business],[Analysis]," +
        //            "[Approach],[Steps],[Reference],[Notes],[LastUpdate]," +
        //            "[ArcImplementation],[ProcessAuthor],[Review],[Testing],[DocumentReference]" +
        //            " FROM [TicketTypes]where TicketTypeID=" + ticketid;
        //        _connection.Open();
        //        var cmd = new SqlCommand { CommandText = query, Connection = _connection };
        //        dr = cmd.ExecuteReader();
        //    }
        //    return dr;
        //}

        //internal IDataReader GetStepsByTicket(int ticketId)
        //{
        //    _connection.Close();
        //    var steps = new SqlCommand("select stepname from ProcessSteps where TicketTypeID=" + ticketId, _connection);
        //    _connection.Open();
        //    var stepDr = steps.ExecuteReader();
        //    return stepDr;
        //}
    }
}
