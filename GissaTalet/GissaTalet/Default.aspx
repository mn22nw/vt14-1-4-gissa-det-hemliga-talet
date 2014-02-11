<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GissaTalet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa Talet</title>
    <link href="~/Content/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="page">
        <div id="container">
            <h1>Gissa det hemliga talet </h1>
        <form id="form1" runat="server">
        <div>
             <%-- Felmeddelanden --%>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors"
                   HeaderText="Fel inträffade. Korrigera och försök igen." />    
           
             <!-- Ange tal-->
            <asp:Label ID="Label1" runat="server" Text="Ange ett tal mellan 1 och 100:" onFocus="this.select()"></asp:Label>           
            <asp:TextBox ID="TextNr" runat="server" onFocus="this.select()"  MaxLength="3"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Ett tal måste anges" CssClass="error" 
                    ControlToValidate="TextNr" SetFocusOnError="True" Text="*" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ErrorMessage="Ett tal måste anges" CssClass="error" Text="*" ControlToValidate="TextNr" 
                    Operator="DataTypeCheck" Type="Integer" SetFocusOnError="True" Display="Dynamic">
                </asp:CompareValidator>
             <asp:RangeValidator ID="RangeValidator1" runat="server"  CssClass="error" 
                    ErrorMessage="Talet måste ligga mellan 1-100." Text="*" Type="Integer"
                    MaximumValue="100" MinimumValue="1" ControlToValidate="TextNr" SetFocusOnError="True"></asp:RangeValidator>
             <!-- Knapp-->
            <asp:Button ID="Gissa" runat="server" Text="Skicka gissning" OnClick="Gissa_Click"/>
           
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
             <!-- Gissade tal-->
            <asp:Label ID="Gissningar" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Image ID="High" runat="server" ImageUrl="~/Content/upp.jpg" Visible="false" />
                <asp:Label ID="HighT" runat="server" Text="För högt" Visible="false"></asp:Label>
                <asp:Image ID="Low" runat="server" ImageUrl="~/Content/ned.jpg" Visible="false" />
                <asp:Label ID="LowT" runat="server" Text="För lågt" Visible="false"></asp:Label>
                <asp:Image ID="Prev" runat="server" ImageUrl="~/Content/already.jpg" Visible="false" />
                <asp:Label ID="PrevT" runat="server" Text="För lågt" Visible="false"></asp:Label>
                <asp:Image ID="NoMore" runat="server" ImageUrl="~/Content/nomore.jpg" Visible="false" />
                <asp:Label ID="SlutText" runat="server" Text="Du har inga gissningar kvar. Det hemliga talet var " Visible="false" CssClass="end"></asp:Label>
                 <asp:Image ID="Klart" runat="server" ImageUrl="~/Content/klar.jpg" Visible="false" />
                <asp:Label ID="KlartT" runat="server" Text="" Visible="false" CssClass="end"></asp:Label>
            <asp:Button ID="GuessAgain" runat="server" Text="Slumpa nytt hemligt tal." Visible="false" />

            </asp:PlaceHolder>
        </div>
        </form>
        </div>
    </div>
</body>
</html>
