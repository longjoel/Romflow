

/// <reference path="js/jquery-1.9.1.js" />
/// <reference path="RomFlowJS.js" />
$(document).ready(function () {

    var selectedTab = 0;
    var maxTabs = 0;

    var NotifyEmulatorClosed = function () { };

    //    $("body").css("overflow", "hidden");
    //    $("body").css("overflow", "auto");
    //    document.body.scroll = "no"; // ie only

    var addTab = function (parent, id, title, body) {
        var titleHTML = '<li><a href="#tabs-' + id + '">' + title + '</a></li>';
        $('#tabs > ul').append(titleHTML);

        var bdx = '<div id="tabs-' + id + '">' + body + '</div>';
        $('#tabs').append(bdx);
        //alert(title +' --'+ bdx);
    };



    var gameDom = RomFlowJS.CLIENT.JSONDocGetContent(); // eval(window.external.GetGameDom());
    maxTabs = gameDom.length;

    for (i = 0; i < gameDom.length; i++) {
        var body = '<ul>';
        var romList = gameDom[i].Roms;

        for (j = 0; j < romList.length; j++) {



            body += '<li>' +
                '<span id="' + gameDom[i].Emulator + '-' + romList[j] +
                '" href = "" onclick="RomFlowJS.CLIENT.ExecuteRom(&quot;' + gameDom[i].Emulator + '&quot;, &quot;' + romList[j] + '&quot;);" >' +
                romList[j] + '</span>' + '</li>';
        }
        body += '</ul>';

        addTab('#tabs', i, gameDom[i].Emulator, body);
    }



    $('#tabs').tabs();




});