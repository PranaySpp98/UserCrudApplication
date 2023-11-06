using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserDAL;
using UserBAL;
using System.Data;
namespace WebApplication14
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvDisplay.Visible = false;
                txtSkills.Attributes.Add("readonly", "readonly");
                txtdtp.Attributes.Add("readonly", "readonly");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text == "Submit")
                {
                    InsertData();
                }
                else if (btnSubmit.Text == "Update")
                {
                    int Id = int.Parse(gvDisplay.Rows[gvDisplay.SelectedIndex].Cells[0].Text);
                    UpdateData(Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateData(int Id)
        {
            UserSchema.Class1 objSchema = new UserSchema.Class1();
            objSchema.Name = txtName.Text;
            objSchema.Designation = txtDesignation.Text;
            objSchema.Skills = txtSkills.Text;
            objSchema.DOB = DateTime.Parse(this.txtdtp.Text);
            UserBAL.Class1 objBAL = new UserBAL.Class1();
            int result = objBAL.Update(objSchema, Id);
            if (result > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Updated Successfully')", true);
            }
            btnSubmit.Text = "Submit";
            BindGrid();
            Clear();
        }
        public void InsertData()
        {
            UserSchema.Class1 objSchema = new UserSchema.Class1();
            objSchema.Name = txtName.Text;
            objSchema.Designation = txtDesignation.Text;
            objSchema.Skills = txtSkills.Text;
            //DateTime dt = DateTime.Parse(Request.Form["txtdtp"]);
            //objSchema.DOB = dt;
            objSchema.DOB = Convert.ToDateTime(txtdtp.Text);
            UserBAL.Class1 objBAL = new UserBAL.Class1();
            int result = objBAL.Insert(objSchema);
            if (result > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Saved Successfully')", true);
            }
            BindGrid();
            Clear();
        }
        private void Clear()
        {
            txtName.Text = "";
            txtDesignation.Text = "";
            txtSkills.Text = "";
            txtdtp.Text = "";
        }
        private void BindGrid()
        {
            try
            {
                UserBAL.Class1 objBal = new UserBAL.Class1();
                gvDisplay.Columns[0].Visible = true;
                gvDisplay.DataSource = objBal.BindGrid();
                gvDisplay.DataBind();
                gvDisplay.Columns[0].Visible = false;
                gvDisplay.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gvDisplay_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                UserBAL.Class1 objBAL = new UserBAL.Class1();
                int Id = int.Parse(gvDisplay.Rows[e.NewSelectedIndex].Cells[0].Text);
                dt = new DataTable();
                dt = objBAL.GetById(Id);
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
                    txtSkills.Text = dt.Rows[0]["Skills"].ToString();
                    txtdtp.Text = dt.Rows[0]["DOB" +
                        ""].ToString();
                    btnSubmit.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gvDisplay_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                int Id = int.Parse(e.CommandArgument.ToString());
                DeleteRecord(Id);
            }
        }
        private void DeleteRecord(int Id)
        {
            try
            {
                UserBAL.Class1 objBAL = new UserBAL.Class1();
                int Result = objBAL.Delete(Id);
                if (Result > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Deleted Successfully')", true);
                }
                BindGrid();
                Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gvDisplay_RowDeleting(object sender, GridViewDeleteEventArgs e) { }
        protected void gvDisplay_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDisplay.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void linkpickdate_Click(object sender, EventArgs e)
        {
            datepicker.Visible = true;
        }

        protected void datepicker_SelectionChanged(object sender, EventArgs e)
        {
            txtdtp.Text = datepicker.SelectedDate.ToShortDateString();
            //txtdtp.Text = datepicker.SelectedDate.ToString("dd-MM-yyyy HH:mm:ss "); //{04-11-2023 hh}
            datepicker.Visible = false;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtSkills.Text = DropDownList1.SelectedValue.ToString();
        }

    }
}