function show(i,n) {
    for (var p= 1; p <= n ; p++ )
    {
        var t = "#field-q" + p;
        if (p == i)
        {
            $(t).show();
        }
        else {
            $(t).hide();
        }
    }
}

function clearresponse(i) {
    var t1 = "#q" + i + "-0";
    var t2 = "#q" + i + "-1";
    var t3 = "#q" + i + "-2";
    var t4 = "#q" + i + "-3";
    $(t1).removeAttr('checked');
    $(t2).removeAttr('checked');
    $(t3).removeAttr('checked');
    $(t4).removeAttr('checked');
}

function next(i, n)
{

}

function previous(i, n) {

}

function countdown(sec) {
    var min = sec / 60;
    var sec1 = sec % 60;
    var time = Math.floor(min) + ":" + sec1;
    document.getElementById('timeout').innerHTML = time;
    sec--;
    if (sec >= 0) {
        var timer = setTimeout('countdown(' + sec + ')', 995);
    }
    else {
        clearTimeout(timer);
        document.getElementById('timeout').innerHTML = "Time Out";
        alert("Please Save The Exam within 20 Seconds and Logout. Else your test will not be valid.");
        setTimeout(timeout, 3000);
    }
}

function timeout() {
    $("#ExamForm").submit();
}

function gettime() {
    var t = document.getElementById('time').innerHTML;
    countdown(t * 60);
}