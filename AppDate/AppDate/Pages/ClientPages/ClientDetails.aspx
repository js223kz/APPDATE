<%@ Page Title="Kunddetaljer" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ClientDetails.aspx.cs" Inherits="AppDate.Pages.ClientPages.ClientDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
    <%--Section displaying all client information--%>
    <asp:FormView ID="CustomerFormView" runat="server"
        ItemType="AppDate.Model.BLL.Client"
        SelectMethod="CustomerFormView_GetItem"
        DeleteMethod="CustomerFormView_DeleteItem"
        RenderOuterTable="false">
        <ItemTemplate>
            <section class="clientdetailssection">
               <div><h1 class="tableheader">Kund</h1></div>
                <div>
                    <p class="clientdetailstext"><%#:String.Format("{0,-27}{1}", "Namn: ", Item.Name)%></p>
                </div>
                <div class="editor-field">
                    <p class="clientdetailstext"><%#:String.Format("{0}{1}{2}{3}{4}{5}","Adress: ", Item.Address,", ", Item.Zipcode, ", ", Item.City)%></p>
                </div>
                <div>
                    <p class="clientdetailstext"><%#: String.Format("{0}{1}", "Användarnamn: ", Item.UserName)%></p>
                </div>
                <div>
                    <p class="clientdetailstext"><%#:String.Format("{0}{1}", "Lösenord: ", Item.PassWord)%></p>
                </div>
                <div>
                    <p class="clientdetailstext"><%#:String.Format("{0}{1}", "Kontaktperson: ", Item.ContactPerson)%></p>
                </div>
                <div>
                    <p class="clientdetailstext"><%#:String.Format("{0}{1}", "Telefon: ", Item.Phone)%></p>
                </div>
                <div>
                    <p class="clientdetailstext"><%#:String.Format("{0}{1}", "E-post: ", Item.EmailAddress)%></p>
                </div>
                <div>
                    <p class="clientdetailstext"><%#:String.Format("{0}{1}", "Organisationsnummer: ", Item.Vatnumber)%></p>
                </div>
                
                 <%--Edit buttons--%>
                <div>
                    <asp:Button runat="server" Text="Redigera" PostBackUrl='<%# GetRouteUrl("EditClient", new { id = Item.ClientId }) %>' />
                    <asp:Button runat="server" Text="Ta bort" PostBackUrl='<%# GetRouteUrl("DeleteClient", new { id = Item.ClientId }) %>' />
                    <asp:Button runat="server" Text="Lägg till veckomeny" PostBackUrl='<%# GetRouteUrl("AddWeekMenu", new { id = Item.ClientId }) %>' />
                </div>
            </section>
        </ItemTemplate>
    </asp:FormView>
    
    <%--Listview that shows list of weekmenues--%>
            <asp:ListView ID="WeekMenuListView" runat="server"
                ItemType="AppDate.Model.BLL.WeekMenu"
                SelectMethod="WeekMenuListView_GetData"
                DataKeyNames="ClientId">
                
                <%--LayoutTemplate--%>
                <LayoutTemplate>
                    <table class="clientlist">
                        <tr>
                            <th class="tableheader"><h1>Veckomenyer</h1>
                            </th>
                        </tr>
                        
                        <%--Placeholder for new rows--%>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                   
                     <%--Datapager controls display of 1 week per page --%>
                    <section class="weekmenudatapager" >
                        <asp:DataPager ID="WeekMenuListViewDataPager" runat="server" PageSize="1" PagedControlID="WeekMenuListView">
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
                    <section class="weekmenusection">

                         <%--Headerrow--%>
                        <tr class="weekmenuheader">
                            <th class="menuheaderrows">
                                <asp:Label ID="WeekLabel" runat="server" Text='<%# String.Format("{0}{1}", "Vecka: ", Item.Weeknumber)%>'></asp:Label>
                            </th>
                            <th class="menuheaderrows">
                                <asp:Label ID="DateLabel" runat="server" Text='<%# String.Format("{0:yyyy MM dd}{1}{2:yyyy MM dd}", Item.Startdate, " - ", Item.Enddate)%>'></asp:Label>
                            </th>

                            <%--Eddit weekmenu button--%>
                            <th class="command">
                                <asp:ImageButton PostBackUrl='<%# GetRouteUrl("WeekMenuDetails", new {weekid = Item.WeekId, id = Item.ClientId}) %>' CssClass="editbutton" ImageUrl="~/Content/Pics/write.png" CommandName="Edit" runat="server"  CausesValidation="false"></asp:ImageButton>
                            </th>
                        </tr>
                        
                        <%--Childrows--%>
                        <tr>
                            <td class="datarows" colspan="3">
                                <asp:Label ID="MondayLabel" runat="server" Text='<%# String.Format("{0}{1}", "Måndag: ", Item.Monday) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="datarows" colspan="3">
                                <asp:Label ID="TuesdayLabel" runat="server" Text='<%# String.Format("{0}{1}", "Tisdag: ", Item.Tuesday) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="datarows" colspan="3">
                                <asp:Label ID="WednesdayLabel" runat="server" Text='<%# String.Format("{0}{1}", "Onsdag: ", Item.Wednesday) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="datarows" colspan="3">
                                <asp:Label ID="ThursdayLabel" runat="server" Text='<%# String.Format("{0}{1}", "Torsdag: ", Item.Thursday) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="datarows" colspan="3">
                                <asp:Label ID="FridayLabel" runat="server" Text='<%# String.Format("{0}{1}", "Fredag: ", Item.Friday) %>'></asp:Label>
                            </td>
                        </tr>
                    </section>
                </ItemTemplate>

                <%--If there are no week menues--%>
                <EmptyDataTemplate>
                    <section class="emptydatatablesection"></section>
                    <h1 class="emptydatatableheader">
                        Veckomenyer saknas.
                    </h1>
                </EmptyDataTemplate>
        </asp:ListView>
</asp:Content>
