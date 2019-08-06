using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;

namespace PtaSheet.Classes
{

    /// <summary>
    /// The runtime class is a module designed to take a bunch of
    /// boiler code and round them into one simple method
    /// </summary>
    public static class Runtime
    {

        public enum ResourceTypes
        {
            Icons,
            Sprites,
            Types
        }

        private static string _path;
        private static Dictionary<Tuple<string, ResourceTypes>, System.Drawing.Image> _images = new Dictionary<Tuple<string, ResourceTypes>, System.Drawing.Image>();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetModuleFileName(IntPtr hModule, StringBuilder buffer, int length);

        /// <summary>
        /// Returns the startup path of this program.
        /// </summary>
        public static string StartupPath
        {
            get
            {
                if (_path == null)
                {
                    StringBuilder buffer = new StringBuilder(260);
                    GetModuleFileName(IntPtr.Zero, buffer, buffer.Capacity);
                    _path = Path.GetDirectoryName(buffer.ToString());
                }
                new FileIOPermission(FileIOPermissionAccess.PathDiscovery, _path).Demand();
                return _path;
            }
        }

        /// <summary>
        /// Loads an image into memory.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static System.Drawing.Image GetImage(string path, ResourceTypes resMod)
        {
            var t = new Tuple<string, ResourceTypes>(path, resMod);
            if (!_images.ContainsKey(t))
            {
                System.Drawing.Bitmap b = null;
                switch (resMod)
                {
                    case ResourceTypes.Icons:
                        b = ImgResources.Icons.ResourceManager.GetObject(path) as System.Drawing.Bitmap;
                        break;

                    case ResourceTypes.Sprites:
                        b = ImgResources.Sprites.ResourceManager.GetObject(path) as System.Drawing.Bitmap;
                        break;

                    case ResourceTypes.Types:
                        b = ImgResources.Types.ResourceManager.GetObject(path) as System.Drawing.Bitmap;
                        break;
                }
                _images.Add(t, b);
            }
            return _images[t];
        }

    }

}
