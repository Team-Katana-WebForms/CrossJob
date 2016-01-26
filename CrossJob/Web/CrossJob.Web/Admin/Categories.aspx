<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="CrossJob.Web.Admin.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true" />

        <asp:ValidationSummary ID="EditValidationSummary" runat="server" EnableClientScript="true"
            HeaderText="List of validation errors" ValidationGroup="Edit" />

        <asp:DynamicValidator runat="server" ID="EditValidator"
            ControlToValidate="CategoriesListView" ValidationGroup="Edit" Display="None" />

        <asp:ListView ID="CategoriesListView" runat="server"
            DataKeyNames="Id"
            ItemType="CrossJob.Models.Category"
            SelectMethod="Categories_GetData"
            UpdateMethod="Categories_UpdateItem"
            DeleteMethod="Categories_DeleteItem"
            InsertMethod="Categories_InsertItem">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No data was returned</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table table-bordered table-hover table-striped" runat="server" id="tblCategories">
                    <tr runat="server">
                        <th>
                            <asp:LinkButton Text="Name" CommandName="Sort" CommandArgument="Name" runat="Server" />
                        </th>
                        <th>&nbsp;</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
                <asp:DataPager runat="server" PageSize="10">
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
                        <asp:DynamicControl runat="server" DataField="Name" />
                    </td>
                    <td class="text-center">
                        <asp:LinkButton class="btn btn-sm btn-warning" ID="EditButton" CommandName="Edit" runat="server" Text="Edit" CausesValidation="false" />
                        <asp:LinkButton class="btn btn-sm btn-danger" ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" CausesValidation="false" OnClientClick='return confirm("Are you sure you want to delete this item?");' />
                    </td>
                </tr>
            </ItemTemplate>
            <EditItemTemplate>
                <tr>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Name" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                    <td class="text-center">
                        <asp:LinkButton class="btn btn-sm btn-warning" ID="UpdateButton" runat="server" CommandName="Update" Text="Update" ValidationGroup="Edit" />
                        <asp:LinkButton class="btn btn-sm btn-success" ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
                    </td>
                </tr>
            </EditItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
