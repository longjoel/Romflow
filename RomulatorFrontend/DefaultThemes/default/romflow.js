/*
RomFlow.js

Joel Longanecker (2013)
Joel.longanecker@gmail.com

A javascript API for use with the RomFlow application. This JavaScript file allows for
bi-directional communication between RomFlow and a given theme.

*/
var RomFlowJS = (function () {
    var _callbacks = {};
    return {
        /*

        HOST functions are called from RomFlow to notify the theme that something has happened,
        including game pad input being sent, or an emulator being closed.

        */
        HOST: {
            NavigateUp: function () {
                if (typeof (_callbacks.NavigateUp) == 'function') _callbacks.NavigateUp();
            },
            NavigateDown: function () {
                if (typeof (_callbacks.NavigateDown) == 'function') _callbacks.NavigateDown();
            },
            NavigateLeft: function () {
                if (typeof (_callbacks.NavigateLeft) == 'function') _callbacks.NavigateLeft();
            },
            NavigateRight: function () {
                if (typeof (_callbacks.NavigateRight) == 'function') _callbacks.NavigateRight();
            },
            NavigateForward: function () {
                if (typeof (_callbacks.NavigateForward) == 'function') _callbacks.NavigateForward();
            },
            NavigateBackward: function () {
                if (typeof (_callbacks.NavigateBackward) == 'function') _callbacks.NavigateBackward();
            },
            OnEmulatorExit: function () {
                if (typeof (_callbacks.OnEmulatorExit) == 'function') _callbacks.OnEmulatorExit();
            }
        },
        /*

        CLIENT functions are called from the theme into the RomFlow application. This includes
        getting emulators, roms, artwork, launching a specific emulator and rom, rebooting the
        PC, or shutting it down.

        Expect frequent updates to this section.

        */
        CLIENT: {
            /*
            Returns a list of emulators as an array of strings
            */
            GetEmulators: function () {
                return window.external.GetEmulators().split('|');
            },
            /*
            Returns a list of roms for the specified emulator
            */
            GetRoms: function (emulatorName) {
                return window.external.GetRoms(emulatorName).split('|');
            },
            /*
            Returns the path of the artwork for a given emulator and ROM.
            Currently not implemented.
            */
            GetArtworkPath: function (emulatorName, romName) {
                return window.external.GetArtworkURI(emulatorName, romName);
            },

            /*
            Returns the number of times that a rom has been played.
            */
            GetPlayCount: function (emulatorName, romName) {
                return window.external.GetPlayCount(emulatorName, romName);
            },
            /*
            Returns the entire collection of emulators and roms as a JSON Document.
            */
            JSONDocGetContent: function () {
                return eval(window.external.GetGameDom());
            },
            /*
            Returns the entire collection of emulators and roms as a serialized XML string.
            */
            XMLDocGetContent: function () {
                return window.external.GetXMLGameDom();
            },
            /*
            Executes a ROM with a particular emulator.
            */
            ExecuteRom: function (emulatorName, romName) {
                window.external.Execute(emulatorName, romName);
            },
            /*
            Registers a game-pad callback to the host application.
            Used primarily for Navigation and when the emulator is closed.
            */
            RegisterCallback: function (funcName, funcFunction) {
                _callbacks[funcName] = funcFunction;
            },
            /*
            Enumerate the game pads, useful for debugging a theme.
            */
            EnumerateGamepads: function () {
                return window.external.EnumerateGamepads();
            },
            /*
            Get the state of a game-pad as a string. Useful for debugging.
            */
            GetGamepadState: function (gamepadIndex) {
                return window.external.GetGamepadState(gamepadIndex);
            },
            /*
            If a shared path has been established, return it.
            */
            GetSharePath: function () {
                return window.external.GetNetworkSharePath();
            },
            /*
            Command to reboot the PC.
            */
            RebootPC: function () {
                window.external.RestartWindows();
            },
            /*
            Command to shut down the PC.
            */
            ShutdownPC: function () {
                window.external.ShutdownWindows();
            }
        }
    };
})();