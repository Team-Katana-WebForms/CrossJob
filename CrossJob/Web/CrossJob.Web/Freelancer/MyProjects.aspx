<%@ Page Title="My Projects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProjects.aspx.cs" Inherits="CrossJob.Web.Freelancer.MyProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-center">
        <h1><%: Title %></h1>
   </div>
               <asp:ListView ID="ViewAllProjects" runat="server"
                            SelectMethod="ViewMyProjects_GetData"
                            ItemType="CrossJob.Models.Project"
                            AllowPaging="True"
                            EnableSortingAndPagingCallback="True"
                            DataKeyNames="ID"
                            AutoGenerateColumns="false">
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
                                            <asp:LinkButton Text="End Date" runat="server"
                                                ID="SortByEndDate"
                                                CommandName="Sort"
                                                CommandArgument="FinishOn" />
                                        </th>
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
                                        <asp:Label Text='<%# Eval("FinishOn","{0:MM-dd-yyyy}")  %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:HyperLink NavigateUrl='<%#: string.Format("~/Employer/ProjectDetails.aspx?id={0}", Item.ID) %>' runat="server"> Details
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        <EmptyDataTemplate runat="server">
                            <div class="text-center">
                              <h2 class="content-empty">You have no projects</h2>
                            </div>
                            </EmptyDataTemplate>
                        </asp:ListView>
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
</asp:Content>
