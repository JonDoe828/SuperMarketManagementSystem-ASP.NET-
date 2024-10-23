<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="SuperMarketManagementSystem_ASP.NET_.Views.Admin.Consumers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">User Management</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">                
                    <label for="" class="form-label text-success">User Name</label> 
                    <input type="text" placeholder="" autocomplete="off" name="name" value="" class="form-control"/>
                </div>
                <div class="mb-3">                
                    <label for="" class="form-label text-success">Email</label> 
                    <input type="email" placeholder="" autocomplete="off" name="name" value="" class="form-control"/>                
                </div>
                <div class="mb-3">                
                    <label for="" class="form-label text-success">Phone Number</label> 
                    <input type="text" placeholder="" autocomplete="off" name="name" value="" class="form-control"/>               
                </div>
                <div class="mb-3">                
                    <label for="" class="form-label text-success">Address</label> 
                    <input type="text" placeholder="" autocomplete="off" name="name" value="" class="form-control"/>
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
