﻿using System;
using CustomTimer.Implementation;
using CustomTimer.Interfaces;

#pragma warning disable CA1822 // Mark members as static

namespace CustomTimer.Factories
{
    /// <summary>
    /// Implements the factory method pattern
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/Factory_method_pattern</cref>
    /// </see>
    /// for creating an object of the class that implements the <see cref="ICountDownNotifier"/> interface.
    /// </summary>
    public class CountDownNotifierFactory
    {
        /// <summary>
        /// Create an object of the class that implements the <see cref="ICountDownNotifier"/> interface.
        /// </summary>
        /// <param name="timer">A reference to a class CustomTimer.</param>
        /// <returns>A reference to an object of the class that implements the <see cref="ICountDownNotifier"/> interface.</returns>
        /// <exception cref="ArgumentNullException">When timer is null.</exception>
        public ICountDownNotifier CreateNotifierForTimer(Timer timer) => timer switch
        {
            null => throw new ArgumentNullException(nameof(timer), "Timer can not be null."),
            _ => new CountDownNotifier(timer),
        };
    }
}
