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

            <asp:ListView ID="ListComments" runat="server" ItemType="CrossJob.Models.Comment" SelectMethod="ListComments_GetData">
                <LayoutTemplate>
                    <h2>Comments</h2>
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
                                <div>By <strong><%# Item.Employer.CompanyName %></strong></div>
                            </div>
                            <div class="col-md-6 col-md-offset-1">
                                <div><%# Item.Content %></div>
                            </div>
                            <div class="col-md-2"><%# string.Format("Publiched: {0:MM/dd/yyyy}", Item.CreatedOn) %></div>
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

        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
