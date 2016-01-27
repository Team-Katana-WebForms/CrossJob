<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployerDetails.aspx.cs" Inherits="CrossJob.Web.EmployerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                   <asp:LoginView runat="server" ViewStateMode="Disabled">
                <LoggedInTemplate>
                    <div class="row text-center">
                        <asp:ListView runat="server" ID="UsersDetail" ItemType="CrossJob.Models.Employer"
                    SelectMethod="ListViewEmployerDetails_GetData" DataKeyNames="ID">
                            <div>
                                  <ItemTemplate>
                                              <div class="row-fluid">
                                                 <p>
                                                      <span><strong>Username: </strong></span>
                                                       <%#: Item.UserName %>
                                                </p>
                                                  <p>
                                                    <span><strong>Company name: </strong></span>
                                                    <%#: Item.CompanyName %>
                                                </p>
                                                 <p>
                                                    <p>
                                                </div>
                                  </ItemTemplate>
                               </div>
                            </asp:ListView>
                    </div>
                </LoggedInTemplate>
            </asp:LoginView>
</asp:Content>
