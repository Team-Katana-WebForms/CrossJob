<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="CrossJob.Web.Admin.Projects1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminMainContent" runat="server">
    <h2>List of posted projects</h2>

    <div>
        <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true" />

        <asp:ValidationSummary ID="EditValidationSummary" runat="server" EnableClientScript="true"
            HeaderText="List of validation errors" ValidationGroup="Edit" />

        <asp:DynamicValidator runat="server" ID="EditValidator"
            ControlToValidate="ProjectListView" ValidationGroup="Edit" Display="None" />

        <asp:ListView ID="ProjectListView" runat="server"
            DataKeyNames="Id"
            ItemType="CrossJob.Models.Project"
            SelectMethod="Projects_GetData"
            UpdateMethod="Projects_UpdateItem"
            DeleteMethod="Projects_DeleteItem">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No data was returned</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table table-bordered table-hover table-striped" runat="server" id="tblEmployers">
                    <tr runat="server">
                        <th>
                            <asp:LinkButton Text="Title" CommandName="Sort" CommandArgument="Title" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="Description" CommandName="Sort" CommandArgument="Description" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="CreatedOn" CommandName="Sort" CommandArgument="CreatedOn" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="Price" CommandName="Sort" CommandArgument="Price" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="EmployerId" CommandName="Sort" CommandArgument="EmployerId" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="FreelancerId" CommandName="Sort" CommandArgument="FreelancerId" runat="Server" />
                        </th>

                        <th>&nbsp;</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
                <asp:DataPager runat="server" PageSize="5">
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
                        <asp:DynamicControl runat="server" DataField="Title" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Description" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="CreatedOn" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Price" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="EmployerId" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="FreelancerId" />
                    </td>
                    <td class="text-center">
                        <asp:LinkButton class="btn btn-sm btn-warning" ID="EditButton" CommandName="Edit" runat="server" Text="Edit" CausesValidation="false" />
                        <asp:LinkButton class="btn btn-sm btn-danger" ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" CausesValidation="false" />
                    </td>
                </tr>
            </ItemTemplate>
            <EditItemTemplate>
                <tr>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Title" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Description" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="CreatedOn" Mode="ReadOnly" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Price" Mode="ReadOnly" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="EmployerId" Mode="ReadOnly" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="FreelancerId" Mode="ReadOnly" />
                    </td>
                    <td class="text-center">
                        <asp:LinkButton class="btn btn-sm btn-warning" ID="UpdateButton" runat="server" CommandName="Update" Text="Update" ValidationGroup="Edit" />
                        <asp:LinkButton class="btn btn-sm btn-success" ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
                    </td>
                </tr>
            </EditItemTemplate>
        </asp:ListView>
    </div>
    <asp:TextBox ID="HiddenfieldDeleteId" runat="server" Visible="false"></asp:TextBox>
    <uc:ModalWindow ID="ModalWindow" runat="server" OKButtonText="Delete" ModalWindowText="Are you sure you want to delete this item? This action is irreversible!" OnOKButtonClicked="ModalWindow_OKButtonClicked" />
</asp:Content>
