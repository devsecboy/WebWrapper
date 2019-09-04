<%@ Page Title="Blacklist3r" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Blacklister.aspx.cs" Inherits="WebWrapper.Blacklister" %>

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
                                    <label for="txtEncryptedCookie">Encrypted Cookie</label>
                                    <asp:TextBox ID="txtEncryptedCookie" runat="server" CssClass="form-control" Height="155px" TextMode="MultiLine" Width="522px"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label for="dropdownPurpose">Purpose</label>

                                    <asp:DropDownList ID="dropdownPurpose" CssClass="form-control" runat="server">
                                        <asp:ListItem>ASPXAUTH</asp:ListItem>
                                        <asp:ListItem>owin.cookie</asp:ListItem>
                                    </asp:DropDownList>
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
                                <asp:Button ID="btnDecrypt" runat="server" CssClass="btn btn-danger btn-lg" Text="Decrypt" OnClick="btnDecrypt_Click" />

                                <hr />
                                <div class="form-group">
                                    <label for="txtPlainTextCookie">Decrypted Cookie Information (Output)</label>


                                    <asp:TextBox ID="txtPlainTextCookie" runat="server" Height="248px" Width="522px" CssClass="form-control" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>

                                </div>


                                <asp:Button ID="btnSwap" runat="server" CssClass="btn btn-danger btn-lg" Text="Edit Cookie >" OnClick="btnSwap_Click" />
                            </div>
                        </div>


                    </div>
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">Encryption</div>
                            <div class="panel-body">


                                <div class="form-group">
                                    <label for="txtSwapPlainTextCookie">Plaintext Cookie</label>

                                    <asp:TextBox ID="txtSwapPlainTextCookie" runat="server" CssClass="form-control" Height="377px" TextMode="MultiLine" Width="522px"></asp:TextBox>
                                </div>

                                <asp:Button ID="btnEncrypt" runat="server" Text="Encrypt" CssClass="btn btn-danger btn-lg" OnClick="btnEncrypt_Click" />

                                <hr />

                                <div class="form-group">
                                    <label for="txtPlainTextCookie">Encrypted Cookie Information (Output)</label>

                                    <asp:TextBox ID="txtReEncryptedCookie" runat="server" Height="248px" Width="522px" CssClass="form-control" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
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
                <asp:Label ID="lblBlacklisterCommand" runat="server" Text="AspDotNetWrapper.exe  --decryptDataFilePath DecryptedText.txt" Style="word-wrap: break-word;"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
