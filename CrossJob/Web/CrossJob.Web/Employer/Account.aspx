<%@ Page Title="Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="CrossJob.Web.Employer.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <%--   <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>--%>
    </div>

    <div class="row">
        <div class="form-horizontal col-md-12">
            <h4>Change your account settings</h4>
            <hr />
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Username</asp:Label>
                <div class="col-md-9">
                    <asp:Literal ID="UserName" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                <div class="col-md-9">
                    <asp:Literal ID="Email" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="CompanyName" CssClass="col-md-2 control-label">Company Name</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" ID="CompanyName" CssClass="form-control" />
                    <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="CompanyName"
                        ValidationExpression=".{3}.*"
                        CssClass="text-danger" ErrorMessage="Minimum company name length is 3." />
                    <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="CompanyName"
                        CssClass="text-danger" ErrorMessage="The company name field is required." />
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="Country" CssClass="col-md-2 control-label">Country</asp:Label>
                <div class="col-md-9">
                    <asp:DropDownList runat="server" ID="Country" CssClass="list-group" />
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="Address" CssClass="col-md-2 control-label">Address</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox ID="Address" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="Website" CssClass="col-md-2 control-label">Website</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox ID="Website" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="Comments" CssClass="col-md-2 control-label">Comments</asp:Label>
                <div class="col-md-9">
                    <asp:HyperLink class="btn btn-default" ID="Comments" runat="server" NavigateUrl="~/Employer/Comments.aspx">See...</asp:HyperLink>
                </div>
            </div>
            <div class="form-group col-md-9">
                <div class="col-md-offset-6">
                    <asp:Button type="Submit" runat="server" OnClick="UpdateAccount_Click" Text="Update" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
