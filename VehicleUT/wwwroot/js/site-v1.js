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