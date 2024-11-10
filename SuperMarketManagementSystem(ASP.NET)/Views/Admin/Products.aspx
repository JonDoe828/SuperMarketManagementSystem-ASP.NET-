<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="SuperMarketManagementSystem_ASP.NET_.Views.Admin.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">

        <div class="row">
            <div class="col">
                <h3 class="text-center my-4">Products Management</h3>
            </div>
        </div>
        
        <div class="row">
  
            <div class="col-12 col-md-4 mb-4 order-1 order-md-1">
                <div class="mb-3">
                    <label for="PNameTb" class="form-label text-success">Product Name</label>
                    <input type="text" placeholder="Enter Product Name" autocomplete="off" runat="server" id="PName" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="PManufactCb" class="form-label text-success">Supplier</label>
                    <asp:DropDownList ID="PManufact" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="PCatCb" class="form-label text-success">Category</label>
                    <asp:DropDownList ID="PCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="PriceTb" class="form-label text-success">Price</label>
                    <input type="text" placeholder="Enter Price" autocomplete="off" runat="server" id="PPrice" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="QtyTb" class="form-label text-success">Quantity</label>
                    <input type="text" placeholder="Enter Quantity" autocomplete="off" runat="server" id="PQty" class="form-control" />
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
                <asp:GridView ID="ProductList" runat="server" CssClass="table table-striped table-responsive" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="ProductList_SelectedIndexChanged">
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

