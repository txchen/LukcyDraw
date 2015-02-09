using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LuckyDrawUI
{
    public static class LuckyCore
    {
        private static Dictionary<string, Image> _thumbs = new Dictionary<string, Image>();
        private static Randomizer<string> _random;
        private static int _selectedIndex;
        private static string _selectedPictureFileName;
        private static bool _inited = false;

        public static int TotalCount
        {
            get
            {
                if (!_inited)
                {
                    return 0;
                }
                return _random.AllCount;
            }
        }
        public static int LuckyCount
        {
            get
            {
                if (!_inited)
                {
                    return 0;
                }
                return _random.LuckyCount;
            }
        }
        public static string CurrentPicUrl { get { return _selectedPictureFileName; } }
        public static Image CurrentPicThumb { get { return _thumbs[_selectedPictureFileName]; } }

        public static void LoadAndStart(List<string> pictures, int thumbwidth, int thumbheight)
        {
            if (pictures.Count < 1)
            {
                throw new ApplicationException("empty pictures");
            }
            _random = new Randomizer<string>(pictures);
            _thumbs.Clear();
            for (int i = 0; i < pictures.Count; i++)
            {
                using (Image orig = Image.FromFile(pictures[i]))
                {
                    Image thumb = orig.GetThumbnailImage(thumbwidth, thumbheight, null, IntPtr.Zero);
                    _thumbs.Add(pictures[i], thumb);
                }
            }
            _selectedIndex = 0;
            _selectedPictureFileName = pictures[0];
            _inited = true;
        }

        public static void Reset()
        {
            if (_inited)
            {
                _random.Reset();
            }
        }

        public static void NextRand()
        {
            _selectedPictureFileName = _random.GetNextValue(out _selectedIndex);
        }

        public static void Celebrate()
        {
            _random.RemoveAtInex(_selectedIndex);
        }
    }
}
