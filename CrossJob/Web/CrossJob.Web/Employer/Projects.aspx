<%@ Page Title="Projects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="CrossJob.Web.Projects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="container-fluid">
            <div class="row text-center">
                <div class="col-md-8 col-md-offset-2">
                    <a runat="server" href="~/Employer/AddProject" class="btn btn-lg btn-primary">Add Project</a>
                </div>
            </div>
            <br />
            <div class="row text-center">
                <div class="col-md-12">
                    <div class="panel panel-info">
                        <div class="panel-heading text-center"><%: Title %></div>
                        <asp:ListView ID="ViewAllProjects" runat="server"
                            SelectMethod="ViewAllProjects_GetData"
                            ItemType="CrossJob.Models.Project"
                            AllowPaging="True"
                            EnableSortingAndPagingCallback="True"
                            AllowSorting="True"
                            DataKeyNames="ID"
                            AutoGenerateColumns="false"
                            DeleteMethod="ViewAllProjects_DeleteItem">
                            <LayoutTemplate>
                                <table class="table table-striped table-hover">
                                    <tr>
                                        <th class="text-center">
                                            <span>Title</span>
                                        </th>
                                        <th class="text-center">
                                            <span>Category</span>
                                        </th>
                                        <th class="text-center">
                                            <asp:LinkButton Text="Price" runat="server"
                                                ID="SortByPrice"
                                                CommandName="Sort"
                                                CommandArgument="Price" />
                                        </th>
                                        <th class="text-center">
                                            <asp:LinkButton Text="Start Date" runat="server"
                                                ID="SortByStartDate"
                                                CommandName="Sort"
                                                CommandArgument="StartOn" />
                                        </th>
                                        <th class="text-center">
                                            <asp:LinkButton Text="End Date" runat="server"
                                                ID="SortByEndDate"
                                                CommandName="Sort"
                                                CommandArgument="FinishOn" />
                                        </th>
                                        <th class="text-center">Details</th>
                                        <th class="text-center">Delete</th>
                                    </tr>
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                </table>
                            </LayoutTemplate>

                            <ItemTemplate runat="server">
                                <tr>
                                    <td>
                                        <asp:Label Text='<%#: Item.Title %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%# Item.Category.Name %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.Price %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%# Eval("StartOn","{0:MM-dd-yyyy}") %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%# Eval("FinishOn","{0:MM-dd-yyyy}")  %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:HyperLink NavigateUrl='<%#: string.Format("~/Employer/ProjectDetails.aspx?id={0}", Item.ID) %>' runat="server" CssClass="btn btn-primary"> Details
                                        </asp:HyperLink>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
                                            CommandName="Delete"></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>

                            <EmptyDataTemplate runat="server">
                                <h5 class="content-empty">No projects available</h5>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>
            <div class="bs-component text-center">
                <asp:DataPager ID="DataPagerAll" PagedControlID="ViewAllProjects" PageSize="5" runat="server" CssClass="btn-group btn-group-sm">
                    <Fields>
                        <asp:NextPreviousPagerField PreviousPageText="<" FirstPageText="<<" ShowPreviousPageButton="true"
                            ShowFirstPageButton="true" ShowNextPageButton="false" ShowLastPageButton="false" ButtonType="Button"
                            ButtonCssClass="btn btn-default" RenderNonBreakingSpacesBetweenControls="false" RenderDisabledButtonsAsLabels="false" />

                        <asp:NumericPagerField ButtonType="Button" CurrentPageLabelCssClass="btn btn-primary disabled" RenderNonBreakingSpacesBetweenControls="false"
                            NumericButtonCssClass="btn btn-default" ButtonCount="10" NextPageText="..." NextPreviousButtonCssClass="btn btn-default" />

                        <asp:NextPreviousPagerField NextPageText=">" LastPageText=">>" ShowNextPageButton="true"
                            ShowLastPageButton="true" ShowPreviousPageButton="false" ShowFirstPageButton="false" ButtonType="Button"
                            ButtonCssClass="btn btn-default" RenderNonBreakingSpacesBetweenControls="false" RenderDisabledButtonsAsLabels="false" />
                    </Fields>
                </asp:DataPager>
            </div>
        </div>
    </div>

</asp:Content>
