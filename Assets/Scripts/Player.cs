namespace MemoryCardGame
{
    public class Player
    {
        private int _points;
        public int Points
        {
            get => _points;
            private set
            {
                if (value < 0)
                    value = 0;

                _points = value;
            }
        }

        public void AddPoint() => Points++;
        public void SubtractPoint() => Points--;
    }
}