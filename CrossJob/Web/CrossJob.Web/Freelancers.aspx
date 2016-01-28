<%@ Page Title="Freelancers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Freelancers.aspx.cs" Inherits="CrossJob.Web.Freelancers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-center">
        <strong>
            <h1><%: Title %></h1>
        </strong>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label runat="server" Text="Show freelancers with rating:" SelectMethod="GridViewFreelancers_GetData" />
            <asp:DropDownList runat="server" AutoPostBack="true" ID="DisplayRating">
                <asp:ListItem Text="All" Value="" />
                <asp:ListItem Value="1" Text="> 1" />
                <asp:ListItem Value="2" Text="> 2" />
                <asp:ListItem Value="3" Text="> 3" />
                <asp:ListItem Value="4" Text="> 4" />
                <asp:ListItem Value="5" Text="= 5" />
            </asp:DropDownList>
            <br />
            <asp:GridView ID="GridViewFreelancers" runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-hover table-striped"
                GridLines="None"
                SelectMethod="GridViewFreelancers_GetData"
                ItemType="CrossJob.Models.Freelancer"
                AllowPaging="True"
                PageSize="5"
                AllowSorting="True"
                DataKeyNames="ID"
                EmptyDataText="There are no data records to display.">
                <Columns>
                    <asp:HyperLinkField HeaderText="First name" DataTextField="FirstName" SortExpression="FirstName" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/FreelancerDetails.aspx?id={0}" />
                    <asp:DynamicField DataField="LastName" HeaderText="Last name" />
                    <asp:DynamicField DataField="Country" HeaderText="Country" />
                    <asp:DynamicField DataField="RatePerHour" HeaderText="Rate per hour" />
                    <asp:TemplateField HeaderText="Rating">
                        <ItemTemplate>
                            <asp:Label ID="lbCat2" runat="server" Text='<%# Item.Ratings.Count() > 0 ? string.Format("{0:0.00}",Item.Ratings.Average(r => r.Value)) : "User is not rated yet" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
