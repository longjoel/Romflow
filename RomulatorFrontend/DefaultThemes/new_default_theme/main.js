function build_romflow_game_tree() {
    var html = [];
    html.push("<ul class='romflow_gametree'>");

    var emulators = RomFlowJS.CLIENT.GetEmulators();

    for (i = 0; i < emulators.length; i++) {
        var emulator = emulators[i];

        html.push("<li>");
        html.push("<h1>" + emulator + "</h1>");
        html.push("<ul>");

        var roms = RomFlowJS.CLIENT.GetRoms(emulator);
        
        for (j = 0; j < roms.length; j++) {
            html.push("<li><a href='#'>");
            html.push(roms[j]);
            html.push("</a></li>");
        }

        html.push("</ul>");
        html.push("</li>");

    }

    html.push("</ul>");

    return html.join('');

}


$(document).ready(function () {

    $('#romflow_container').append(build_romflow_game_tree);

    // selectors used for the whole document
    var q_sections = 'ul.romflow_gametree li ul';
    var q_visible_items = 'ul.romflow_gametree li ul:visible a';

    // 'global' variables row and column
    var section_index = 0;
    var item_index = 0;

    var display_degrees = 5

    // function to select the section
    var select_section = function (index) {
        $(q_sections).hide();
        $(q_sections).eq(index).show();
    };

    // function to select 
    var select_item = function (index) {
        for (i = 0; i < $(q_visible_items).length; i++) {
            if (Math.abs(i - index) < display_degrees) {
                var degree = Math.abs(i - index);
                var ix = $(q_visible_items).eq(i);
                if (degree === 0) {
                    ix.width(100);
                    ix.height(100);
                } else if (degree === 1) {
                    ix.width(75);
                    ix.height(75);
                } else {
                    ix.width(50);
                    ix.height(50);
                }

                ix.show();
            } else {
                $(q_visible_items).eq(i).hide();
            }

        }
    };

    var next_section = function () {
        var max = $(q_sections).length;
        if (section_index < max - 1) {
            section_index++;

        } else {
            section_index = 0;
        }

        select_section(section_index);
        item_index = 0;
        select_item(item_index);
    };

    var prev_section = function () {
        var max = $(q_sections).length;
        if (section_index > 0) {
            section_index--;

        } else {
            section_index = max - 1;
        }

        select_section(section_index);
        item_index = 0;
        select_item(item_index);

    };

    var prev_item = function () {
        var max = $(q_visible_items).length;
        if (item_index > 0) {
            item_index--;

        } else {
            item_index = max - 1;
        }

        select_item(item_index);

    };

    var next_item = function () {
        var max = $(q_visible_items).length;
        if (item_index < max - 1) {
            item_index++;

        } else {
            item_index = 0;
        }

        select_item(item_index);
    };

    RomFlowJS.CLIENT.RegisterCallback('NavigateUp', prev_section);
    RomFlowJS.CLIENT.RegisterCallback('NavigateDown', next_section);
    RomFlowJS.CLIENT.RegisterCallback('NavigateLeft', prev_item);
    RomFlowJS.CLIENT.RegisterCallback('NavigateRight', next_item);


    $(document).keyup(function (event) {

        // move emulator down
        if (event.which === 40) {

            next_section();
        }
        // move emulator up
        else if (event.which === 38) {

            prev_section();
        }

        // move emulator left
        else if (event.which === 37) {

            prev_item();
        }

        // move emulator right
        else if (event.which === 39) {


            next_item();
        }



    });


    select_section(0);
    select_item(0);



});