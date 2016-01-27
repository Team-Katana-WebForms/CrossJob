<%@ Page Title="Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="CrossJob.Web.Employer.ProjectDetails" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../Content/site.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="BodyContent2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewProjectDetails" ItemType="CrossJob.Models.Project"
        SelectMethod="FormViewProjectDetails_GetItem" DataKeyNames="ID" CssClass="">
        <ItemTemplate>
            <div class="row">
                <h1><%: Title %></h1>
                <div class="col-md-20">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="title"><%#: Item.Title %>
                                <span>
                                    <i class="muted element-font">by 
                                        <strong><%#: Item.Employer.CompanyName %></strong>
                                    </i>
                                </span>
                            </h3>
                            <p class="text-muted inline-element">From <span class="glyphicon glyphicon-calendar"></span><%#: string.Format("{0:MM-dd-yyyy}", Item.StartOn) %></p>
                            <p class="text-muted inline-element">To <span class="glyphicon glyphicon-calendar"></span><%#: string.Format("{0:MM-dd-yyyy}", Item.FinishOn) %></p>
                        </div>
                        <div class="panel-body">
                            <p class="element-margins">
                                <%#: Item.Description %>
                            </p>
                        </div>
                        <div class="panel-footer">
                            <asp:Label runat="server" ID="projectId" Text="<%#: Item.ID %>" style="display: none;"></asp:Label>
                            <p class="text-danger">Price <strong><%#: Item.Price %></strong></p>
                            <p class="text-danger">Freelancer <strong><%#: string.Format("{0}", Item.Freelancer != null ? string.Format("{0} {1}", Item.Freelancer.FirstName, Item.Freelancer.LastName) : "No freelancers") %></strong></p>
                            <p class="text-muted">Category <i><%#: Item.Category.Name %></i></p>
                        </div>
                    </div>
                </div>
            </div>
            <%-- <div>
                <asp:LinkButton Text="Edit" runat="server" ID="lbEdit" CommandName="Edit"></asp:LinkButton>
            </div>--%>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:LoginView runat="server" ID="freelanseZone" ViewStateMode="Disabled">
                <RoleGroups>
                   <asp:RoleGroup Roles="Freelancer">
                       <ContentTemplate>
                              <asp:LinkButton class="btn btn-success" OnCommand="ApplyForWork_Click" Text="Apply" runat="server" />
                        </ContentTemplate>
                   </asp:RoleGroup>
             </RoleGroups>
            </asp:LoginView>
        </ContentTemplate>
       </asp:UpdatePanel>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
