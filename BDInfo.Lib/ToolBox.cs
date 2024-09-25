﻿//============================================================================
// BDInfo - Blu-ray Video and Audio Analysis Tool
// Copyright © 2010 Cinema Squid
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//=============================================================================

using System.Globalization;
using System;
using System.Text;

namespace BDInfo.Lib
{
    public class ToolBox
    {
        public static string FormatFileSize(double fSize, bool humanReadable)
        {
            if (fSize <= 0)
            {
                return "0";
            }

            var units = new[] { "B", "KB", "MB", "GB", "TB", "PB", "EB" };

            var digitGroups = 0;
            if (humanReadable)
            {
                digitGroups = (int)(Math.Log10(fSize) / Math.Log10(1024));
            }

            return string.Format(CultureInfo.InvariantCulture, "{0:N2} {1}", fSize / Math.Pow(1024, digitGroups), units[digitGroups]);
        }

        public static string ReadString(
            byte[] data,
            int count,
            ref int pos)
        {
            string val =
                Encoding.ASCII.GetString(data, pos, count);

            pos += count;

            return val;
        }

        public static string GetSafeFileName(string fileName)
        {
            string outFileName = fileName;

            foreach (char lDisallowed in System.IO.Path.GetInvalidFileNameChars())
            {
                outFileName = outFileName.Replace(lDisallowed.ToString(), "");
            }
            foreach (char lDisallowed in System.IO.Path.GetInvalidPathChars())
            {
                outFileName = outFileName.Replace(lDisallowed.ToString(), "");
            }

            return outFileName;
        }
    }
}