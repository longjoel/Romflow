/// <reference path="romflow.js"/>
/// <reference path="jquery.min.js"/>
/// <reference path="JSON.js"/>

var clickSound = new Audio('page.mp3');
clickSound.volume = 0.1;

/*

Select Item (for a given row and column, build the grid out)

*/
var select_item = function (row, col, degrees) {

    // html is the generated html that composes the game document
    var html = [];
    html.push('<ul class="root">');

    // get the number of rows in the game dom.
    var emulators = RomFlowJS.CLIENT.GetEmulators();

    // for each emulator...
    for (i = 0; i < emulators.length; i++) {
        html.push('<li>');

        // emulator name


        // get the degree away from the selected emulator and set the 
        // size of the header of each row.
        var emulator_degree = Math.abs(row - i);
        if (emulator_degree === 0) {
            html.push('<h1>' + emulators[i] + '</h1>');
        } else if (emulator_degree === 1) {
            html.push('<h2>' + emulators[i] + '</h2>');
        } else if (emulator_degree === 2) {
            html.push('<h3>' + emulators[i] + '</h3>');
        } 

        // if we are on the selected row, populate the list items
        // with 2 degrees in each direction
        if (i === row) {
            html.push('<ul>');
            var roms = RomFlowJS.CLIENT.GetRoms(emulators[i]);
            // create the minimum and maximum 
            var min = Math.max(0, col - degrees);
            var max = Math.min(col + degrees, roms.length-1);

            for (j = min; j <= max; j++) {

                var rom_degree = Math.abs(col - j);

                // fetch the rom name
                var rom_name = roms[j];
                var class_name = '';

                // calculate the class based on the degree
                if (rom_degree === 0) {
                    class_name = '"selected"';
                } else if (rom_degree === 1) {
                    class_name = '"medium"';
                } else if (rom_degree === 2) {
                    class_name = '"small"';
                } else {
                    class_name = '"tiny"';
                }

                // build the list item
                html.push('<li class = ' + class_name + '>');

                // populate the list item

               html.push("<a href='#' data-action = 'load_rom' data-emulator = '" + emulators[i] + "' data-rom='" + roms[j] + "'>");
                if (RomFlowJS.CLIENT.GetArtworkPath(emulators[i], roms[j]) !== '') {
                    var artPath = RomFlowJS.CLIENT.GetArtworkPath(emulators[i], roms[j]);
                    html.push('<img src = "' + 'file://' + artPath + '" />');
                }
                html.push('<p>' + roms[j] + '</p>');

                html.push("</a></li>");

            }

            html.push('</ul>');
        }

        html.push('</li>');

    }
  

    html.push('</ul>');
    
    return html.join('');

};

var make_clickable = function () {
    $('ul.root li ul li a').click(function () {
        if ($(this).attr('data-action') == "load_rom") {
            var emu = $(this).attr('data-emulator');
            var rom = $(this).attr('data-rom');

            RomFlowJS.CLIENT.ExecuteRom(emu, rom);
        }
    });
};

$(document).ready(function () {

    var q_sections = 'ul.root li ul';
    var q_visible_items = 'ul.root li ul:visible li a';

    // 'global' variables row and column
    var section_index = 0;
    var item_index = 0;
    var degrees = 3;

    var next_section = function () {
        var max = RomFlowJS.CLIENT.GetEmulators().length ;
        if (section_index < max - 1) {
            section_index++;

        } else {
            section_index = 0;
        }
        item_index = 0;
        $('#root').html(select_item(section_index, item_index, degrees));
        make_clickable();
    };

    var prev_section = function () {
        var max = RomFlowJS.CLIENT.GetEmulators().length;
        if (section_index > 0) {
            section_index--;

        } else {
            section_index = max - 1;
        }


        item_index = 0;
        $('#root').html(select_item(section_index, item_index, degrees));
        make_clickable();
    };

    var prev_item = function () {

        var max = RomFlowJS.CLIENT.GetRoms(RomFlowJS.CLIENT.GetEmulators()[section_index]).length;
        if (item_index > 0) {
            item_index--;

        } else {
            item_index = max - 1;
        }

        $('#root').html(select_item(section_index, item_index, degrees));
        make_clickable();
        clickSound.play();

    };

    var next_item = function () {
        var max = RomFlowJS.CLIENT.GetRoms(RomFlowJS.CLIENT.GetEmulators()[section_index]).length;

        if (item_index < max - 1) {
            item_index++;


        } else {
            item_index = 0;
        }

        $('#root').html(select_item(section_index, item_index, degrees));
        make_clickable();
        clickSound.play();
    };

    var exec_rom = function () {
       
        $('li.selected a').eq(0).click();
    }

    RomFlowJS.CLIENT.RegisterCallback('NavigateUp', prev_section);
    RomFlowJS.CLIENT.RegisterCallback('NavigateDown', next_section);
    RomFlowJS.CLIENT.RegisterCallback('NavigateLeft', prev_item);
    RomFlowJS.CLIENT.RegisterCallback('NavigateRight', next_item);
    RomFlowJS.CLIENT.RegisterCallback('NavigateForward', exec_rom);


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


    //alert(select_item(section_index, item_index, degrees));
    $('#root').html(select_item(section_index, item_index, degrees));
    make_clickable();

});