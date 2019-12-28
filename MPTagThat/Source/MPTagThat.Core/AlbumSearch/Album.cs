﻿#region Copyright (C) 2020 Team MediaPortal
// Copyright (C) 2020 Team MediaPortal
// http://www.team-mediaportal.com
// 
// MPTagThat is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// MPTagThat is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with MPTagThat. If not, see <http://www.gnu.org/licenses/>.
#endregion

#region

using System;
using MPTagThat.Core.AlbumCoverSearch;
using MPTagThat.Core.Utils;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Media.Imaging;
using TagLib;

#endregion

namespace MPTagThat.Core.AlbumSearch
{
  /// <summary>
  /// The Album as returned by an AlbumSearch
  /// </summary>
  public class Album
  {
    #region ctor

    public Album()
    {
      CoverHeight = "";
      CoverWidth = "";
      Discs = new List<List<AlbumSong>>();
    }

    #endregion

    #region Properties

    public string Site { get; set; }

    public string MusicBrainzId { get; set; }

    public string Asin { get; set; }

    public string Title { get; set; }

    public string Artist { get; set; }

    public string Binding { get; set; }

    public string Label { get; set; }

    public string Year { get; set; }

    public int DiscCount { get; set; }

    public List<List<AlbumSong>> Discs { get; set; }

    public string SmallImageUrl { get; set; }

    public string MediumImageUrl { get; set; }

    public string LargeImageUrl { get; set; }

    public string CoverWidth { get; set; }

    public string CoverHeight { get; set; }

    public string ListViewText
    {
      get
      { 
        var albumSize = (CoverWidth == "0" || CoverWidth == "") ? " " : $" {CoverWidth}x{CoverHeight} ";
        return $"{Title}{albumSize}";
      }
    }

    public BitmapImage AlbumImage
    {
      get
      {
        var sUrl = LargeImageUrl ?? MediumImageUrl ?? SmallImageUrl;

        if (sUrl == null)
        {
          return null;
        }

        try
        {
          BitmapImage bitmap = new BitmapImage();
          bitmap.BeginInit();
          bitmap.UriSource = new Uri(sUrl, UriKind.Absolute);
          bitmap.CacheOption = BitmapCacheOption.OnLoad;
          bitmap.EndInit();
          return bitmap;
        }
        catch { /* On purpose */}

        return null;
      }
    }
    #endregion
  }
}
