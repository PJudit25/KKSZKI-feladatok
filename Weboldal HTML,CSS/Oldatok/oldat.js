function kiszamitas() {
    var oldott = parseInt(document.getElementById('oldott').value);
    var oldoszer = parseInt(document.getElementById('oldoszer').value);
    var eredmeny = (oldott / (oldoszer + oldott)) * 100;
    document.getElementById('megoldas').innerHTML = eredmeny;
}