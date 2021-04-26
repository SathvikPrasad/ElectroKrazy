@Code
    ViewData("Title") = "Home Page"
End Code



<style>


    html {
        width: 100vh;
        height: auto;
    margin:0px;
    padding:0px;
    }
    .container.body-content{
        width:100% !important;
        padding:0px;

    }
  body{
      width:100vw;
      height:100vh
  }
    .footer {
        width: 100%;
        height: 30vh;
        background-color: #5F411A;
        color: white;
        display: flex;
        justify-content: space-around;
        align-items: center;
        margin: 0px;
      
    }

    .hero {
        width: 100vw;
        height: 100vh;
        background-image: url('../../Images/ian-dooley-DJ7bWa-Gwks-unsplash 1.png');
        background-size: cover;
        background-repeat: no-repeat;
        background-position:center;
            position:relative
    }
    .welcome{
        position:absolute;
        top:10%;
        left:5%;
        color:white;
    }
        .welcome h1 {
            font-size: 100px;
            font-family: cursive;
            text-shadow: 4px 4px 2px rgba(150, 150, 150, 1);
        }
        .hero h3 {
            -webkit-tap-highlight-color: rgba(0, 0, 0, 0);
            box-sizing: border-box;
            font-weight: 500;
            line-height: 1.1;
            margin-top: 20px;
            margin-bottom: 10px;
            position: absolute;
            font-size: 44px;
            font-family: cursive;
            color: white;
            left: 6%;
            top: 40%;
        }
    h1 span {
        color: #46D4E8
    }
    .hero button {
        position: absolute;
        top: 60%;
        left: 6%;
        width: auto;
        padding: 15px;
        border: none;
        outline: none;
        background-color: #45CFE2;
        color: white;
        font-size: 40px;
        border-radius: 20px;
        box-shadow: 5px 5px 15px 5px rgba(0,0,0,0.62);
    }
        .hero button a {
            font-size: 40px;
            color:white
        }


    .card_cointainer{
        width:100vw;
        padding:20px;
        display:flex;
        justify-content:space-evenly;
        align-items:center;
        flex-wrap:wrap;
            padding-bottom:45px
    }
    .card {
        width: 30%;
        height: 290px;
        background: white;
        margin-top: 45px;
        border-radius: 20px;
        background-size: cover;
        background-repeat: no-repeat;
        background-position: center;
        transition: transform .2s;
    }

        .card:hover {
            transform: scale(1.1);
        }

</style>



<div class="hero">
    <div class="text-ceter welcome " style="text-align:center;">
        <h1>Welcome To <span>Electrokraze</span> </h1>

    </div>
    <h3>Buy electronic products at your fingertips!</h3>
    
    <button>@Html.ActionLink("Shop Now!..", "Login", "Home")</button>
</div>






<div class="card_cointainer">

    <div class="card" style="        background-image: url('../../Images/pexels-craig-dennis-205421 (1).jpg');"></div>
    <div class="card" style="        background-image: url('../../Images/pexels-jess-bailey-designs-788946 (1).jpg');"></div>
    <div class="card" style="        background-image: url('../../Images/pexels-junior-teixeira-2047905 (1).jpg');"></div>
    <div class="card" style="        background-image: url('../../Images/pexels-kindel-media-7054720 (1).jpg');"></div>
    <div class="card" style=" background-image: url('../../Images/pexels-josh-sorenson-1334597 (1).jpg');"></div>
    <div class="card" style="        background-image: url('../../Images/mouse.jpg'); " ></div>

</div>



<div class="footer">

    <p> All copy rights reserved ©2021</p>
    <p> Terms of Services</p>
    <p> Accessibility</p>

</div>


