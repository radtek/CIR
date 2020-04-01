namespace Cir.Data.Api.DataManipulation
{
    /// <summary>
    /// Stores methods used to manipulate data passed through arguments to controllers before sending them to Services.
    /// </summary>
    public static class UserIdParameterManipulator
    {
        /// <summary>
        /// Used to Convert full email to only initials of the user.
        /// aaa_bbb_vestas.com#EXT#@VestasDev.onmicrosoft.com" gets converted to aaa_bbb
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string ConvertUserIdFromPrincipalNameToInitials(string userId)
        {
            if (!userId.Contains("@"))
            {
                return userId;
            }
            else
            {
                char divisionMark = '_';

                if (userId.Contains("#EXT#@"))
                {
                    divisionMark = '_';
                }
                else
                {
                    divisionMark = '@';
                }

                var underscoreLocation = userId.LastIndexOf(divisionMark);
                var initialsFromEmail = userId.Substring(0, underscoreLocation);

                return initialsFromEmail;
            }
           
        }
    }
}