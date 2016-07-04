<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="DeleteClient.aspx.cs" Inherits="AppDate.Pages.ClientPages.DeleteClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--Optiondialog to confirm delete client--%>
 <asp:FormView ID="DeleteClientFormView" runat="server"
        ItemType="AppDate.Model.BLL.Client"
        DataKeyNames="ClientId"
        SelectMethod="CustomerFormView_GetItem"
        RenderOuterTable="false">
      <ItemTemplate>
          <asp:PlaceHolder ID="ConfirmationBoxPlaceHolder" runat="server"></asp:PlaceHolder>
              <section class="confirmationbox">
                  <h1 class="confirmationheader"><%#:String.Format("{0}{1}{2}", "Säkert du vill radera ", Item.Name, "?")%></h1>
                  
                  <%--Actionbuttons--%>
                  <div class="buttondiv">
                  <asp:Button ID="ConfirmButton" class="confirmationbutton" OnCommand="DeleteButton_Command" CommandArgument='<%$ RouteValue:id %>' runat="server" Text="Radera" />
                  <asp:Button ID="CancelButton" class="confirmationbutton" PostBackUrl='<%# GetRouteUrl("ClientDetails", new { id = Item.ClientId }) %>' runat="server" Text="Avbryt" />
                  </div>
              </section>
      </ItemTemplate> 
  </asp:FormView> 
</asp:Content>
