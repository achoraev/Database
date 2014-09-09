namespace Company.DataGenerator
{
    public interface IRandomDataGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomStringRandomLength(int min, int max);
    }
}