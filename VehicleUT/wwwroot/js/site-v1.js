var opts = document.getElementsByClassName('options'),
    infoBlock = document.getElementsByClassName('infoBlock');

function showOptions(id) {
    var opt = opts[id],
        ib = infoBlock[id];

    if (opt.style.display == 'none') {
        closeAll(),
            ib.style.height = '140px',
            opt.style.display = 'block';
    }
    else {
        closeAll();
    }
};

function closeAll() {
    for (var i = 0; i < opts.length; i++) {
        infoBlock[i].style.height = '80px',
            opts[i].style.display = 'none';
    }
};

function openModal(id) {
    document.getElementById(id).style.display = 'block';
}

function dateFormat(time) {
    var dt = new Date(time);
    var DD = ("0" + dt.getDate()).slice(-2);
    var month = new Array();
    month[0] = "January";
    month[1] = "February";
    month[2] = "March";
    month[3] = "April";
    month[4] = "May";
    month[5] = "June";
    month[6] = "July";
    month[7] = "August";
    month[8] = "September";
    month[9] = "October";
    month[10] = "November";
    month[11] = "December";
    var MM = month[dt.getMonth()];
    if (dt.getHours() > 12) {
        var hh = (dt.getHours() - 12);
        var ht = 'PM';
    }
    else {
        var hh = dt.getHours();
        var ht = 'AM';
    }
    var mm = ("0" + dt.getMinutes()).slice(-2);
    var date_string = MM + " " + DD + " " + hh + ":" + mm + " " + ht;
    return date_string;
}

function getIndex(array, event) {
    for (var i = 0; i < array.length; i++) {
        if (array[i].getAttribute('name') === event.getAttribute('name')) {
            return i;
        }
    }
    return -1;
}