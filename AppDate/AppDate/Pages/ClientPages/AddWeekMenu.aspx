<%@ Page Title="Lägg till veckomeny" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AddWeekMenu.aspx.cs" Inherits="AppDate.Pages.ClientPages.AddWeekMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:FormView  ID="AddWeekMenuFormView" runat="server"
    ItemType="AppDate.Model.BLL.WeekMenu"
    DefaultMode="Insert"
    DataKeyNames="ClientId"
    RenderOuterTable="false"
    InsertMethod="AddWeekMenuFormView_InsertItem">
    
        <InsertItemTemplate>
            <section id="form" class="addclientsection">
                <div>
                    <p class="textboxheader">Vecka</p>
                    <asp:DropDownList ID="WeeksDropDownList" runat="server"
                        Itemtype="AppDate.Model.BLL.Week"
                        SelectMethod="WeeksDropDownList_GetData"
                        DataTextField="WeekNumber"
                        DataValueField="WeekId"
                        SelectedValue='<%# BindItem.WeekId %>' />
                </div>
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
                    <asp:Button ID="SubmitWeekMenuButton" CommandName="Insert" CssClass="submitclientbutton" runat ="server" Text="Spara veckomeny"/>
                </div>
            </section>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
