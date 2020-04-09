<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MBA.aspx.cs" Inherits="MBA" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container-fluid">
      <div class="row">
        
         <div class="col-md-12">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>College List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr />
                     </div>
                  </div>
                  <div class="row">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT college_id, college_name, college_stream, college_feature, college_state, college_city, college_url, college_img_link, college_desc FROM college_master_tbl WHERE (college_stream = 'MBA')" >
                      </asp:SqlDataSource>
                     <div class="col">                        
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="college_id" DataSourceID="SqlDataSource1">
                        <Columns>
                              <asp:BoundField DataField="college_id" HeaderText="ID" ReadOnly="True" SortExpression="college_id" >
                                 <ControlStyle Font-Bold="True" />
                                 <ItemStyle Font-Bold="True" />
                              </asp:BoundField>
                              <asp:TemplateField>
                                 <ItemTemplate>
                                    <div class="container-fluid">
                                       <div class="row">
                                          <div class="col-lg-10">
                                             <div class="row">
                                                <div class="col-12">
                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("college_name") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   <span>Stream - </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("college_stream") %>' Font-Size="Small"></asp:Label>
                                                   &nbsp;| <span><span>&nbsp;</span>Feature - </span>
                                                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("college_feature") %>' Font-Size="Small"></asp:Label>
                                                   &nbsp;| 
                                                   <span>
                                                      State -<span>&nbsp;</span>
                                                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("college_state") %>' Font-Size="Small"></asp:Label>
                                                   </span>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   City -
                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("college_city") %>' Font-Size="Small"></asp:Label>
                                                   &nbsp;| Website -

                                                   <a href='<%# Eval("college_url") %>' target="_blank"><asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("college_url") %>' Font-Italic="True" Font-Size="Small"></asp:Label></a>
                                                   
                                                </div>
                                             </div>                                         
                                             <div class="row">
                                                <div class="col-12">
                                                   Description -
                                                   <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("college_desc") %>'></asp:Label>
                                                </div>
                                             </div>
                                          </div>
                                          <div class="col-lg-2">
                                             <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("college_img_link") %>' />
                                          </div>
                                       </div>
                                    </div>
                                 </ItemTemplate>
                              </asp:TemplateField>
                           </Columns>
                            
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>


</asp:Content>



