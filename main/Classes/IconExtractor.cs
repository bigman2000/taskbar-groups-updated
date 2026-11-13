using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace client.Classes
{
    public static class IconExtractor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern uint PrivateExtractIcons(
            string szFileName,
            int nIconIndex,
            int cxIcon,
            int cyIcon,
            IntPtr[] phicon,
            uint[] piconid,
            uint nIcons,
            uint flags);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DestroyIcon(IntPtr hIcon);

        /// <summary>
        /// Extracts all icons embedded in an .exe, .dll, or .ico file.
        /// </summary>
        public static List<Bitmap> ExtractIconsFromFile(string filePath, int iconSize = 48)
        {
            List<Bitmap> icons = new List<Bitmap>();
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                return icons;

            uint count = PrivateExtractIcons(filePath, 0, 0, 0, null, null, 0, 0);
            if (count == 0 || count == uint.MaxValue)
                return icons;

            IntPtr[] hIcons = new IntPtr[count];
            uint[] iconIds = new uint[count];
            uint extracted = PrivateExtractIcons(filePath, 0, iconSize, iconSize, hIcons, iconIds, count, 0);

            for (int i = 0; i < extracted; i++)
            {
                if (hIcons[i] != IntPtr.Zero)
                {
                    try
                    {
                        using (Icon ico = Icon.FromHandle(hIcons[i]))
                        {
                            icons.Add(new Bitmap(ico.ToBitmap()));
                        }
                    }
                    finally
                    {
                        DestroyIcon(hIcons[i]);
                    }
                }
            }

            return icons;
        }

        /// <summary>
        /// Loads a Bitmap from a graphic or .ico file without locking the source file on disk.
        /// </summary>
        public static Bitmap LoadIconFromImageFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                return null;

            string ext = Path.GetExtension(filePath).ToLowerInvariant();
            if (ext == ".ico")
            {
                List<Bitmap> icoBitmaps = ExtractIconsFromFile(filePath, 64);
                if (icoBitmaps.Count > 0)
                {
                    for (int i = 1; i < icoBitmaps.Count; i++)
                        icoBitmaps[i].Dispose();
                    return icoBitmaps[0];
                }

                using (Icon ico = new Icon(filePath, 64, 64))
                {
                    return new Bitmap(ico.ToBitmap());
                }
            }

            byte[] bytes = File.ReadAllBytes(filePath);
            using (MemoryStream ms = new MemoryStream(bytes))
            using (Image img = Image.FromStream(ms))
            {
                return new Bitmap(img);
            }
        }
    }
}

