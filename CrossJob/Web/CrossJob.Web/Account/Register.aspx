<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CrossJob.Web.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12 text-center">
            <h2>Let's get started!</h2>
            <h2>First, tell us what you're looking for.</h2>
        </div>
        <br /><br /><br />
        <div class="col-md-12 text-center">
            <div class="col-md-3 col-md-offset-2">
                <div>
                    <div>I want to hire a freelancer</div><br /><br />
                </div>
                <a class="btn btn-primary btn-block text-capitalize m-0" href="RegisterEmployer.aspx">Hire</a>
            </div>

            <div class="col-md-2">OR</div>

            <div class="col-md-3">
                <div>
                    <div>I'm looking for online work</div><br /><br />
                </div>
                <a class="btn btn-primary btn-block text-capitalize m-0" href="RegisterFreelancer.aspx">Work</a>
            </div>
        </div>
    </div>

</asp:Content>
