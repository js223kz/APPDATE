
<%@ Page Title="Kundlista" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="AppDate.Pages.ClientPages.WebForm1" %>

<asp:Content ID="ClientListContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <%--Listview that shows list of clients--%>
            <asp:ListView ID="ClientListView" runat="server"
                ItemType="AppDate.Model.BLL.Client"
                SelectMethod="ClientListView_GetData"
                DataKeyNames="ClientId">
                
                <%--LayoutTemplate--%>
                <LayoutTemplate>
                    <table class="clientlist">
                        <tr>
                            <th class="tableheader"><h1>Kundlista</h1>
                            </th>
                        </tr>
                        
                        <%--Placeholder for new rows--%>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                   
                     <%--Datapager controls display of 5 clients per page --%>
                    <section class="listviewdatapager" >
                        <asp:DataPager ID="ListViewDataPager" runat="server" PageSize="5" PagedControlID="ClientListView">
                            <Fields>
                                <asp:NextPreviousPagerField
                                    ButtonType="Button"
                                    ShowFirstPageButton="True"
                                    ShowLastPageButton="True"/>
                            </Fields>
                        </asp:DataPager>
                    </section>
                </LayoutTemplate>

                <%--Items--%>
                <ItemTemplate>
                    <tr class="rows">
                        <td class="datarows">
                            <asp:Label ID="ClientLabel" runat="server" Text='<%#:String.Format("{0}{1}{2}{3}{4}{5}{6}", Item.Name,", ", Item.Address, ", ",Item.Zipcode, " ", Item.City )%>'></asp:Label>
                        </td>
                        <td class="command">
                            <asp:ImageButton PostBackUrl='<%# GetRouteUrl("ClientDetails", new { id = Item.ClientId }) %>' CssClass="editbutton" ImageUrl="~/Content/Pics/write.png" CommandName="Edit" runat="server"  CausesValidation="false"></asp:ImageButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                     <tr class="alternatingitem">
                        <td class="datarows">
                            <asp:Label ID="NameLabel" runat="server" Text='<%#:String.Format("{0}{1}{2}{3}{4}{5}{6}", Item.Name,", ", Item.Address, ", ",Item.Zipcode, " ",Item.City )%>'></asp:Label>
                        </td>
                        <td class="command">
                            <asp:ImageButton PostBackUrl='<%# GetRouteUrl("ClientDetails", new { id = Item.ClientId }) %>' CssClass="editbutton" ImageUrl="~/Content/Pics/write.png" runat="server"  CausesValidation="false"></asp:ImageButton>
                        </td>
                    </tr>
                </AlternatingItemTemplate>

                <%--If there are no clients--%>
                <EmptyDataTemplate>
                    <section class="emptydatatablesection"></section>
                    <h1 class="emptydatatableheader">
                        Kunder saknas.
                    </h1>
                </EmptyDataTemplate>
        </asp:ListView>
</asp:Content>

