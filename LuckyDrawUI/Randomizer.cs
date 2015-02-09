using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyDrawUI
{
    public class Randomizer<T>
    {
        private List<T> _data;
        private Random _rand = new Random();
        private int _luckyCount = 0;
        private List<T> _remainingOnes = new List<T>();

        public Randomizer(List<T> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (data.Count < 1)
            {
                throw new ArgumentException("length cannot be less than 1");
            }
            _data = data;
        }

        public int AllCount
        {
            get
            {
                return _data.Count;
            }
        }

        public int LuckyCount
        {
            get
            {
                return _luckyCount;
            }
        }

        public T GetNextValue(out int selectedIndex)
        {
            if (_remainingOnes.Count == 0)
            {
                Reset();
            }
            selectedIndex = _rand.Next(_remainingOnes.Count);
            T result = _remainingOnes[selectedIndex];
            return result;
        }

        public void Reset()
        {
            _remainingOnes = new List<T>(_data);
            _luckyCount = 0;
        }

        public void RemoveAtInex(int index)
        {
            _remainingOnes.RemoveAt(index);
            _luckyCount++;
        }
    }
}
