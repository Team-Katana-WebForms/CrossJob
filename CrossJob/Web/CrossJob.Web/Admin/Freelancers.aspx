<%@ Page Title="Freelancers" Language="C#" MasterPageFile="../Site.Master" AutoEventWireup="true" CodeBehind="Freelancers.aspx.cs" Inherits="CrossJob.Web.Admin.Freelancers" %>
<asp:Content ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>List of registered freelancers</h2>

    <div>
        <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true" />

        <asp:ValidationSummary ID="EditValidationSummary" runat="server" EnableClientScript="true"
            HeaderText="List of validation errors" ValidationGroup="Edit" />

        <asp:DynamicValidator runat="server" ID="EditValidator"
            ControlToValidate="FreelancerListView" ValidationGroup="Edit" Display="None" />

        <asp:ListView ID="FreelancerListView" runat="server"
            DataKeyNames="Id"
            ItemType="CrossJob.Models.Freelancer"
            SelectMethod="Freelancers_GetData"
            UpdateMethod="Freelancers_UpdateItem"
            DeleteMethod="Freelancers_DeleteItem">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No data was returned</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table table-bordered" runat="server" id="tblFreelancers">
                    <tr runat="server">
                        <th>
                            <asp:LinkButton Text="UserName" CommandName="Sort" CommandArgument="UserName" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="Email" CommandName="Sort" CommandArgument="Email" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="FirstName" CommandName="Sort" CommandArgument="FirstName" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="LastName" CommandName="Sort" CommandArgument="LastName" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="Country" CommandName="Sort" CommandArgument="Country" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="RatePerHour" CommandName="Sort" CommandArgument="RatePerHour" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="AverageRating" CommandName="Sort" CommandArgument="AverageRating" runat="Server" />
                        </th>
                        <th>&nbsp;</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
                <asp:DataPager runat="server" PageSize="3">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="false"
                            ShowNextPageButton="false" ShowPreviousPageButton="true" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowLastPageButton="false"
                            ShowNextPageButton="true" ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:DynamicControl runat="server" DataField="UserName" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Email" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="FirstName" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="LastName" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Country" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="RatePerHour" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="AverageRating" />
                    </td>
                    <td>
                        <asp:LinkButton ID="EditButton" CommandName="Edit" runat="server" Text="Edit" CausesValidation="false" />
                        <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" CausesValidation="false" OnClientClick='return confirm("Are you sure you want to delete this item?");' />
                    </td>
                </tr>
            </ItemTemplate>
            <EditItemTemplate>
                <tr>
                    <td>
                        <asp:DynamicControl runat="server" DataField="UserName" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Email" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="FirstName" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="LastName" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Country" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="RatePerHour" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="AverageRating" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" Text="Update" ValidationGroup="Edit" />
                        <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
                    </td>
                </tr>
            </EditItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
