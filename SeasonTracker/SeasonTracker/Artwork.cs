using System;
using System.IO;

namespace SeasonTracker
{
    public class Artwork
    {
        private static readonly Lazy<Artwork> lazy = new Lazy<Artwork>(() => new Artwork());
        public static Artwork Instance { get { return lazy.Value; } }

        //public string BinaryPath { get; set; }
        private string _binaryPath;
        private string _artworkPath;
        //private string defaultPath;
        //private string idPath;

        /// <summary>
        /// Constructor for Artwork
        /// </summary>
        private Artwork()
        {
            _binaryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            _artworkPath = _binaryPath + @"\artwork";
        }

        public string GetSeasonArtwork(int databaseID)
        {
            //Create the folder based on the id. If it exists, no exception is thrown
            //Creates something like: ...\Debug\artwork\28\
            string showPath = Path.Combine(_artworkPath, databaseID.ToString());
            Directory.CreateDirectory(showPath);

            //Check if the artwork exists in the folder.
            //If the artwork doesn't exist in the id folder (in the form of: ...\Debug\artwork\28\28.png) then
            //copy over default image from the default folder
            //If it does exist, return the file path
            string fileName = showPath + "\\" + databaseID.ToString() + ".png";
            if (!File.Exists(fileName))
            {
                //Copy the default file into the showPath folder
                //TODO: Right now, a default.png file needs to be in the binary folder location. Figure out a better place to store it.
                //      It needs to be placed there manually for the first time.
                string defaultPath = _binaryPath + "\\default.png";
                File.Copy(defaultPath, showPath + "\\default.png", true);

                fileName = showPath + "\\default.png";
            }
      
            //return path and filename back to the calling function.
            return fileName;  
        }

        public string GetArtworkPathWithIDAndFileName(int id)
        {
            return _artworkPath + "\\" + id.ToString() + "\\" + id.ToString() + ".png";
        }
    }
}
