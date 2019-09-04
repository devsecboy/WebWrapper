<%@ Page Title="Blacklist3r-ViewState" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BlacklisterViewState.aspx.cs" Inherits="WebWrapper.BlacklisterViewState" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="page-header">
                    <h1><a href="https://github.com/NotSoSecure/Blacklist3r"><%: Title %> </a></h1>
                    <br />
                    <p>Blacklist3r tools to audit the target application and verify the usage of these pre-published keys. </p>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">Decryption</div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label for="dropdownAspNetVersion">Asp.Net Version</label>
                                    <asp:DropDownList ID="dropdownAspNetVersion" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="dropdownAspNetVersion_SelectedIndexChanged">
                                        <asp:ListItem>Asp.Net < 4.5</asp:ListItem>
                                        <asp:ListItem>Asp.Net >= 4.5</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="txtViewState">ViewState</label>
                                    <asp:TextBox ID="txtViewState" runat="server" CssClass="form-control" Height="155px" TextMode="MultiLine" Width="522px"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="dropdownValdiationAlgo">Validation Algorithm</label>
                                    <asp:DropDownList ID="dropdownValdiationAlgo" CssClass="form-control" runat="server">
                                        <asp:ListItem>sha1</asp:ListItem>
                                        <asp:ListItem>hmacsha256</asp:ListItem>
                                        <asp:ListItem>hmacsha384</asp:ListItem>
                                        <asp:ListItem>hmacsha512</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group">
                                    <label for="dropdownDecryptionAlgo">Decryption Algorithm</label>
                                    <asp:DropDownList ID="dropdownDecryptionAlgo" CssClass="form-control" runat="server">
                                        <asp:ListItem>aes</asp:ListItem>
                                        <asp:ListItem>des</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="labelModifier" runat="server" Text="Modifier" Font-Bold="true"></asp:Label>
                                    <asp:TextBox ID="txtModifier" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lableTaragetPagePath" runat="server" Text="Target page path" Font-Bold="true"></asp:Label>
                                    <asp:TextBox ID="txtTargetPagePath" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="labelIISPath" runat="server" Text="Application path in IIS" Font-Bold="true"></asp:Label>
                                    <asp:TextBox ID="txtAppPathInIIS" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:Button ID="btnDecrypt" runat="server" CssClass="btn btn-danger btn-lg" Text="Decrypt" OnClick="btnDecrypt_Click" />
                            </div>
                        </div>


                    </div>
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">Encryption</div>
                            <div class="panel-body">
                                <div class="panel-body">
                                    <div class="form-group">
                                        <label for="txtDecryptionInfo">MachineKey Info</label>
                                        <asp:TextBox ID="txtDecryptionInfo" runat="server" CssClass="form-control" Height="377px" TextMode="MultiLine" Width="490px"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <hr />
            <div class="alert alert-success" role="alert">
                <asp:Label ID="lblBlacklisterCommand" runat="server" Text="" Style="word-wrap: break-word;"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
