<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="simple_web_crud.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    



    <!--Textbox and labels-->
    <div class="row margin-top-60px">
        <div class ="col-3">
            <label><strong>Product</strong></label>
            <asp:TextBox ID="Product" MaxLength="36" runat="server"></asp:TextBox>
        </div>

        <div class ="col-3 box-padding-left-20px">
            <label><strong>Category</strong></label>
            <asp:TextBox ID="Category" MaxLength="36" runat="server"></asp:TextBox>
        </div>
    </div>


    
    <!--Buttons-->
    <div class="row margin-top-10px">
        <div class="col-1">
            <asp:Button CssClass="button-save button-hsave" OnClick="Save_Click" ID="Save" runat="server" Text=" Save " />
        </div>
        <div class="col-1">
            <asp:Button CssClass="button-update button-hupdate" ID="Update" runat="server" Text="Update" />
        </div>
        <div class="col-1">
            <asp:Button CssClass="button-delete button-hdelete" ID="Delete" runat="server" Text="Delete" />
        </div>
    </div>

    <!--GridView-->
    <div class="row margin-top-60px">
        <div class="col-6 box-border ">
            <asp:GridView ID="GridView1" AutoGenerateColumns="true" HeaderStyle-BackColor="LightGray" CellPadding="8" Width="100%" BorderColor="Silver" runat="server"></asp:GridView>
        </div>
        
    </div>
    
</asp:Content>
