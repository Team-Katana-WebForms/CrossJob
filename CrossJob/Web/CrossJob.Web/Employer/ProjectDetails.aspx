<%@ Page Title="Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="CrossJob.Web.Employer.ProjectDetails" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../Content/Styles/site.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="BodyContent2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewProjectDetails" ItemType="CrossJob.Models.Project"
        SelectMethod="FormViewProjectDetails_GetItem" DataKeyNames="ID">
        <ItemTemplate>
            <h1><%: Title %></h1>
            <p>
                <span><strong>Title: </strong></span>
                <%#: Item.Title %>
            </p>
            <div class="row-fluid">
                <p>
                    <span><strong>Description: </strong></span>
                    <%#: Item.Description %>
                </p>
            </div>
            <p>
                <span><strong>Category: </strong></span>
                <%#: Item.Category.Name %>
            </p>
            <p>
                <span><strong>Company Name: </strong></span>
                <%#: Item.Employer.CompanyName %></a>
            </p>
            <p>
                <span><strong>Freelancer employed:</strong> </span>
                <%#: string.Format("{0}", Item.Freelancer != null ? string.Format("{0} {1}", Item.Freelancer.FirstName, Item.Freelancer.LastName) : "No freelancers") %>
            </p>
            <p>
                <span><strong>Start Date:</strong></span>
                <%#: string.Format("{0:MM-dd-yyyy}", Item.StartOn) %>
            </p>
            <p>
                <span><strong>End Date:</strong></span>
                <%#: string.Format("{0:MM-dd-yyyy}", Item.FinishOn) %>
            </p>
            <p>
                <span><strong>Price: </strong></span>
                <%#: Item.Price %>
            </p>
           <%-- <div>
                <asp:LinkButton Text="Edit" runat="server" ID="lbEdit" CommandName="Edit"></asp:LinkButton>
            </div>--%>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
