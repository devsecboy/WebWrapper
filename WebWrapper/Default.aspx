<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebWrapper.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Web Wrapper</h1>
        <p class="lead">Collection of tools, scripts used during the class</p>
    </div>

    <div class="row">
        <div class="col-md-6">
            <h2>Blacklister</h2>
            <p>
                The goal of this project is to accumulate the secret keys / secret materials related to various web frameworks, that are publicly available and potentially used by developers. These secrets will be utilized by the Blacklist3r tools to audit the target application and verify the usage of these pre-published keys.

We are releasing this project with.Net machine key tool to identify usage of pre-shared Machine Keys in the application for encryption and decryption of forms authentication cookie.
            </p>
            <p>
                <a class="btn btn-primary" href="Blacklister">Generate Payload</a>
                <a class="btn btn-default" href="https://github.com/NotSoSecure/Blacklist3r">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-6">
            <h2>ysoserial.net</h2>
            <p>
                ysoserial.net is a collection of utilities and property-oriented programming "gadget chains" discovered in common .NET libraries that can, under the right conditions, exploit .NET applications performing unsafe deserialization of objects. The main driver program takes a user-specified command and wraps it in the user-specified gadget chain, then serializes these objects to stdout. When an application with the required gadgets on the classpath unsafely deserializes this data, the chain will automatically be invoked and cause the command to be executed on the application host.
            </p>
            <p>
                <a class="btn btn-primary" href="YSoSerial">Generate Payload</a>
                <a class="btn btn-default" href="https://github.com/pwntester/ysoserial.net">Learn more &raquo;</a>
            </p>
        </div>
        <%--  <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>--%>
    </div>

</asp:Content>