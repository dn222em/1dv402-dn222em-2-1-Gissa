using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1A
{
    public class SecretNumber
    {
        //Fälten (Fields)
        private int _count;
        private int _number;

        //Konstant (Constant)
        public const int MaxNumberOfGuesses = 7;

        /// <summary>
        /// Konstruktor (Constructor)
        /// Konstruktorn har till uppgift att se till att ett SecretNumber-objekt är korrekt initierat. 
        /// Det innebär att fälten har blivit tilldelade lämpliga värden, vilket enklast görs genom att låta 
        /// konstruktorn anropa metoden Initialize(). 
        /// </summary>
        public SecretNumber()
        {
            Initialize();
        }
        
        /// <summary>
        /// Publik metod som initierar klassens fält. 
        /// </summary>
        public void Initialize()
        {
            _count = 0;

            Random numberRandom = new Random();
            _number = numberRandom.Next(1, 101);          
        }

        /// <summary>
        /// Publik metod som anropas för att göra en gissning av det hemliga talet. 
        /// Beroende om det gissade talets värde, som parametern number innehåller, 
        /// är för högt, lågt eller överensstämmer med det hemliga talet, skrivs lämpliga meddelanden ut.  
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool MakeGuess(int number)
        {
            if (_count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }

            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            _count++;

            if (number == _number)
            {
                Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försök.", _count); 
                return true;
            }

            if (number < _number)
            {
                Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar.", number, MaxNumberOfGuesses - (_count)); 
            }
            else
            {
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.",number, MaxNumberOfGuesses - (_count));
            }
          

            if ( _count == MaxNumberOfGuesses)
            {
                Console.WriteLine("Det hemliga talet är {0}", _number);
            }

            return false;
        }
    }
}
