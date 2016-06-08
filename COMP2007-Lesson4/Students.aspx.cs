using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements that are required to connnect to EF DB
using COMP2007_Lesson4.Models;
using System.Web.ModelBinding;

namespace COMP2007_Lesson4
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading page for first time, populate the student grid
            if (!IsPostBack)
            {
                // Get the student data
                this.GetStudents();
            }

        }
        /**
         * <summary>
         * This method gets the student from the DB.
         * </summary>
         * 
         * @method GetStudents
         * @return {void}
         */
        protected void GetStudents()
        {
            // connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                // query the students table using EF and LINQ
                var Students = (from allStudents in db.Students
                                select allStudents);

                // bind the result to the GridView
                StudentsGridview.DataSource = Students.ToList();
                StudentsGridview.DataBind();
            }
        }
    }
}