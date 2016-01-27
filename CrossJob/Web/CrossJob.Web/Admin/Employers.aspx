<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Employers.aspx.cs" Inherits="CrossJob.Web.Admin.Employers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminMainContent" runat="server">
    <h2>List of registered employers</h2>

    <div>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
        <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true" />

        <asp:ValidationSummary ID="EditValidationSummary" runat="server" EnableClientScript="true"
            HeaderText="List of validation errors" ValidationGroup="Edit" />

        <asp:DynamicValidator runat="server" ID="EditValidator"
            ControlToValidate="EmployerListView" ValidationGroup="Edit" Display="None" />

        <asp:ListView ID="EmployerListView" runat="server"
            DataKeyNames="Id"
            ItemType="CrossJob.Models.Employer"
            SelectMethod="Employers_GetData"
            UpdateMethod="Employers_UpdateItem"
            DeleteMethod="Employers_DeleteItem">
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
                            <asp:LinkButton Text="UserName" CommandName="Sort" CommandArgument="UserName" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="Email" CommandName="Sort" CommandArgument="Email" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="CompanyName" CommandName="Sort" CommandArgument="CompanyName" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="Country" CommandName="Sort" CommandArgument="Country" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="Address" CommandName="Sort" CommandArgument="Address" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="Website" CommandName="Sort" CommandArgument="Website" runat="Server" />
                        </th>
                        <th>
                            <asp:LinkButton Text="Avatar" runat="Server" />
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
                        <asp:DynamicControl runat="server" DataField="UserName" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Email" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="CompanyName" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Country" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Address" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Website" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Avatar" />
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
                        <asp:DynamicControl runat="server" DataField="UserName" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Email" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="CompanyName" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Country" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Address" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Website" Mode="Edit" ValidationGroup="Edit" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Avatar" Mode="Edit" ValidationGroup="Edit" />
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
 </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>
