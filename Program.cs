namespace HashTable_day15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hash table ");
            MyMapMode<string, string> hash = new MyMapMode<string, string>(5);
            hash.Add("0","to");
            hash.Add("1", "be");
            hash.Add("2", "or");
            hash.Add("3", "not");
            hash.Add("4", "to");
            hash.Add("5", "be");

            string hash2 = hash.Get("5");
            Console.WriteLine(hash2);


        }
    }
}