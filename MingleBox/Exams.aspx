<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Exams.aspx.cs" Inherits="Exams" %>

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
                           <h4>Exam List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr />
                     </div>
                  </div>
                  <div class="row">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [exam_master_tbl]" >
                      </asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="exam_id" DataSourceID="SqlDataSource1">
                            
                        <Columns>
                              <asp:BoundField DataField="exam_id" HeaderText="ID" ReadOnly="True" SortExpression="college_id" >
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
                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("exam_name") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   <span>Stream - </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("exam_stream") %>' Font-Size="Small"></asp:Label>
                                                   &nbsp;| <span><span>&nbsp;</span>Feature - </span>
                                                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("exam_feature") %>' Font-Size="Small"></asp:Label>
                                                   &nbsp;| 
                                                   <span>
                                                      Date -<span>&nbsp;</span>
                                                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("exam_date") %>' Font-Size="Small"></asp:Label>
                                                   </span>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   Last Date -
                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("exam_lastdate") %>' Font-Size="Small"></asp:Label>
                                                   &nbsp;| Website -

                                                   <a href='<%# Eval("exam_url") %>' target="_blank"><asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("exam_url") %>' Font-Italic="True" Font-Size="Small"></asp:Label></a>
                                                   
                                                </div>
                                             </div>                                         
                                             <div class="row">
                                                <div class="col-12">
                                                   Description -
                                                   <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("exam_desc") %>'></asp:Label>
                                                </div>
                                             </div>
                                          </div>
                                          <div class="col-lg-2">
                                             <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("exam_img_link") %>' />
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

