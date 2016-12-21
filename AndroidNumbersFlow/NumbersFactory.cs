using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidNumbersFlow
{
    public class NumbersFactory
    {
        private List<int> _currentNumbers { get; set; }
    
        private int _nextNumber { get; set; }

        private int _start { get; set; }

        private int _limit { get; set; }

        private int _gameLimit
        {
            get
            {
                return Constants.GAME_INDEX * Constants.GAME_INDEX;
            }
        }

        public NumbersFactory()
        {
            Reset();
        }

        public void Reset()
        {
            _currentNumbers = new List<int>();
            _nextNumber = 1;
            _start = 1;
            _limit = _gameLimit;
        }

        public int Score
        {
            get
            {
                return _nextNumber - 1;
            }
        }

        public int LastNumber
        {
            get
            {
                return _nextNumber;
            }
        }

        public int NextNumber
        {
            get
            {
                if(_currentNumbers.Count == 0)
                {
                    UpdateCurrentList();
                }

                var nextNumber = _currentNumbers[0];
                _currentNumbers.RemoveAt(0);
                return nextNumber;
            }
        }

        public bool ValidateNumber(int number)
        {
            if(number == _nextNumber)
            {
                _nextNumber += 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateCurrentList()
        {
            var orderedNumbers = GetNumbers(_start, _limit);
            _start += _gameLimit;
            _limit += _gameLimit;

            while(orderedNumbers.Count != 0)
            {
                var random = new Random();
                var randomIndex = 0;
                if(orderedNumbers.Count > 1)
                {
                    randomIndex = random.Next(0, orderedNumbers.Count);
                }

                var number = orderedNumbers[randomIndex];
                _currentNumbers.Add(number);
                orderedNumbers.RemoveAt(randomIndex);
            }
        }

        private List<int> GetNumbers(int start,int limit)
        {
            var numbers = new List<int>();

            for(int number = start; number <= limit; number++)
            {
                numbers.Add(number);
            }

            return numbers;
        }
    }
}