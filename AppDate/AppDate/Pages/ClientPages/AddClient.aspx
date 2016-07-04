<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="AppDate.Pages.ClientPages.AddClient" %>
<asp:Content ID="ClientListContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:FormView  ID="AddClientFormView" runat="server"
    ItemType="AppDate.Model.BLL.Client"
    DefaultMode="Insert"
    RenderOuterTable="false"
    InsertMethod="ClientFormView_InsertItem">
    
        <InsertItemTemplate>
            <section id="form" class="addclientsection">
                <%--Name--%>
                <p class="textboxheader">Namn</p>
                <asp:TextBox ID="NameTextBox" Text='<%# BindItem.Name %>' CssClass="textbox" MaxLength="50" runat="server" Columns="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" ErrorMessage="Namn saknas" ControlToValidate="NameTextBox" CssClass="field-validation-errors">*</asp:RequiredFieldValidator>
        
                <%--Address--%>
                <p class="textboxheader">Postadress</p>
                <asp:TextBox ID="AddressTextBox" Text='<%# BindItem.Address %>' CssClass="textbox" MaxLength="30" runat ="server" Columns="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="AddressRequiredFieldValidator" runat="server" ErrorMessage="Postadress saknas." Display="Dynamic" ControlToValidate="AddressTextBox" Text="*" CssClass="field-validation-errors">*</asp:RequiredFieldValidator>
        
                <%--Zipcode--%>
                <p class="textboxheader">Postnummer</p>
                <asp:TextBox ID="ZipcodeTextBox" Text='<%# BindItem.Zipcode %>' CssClass="textbox" MaxLength="5" MinLength="5" runat="server" Columns="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ZipcodeRequiredFieldValidator" runat="server" ErrorMessage="Postnummer saknas." Display="Dynamic" Text="*" ControlToValidate="ZipcodeTextBox" CssClass="field-validation-errors"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="ZipcodeCompareValidator" runat="server" ErrorMessage="Postnummer får bara innehålla siffror." Type="Integer" Display="Dynamic" Text="*" ControlToValidate="ZipcodeTextBox" Operator="DataTypeCheck" CssClass="field-validation-errors"></asp:CompareValidator>
                <asp:RegularExpressionValidator ID="ZipcodeRegularExpressionValidator" ValidationExpression=".{5}.*" runat="server" ControlToValidate="ZipcodeTextBox" ErrorMessage="Postnummer måste innehåla exakt 5 siffror
                    ." Display="Dynamic" Text="*" CssClass="field-validation-errors"></asp:RegularExpressionValidator>

                <%--City--%>
                <p class="textboxheader">Stad</p>
                <asp:TextBox ID="CityTextBox" Text='<%# BindItem.City %>' CssClass="textbox" MaxLength="25" runat="server" Columns="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CityRequiredFieldValidator" runat="server" ErrorMessage="Stad saknas" Display="Dynamic" Text="*" ControlToValidate="CityTextBox" CssClass="field-validation-errors"></asp:RequiredFieldValidator>
        
                <%--Username--%>
                <p class="textboxheader">Användarnamn</p>
                <asp:TextBox ID="UserNameTextBox" Text='<%# BindItem.UserName %>' CssClass="textbox" MaxLength="15" runat="server" Columns="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequiredFieldValidator" runat="server" ErrorMessage="Användarnamn saknas." Display="Dynamic" Text="*" ControlToValidate="UserNameTextBox" CssClass="field-validation-errors"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="UserNameRegularExpressionValidator" ValidationExpression=".{6}.*" runat="server" ControlToValidate="UserNameTextBox" ErrorMessage="Användarnamnet måste bestå av minst 6 och maximalt 15 tecken." Display="Dynamic" Text="*" CssClass="field-validation-errors"></asp:RegularExpressionValidator>
        
                <%--Password--%>
                <p class="textboxheader">Lösenord</p>
                <asp:TextBox ID="PasswordTextBox" Text='<%# BindItem.PassWord %>' CssClass="textbox" MaxLength="10" runat="server" Columns="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Lösenord saknas." Display="Dynamic" Text="*" ControlToValidate="PasswordTextBox" CssClass="field-validation-errors"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="PasswordRegularExpressionValidator" ValidationExpression=".{6}.*" runat="server" ErrorMessage="Lösenordet måste bestå av minst 6 och maximalt 10 tecken." Display="Dynamic" Text="*" ControlToValidate="PasswordTextBox" CssClass="field-validation-errors"></asp:RegularExpressionValidator>
        
                <%--Contact person--%>
                <p class="textboxheader">Kontaktperson</p>
                <asp:TextBox ID="ContactPersonTextBox" Text='<%# BindItem.ContactPerson %>' CssClass="textbox" MaxLength="40" runat="server" Columns="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ContactPersonRequiredFieldValidator" runat="server" ErrorMessage="Kontaktperson saknas." Display="Dynamic" Text="*" ControlToValidate="ContactPersonTextBox" CssClass="field-validation-errors"></asp:RequiredFieldValidator>
        
                <%--Phone--%>
                <p class="textboxheader">Telefonnummer</p>
                <asp:TextBox ID="PhoneTextBox" Text='<%# BindItem.Phone %>' CssClass="textbox" MaxLength="11" runat="server" Columns="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PhoneTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Telefonnummer saknas." Display="Dynamic" Text="*" ControlToValidate="PhoneTextBox" CssClass="field-validation-errors"></asp:RequiredFieldValidator>
        
                <%--Email--%>
                <p class="textboxheader">E-post</p>
                <asp:TextBox ID="EmailTextBox" Text='<%# BindItem.EmailAddress %>' CssClass="textbox" MaxLength="50" runat="server" Columns="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="E-post saknas" Display="Dynamic" Text="*" ControlToValidate="EmailTextBox" CssClass="field-validation-errors"></asp:RequiredFieldValidator>
        
                <%--Vat--%>
                <p class="textboxheader">Organisationsnummer</p>
                <asp:TextBox ID="VatTextBox" Text='<%# BindItem.Vatnumber %>' CssClass="textbox" MaxLength="11" runat="server" Columns="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="VatTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Organisationsnummer saknas." Display="Dynamic" Text="*" ControlToValidate="VatTextBox" CssClass="field-validation-errors"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="VatTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Organisationsnummer är ogiltigt." Display="Dynamic" Text="*" ControlToValidate="VatTextBox" ValidationExpression='^(\d{1})(\d{5})\-(\d{4})$' CssClass="field-validation-errors"></asp:RegularExpressionValidator>
        
                <%--Submitbutton--%>
                <div>
                    <asp:Button ID="SubmitClientButton" CommandName="Insert" CssClass="submitclientbutton" runat ="server" Text="Spara kund"/>
                </div>
            </section>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
