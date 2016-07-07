using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLHandler;

namespace MasterDemo
{

    public partial class AddContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"];
            string cid = Request["cid"];

            if (IsPostBack)
            {
                this.Validate();

                if (action != null)
                {
                    if (this.IsValid)
                    {
                        if (cid != "" && action.Equals("edit"))
                        {
                            SQL.UpdateContact(cid, firstname.Text, lastname.Text);
                        }
                        else if (action.Equals("add"))
                        {
                            SQL.AddNewContact(firstname.Text, lastname.Text);
                        }
                    }
                }
            }

            if (action != null)
            {
                if (action.Equals("edit"))
                {
                    Contact myContact = SQL.GetContact(cid);

                    if (myContact != null)
                    {
                        firstname.Text = myContact.FirstName;
                        lastname.Text = myContact.LastName;
                        Button1.Text = "Edit";
                    }
                }

                if (action.Equals("add"))
                {
                    Button1.Text = "Add";
                }
            }
        }
    }
}