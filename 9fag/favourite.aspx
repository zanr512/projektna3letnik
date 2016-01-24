<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="favourite.aspx.cs" Inherits="_9fag.favourite" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>9FAG | Favourite</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<!--[if lte IE 8]><script src="assets/js/ie/html5shiv.js"></script><![endif]-->
		<link rel="stylesheet" href="assets/css/main.css" />
		<!--[if lte IE 8]><link rel="stylesheet" href="assets/css/ie8.css" /><![endif]-->
        <script type="text/javascript" src="scripts/buttons.js"></script>
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
                            <a href="user.aspx"><asp:Label ID="label_user" runat="server" Text="User"></asp:Label></a>
                            <a class="heartactivated" href="favourite.aspx">♡</a>
                            <a class="upload" href="upload.aspx">Upload</a>
                            <li><a href="logout.aspx">Logout</a></li>
						</ul>
					</nav>
				</header>

			<!-- Banner -->
				<section id="banner">
					<h2>Favourites</h2>
				</section>

			<!-- Main -->
				<section id="main" class="container">
					<section class="box special features">
                        <script src="scripts/ai.0.15.0-build58334.js"></script>
                        <div class="images">
                            <p>Fejvrana slika</p>
                        </div>
                        <br />
                        <br />
                        <div class="images">
                            <p>Fejvrana slika</p>
                        </div>
                    </section>
				</section>
		    </div>
        </form>

			<!-- Footer -->
				<footer id="footer">
					<ul class="copyright">
						<li>&copy; 9Fag. All rights reserved.</li><li>Design: <a href="http://html5up.net">HTML5 UP</a></li>
					</ul>
				</footer>



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