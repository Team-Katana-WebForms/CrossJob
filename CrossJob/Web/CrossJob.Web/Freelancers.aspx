<%@ Page Title="Freelancers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Freelancers.aspx.cs" Inherits="CrossJob.Web.Freelancers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
          <div class="jumbotron text-center">
            <strong><h1><%: Title %></h1></strong>
         </div>
        <asp:Label runat="server" Text="Show freelancers with rating:"  SelectMethod="GridViewFreelancers_GetData"/>
        <asp:DropDownList runat="server" AutoPostBack="true" ID="DisplayRating">
            <asp:ListItem Text="All" Value ="" />
            <asp:ListItem Value ="1" Text="> 1" />
            <asp:ListItem Value ="2" Text="> 2" />
            <asp:ListItem Value ="3" Text="> 3" />
            <asp:ListItem Value ="4" Text ="> 4" />
            <asp:ListItem Value ="5" Text="= 5" />
        </asp:DropDownList>
        </asp:Label>
        <div><%:DisplayRating.SelectedValue%></div>
        <br />
        <asp:GridView ID="GridViewFreelancers" runat="server" 
                AutoGenerateColumns="False" 
                CssClass="table table-hover table-striped" 
                GridLines="None"
                SelectMethod="GridViewFreelancers_GetData"
                ItemType="CrossJob.Models.Freelancer"
                AllowPaging="True" 
                PageSize="10" 
                AllowSorting="True"
                DataKeyNames="ID">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="First name" />
                    <asp:DynamicField DataField="LastName" HeaderText="Last name" />
                    <asp:DynamicField DataField="RatePerHour" HeaderText="Rate per hour" />
                    <asp:BoundField DataField="AverageRating" HeaderText="Average rating" />
                </Columns>
            </asp:GridView>
</asp:Content>
