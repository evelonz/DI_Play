using System;

namespace LibraryToTest
{
    public class SuperService
    {
        private readonly IDateService _dateService;

        public SuperService(IDateService dateService)
        {
            _dateService = dateService;
        }

        public string GetMessage(int number) => $"My number is {number}";

        public string GetShortDate(DateTime? date) => $"Short date is {((date != null) ? (DateTime)date : _dateService.GetDate()).ToString("yyyy-MM-dd")}.";

    }

    public interface IDateService
    {
        DateTime GetDate();
    }
}
