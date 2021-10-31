using System;

#pragma warning disable CA1822 // Mark members as static

namespace CustomTimer.Factories
{
    /// <summary>
    /// Implements the factory method pattern
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/Factory_method_pattern</cref>
    /// </see>
    /// >
    /// for creating an object of the <see cref="Timer"/> class.
    /// </summary>
    public class TimerFactory
    {
        /// <summary>
        /// Create an object of the <see cref="Timer"/> class.
        /// </summary>
        /// <param name="name">Name of timer.</param>
        /// <param name="ticks">Count of ticks.</param>
        /// <returns>A reference to an object of the <see cref="Timer"/> class.</returns>
        public Timer CreateTimer(string name, int ticks) => (name, ticks) switch
        {
            _ when string.IsNullOrEmpty(name) => throw new ArgumentException("Name can not be null or empty.", nameof(name)),
            _ when ticks < 1 => throw new ArgumentException("Ticks can not be less than one.", nameof(ticks)),
            _ => new Timer(name, ticks),
        };
    }
}
