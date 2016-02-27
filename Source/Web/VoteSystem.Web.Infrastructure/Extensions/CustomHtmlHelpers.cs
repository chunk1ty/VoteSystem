namespace VoteSystem.Web.Infrastructure.Extensions
{
    using System;
    using System.Web.Mvc;

    public static class CustomHtmlHelpers
    {
        public static string TimeDisplay(this HtmlHelper helper, DateTime endDate)
        {
            TimeSpan ts = endDate - DateTime.Now;

            string timeAsString = string.Empty;
            if (ts.Days <= 0)
            {
                timeAsString = string.Format(
                                            "{0} hour{1} {2} minute{3}",
                                            ts.Hours,
                                            ts.Hours == 1 ? string.Empty : "s",
                                            ts.Minutes,
                                            ts.Minutes == 1 ? string.Empty : "s",
                                            ts.Days);
            }
            else
            {
                timeAsString = string.Format(
                                            "{4} days {0} hour{1} {2} minute{3}",
                                            ts.Hours,
                                            ts.Hours == 1 ? string.Empty : "s",
                                            ts.Minutes,
                                            ts.Minutes == 1 ? string.Empty : "s",
                                            ts.Days);
            }

            return timeAsString;
        }
    }
}
