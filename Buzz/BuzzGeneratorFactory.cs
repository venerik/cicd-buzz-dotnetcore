namespace Buzz
{
    public class BuzzGeneratorFactory
    {
        public static IBuzzGenerator Create()
        {
            return new Generator();
        }
    }
}
