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
                    <input type="text" autocomplete="off" class="form-control" runat="server" id="ManufacturerId"/>
                </div>
                <div class="mb-3">                
                    <label for="" class="form-label text-success">Production license</label> 
                    <input type="text" autocomplete="off" class="form-control" runat="server" id="LicenseNum"/>
                
                </div>
                <div class="mb-3">                
                    <label for="" class="form-label text-success">Origin</label> 
                    <asp:DropDownList  ID="PlaceCb" runat="server" Class="form-control">
                        <asp:ListItem >Sydney</asp:ListItem>
                        <asp:ListItem >Brisbane</asp:ListItem>
                        <asp:ListItem >Melbourne</asp:ListItem>
                        <asp:ListItem >Overseas</asp:ListItem>
                    </asp:DropDownList>
                
                </div>
            
                <div class="row">
                    <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger">    </asp:label>
                    <div class="col-md-4"><asp:Button Text="EDIT" runat="server" class="btn-warning btn-block btn" Width="100px" id="EditBtn" OnClick="EditBtn_Click" /></div>
                    <div class="col-md-4"><asp:Button Text="SAVE" runat="server" class="btn-success btn-block btn" Width="100px" id="SaveBtn" OnClick="SaveBtn_Click"/></div>
                    <div class="col-md-4"><asp:Button Text="DELETE" runat="server" class="btn-danger btn-block btn" Width="100px" id="DeleteBtn" OnClick="DeleteBtn_Click"/></div>
                </div>            
            </div>
            <div class="col-md-8">
                <asp:GridView ID="ManufactList" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="ManufactList_SelectedIndexChanged" Width="600px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="teal" Font-Bold="false" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" />
                    </Columns>
                 </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
