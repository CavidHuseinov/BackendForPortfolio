
namespace Portfolio.Core.ValudObjects
{
    public class CreatedAtVO
    {
        public DateTime Date { get; private set; } = DateTime.UtcNow;

        private CreatedAtVO() { }
        public CreatedAtVO(DateTime date)
        {
            Date = date;
        }
        public override string ToString() =>
            (this.Date.Date) switch
            {
                var date when date == DateTime.Today => $"Bugün {Date:HH:mm}",
                var date when date == DateTime.Today.AddDays(-1) => $"Dünən {Date:HH:mm}",
                _ => Date.ToString("dd.MM.yyyy HH:mm")
            };
    }
}
