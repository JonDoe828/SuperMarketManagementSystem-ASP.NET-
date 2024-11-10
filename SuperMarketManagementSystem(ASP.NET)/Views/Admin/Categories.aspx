<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="SuperMarketManagementSystem_ASP.NET_.Views.Admin.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Category Management</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-12 col-md-4 mb-4 order-1 order-md-1">
                <div class="mb-3">                
                    <label for="" class="form-label text-success">Category Name</label> 
                    <input type="text" autocomplete="off" class="form-control" runat="server" id="CategoryName" />
                </div>
                <div class="mb-3">                
                    <label for="" class="form-label text-success">Detail</label> 
                    <input type="text" autocomplete="off" class="form-control" runat="server" id="CatDetail"/>               
                </div>
                
                <div class="row text-center text-md-start">
                    <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger mb-2"></asp:Label>
                    <div class="col-4 col-md-12 col-lg-4 mb-2">
                        <asp:Button Text="EDIT" runat="server" id="EditBtn" CssClass="btn btn-warning w-100" OnClick="EditBtn_Click"/>
                    </div>
                    <div class="col-4 col-md-12 col-lg-4 mb-2">
                        <asp:Button Text="SAVE" runat="server" id="SaveBtn" CssClass="btn btn-success w-100" OnClick="SaveBtn_Click"/>
                    </div>
                    <div class="col-4 col-md-12 col-lg-4 mb-2">
                        <asp:Button Text="DELETE" runat="server" id="DeleteBtn" CssClass="btn btn-danger w-100" OnClick="DeleteBtn_Click"/>
                    </div>
                </div>                     
            </div>
            <div class="col-12 col-md-8 order-2 order-md-2">
                <asp:GridView ID="CategoryList" runat="server" CssClass="table table-striped table-responsive" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="CategoryList_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="teal" Font-Bold="false" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                    <Columns>
           
                        <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" />
                    </Columns>
                </asp:GridView>
</div>
        </div>
    </div>



</asp:Content>
