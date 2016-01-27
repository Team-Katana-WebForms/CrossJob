<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModalWindow.ascx.cs" Inherits="TestASCX.ModalWindow" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div id="modalWindowControlHolder" hidden="hidden">
            <asp:TextBox ID="TextBox" runat="server"></asp:TextBox>
            <button id="modalWindowButtonOpen" data-toggle="modal" data-target="#modalWindow"></button>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

<div class="modal" id="modalWindow">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title">Delete confirmation</h4>
            </div>
            <div class="modal-body">
                <p>
                    <asp:Literal ID="ModalText" runat="server"></asp:Literal>
                </p>
            </div>
            <div class="modal-footer">
                <asp:Button ID="OKBtn" OnClick="ModalWindow_OKButtonClicked" runat="server" Text="OK" CssClass="btn btn-lg btn-danger"></asp:Button>
                <button type="button" class="btn btn-lg btn-success" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>
