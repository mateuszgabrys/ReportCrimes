namespace ReportCrimes.Web
{
    public static class SD
    {
        public static string LawEnforcementAPIBase { get; set; }
        public static string CrimeAPIBase { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
