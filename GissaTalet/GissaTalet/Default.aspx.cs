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

                    PlaceHolder1.Visible = true;
                    Gissningar.Visible = true;
                   var gissatNr = SecretNumber.MakeGuess(Int32.Parse(TextNr.Text));
                   TextNr.Attributes.Add("onfocus", "this.select();");
                   

                   if (gissatNr == SecretNumber.Outcome.Low) 
                   
                   {
                       Gissningar.Text += String.Format("låågt {0}", SecretNumber.LastOutcome);
                      
                   /*    Image myImg = new Image();
                       myImg.ImageUrl = "~/Content/qm.jpg";
                       myImg.Visible = true;
                       Gissningar.Controls.Add(myImg);*/
                   }

                   if (gissatNr == SecretNumber.Outcome.High)
                   {
                       Gissningar.Text += String.Format("Högt ju vah + {0}", TextNr.Text);
                      // High.Visible = true;
                   }

                   if (gissatNr == SecretNumber.Outcome.Correct)
                   {
                       Gissningar.Text += String.Format("Grattis!! Du klarade det på {0} försök", SecretNumber.Count);

                   }

                   if (gissatNr == SecretNumber.Outcome.NoMoreGuesses)
                   {
                       SlutText.Visible = true;
                       SlutText.Text += String.Format("Du har inga mer gissnigar kvar. Det hemliga talet var {0}", SecretNumber.Number);

                   }


 
                    //textbox.SelectionStart = 0;
                    //textbox.SelectionLength = textbox.Text.Length;

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