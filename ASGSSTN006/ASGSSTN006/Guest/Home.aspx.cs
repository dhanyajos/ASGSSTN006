using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ASGSSTN006
{
    public partial class Home : System.Web.UI.Page
    {
        BAL.DesignationBAL objdptbl = new BAL.DesignationBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dept_bind();
                GridView1.DataSource = objdptbl.viewDesignation();
                GridView1.DataBind();

            }
        }

        public void dept_bind()
        {
            DataTable prod = objdptbl.DesignationValues();
            ddldept.DataSource = objdptbl.DesignationValues();
            ddldept.DataTextField = "dept_name";
            ddldept.DataValueField = "dept_id";
            ddldept.DataBind();
            ddldept.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            objdptbl.desig = TextBox1.Text;
            objdptbl.deptid = Convert.ToInt32(ddldept.SelectedIndex);

            int i = objdptbl.insertDesignation();
            TextBox1.Text = "";
            ddldept.SelectedIndex = 0;
            GridView1.DataSource = objdptbl.viewDesignation();
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

            objdptbl.desigid = id;

            int i = objdptbl.deleteDesignation();

            GridView1.DataSource = objdptbl.viewDesignation();
            GridView1.DataBind();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = objdptbl.viewDesignation();
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            TextBox txt = new TextBox();
            txt = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            objdptbl.desigid = id;
            objdptbl.desig = txt.Text;
            int i = objdptbl.updateDesignation();
            GridView1.EditIndex = -1;
            GridView1.DataSource = objdptbl.viewDesignation();
            GridView1.DataBind();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = objdptbl.viewDesignation();
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HtmlInputCheckBox chk;
            foreach (GridViewRow dr in GridView1.Rows)
            {
                chk = (HtmlInputCheckBox)dr.FindControl("ch");
                if (chk.Checked)
                {
                    objdptbl.chk = chk.Value;
                    objdptbl.DeleteAll();
                }
            }
            GridView1.DataSource = objdptbl.viewDesignation();
            GridView1.DataBind();
        }
    }
}