<%@ Page Title="Redigera veckomeny" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="EditWeekMenu.aspx.cs" Inherits="AppDate.Pages.ClientPages.EditWeekMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:FormView  ID="EditWeekMenuFormView" runat="server"
        ItemType="AppDate.Model.BLL.WeekMenu"
        DefaultMode="Edit"
        DataKeyNames="ClientId, WeekId"
        RenderOuterTable="false"
        SelectMethod="EditWeekMenuFormView_GetItem"
        UpdateMethod="EditWeekMenuFormView_UpdateItem">
    
     <EditItemTemplate>
            <section id="form" class="addclientsection">
                 <div>
                     <asp:Label ID="HeaderTextLabel" CssClass="textboxheader" runat="server" Text='<%# String.Format("{0}{1}", "Vecka: ", Item.Weeknumber) %>'></asp:Label>
                <div>
                <%--Monday--%>
                <p class="textboxheader">Måndag</p>
                <asp:TextBox ID="MondayTextBox" Text='<%# BindItem.Monday %>' CssClass="textbox" MaxLength="150" runat="server" Columns="60"></asp:TextBox>
                <asp:RequiredFieldValidator ID="MondayRequiredFieldValidator" runat="server" ErrorMessage="Dagens måndag saknas" ControlToValidate="MondayTextBox" CssClass="field-validation-errors">*</asp:RequiredFieldValidator>
                
                 <%--Tuesday--%>
                <p class="textboxheader">Tisdag</p>
                <asp:TextBox ID="TuesdayTextBox" Text='<%# BindItem.Tuesday %>' CssClass="textbox" MaxLength="150" runat="server" Columns="60"></asp:TextBox>
                <asp:RequiredFieldValidator ID="TuesdayRequiredFieldValidator" runat="server" ErrorMessage="Dagens tisdag saknas" ControlToValidate="TuesdayTextBox" CssClass="field-validation-errors">*</asp:RequiredFieldValidator>
        
                 <%--Wednesday--%>
                <p class="textboxheader">Onsdag</p>
                <asp:TextBox ID="WednesdayTextBox" Text='<%# BindItem.Wednesday %>' CssClass="textbox" MaxLength="150" runat="server" Columns="60"></asp:TextBox>
                <asp:RequiredFieldValidator ID="WednesdayRequiredFieldValidator" runat="server" ErrorMessage="Dagens onsdag saknas" ControlToValidate="WednesdayTextBox" CssClass="field-validation-errors">*</asp:RequiredFieldValidator>
        
                 <%--Thursday--%>
                <p class="textboxheader">Torsdag</p>
                <asp:TextBox ID="ThursdayTextBox"  Text='<%# BindItem.Thursday %>' CssClass="textbox" MaxLength="150" runat="server" Columns="60"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ThusdayRequiredFieldValidator" runat="server" ErrorMessage="Dagens torsdag saknas" ControlToValidate="ThursdayTextBox" CssClass="field-validation-errors">*</asp:RequiredFieldValidator>
        
                 <%--Friday--%>
                <p class="textboxheader">Fredag</p>
                <asp:TextBox ID="FridayTextBox" Text='<%# BindItem.Friday %>' CssClass="textbox" MaxLength="150" runat="server" Columns="60"></asp:TextBox>
                <asp:RequiredFieldValidator ID="FridayRequiredFieldValidator" runat="server" ErrorMessage="Dagens fredag saknas" ControlToValidate="FridayTextBox" CssClass="field-validation-errors">*</asp:RequiredFieldValidator>
        
               <%--Submitbutton--%>
                <div>
                    <asp:Button ID="SubmitChangesButton" CommandName="Update" CssClass="submitclientbutton" runat ="server" Text="Spara ändringar"/>
                </div>
            </section>
        </EditItemTemplate>
    </asp:FormView>


</asp:Content>
