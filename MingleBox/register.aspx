<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="120px" src="images/log.jpg"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Register</h4>
                        </center>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col-md-6">
                         <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Full Name" TextMode="SingleLine"></asp:TextBox>
                        </div>
                       
                     </div>
     
                     <div class="col-md-6">
                         <label>E-mail Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="E-mail" TextMode="Email"></asp:TextBox>
                        </div>
                       
                     </div>
                  </div>

                   <div class="row">
                     <div class="col-md-6">
                         <label>Mobile Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Mobile Number" TextMode="Number"></asp:TextBox>
                        </div>
                       
                     </div>
     
                     <div class="col-md-6">
                         <label>State</label>
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                              <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                              <asp:ListItem Text="Assam" Value="Assam" />
                              <asp:ListItem Text="Bihar" Value="Bihar" />
                              <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Goa" Value="Goa" />
                              <asp:ListItem Text="Gujarat" Value="Gujarat" />
                              <asp:ListItem Text="Haryana" Value="Haryana" />
                              <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                              <asp:ListItem Text="Jammu and Kashmir" Value="Jammu and Kashmir" />
                              <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                              <asp:ListItem Text="Karnataka" Value="Karnataka" />
                              <asp:ListItem Text="Kerala" Value="Kerala" />
                              <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                              <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                              <asp:ListItem Text="Manipur" Value="Manipur" />
                              <asp:ListItem Text="Meghalaya" Value="Meghalaya" />
                              <asp:ListItem Text="Mizoram" Value="Mizoram" />
                              <asp:ListItem Text="Nagaland" Value="Nagaland" />
                              <asp:ListItem Text="Odisha" Value="Odisha" />
                              <asp:ListItem Text="Punjab" Value="Punjab" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Sikkim" Value="Sikkim" />
                              <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                              <asp:ListItem Text="Telangana" Value="Telangana" />
                              <asp:ListItem Text="Tripura" Value="Tripura" />
                              <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                              <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                              <asp:ListItem Text="West Bengal" Value="West Bengal" />
                            </asp:DropDownList>
                        </div>                        
                       
                     </div>
                  </div>

                   <div class="row">
                     <div class="col-md-6">
                         <label>City</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="City" TextMode="SingleLine"></asp:TextBox>
                        </div>
                       
                     </div>
     
                     <div class="col-md-6">
                         <label>Education Interest/Preference</label>
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="MBA" Value="MBA" />
                              <asp:ListItem Text="Engineering" Value="Engineering" />
                              <asp:ListItem Text="Design" Value="Design" />
                            </asp:DropDownList>
                        </div>
                       
                     </div>                   
                  </div>

                   <div class="row">
                     <div class="col-md-6">
                         <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                       
                     </div>
     
                     <div class="col-md-6">
                         <label>Confirm Password</label>
                        <div class="form-group">
                            <asp:TextBox class="form-control" ID="TextBox8" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                       
                     </div>                   
                  </div>
                 <br />
                  <div class="row">    
                      <div class ="col">             
                        <div class="form-group">
                               <asp:Button class="btn btn-success btn-block btn-lg" id="Button2" runat="server" Text="Register" OnClick="Button2_Click" />
                        </div>
                      </div>
                  </div>

                  
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a>
             <br />
             <br />
         </div>
      </div>
   </div>




</asp:Content>

