<%@ Page Title="Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="CrossJob.Web.Employer.ProjectDetails" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../Content/Styles/site.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="BodyContent2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewProjectDetails" ItemType="CrossJob.Models.Project"
        SelectMethod="FormViewProjectDetails_GetItem" DataKeyNames="ID" UpdateMethod="FormViewProjectDetails_UpdateItem">
        <ItemTemplate>
            <h1><%: Title %></h1>
            <p>
                <span><strong>Title: </strong></span>
                <%#: Item.Title %>
            </p>
            <div class="row-fluid">
                <p>
                    <span><strong>Description: </strong></span>
                    <%#: Item.Description %>
                </p>
            </div>
            <p>
                <span><strong>Category: </strong></span>
                <%#: Item.Category.Name %>
            </p>
            <p>
                <span><strong>Company Name: </strong></span>
                <%#: Item.Employer.CompanyName %></a>
            </p>
            <p>
                <span><strong>Freelancer employed:</strong> </span>
                <%#: string.Format("{0}", Item.Freelancer != null ? string.Format("{0} {1}", Item.Freelancer.FirstName, Item.Freelancer.LastName) : "No freelancers") %>
            </p>
            <p>
                <span><strong>Start Date:</strong></span>
                <%#: string.Format("{0:MM-dd-yyyy}", Item.StartOn) %>
            </p>
            <p>
                <span><strong>End Date:</strong></span>
                <%#: string.Format("{0:MM-dd-yyyy}", Item.FinishOn) %>
            </p>
            <p>
                <span><strong>Price: </strong></span>
                <%#: Item.Price %>
            </p>
            <div>
                <asp:LinkButton Text="Edit" runat="server" ID="lbEdit" CommandName="Edit"></asp:LinkButton>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="row form-horizontal">
                <div class="form-group">
                    <label for="tbTitle" class="col-md-3 control-label"><strong>Title: </strong></label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="tbTitle" PlaceHolder="Title" CssClass="form-control" Text='<%# BindItem.Title %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ErrorMessage="*Title is required" ControlToValidate="tbTitle" runat="server" ValidationGroup="UpdateProject" ForeColor="Red" />
                        <asp:RegularExpressionValidator ErrorMessage="Title is between 5 and 50 characters long" ControlToValidate="tbTitle" runat="server" ValidationGroup="AddProject" ForeColor="Red"
                            ValidationExpression="^[\s\S]{5,50}" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="tbDescription" class="col-md-3 control-label">Description: </label>
                    <div class="col-md-9">
                        <asp:TextBox ID="tbDescription" runat="server" CssClass="form-control" TextMode="MultiLine" PlaceHolder="Description" Text='<%# BindItem.Description %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ErrorMessage="*Description is required" ControlToValidate="tbDescription" runat="server" ValidationGroup="UpdateProject" ForeColor="Red" />
                        <asp:RegularExpressionValidator ErrorMessage="Description is between 10 and 50 characters long" ControlToValidate="tbDescription" ValidationGroup="AddProject" runat="server" ForeColor="Red"
                            ValidationExpression="^[\s\S]{10,1000}" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="ddlCategory" class="col-md-3 control-label">Category: </label>
                    <div class="col-md-9">
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control select" ValidationGroup="UpdateProject"
                            SelectMethod="GetCategories" DataTextField="Name" DataValueField="ID" SelectedValue='<%# Bind("ID")%>'>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group text-left">
                    <label for="calStartedDate" class="col-md-3 control-label">Start Date: </label>
                    <div class="col-md-9">

                        <asp:UpdatePanel runat="server" ID="upTextBox" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="tbStartDate" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ErrorMessage="Date must be in format MM/DD/YYYY" ControlToValidate="tbStartDate" ValidationGroup="UpdateProject" runat="server" ForeColor="Red"
                                    ValidationExpression="^$|(^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$)" />
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:ImageButton ID="imgStartDate" runat="server" OnClick="imgStartDate_Click"
                            CssClass="image-container" ImageUrl="~/Imgs/calendar-icon.jpg" />

                        <asp:UpdatePanel ID="upCalendar" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="imgStartDate" EventName="Click" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Calendar runat="server" ID="calStartDate" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px"
                                    OnSelectionChanged="calStartDate_SelectionChanged" OnDayRender="calStartDate_DayRender">
                                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                    <OtherMonthDayStyle ForeColor="#CC9966" />
                                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                    <SelectorStyle BackColor="#FFCC66" />
                                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                </asp:Calendar>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>


                <div class="form-group">
                    <label for="tbPrice" class="col-md-3 control-label">Price: </label>
                    <div class="col-md-9">
                        <asp:TextBox ID="tbPrice" runat="server" CssClass="form-control" PlaceHolder="0.00" Text='<%# BindItem.Price %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ErrorMessage="*Price is required" ControlToValidate="tbPrice" runat="server" ValidationGroup="UpdateProject" ForeColor="Red" />
                  <%--      <asp:RangeValidator ErrorMessage="Price must be greater than 0" ControlToValidate="tbPrice" runat="server" ValidationGroup="UpdateProject" ForeColor="Red"
                            MinimumValue="0.0"
                            Type="Double"/>--%>
                    </div>
                </div>
            </div>
            <asp:LinkButton Text="Save" runat="server" ID="lbEdit" CommandName="Update" ValidationGroup="UpdateProject"></asp:LinkButton>
            <asp:LinkButton Text="Cancel" runat="server" ID="lbCancel" CommandName="Cancel"></asp:LinkButton>

        </EditItemTemplate>

    </asp:FormView>
</asp:Content>
