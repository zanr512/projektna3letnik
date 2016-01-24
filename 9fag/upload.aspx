<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="_9fag.upload" %>

<!DOCTYPE HTML>
<html>
	<head>
		<title>9FAG | User Panel</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<!--[if lte IE 8]><script src="assets/js/ie/html5shiv.js"></script><![endif]-->
		<link rel="stylesheet" href="assets/css/main.css" />
		<!--[if lte IE 8]><link rel="stylesheet" href="assets/css/ie8.css" /><![endif]-->
	</head>
	<body class="landing">
		<form id="form1" runat="server">
		<div id="page-wrapper">

			<!-- Header -->
				<header id="header" class="alt">
					<h1>Welcome to <a href="index.aspx">9FAG</a></h1>
					<nav id="nav">
						<ul>
							<li><a href="index.aspx">Home</a></li>
							<a class="userpanel" href="user.aspx"><asp:Label ID="label_user" runat="server" Text="User"></asp:Label></a>
                            <a class="heart" href="favourite.aspx">♡</a>
                            <a class="uploadactivated" href="upload.aspx">Upload</a>
                            <li><a href="logout.aspx">Logout</a></li>
						</ul>
					</nav>
				</header>

			<!-- Banner -->
				<section id="banner">
					<h2>Upload</h2>
				</section>

			<!-- Main -->
				<section id="main" class="container">
					<section class="box special">
                        <div class="images">
                               <div>
                                   <asp:TextBox ID="comment1" runat="server"></asp:TextBox>
                                   <br />
                                   <asp:RequiredFieldValidator ErrorMessage="Please Enter Pic Description" ForeColor="Red" ControlToValidate="comment1"
                                    runat="server" />
                                   <br />
                                  <asp:FileUpload  runat="server" ID="file_upload" />
                                  <asp:Button  runat="server" ID="btnUpload" Text="Upload" onclick="btnUpload_Click" />
                                  <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
                                </div>
                        </div>
					</section>
                </section>

			<!-- Footer -->
				<footer id="footer">
					<ul class="copyright">
						<li>&copy; 9Fag. All rights reserved.</li><li>Design: <a href="http://html5up.net">HTML5 UP</a></li>
					</ul>
				</footer>

		</div>

		<!-- Scripts -->
			<script src="assets/js/jquery.min.js"></script>
			<script src="assets/js/jquery.dropotron.min.js"></script>
			<script src="assets/js/jquery.scrollgress.min.js"></script>
			<script src="assets/js/skel.min.js"></script>
			<script src="assets/js/util.js"></script>
			<!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
			<script src="assets/js/main.js"></script>

	    </form>

	</body>
</html>
