<%@ Page Title="JobCross PLatform" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CrossJob.Web._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="Content/site.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="jumbotron row">
            <div class="col-md-offset-3">
                <h1>Give the JobCross work.</h1>
            </div>
            <div class="col-md-offset-9">
                <h3><em>And let's get it done!</em></h3>
            </div>
        </div>

        <div class="row text-bold">
            <div class="text-center">
                <div class="col-md-4 text-bold">Registered freelancers</div>
                <div class="col-md-4">Registered employers</div>
                <div class="col-md-4">Registered projects</div>
            </div>
            <asp:Repeater ID="Statistics" runat="server">
                <HeaderTemplate>
                    <div class="row text-center">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-md-4"><%# Container.DataItem %></div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <hr />

        <div class="row vertical-divider" style="margin-top: 30px">
            <div class="col-md-6 text-center">
                <h3>Top 10 Freelancers</h3>
                <asp:ListView runat="server" ID="ListViewTop10Freelancers"
                    ItemType="CrossJob.Models.Freelancer"
                    SelectMethod="ListViewTopFreelancers_GetData">
                    <LayoutTemplate>
                        <div class="list-group">
                        </div>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                    </LayoutTemplate>
                    <ItemTemplate>
                        <a class="list-group-item"
                            href='<%#: string.Format("FreelancerDetails.aspx?id={0}", Item.Id) %>'>
                            <%#:Item.UserName  %>
                            <span class="pull-right"><%#: Item.Ratings.Count() > 0 ? string.Format("{0:0.00}",Item.Ratings.Average(r => r.Value)) : "Not rated" %></span>
                        </a>
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <em>No freelancers yet.</em>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
            <div class="col-md-6 text-center">
                <h3>Recent published projects</h3>
                <asp:ListView runat="server" ID="ListViewRecent10Projects"
                    ItemType="CrossJob.Models.Project"
                    SelectMethod="ListViewLatestProjects_GetData">
                    <LayoutTemplate>
                        <div class="list-group">
                        </div>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                    </LayoutTemplate>
                    <ItemTemplate>
                        <a class="list-group-item"
                            href='<%#: string.Format("ProjectDetails.aspx?id={0}", Item.ID) %>'>
                            <b>Title: </b><%#:Item.Title  %>
                            <span class="pull-right"><b>Category: </b><%#: Item.Category.Name %></span>
                        </a>
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <em>No projects yet.</em>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </div>
        <br />
    </div>




</asp:Content>
