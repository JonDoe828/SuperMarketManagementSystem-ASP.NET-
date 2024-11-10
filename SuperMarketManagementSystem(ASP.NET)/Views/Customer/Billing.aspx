<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Customer/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="SuperMarketManagementSystem_ASP.NET_.Views.Customer.Billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintBill() {
            var PGrid = document.getElementById('<%=ShoppingCartList.ClientID%>');
            PGrid.bordr = 0;
            var PWin = window.open('', 'PrintGrid', 'left=100, top=100, width=1024, height=768, toolbar=0, scrollbars=1, status=0, resizable=1');
            PWin.document.write(PGrid.outerHTML);
            PWin.document.close();
            PWin.focus();
            PWin.print();
            PWin.close();
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center my-4" style="color:teal;">Products Management</h3>
            </div>
        </div>

        <div class="row">
    
            <div class="col-12 col-md-5 mb-4 order-1 order-md-1">
                <h4 class="text-center" style="color:teal;">Product Selection</h4>
                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                            <label for="PnameTb" class="form-label text-success">Product Name</label>
                            <input type="text" placeholder="" autocomplete="off" class="form-control" runat="server" id="PnameTb" readonly/> 
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                            <label for="PriceTb" class="form-label text-success">Price</label>
                            <input type="text" placeholder="" autocomplete="off" class="form-control" runat="server" id="PriceTb" readonly/>
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                            <label for="QtyTb" class="form-label text-success">Amount</label>
                            <input type="text" placeholder="Enter Quantity" autocomplete="off" class="form-control" runat="server" id="QtyTb" />
                        </div>
                    </div>
                </div>
                <div class="row mt-3 mb-3">
                    <div class="col d-grid">
                        <asp:Button Text="Add to Cart" runat="server" id="AddToBillBtn" CssClass="btn btn-warning w-100" OnClick="AddToBillBtn_Click"/>
                    </div>
                </div>
                <asp:Label ID="ErrMsg" runat="server" ForeColor="Red" CssClass="mb-4" />

   
                <h4 class="text-center mt-5" style="color:teal;">Product List</h4>
                <asp:GridView ID="ProductList" runat="server" CssClass="table table-striped table-responsive" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="ProductList_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BackColor="teal" ForeColor="White" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" />
                    </Columns>
                </asp:GridView>
            </div>

            <div class="col-12 col-md-7 order-2 order-md-2">
                <h4 class="text-center" style="color:firebrick;">CART</h4>
                <asp:GridView ID="ShoppingCartList" runat="server" CssClass="table table-striped table-responsive" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BackColor="SlateBlue" ForeColor="White" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>

           
                <div class="row mt-3">
                    <div class="col-md-5"></div>
                    <div class="col-md-1 text-center flex-fill">
                        <asp:Label runat="server" ID="MoneyLabel" CssClass="text-danger "></asp:Label>                                     
                        <asp:Label runat="server" ID="GrdTotalTb" CssClass="text-danger "></asp:Label>
                    </div>
                </div>
                <div class="row mt-2">
                    <div class="col">
                        <asp:Button Text="Check Out" runat="server" id="PrintBtn" OnClientClick="PrintBill()" CssClass="btn btn-warning w-100" OnClick="PrintBtn_Click"/>
                    </div>
                </div>
                
                <asp:Label ID="BillContent" runat="server" Text="Latest Bill Information Will Appear Here" CssClass="mt-4 d-block"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

