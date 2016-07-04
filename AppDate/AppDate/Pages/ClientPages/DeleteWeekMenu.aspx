<%@ Page Title="Radera veckomeny" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="DeleteWeekMenu.aspx.cs" Inherits="AppDate.Pages.DeleteWeekMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--Optiondialog to confirm delete weekmenu--%>
<asp:FormView ID="DeleteWeekMenuFormView" runat="server"
        ItemType="AppDate.Model.BLL.WeekMenu"
        DataKeyNames="WeekId, ClientId"
        SelectMethod="DeleteWeekMenuFormView_GetItem"
        RenderOuterTable="false">
      <ItemTemplate>
          <asp:PlaceHolder ID="ConfirmationBoxPlaceHolder" runat="server"></asp:PlaceHolder>
              <section class="confirmationbox">
                  <h1 class="confirmationheader"><%#:String.Format("{0}{1}{2}", "Säkert du vill radera menyn vecka: ", Item.Weeknumber, "?")%></h1>
                  
                  <%--Actionbuttons--%>
                  <div class="buttondiv">
                  <asp:Button ID="ConfirmButton" class="confirmationbutton" OnCommand="DeleteButton_Command" CommandArgument='<%# Item.ClientId+ "," + Item.WeekId%>' runat="server" Text="Radera" />
                  <asp:Button ID="CancelButton" class="confirmationbutton" PostBackUrl='<%# GetRouteUrl("WeekMenuDetails", new {weekid = Item.WeekId, id = Item.ClientId }) %>' runat="server" Text="Avbryt" />
                  </div>
              </section>
      </ItemTemplate> 
  </asp:FormView> 
</asp:Content>
