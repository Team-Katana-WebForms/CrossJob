<%@ Page Title="Details about freelancer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FreelancerDetails.aspx.cs" Inherits="CrossJob.Web.FreelancerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server" ViewStateMode="Disabled" ID="loginFreelancer">
        <LoggedInTemplate>
            <div class="jumbotron text-center">
                <h1><%: Title %></h1>
            </div>
            <div class="row text-center">
                <asp:ListView runat="server" ID="lvFreelancerDetails" ItemType="CrossJob.Models.Freelancer"
                    SelectMethod="ListViewFreelancerDetails_GetData" DataKeyNames="ID">
                    <ItemTemplate>
                        <div class="row-fluid">
                            <p>
                                <asp:Image ImageUrl='<%#: Item.Avatar %>' Width="250px" runat="server" />
                            </p>
                            <p>
                                <span><strong>Username: </strong></span>
                                <%#: Item.UserName %>
                            </p>
                            <p>
                                <span><strong>Name: </strong></span>
                                <%#: Item.FirstName %> <%#: Item.LastName %>
                            </p>
                            <p>
                                <span><strong>Rate per hour: </strong></span>
                                <%#: Item.RatePerHour %>
                            </p>
                            <p>
                                <span><strong>Average rating: </strong></span>
                                <%#: Item.Ratings.Count() > 0 ? string.Format("{0:0.00}",Item.Ratings.Average(r => r.Value)) : "User is not rated yet" %>
                            </p>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>

            <asp:Label ID="lbRate" runat="server" Visible="false"></asp:Label>

            <div class="col-md-offset-5">
                <asp:TextBox ID="tbRate" runat="server" TextMode="Number" CssClass="form-control box-number" ValidationGroup="Rating"></asp:TextBox>
                <asp:RangeValidator ID="rvRating" runat="server" Display="Dynamic" ControlToValidate="tbRate"
                    MinimumValue="0" MaximumValue="5" ErrorMessage="Rating must be between 1 and 5 stars" ValidationGroup="Rating"></asp:RangeValidator>
                <asp:ImageButton ID="btnRate" runat="server" OnClick="btnRate_Click" ImageUrl="~/Imgs/rating.jpg" CssClass="image-container" ValidationGroup="Rating" />
            </div>

            <div>
                <asp:TextBox ID="tbComment" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control" ValidationGroup="Comment"></asp:TextBox>
                <asp:RegularExpressionValidator ErrorMessage="Comment is between 10 and 500 characters long" ControlToValidate="tbComment" ValidationGroup="Comment" runat="server" ForeColor="Red"
                                            ValidationExpression="^[\s\S]{10,500}" />
                <asp:Button ID="btnComment" runat="server" OnClick="btnComment_Click" CssClass="btn btn-success box-text" ValidationGroup="Comment" Text="Add Comment" />
            </div>

        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
