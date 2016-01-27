﻿<%@ Page Title="Details about freelancer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FreelancerDetails.aspx.cs" Inherits="CrossJob.Web.FreelancerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                   <asp:LoginView runat="server" ViewStateMode="Disabled">
                <LoggedInTemplate>
                         <div class="jumbotron text-center">
                           <h1><%: Title %></h1>
                       </div>
                    <div class="row text-center">
                        <asp:ListView runat="server" ID="FreelancerDetails" ItemType="CrossJob.Models.Freelancer"
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
                                                    <%#: Item.AverageRating %>
                                                </p>
                                                </div>
                                  </ItemTemplate>
                            </asp:ListView>
                    </div>
                </LoggedInTemplate>
            </asp:LoginView>
</asp:Content>