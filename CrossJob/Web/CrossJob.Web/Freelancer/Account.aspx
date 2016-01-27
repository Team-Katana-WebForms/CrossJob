<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="CrossJob.Web.Freelancer.Account" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2>Personal Account</h2>
    <div class="row">
        <div class="form-horizontal col-md-12">
            <h4>Change your account settings</h4>
            <hr />
            <div class="form-group col-md-9 text-center">
                <asp:Image ID="Avatar" runat="server" />
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="FileUploadControl" CssClass="col-md-2 control-label">Upload new image</asp:Label>
                <div class="col-md-9">
                    <asp:FileUpload ID="FileUploadControl" runat="server" OnClick="UpdateAccount_Click" />
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Username</asp:Label>
                <div class="col-md-9">
                    <asp:Literal ID="UserName" runat="server" Mode="Encode"></asp:Literal>
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                <div class="col-md-9">
                    <asp:Literal ID="Email" runat="server" Mode="Encode"></asp:Literal>
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="Rating" CssClass="col-md-2 control-label">Rating</asp:Label>
                <div class="col-md-9">
                    <asp:Literal ID="Rating" runat="server" Mode="Encode"></asp:Literal>
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
                    <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="FirstName"
                        ValidationExpression=".{3}.*"
                        CssClass="text-danger" ErrorMessage="Minimum first name length is 3." />
                    <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="FirstName"
                        CssClass="text-danger" ErrorMessage="The first name field is required." />
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                    <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="LastName"
                        ValidationExpression=".{3}.*"
                        CssClass="text-danger" ErrorMessage="Minimum first name length is 3." />
                    <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="LastName"
                        CssClass="text-danger" ErrorMessage="The first name field is required." />
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="Country" CssClass="col-md-2 control-label">Country</asp:Label>
                <div class="col-md-9">
                    <asp:DropDownList runat="server" ID="Country" CssClass="list-group btn btn-default dropdown-toggle" />
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="RatePerHour" CssClass="col-md-2 control-label">Rate per hour</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" ID="RatePerHour" CssClass="form-control" />
                    <asp:RangeValidator Display="Dynamic" runat="server" ControlToValidate="RatePerHour"
                        Type="Currency" MinimumValue="0" MaximumValue="99999"
                        CssClass="text-danger" ErrorMessage="The value should be number.">
                    </asp:RangeValidator>
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="Comments" CssClass="col-md-2 control-label">Comments</asp:Label>
                <div class="col-md-9">
                    <asp:HyperLink class="btn btn-default" ID="Comments" runat="server" NavigateUrl="~/Freelancer/Comments.aspx">See...</asp:HyperLink>
                </div>
            </div>
            <div class="form-group col-md-9">
                <div class="col-md-offset-2 col-md-6">
                    <asp:Button type="Submit" runat="server" OnClick="UpdateAccount_Click" Text="Update" CssClass="btn btn-primary btn-block" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
