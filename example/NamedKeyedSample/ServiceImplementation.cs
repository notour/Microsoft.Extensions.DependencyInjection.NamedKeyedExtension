namespace NamedKeyedSample
{
    /// <summary>
    /// Implementation <see cref="IService"/>
    /// </summary>
    internal sealed class ServiceImplementation : IService
    {
        private readonly string _message;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceImplementation"/> class.
        /// </summary>
        public ServiceImplementation(string message)
        {
            this._message = message;
        }

        /// <inheritdoc />
        public string GetSampleText()
        {
            return this._message;
        }
    }
}
