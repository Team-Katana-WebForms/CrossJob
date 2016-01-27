<%@ Page Title="New Project" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="CrossJob.Web.Employer.AddProject" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../Content/site.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div class="container-fluid">
        <div class="row text-center">
            <h2><%: Title %></h2>
            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>
            <div class="row form-horizontal">
                <div class="col-md-6 col-md-offset-3">
                    <fieldset>
                        <div class="form-group">
                            <label for="tbTitle" class="col-md-3 control-label">Title</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="tbTitle" runat="server" CssClass="form-control" PlaceHolder="Title"></asp:TextBox>
                                <asp:RequiredFieldValidator ErrorMessage="*Title is required" ControlToValidate="tbTitle" runat="server" ValidationGroup="AddProject" ForeColor="Red" />
                                <asp:RegularExpressionValidator ErrorMessage="Title is between 5 and 50 characters long" ControlToValidate="tbTitle" runat="server" ValidationGroup="AddProject" ForeColor="Red"
                                    ValidationExpression="^[\s\S]{5,50}" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="tbDescription" class="col-md-3 control-label">Description</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="tbDescription" runat="server" CssClass="form-control" TextMode="MultiLine" PlaceHolder="Description"></asp:TextBox>
                                <asp:RequiredFieldValidator ErrorMessage="*Description is required" ControlToValidate="tbDescription" runat="server" ValidationGroup="AddProject" ForeColor="Red" />
                                <asp:RegularExpressionValidator ErrorMessage="Description is between 10 and 50 characters long" ControlToValidate="tbDescription" ValidationGroup="AddProject" runat="server" ForeColor="Red"
                                    ValidationExpression="^[\s\S]{10,1000}" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="ddlCategory" class="col-md-3 control-label">Category</label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control select" ValidationGroup="AddProject"
                                    SelectMethod="GetCategories" DataTextField="Name" DataValueField="ID">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group text-left">
                            <label for="calStartedOn" class="col-md-3 control-label">Started On</label>
                            <div class="col-md-9">

                                <asp:UpdatePanel runat="server" ID="upStartOn" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbStartOn" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ErrorMessage="Date must be in format MM/DD/YYYY" ControlToValidate="tbStartOn" ValidationGroup="AddProject" runat="server" ForeColor="Red"
                                            ValidationExpression="^$|(^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$)" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:ImageButton ID="imgStartOn" runat="server" OnClick="imgStartOn_Click"
                                    CssClass="image-container" ImageUrl="~/Imgs/calendar-icon.jpg" />

                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="imgStartOn" EventName="Click" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:Calendar runat="server" ID="calStartOn" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px"
                                            OnSelectionChanged="calStartOn_SelectionChanged" OnDayRender="calStartOn_DayRender">
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
                        <div class="form-group text-left">
                            <label for="calFinishedOn" class="col-md-3 control-label">Finished On</label>
                            <div class="col-md-9">

                                <asp:UpdatePanel runat="server" ID="upTbFinishedOn" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbFinishOn" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ErrorMessage="Date must be in format MM/DD/YYYY" ControlToValidate="tbFinishOn" ValidationGroup="AddProject" runat="server" ForeColor="Red"
                                            ValidationExpression="^$|(^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$)" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:ImageButton ID="imgFinishOn" runat="server" OnClick="imgFinishOn_Click"
                                    CssClass="image-container" ImageUrl="~/Imgs/calendar-icon.jpg" />

                                <asp:UpdatePanel ID="upFinishOn" runat="server">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="imgFinishOn" EventName="Click" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:Calendar runat="server" ID="calFinihedOn" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px"
                                            OnSelectionChanged="calFinihedOn_SelectionChanged" OnDayRender="calFinihedOn_DayRender">
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
                            <label for="tbPrice" class="col-md-3 control-label">Price per hour</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="tbPrice" runat="server" CssClass="form-control" PlaceHolder="0.00"></asp:TextBox>
                                <asp:RequiredFieldValidator ErrorMessage="*Price is required" ControlToValidate="tbPrice" runat="server" ValidationGroup="AddProject" ForeColor="Red" />
                                <asp:RangeValidator ErrorMessage="Price must be greater than 0" ControlToValidate="tbPrice" runat="server" ValidationGroup="AddProject" ForeColor="Red"
                                    MinimumValue="0"
                                    Type="Double" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-9 col-lg-offset-3 pull-right">
                                <asp:Button ID="btnAddProject" runat="server" OnClick="btnAddProject_Click" Text="Add Project" ValidationGroup="AddProject" CssClass="btn btn-info full-width" />
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
