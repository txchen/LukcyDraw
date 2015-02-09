using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace LuckyDrawUI
{
    public class LuckyConfig
    {
        [CategoryAttribute("BigPicture"), DescriptionAttribute("PictureWidth")]
        public int PictureWidth { get; set; }
        [CategoryAttribute("BigPicture"), DescriptionAttribute("PictureHeight")]
        public int PictureHeight { get; set; }
        [CategoryAttribute("BigPicture"), DescriptionAttribute("IntervalInMs")]
        public int IntervalInMs { get; set; }
        [CategoryAttribute("PreLoad"), DescriptionAttribute("ThumbnailWidth")]
        public int ThumbnailWidth { get; set; }
        [CategoryAttribute("PreLoad"), DescriptionAttribute("ThumbnailHeight")]
        public int ThumbnailHeight { get; set; }

        public LuckyConfig()
        {
            PictureWidth = 800;
            PictureHeight = 600;
            ThumbnailWidth = 160;
            ThumbnailHeight = 120;
            IntervalInMs = 50;
        }
    }
}
