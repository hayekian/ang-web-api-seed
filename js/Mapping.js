

// <div id="map_canvas" style="width: 700px; height: 500px; float: left"></div>

function initMap() {
    var c = { "lat": 26.686729520004036, "lng": -80.3594970703125 };
    var myOptions = {
        zoom: 8,
        center: c,
        scaleControl: true,
        mapTypeId: google.maps.MapTypeId.HYBRID
    }
    map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);



}



function AddPin(lon, lat, title, desc, pin) {

    var p = new google.maps.LatLng(lat, lon);
    var marker = new google.maps.Marker({
        map: map,
        position: p,
        title: title,
        icon: pin
    });
    var info = new google.maps.InfoWindow({ content: '<div class="MapInfo">' + desc + '</div>' });

    google.maps.event.addListener(marker, "click", function () {
        info.open(map, marker);
    });

}