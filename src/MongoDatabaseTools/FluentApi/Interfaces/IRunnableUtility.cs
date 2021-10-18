namespace FluentApi.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for runnable mongo utilities.
    /// </summary>
    public interface IRunnableUtility
    {
        /// <summary>
        /// Runs MongoDB database tool.
        /// </summary>
        /// <param name="informationLog">Enables standard output logging.</param>
        /// <param name="errorLog">Enables error logging.</param>
        /// <param name="processLog">Enables process info logging.</param>
        /// <returns><see cref="Task"/>.</returns>
        Task Run(bool informationLog = true, bool errorLog = true, bool processLog = false);
    }
}