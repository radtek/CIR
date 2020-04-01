namespace Cir.CloudConvert.Wrapper.Options
{
    /// <summary>
    /// This determines the download method.
    /// </summary>
    public enum DownloadMethod
    {
        /// <summary>
        /// Specifies no download is allowed.
        /// </summary>
        False,

        /// <summary>
        /// Specifies download is allowed as soon as the conversion is completed.
        /// </summary>
        True,

        /// <summary>
        /// Specifies download is rendered in a browser.
        /// </summary>
        Inline,
    }
}