<%@ Page Title="Top 10 Freelancers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TopFreelancers.aspx.cs" Inherits="CrossJob.Web.TopFreelancers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <div class="jumbotron text-center">
                <strong><h1><%: Title %></h1></strong>
         </div>
    <asp:ListView runat="server" ID="ListViewTop10Freelancers" ItemType="CrossJob.Models.Freelancer" SelectMethod="ListViewTop10Freelancers_GetData">
        <LayoutTemplate>    
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
        </LayoutTemplate>
            <ItemTemplate>
            <div class="row">
                <h3><strong>Name: <%#: Item.FirstName  %></strong></h3>
                <div>
                    <p>Rating: <%#: Item.AverageRating %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>