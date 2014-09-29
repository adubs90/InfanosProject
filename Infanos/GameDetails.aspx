<%@ Page Title="Game Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="GameDetails.aspx.cs" Inherits="Infanos.GameDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="gameDetail" runat="server" ItemType="Infanos.Models.Games" SelectMethod ="GetGames" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.GameName %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%#:Item.ImagePath %>" style="border:solid; height:300px" alt="<%#:Item.GameName %>"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <b>Description:</b><br /><%#:Item.Description %>
                        <br />
                        <span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.GamePrice) %></span>
                        <br />
                        <span><b>Product Number:</b>&nbsp;<%#:Item.GameID %></span>
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>