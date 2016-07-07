using SQLHandler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterDemo
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"];
            string id = Request["cid"];

            if (action != null)
            {
                if (action.Equals("delete"))
                {
                    SQL.RemoveContact(id);
                }
            }

            LoadContacts();
        }
        public void LoadContacts()
        {
            List<Contact> contactList = SQL.LoadContacts();

            if (!IsPostBack)
            {
                string html = "";

                foreach (Contact contact in contactList)
                {
                    html += "<tr>";
                    html += $"<td>{contact.ID}</td>";
                    html += $"<td>{contact.FirstName}</td>";
                    html += $"<td>{contact.LastName}<td>";
                    html += $"<td><a href=\"AddContact.aspx?action=edit&cid={contact.ID}\"><span class=\"glyphicon glyphicon-pencil\"></span></a></td>";
                    html += $"<td><a href =\"Index.aspx?action=delete&cid={contact.ID}\"><span class=\"glyphicon glyphicon-trash\"></span></a></td>";       
                    html += "</tr>";
                }
                myLiteral.Text = html;
            }
        }
    }
}