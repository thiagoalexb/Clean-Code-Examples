using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;

namespace Project.UserControls
{
    public class PostControlWrong : System.Web.UI.UserControl
    {
        private PostDbContext DBContext;


        protected void Page_Load(object sender, EventArgs e)
        {
            DBContext = new PostDbContext();

            if (Page.IsPostBack)
            {
                PostValidator validator = new PostValidator();
                Post entity = new Post()
                {
                    // Map form fields to entity properties
                    Id = Convert.ToInt32(PostId.Value),
                    Title = PostTitle.Text.Trim(),
                    Body = PostBody.Text.Trim()
                };
                ValidationResult results = validator.Validate(entity);

                if (results.IsValid)
                {
                    // Save to the database and continue to the next page
                    DBContext.Posts.Add(entity);
                    DBContext.SaveChanges();
                }
                else
                {
                    BulletedList summary = (BulletedList)FindControl("ErrorSummary");

                    // Display errors to the user
                    foreach (var failure in results.Errors)
                    {
                        Label errorMessage = FindControl(failure.PropertyName + "Error") as Label;

                        if (errorMessage == null)
                        {
                            summary.Items.Add(new ListItem(failure.ErrorMessage));
                        }
                        else
                        {
                            errorMessage.Text = failure.ErrorMessage;
                        }
                    }
                }
            }
            else
            {
                // Display form
                Post entity = DBContext.Posts.SingleOrDefault(p => p.Id == Convert.ToInt32(Request.QueryString["id"]));
                PostBody.Text = entity.Body;
                PostTitle.Text = entity.Title;

            }
        }

        public Label PostBody { get; set; }

        public Label PostTitle { get; set; }

        public int? PostId { get; set; }
    }
}