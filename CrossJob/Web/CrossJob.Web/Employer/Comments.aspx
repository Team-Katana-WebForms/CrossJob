<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="CrossJob.Web.Employer.Comments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListComments" runat="server" ItemType="CrossJob.Models.Comment">
        <LayoutTemplate>
            <h2>Comments</h2>
            <h4>by me</h4>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>

        <EmptyDataTemplate>
            <h3>No comments</h3>
        </EmptyDataTemplate>

        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>

        <ItemTemplate>
            <div class="jumbotron">
                <div class="row">
                    <div class="col-md-3">
                        <div>for User: <strong><%# Item.Freelancer.UserName %></strong></div>
                    </div>
                    <div class="col-md-6 col-md-offset-1">
                        <div><%# Item.Content %></div>
                    </div>
                    <div class="col-md-2"><%# Item.CreatedOn %></div>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <asp:DataPager ID="DataPagerCustomers" runat="server"
        PagedControlID="ListComments" PageSize="3"
        QueryStringField="page">
        <Fields>
            <asp:NextPreviousPagerField ShowFirstPageButton="false"
                ShowNextPageButton="false" ShowPreviousPageButton="true" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowLastPageButton="false"
                ShowNextPageButton="true" ShowPreviousPageButton="false" />
        </Fields>
    </asp:DataPager>
</asp:Content>
