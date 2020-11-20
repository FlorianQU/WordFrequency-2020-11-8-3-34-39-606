namespace WordFrequency
{
    public class WordCount
    {
        private string value;
        private int count;

        public WordCount(string value, int count)
        {
            this.value = value;
            this.count = count;
        }

        public string Value
        {
            get { return this.value; }
        }

        public int Count
        {
            get { return this.count; }
        }
    }
}
