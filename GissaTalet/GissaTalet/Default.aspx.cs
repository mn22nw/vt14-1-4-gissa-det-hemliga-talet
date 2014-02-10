using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GissaTalet.Model;

namespace GissaTalet
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (SecretNumber == null)
                SecretNumber = new SecretNumber();

            Image myImg = new Image();
            myImg.ImageUrl = "~/Content/qm.jpg";
            myImg.Visible = true;
            Tal.Controls.Add(myImg);
            TextNr.Focus();
        }

        public SecretNumber SecretNumber
        {
            get
            {
                return Session["SecretNumber"] as SecretNumber;
            }
            set
            {
                Session["SecretNumber"] = value;
            }
        }

        protected void Gissa_Click(object sender, EventArgs e)
        {

            if (IsValid)
            {
                try
                {

                    SecretNumber.MakeGuess(Int32.Parse(TextNr.Text));

                    TextNr.Attributes.Add("onfocus", "this.select();");

                    //textbox.SelectionStart = 0;
                    //textbox.SelectionLength = textbox.Text.Length;


                    /*  if (PrevCount.HasValue)
                          {
                              // ...bestäm skillnaden och...
                              var diffCount = count - PrevCount.Value;

                              // ...fastställ om det är fler, färre eller lika många.
                              if (diffCount > 0)
                              {
                                  DifferenceLiteral.Text = String.Format(DifferenceLiteral.Text, diffCount, " fler");
                              }
                              else if (diffCount < 0)
                              {
                                  DifferenceLiteral.Text = String.Format(DifferenceLiteral.Text, -diffCount, " färre");
                              }
                              else
                              {
                                  DifferenceLiteral.Text = String.Format(DifferenceLiteral.Text, String.Empty, "lika många");
                              }

                              DifferenceLiteral.Visible = true;
                          }

                          // Spara aktuellt antal vokaler.
                          PrevCount = count;*/
                }

                catch (Exception ex)
                {
                    var error = new CustomValidator
                    {
                        IsValid = false,
                        ErrorMessage = ex.Message
                    };
                    Page.Validators.Add(error);
                }
            }
        }
    }
}