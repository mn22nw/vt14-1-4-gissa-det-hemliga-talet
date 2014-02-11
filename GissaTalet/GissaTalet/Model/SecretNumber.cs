using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GissaTalet.Model
{
    public class SecretNumber
    {      
        public const int MaxNumberOfGuesses = 7;  //
        public const int maxNumber = 100;
        public const int minNumber = 1;
        private int _number; // Innehåller det hemliga talet
        private int _count;
        private Outcome _lastOutcome;
        private List<int> _previousGuesses; // lagrar gissningar som är gjorda sedan slumptalet slumpades fram

        public bool CanMakeGuess { get { return LastOutcome != Outcome.Correct && LastOutcome != Outcome.NoMoreGuesses; } } //ger värde om gissning kan göras eller inte
        public int Count
        {
            get
            {
                return _previousGuesses.Count;
            }
        } //antalet gjorda gissningar sedan slumptalet slumpades fram

        public int? Number
        {
            get
            {
                return CanMakeGuess ? default(int?) : _number;
            }
        }// är null så länge en gissning kan göras

        public Outcome LastOutcome { get { return _lastOutcome; } } // resultat av senaste gissningen
        public IEnumerable<int> PreviousGuesses { get { return _previousGuesses; } } //

        public int secretNumber()
        {
            Random rnd = new Random();
            _number = 0;
            _number = rnd.Next(minNumber, maxNumber);
            return _number;
        }

        public void Initialize()
        {
            _number = secretNumber();
            _count = 0;
            _previousGuesses.Clear();  //tar bort det som finns
            _lastOutcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int number)
        {

            if (number < 1 || number > 100)
                {
                    throw new ArgumentOutOfRangeException("number", "Du måste ange ett värde mellan 1 och 100");
                }


            if (_count >= 7) 
            {
                return _lastOutcome = Outcome.NoMoreGuesses;
            }
            if (_previousGuesses.Contains(number))
            {
                return _lastOutcome = Outcome.PreviousGuess;
            }

            _previousGuesses.Add(number);

            if (_count < 7)
            {
                _count++;

                if (number == _number)
                {
                    return _lastOutcome = Outcome.Correct;
                }

                if (number < _number)
                {
                    return _lastOutcome = Outcome.Low;           
                }

                if (number > _number)
                {
                    return _lastOutcome = Outcome.High;
                }

                if (_count >= 7)
                {
                    return _lastOutcome = Outcome.NoMoreGuesses;
                }

            }

            return _lastOutcome = Outcome.Indefinite;
        }

        public SecretNumber()
        {
            _previousGuesses = new List<int>();
            Initialize();
           
        }

        public enum Outcome
        {
            Indefinite,
            Low,
            High,
            Correct,
            NoMoreGuesses,
            PreviousGuess
        };
    } // end class
}