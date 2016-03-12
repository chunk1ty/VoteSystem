namespace VoteSystem.Web.Infrastructure.Extensions
{
    using System;
    using System.Web.Mvc;

    using HtmlTags;

    public static class CustomHtmlHelpers
    {
        public static string TimeDisplay(this HtmlHelper helper, DateTime endDate)
        {
            TimeSpan ts = endDate - DateTime.Now;

            string timeAsString = string.Empty;

            if (ts.Hours == 0 && ts.Days == 0)
            {
                timeAsString = string.Format(
                                           "{0} minute{1}",                                         
                                           ts.Minutes,
                                           ts.Minutes == 1 ? string.Empty : "s");
            }
            else if (ts.Days == 0)
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

        public static HtmlTag RateSystemStatus(this HtmlHelper helper, DateTime startDate, DateTime endDate)
        {
            if (startDate == null)
            {
                throw new ArgumentNullException("Start date can not be null");
            }

            if (endDate == null)
            {
                throw new ArgumentNullException("End date can not be null");
            }
            
            HtmlTag status = new HtmlTag("span");
           
            if (startDate <= DateTime.Now && DateTime.Now <= endDate)
            {
                status.Text("Active").AddClass("btn btn-success btn-xs");
            }
            else if (startDate > DateTime.Now)
            {
                status.Text("Upcoming").AddClass("btn btn-warning btn-xs");
            }
            else if (endDate < DateTime.Now)
            {
                status.Text("Past").AddClass("btn btn-danger btn-xs");
            }

            return status;
        }
    }
}
