
<%@ Page Title="Veckomeny detaljer" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="WeekMenuDetails.aspx.cs" Inherits="AppDate.Pages.ClientPages.WeekMenuDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--Section displayng weekmenudetails--%>
<asp:FormView ID="WeekMenuFormView" runat="server"
        ItemType="AppDate.Model.BLL.WeekMenu"
        SelectMethod="WeekMenuFormView_GetItem"
        RenderOuterTable="false">
        <ItemTemplate>
           <section class="weekmenudetailssection">
               <div><h1 class="tableheader">Veckomeny</h1></div>
                <div>
                    <p class="clientdetailstext"><%#:String.Format("{0}{1}", "Vecka: ", Item.Weeknumber)%></p>
                </div>
                <div class="editor-field">
                    <p class="clientdetailstext"><%#:String.Format("{0}{1}","Måndag: ", Item.Monday)%></p>
                </div>
                <div>
                    <p class="clientdetailstext"><%#: String.Format("{0}{1}", "Tisdag: ", Item.Tuesday)%></p>
                </div>
                <div>
                    <p class="clientdetailstext"><%#:String.Format("{0}{1}", "Onsdag: ", Item.Wednesday)%></p>
                </div>
                <div>
                    <p class="clientdetailstext"><%#:String.Format("{0}{1}", "Torsdag: ", Item.Thursday)%></p>
                </div>
                <div>
                    <p class="clientdetailstext"><%#:String.Format("{0}{1}", "Fredag: ", Item.Friday)%></p>
                </div>
               
               <%--Actionbuttons--%> 
               <div>
                    <asp:Button runat="server" Text="Redigera" PostBackUrl='<%# GetRouteUrl("EditWeekMenu", new { weekid = Item.WeekId, id = Item.ClientId }) %>' />
                    <asp:Button runat="server" Text="Ta bort" PostBackUrl='<%# GetRouteUrl("DeleteWeekMenu", new {weekid = Item.WeekId, id = Item.ClientId }) %>' />
                </div>
            </section>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
