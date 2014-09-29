	<%@ Page Title="Games" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="GamesList.aspx.cs" Inherits="Infanos.GamesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <asp:ListView ID="gamesList" runat="server" 
                DataKeyNames="GameID" GroupItemCount="4"
                ItemType="Infanos.Models.Games" SelectMethod="GetGames">
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No games were returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                     <a href="<%#: GetRouteUrl("GamesByNameRoute", new {gameName = Item.GameName}) %>">
                                        <image src='/Catalog/Images/Thumbs/<%#:Item.ImagePath%>'
                                        width="100" height="75" border="1" />
                                      </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                     <a href="<%#: GetRouteUrl("GamesByNameRoute", new {gameName = Item.GameName}) %>">
                                         <%#:Item.GameName%>
                                     </a>
                                    <br />
                                    <span>
                                        <b>Price: </b><%#:String.Format("{0:c}", Item.GamePrice)%>
                                    </span>
                                    <br />
                                     <a href="/AddToCart.aspx?gameID=<%#:Item.GameID %>">               
                                        <span class="GameListItem">
                                            <b>Add To Cart<b>
                                        </span>           
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>