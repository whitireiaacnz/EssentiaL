function SetActivePage() {
    var url = window.location.href;
    var pagename = url.substring(url.lastIndexOf("/") + 1);
    alert(pagename);

    switch (pagename) {
        case "Volume1.aspx":
            document.getElementById("imgVolume1").src = "images/btn-volume-1-over.png";
            break;
        case "Volume2.aspx":
            document.getElementById("imgVolume2").src = "images/btn-volume-2-over.png";
            break;
        case "Volume3.aspx":
            document.getElementById("imgVolume3").src = "images/btn-volume-3-over.png";
            break;
    }
}