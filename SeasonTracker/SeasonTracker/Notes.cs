using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeasonTracker
{
    class Notes
    {
        /*
         * 
         * Hierarchy of Call Tree
         *                              
         *          Home.cs (Form - communciates with database.cs or TvShow. Events can be raised at each class, but Home needs to subscribe to the events. 
         *          |               |   
         *          Database.cs     TvShow.cs   (at this level, Database and TvShow do not communicate with each other)
         * 
         * 
         * 
         * 
         * 
         * **************************************************************************************************************************************** 
         *  TODO's:
         * ****************************************************************************************************************************************
         * 
         * 1. Create a way to display status or issues from all of the try/catch. And especially around the open connections
         * 2. Figure out how to create an install package which includes automatically creating the database on install to a new computer
         * 
         * 
         * 
         * 
         * **************************************************************************************************************************************** 
         *  Design Notes:
         * ****************************************************************************************************************************************
         * 
         * SQL Table:
              Database Name:
              Table Name:
              Columns:
                  ID
                  Show Name
                  Season
                  Total Episodes
                  Watch List

              Example: 1 | Big Bang Theory | 4 | 10 | YYYNNNNNNN
         * 
         * Storing images for artwork display:
         *      1. Determine the location of the binary.
         *      2. When a cover artwork is downloaded, a folder is created based off the ID stored in the table
         *      3. If there is no artwork there, default to the image in a default folder
         *      
         *      Example: 
         *          bin\debug\seasontracker.exe
         *          bin\debug\artwork
         *                          ...\default\default.png
         *                          ...\1\art.png
         *                          ...\2\art.png
         * 
         * ****************************************************************************************************************************************
         * Reference Materials:
         * **************************************************************************************************************************************** 
         * 
         * Flat UI design tutorial:
         *      https://www.youtube.com/watch?v=nLfzH4xOVqo&feature=youtu.be
         * 
         * Color Picker:
         *      https://color.adobe.com/create/color-wheel/
         * 
         * Icon Picker:
         *      https://www.iconfinder.com/
         *  
         *  Handling Events:
         *      https://docs.microsoft.com/en-us/dotnet/standard/events/
         *  
         *  Threading:
         *      https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread?view=netframework-4.7.2
         *      
         *  Classes:
         *      https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/classes
         *      
         *  Button Sytling:
         *      http://www.bootcss.com/p/flat-ui/
         *      
         *  DPI Aware Scaling Issue (IMPORTANT)
         *      https://stackoverflow.com/questions/13228185/how-to-configure-an-app-to-run-correctly-on-a-machine-with-a-high-dpi-setting-e/13228495#13228495
         *      To make the application aware of high resolution screens, such that when you run it, things aren't blurry, do the following:
         *      1. Project --> Add New Item
         *      2. Select "Application Manifest File"
         *      3. Uncomment the lines:
         *      <application xmlns="urn:schemas-microsoft-com:asm.v3">
         *          <windowsSettings>
         *              <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
         *          </windowsSettings>
         *      </application>
         *      
         *  Passing Data Between Forms
         *      https://www.codeproject.com/Articles/14122/Passing-Data-Between-Forms
         *      
         *      
         */

    }
}
