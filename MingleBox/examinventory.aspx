<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="examinventory.aspx.cs" Inherits="examinventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }

   </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Exam Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img id="imgview" height="100px" width="100px" src="exam_inventory/exams1.jpg" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:FileUpload class="form-control" onchange="readURL(this);" ID="FileUpload1" runat="server" />
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-3">
                        <label>Exam ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Exam ID"></asp:TextBox>
                              <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" OnClick="Button4_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-9">
                        <label>Exam Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Exam Name"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Stream</label>
                         <div class="form-group">    
                            <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                               <asp:ListItem>Select</asp:ListItem>                    
                               <asp:ListItem>MBA</asp:ListItem>
                               <asp:ListItem>Engineering</asp:ListItem>
                               <asp:ListItem>Design</asp:ListItem>
                               <asp:ListItem>Study Abroad</asp:ListItem>                             
                            </asp:DropDownList>                          
                        </div>
                    </div>

                    <div class="col-md-4">
                         <label>Exam Feature</label>
                          <div class="form-group">
                            <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                              <asp:ListItem>Select</asp:ListItem> 
                              <asp:ListItem Text="Yes" Value="Yes" />
                              <asp:ListItem Text="No" Value="No" />
                            </asp:DropDownList>
                          </div>
                        </div>     

                     <div class="col-md-4">
                        <label>Exam Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" TextMode="DateTime"></asp:TextBox>
                        </div>
                     </div>
                                     
                     
                  </div>

                   
                  <div class="row">
                   
                    <div class="col-md-6">
                        <label>Website</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Website" TextMode="Url"></asp:TextBox>
                        </div>
                     </div>

                    <div class="col-md-6">
                        <label>Last Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Last Date" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  
                                                                                       
                  <div class="row">
                     <div class="col-12">
                        <label>Exam Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Exam Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button1_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button2_Click" />
                     </div>
                  </div>
         
                              
            <a href="homepage.aspx"><< Back to Home</a><br />
            <br />
         </div>
            </div>
        </div>


         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Exam Inventory List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr />
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [exam_master_tbl]"></asp:SqlDataSource>
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

