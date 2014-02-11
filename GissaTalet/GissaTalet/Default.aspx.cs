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

        protected void Reload_Click(object sender, EventArgs e)
        {

            SecretNumber.Initialize();
 
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
                       Gissningar.Text = string.Join(", ", SecretNumber.PreviousGuesses);
                       LowT.Visible = true;
                       Low.Visible = true;
                   } 

                   if (gissatNr == SecretNumber.Outcome.High)
                   {
                       Gissningar.Text = string.Join(", ", SecretNumber.PreviousGuesses);
                       HighT.Visible = true;   
                       High.Visible = true;
                      
                   }
                   if (gissatNr == SecretNumber.Outcome.PreviousGuess)
                   {
                       Gissningar.Text = string.Join(", ", SecretNumber.PreviousGuesses);
                       PrevT.Visible = true;   
                       Prev.Visible = true;
                      
                   }
 
                   if (gissatNr == SecretNumber.Outcome.Correct)
                   {
                       Gissningar.Enabled = false;
                       Gissa.Enabled = false;
                       Klart.Visible = true;
                       KlartT.Visible = true;
                       KlartT.Text = String.Format("Grattis!! Du klarade det på {0} försök", SecretNumber.Count);
                       GuessAgain.Visible = true;
                       GuessAgain.Focus();
                   }

                   if (gissatNr == SecretNumber.Outcome.NoMoreGuesses)
                   {
                       Gissningar.Enabled = false;
                       Gissa.Enabled = false;
                       NoMore.Visible = true;
                       SlutText.Visible = true;
                       SlutText.Text = String.Format("Du har inga mer gissnigar kvar. Det hemliga talet var {0}", SecretNumber.Number);
                       GuessAgain.Visible = true;
                       GuessAgain.Focus();
                   }
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
//textbox.SelectionStart = 0;
//textbox.SelectionLength = textbox.Text.Length;
/*    Image myImg = new Image();
  myImg.ImageUrl = "~/Content/qm.jpg";
  myImg.Visible = true;
  Gissningar.Controls.Add(myImg);*/
