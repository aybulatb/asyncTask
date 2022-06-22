namespace AsyncAwait.Task2.CodeReviewChallenge.Services;

public class PrivacyDataService : IPrivacyDataService
{
    public string GetPrivacyDataAsync()
    {
        /// мне кажется тут лучше не создавать таск, т.к. это занимает доп. ресурсы,
        /// а просто возвращать строку
        
        return "This Policy describes how async/await processes your personal data," +
               "but it may not address all possible data processing scenarios.";
    }
}
