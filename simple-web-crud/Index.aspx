<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="simple_web_crud.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <!--Textbox and labels-->
    <div class="row margin-top-60px">
        <div class="col-3">
            <label><strong>Product</strong></label>
            <asp:TextBox ID="Product" MaxLength="36" runat="server"></asp:TextBox>
        </div>
        <div class="col-2 box-padding-left-20px">
            <label><strong>Price</strong></label>
            <asp:TextBox ID="Price" MaxLength="36" runat="server"  Text='<%#Eval("{0:c2}")%>' ToolTip="sasa"></asp:TextBox>
        </div>
        <div class="col-2 box-padding-left-20px">
            <label><strong>Quantity</strong></label>
            <asp:TextBox ID="Quantity" MaxLength="36" runat="server" TextMode="Number"  Height="40" Width="180"></asp:TextBox>
            
        </div>
        <div class="col-3 box-padding-left-20px">
            <label><strong>Category</strong></label>
            <asp:DropDownList ID="DropDownListCategory" runat="server"></asp:DropDownList>
        </div>

    </div>





    <!--Buttons-->
    <div class="row margin-top-10px">
        <div class="col-1">
            <asp:Button CssClass="button-save button-hsave" OnClick="Save_Click" ID="Save" runat="server" Text=" Save " />
        </div>
        <div class="col-1">
            <asp:Button CssClass="button-update button-hupdate" ID="Update" OnClick="Update_Click" runat="server" Text="Update" />
        </div>
        <div class="col-1">
            <asp:Button CssClass="button-delete button-hdelete" OnClick="Delete_Click" ID="Delete" runat="server" Text="Delete" />
        </div>
    </div>

    <!--Message label-->
    <div class="row margin-top-60px">
        <asp:Label ID="Message" CssClass="red-text" Text="" runat="server"></asp:Label>
        <asp:Label ID="SelectedIdText" Visible="false" Text="" runat="server"></asp:Label>
    </div>

    <!--GridView-->
    <div class="row" style="margin-top: 5px">

        <div class="col-6 box-border ">

            <asp:GridView ID="PageGridView" AutoGenerateColumns="false" HeaderStyle-BackColor="LightGray" CellPadding="8" Width="100%" BorderColor="Silver" runat="server">
                <Columns>
                    <asp:BoundField DataField="IdProducts" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Price" DataFormatString="{0:C2}" HeaderText="Price " />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" />
                    <asp:TemplateField ItemStyle-Width="60">
                        <ItemTemplate>
                            <asp:Button ID="SelectButton" Text="Select" CssClass="button-select" OnClick="SelectButton_Click" CommandArgument='<%#Eval("IdProducts")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>

    </div>

</asp:Content>
