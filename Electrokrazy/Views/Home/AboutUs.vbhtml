@Code
    ViewData("Title") = "AboutUs"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code




<style>

    .aboutUs_main {
        background-color: rgba(255,255,255,0) !important;
        padding: 10px 25px;
        display: flex;
        justify-content: center;
        align-items: center
    }

    .about_card {
        width: 500px;
        height: auto;
        display: flex;
        background-color: #5F411A;
        margin: 20px auto;
        border-radius: 20px;
        padding: 30px;
        margin:20px;
        margin-top:50px;
    }


    .avatar {
        width: 150px;
        display: flex;
        align-items: center;
        justify-content: center
    }


    .details {
        height: 150px;
        display: flex;
        flex-direction: column;
        justify-content: space-evenly;
        color: white;
    }

    span {
        font-weight: bold;
        font-size: larger !important;
    }

    h1 {
        padding-left: 10px;
        font-size:22px
    }

    p {
        font-size: large;
        padding-left: 13px
    }

    .avatar div {
        background-color: white;
        border-radius: 50%;
        width: 90%;
        height: 90%;
        background-size: cover;
        background-repeat: no-repeat;
        background-position: center;
    }
    .info{
        display:flex;
        
    }
    .container {
        width:90%
    }
</style>

<div class="aboutUs_main" style=" text-align: center;

        padding: 10px 40px;
        display: flex;
        flex-direction:column;
        justify-content: center;
        align-items: center
">

    <p style="font-family:Calibri;line-height:25px;font-size:x-large;margin-top:30px">
        In the US,  most IT professionals, small businesses, students, engineers, programmers, tech enthusiasts, gamers, and electronic device customers have relied on ELECTROCRAZE for their communication and information technology support needs since 2000.
        ELECTROCRAZE provides the most affordable technology and online deals to its customers. During this pandemic period, as 1 in 5 Americans has been ordered to stay at home following the CDC guidelines, ELECTROCRAZE can provide you with the essential technical support products and services to work, learn, and receive Information from the safety of your home.
        ELECTROCRAZE focused on information technology products, such as Desktops, Laptops, Phones, and accessories devices, ranging from brands like Apple, Samsung, and others. We are here for your online shopping with delivery all over the world.
    </p>








</div>

<div class="info">
    <div class=" about_card">
        <div class="avatar"><div style=" background-image: url('../../Images/IMG_2892 (3).JPG');"></div></div>
        <div class="details">
            <div><h1> Sathvik prasad</h1></div>
            <div><p>Information Technology</p></div>
            <div><p>T01308991</p></div>

        </div>

    </div>
    <div class=" about_card">
        <div class="avatar"><div style=" background-image: url('../../Images/avatar-c.jpg');"></div></div>
        <div class="details">
            <div>
                <h1>
                    Kevin Torkelson
                </h1>
            </div>
            <div><p>Information Technology</p></div>
            <div><p>T01313635</p></div>

        </div>

    </div>
    <div class=" about_card">
        <div class="avatar"><div style=" background-image: url('../../Images/photo_2021-04-23_12-40-43.jpg');"></div></div>
        <div class="details">
            <div><h1>UG Onuegbu</h1></div>
            <div><p>Information Technology</p></div>
            <div><p>T01252631</p></div>

        </div>

    </div>

</div>


