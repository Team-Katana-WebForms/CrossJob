<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="CrossJob.Web.Freelancer.Account" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
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
                <asp:Label runat="server" CssClass="col-md-2 control-label">Username</asp:Label>
                <div class="col-md-9">
                    <asp:Literal ID="UserName" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Email</asp:Label>
                <div class="col-md-9">
                    <asp:Literal ID="Email" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Rating</asp:Label>
                <div class="col-md-9">
                    <asp:Literal ID="Rating" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="form-group col-md-9">
                <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" placeholder='First Name' />
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
                    <asp:TextBox runat="server" ID="LastName" CssClass="form-control" placeholder='Last Name' />
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
                    <asp:DropDownList runat="server" ID="Country" CssClass="list-group" />
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
                <div class="col-md-offset-6">
                    <asp:Button type="Submit" runat="server" OnClick="UpdateAccount_Click" Text="Update" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
