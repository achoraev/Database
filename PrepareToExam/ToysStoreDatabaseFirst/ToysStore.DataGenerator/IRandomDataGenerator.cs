namespace ToysStore.DataGenerator
{
    internal interface IRandomDataGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomStringRandomLength(int min, int max);
    }
}