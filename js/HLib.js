function h_ToShortDateTime(d) {

    if (d != null)
        return moment(d).format("L");
    else return '';


}


function h_fixDates(obj) {

    for (x in obj) {
        var v = obj[x];
        if (typeof v == 'string' && (v.charAt(4) == '-' && v.charAt(7) == '-'))
            obj[x] = moment(v).format('L');
    }


}


function ObjDifferences(o, n) {

    var changes = {};
    for (var x in o) {

        if ($.isArray(o[x]) == false && o[x] != n[x]) {
            changes[x] = {};
            changes[x].o = o[x];
            changes[x].n = n[x];
        }
    }

    return changes;
}


function h_AddPolygon(map, points, color) {



    var pointsPoly = new Array();
    $.each(points, function (index, value) {
        var p = new google.maps.LatLng(value.Lat, value.Lon);
        pointsPoly.push(p);
    });


    var poly = new google.maps.Polygon({

        strokeWeight: 2, strokeOpacity: 1, fillColor: color

    });

    poly.setPaths(pointsPoly);
    poly.setMap(map);
    return poly;


}