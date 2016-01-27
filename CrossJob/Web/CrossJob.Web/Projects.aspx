<%@ Page Title="Projects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="CrossJob.Web.Projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-center">
        <h1><%: Title %></h1>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridViewProjects" runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-hover table-striped"
                GridLines="None"
                SelectMethod="GridViewProjects_GetData"
                ItemType="CrossJob.Models.Project"
                AllowPaging="True"
                PageSize="5"
                AllowSorting="True"
                DataKeyNames="ID"
                EmptyDataText="There are no data records to display.">
                <Columns>
                    <asp:HyperLinkField HeaderText="Title" DataTextField="Title" SortExpression="Title" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/ProjectDetails.aspx?id={0}" />
                    <asp:DynamicField DataField="Description" HeaderText="Description" />
                    <asp:TemplateField HeaderText="Categody" SortExpression="CategoryId">
                        <EditItemTemplate>
                            <asp:Label ID="lbCat1" runat="server" Text='<%# Eval("CategoryId") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbCat2" runat="server" Text='<%# Bind("Category.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employer" SortExpression="EmployerId">
                        <EditItemTemplate>
                            <asp:Label ID="lbEmpl1" runat="server" Text='<%# Eval("EmployerId") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbEmpl2" runat="server" Text='<%# Bind("Employer.CompanyName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:DynamicField DataField="FinishOn" HeaderText="Deadline" />
                    <asp:DynamicField DataField="Price" HeaderText="Price" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
