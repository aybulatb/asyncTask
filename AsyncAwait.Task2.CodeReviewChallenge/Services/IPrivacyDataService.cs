namespace AsyncAwait.Task2.CodeReviewChallenge.Services;

public interface IPrivacyDataService
{
    /// мне кажется тут лучше не создавать таск, т.к. это занимает доп. ресурсы,
    /// а просто возвращать строку
    string GetPrivacyDataAsync();
}
