<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Manufacturers.aspx.cs" Inherits="SuperMarketManagementSystem_ASP.NET_.Views.Admin.Suppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
    <div class="row">
        <div class="col">
            <h3 class="text-center">Manufacturer Management</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">                
                <label for="" class="form-label text-success">Manufacturer</label> 
                <input type="text" placeholder="" autocomplete="off" name="name" value="" class="form-control"/>
            </div>
            <div class="mb-3">                
                <label for="" class="form-label text-success">Production license</label> 
                <input type="text" placeholder="" autocomplete="off" name="name" value="" class="form-control"/>
                
            </div>
            <div class="mb-3">                
                <label for="" class="form-label text-success">Origin</label> 
                <asp:DropDownList  ID="DropDownList1" runat="server" Class="form-control">
                    <asp:ListItem >Sydney</asp:ListItem>
                    <asp:ListItem >Brisbane</asp:ListItem>
                    <asp:ListItem >Melbourne</asp:ListItem>
                    <asp:ListItem >Overseas</asp:ListItem>
                </asp:DropDownList>
                
            </div>
            
            <div class="row">
                <div class="col-md-4"><asp:Button Text="EDIT" runat="server" class="btn-warning btn-block btn" Width="100px"/></div>
                <div class="col-md-4"><asp:Button Text="SAVE" runat="server" class="btn-success btn-block btn" Width="100px"/></div>
                <div class="col-md-4"><asp:Button Text="DELETE" runat="server" class="btn-danger btn-block btn" Width="100px"/></div>
            </div>
            
            

        </div>
        <div class="col-md-8">
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>

        </div>

    </div>

</div>
</asp:Content>
