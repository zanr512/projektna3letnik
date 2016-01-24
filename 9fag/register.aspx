<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="_9fag.register" %>

<!DOCTYPE HTML>
<html>
	<head>
		<title>9FAG | Register</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<!--[if lte IE 8]><script src="assets/js/ie/html5shiv.js"></script><![endif]-->
		<link rel="stylesheet" href="assets/css/main.css" />
		<!--[if lte IE 8]><link rel="stylesheet" href="assets/css/ie8.css" /><![endif]-->
	</head>
	<body class="landing">
		<div id="page-wrapper">

			<!-- Header -->
				<header id="header" class="alt">
					<h1>Welcome to <a href="index.aspx">9FAG</a></h1>
					<nav id="nav">
						<ul>
							<li><a href="index.aspx">Home</a></li>
							<li><a href="register.aspx" class="button">Register</a></li>
						</ul>
					</nav>
				</header>

			<!-- Banner -->
				<section id="banner">
					<h2>Register</h2>
				</section>

			<!-- Main -->
				<section id="main" class="container">
					<section class="box special">
                        <form id="form1" runat="server">
                            E-mail:<asp:TextBox ID="register_mail" TextMode="Email" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter E-mail" ForeColor="Red" ControlToValidate="register_mail"></asp:RequiredFieldValidator>
                            <br />
                            Password:<asp:TextBox ID="register_pass" TextMode="Password" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter password" ForeColor="Red" ControlToValidate="register_pass"></asp:RequiredFieldValidator>
                            <br />
                            Confirm Password:<asp:TextBox ID="register_pass_re" TextMode="Password" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Confirm your password" ForeColor="Red" ControlToValidate="register_pass_re"></asp:RequiredFieldValidator>
                            <br />
                            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="register_pass" controltocompare="register_pass_re" Operator="Equal" runat="server" ErrorMessage="Both passwords must match"></asp:CompareValidator>
                            <br />
                            <asp:Button ID="register_button" runat="server" Text="Register" OnClick="register_button_Click" />
                            
                        </form>
                        <br />
                        <asp:Label ID="register_status" runat="server"></asp:Label>
					</section>
                </section>

			<!-- Footer -->
				<footer id="footer">
					<ul class="copyright">
						<li>&copy; Untitled. All rights reserved.</li><li>Design: <a href="http://html5up.net">HTML5 UP</a></li>
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

	</body>
</html>