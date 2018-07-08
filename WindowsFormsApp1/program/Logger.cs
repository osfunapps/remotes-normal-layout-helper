using System;

namespace LayoutProject
{
    internal class Logger
    {
        internal static string GetTxt()
        {
            return
                "Version 1.9" +
                "\n- added mute btn skip" +
                "\n\nVersion 1.8" +
                "\n- params will now save " +
                 "\n\nVersion 1.7" +
                 "\n- fixed a bug regarding the saving of app settings on go click and load them back in time when app starts." +
                 "\n\nVersion 1.6" +
                "\n- added tinyPng support. Produce api key and use it:" +
                "\n- if you only want to use tiny png compressor, keep the xml path empty!" +
                "\n\nVersion 1.5:" +
                "\n- the program will skip device_vol+ and device_vol-" +
                "\n\nVersion 1.4:" +
                "\n- setting the background image width, height and name" +
                "\n- fixed error on end" +
                "\n\nVersion 1.3:" +
                "\n- added this window lol" +
                "\n- added an option to drag files into the window to get their path" +
                "\n- now the program will automatically continue from the last location stopped in a file" +
                "\n- the program can delete wrong tv entries in the <keys> tag" +
                "\n- added an option to run over existing arguments" +
                "\n- an error regarding the program end sequence has been fixed" +
                "\n- more minor fixes regarding the deleting of new arguments and the software speed" +
                "\n- fixed a bug which caused the program to load again and again layout params in an xml file.";
        }
    }
}