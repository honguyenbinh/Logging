// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Console;

namespace Microsoft.Extensions.Logging
{
    public static class ConsoleLoggerExtensions
    {
        /// <summary>
        /// Adds a console logger named 'Console' to the factory.
        /// </summary>
        /// <param name="builder">The <see cref="LoggerFactory"/> to use.</param>
        public static ILoggerBuilder AddConsole(this ILoggerBuilder builder)
        {
            builder.Services.AddSingleton<ILoggerProvider, ConsoleLoggerProvider>();

            return builder;
        }

        /// <summary>
        /// Adds a console logger named 'Console' to the factory.
        /// </summary>
        /// <param name="builder">The <see cref="LoggerFactory"/> to use.</param>
        /// <param name="configure"></param>
        public static ILoggerBuilder AddConsole(this ILoggerBuilder builder, Action<ConsoleLoggerOptions> configure)
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            builder.AddConsole();
            builder.Services.Configure(configure);

            return builder;
        }

        /// <summary>
        /// Adds a console logger named 'Console' to the factory.
        /// </summary>
        /// <param name="builder">The <see cref="LoggerFactory"/> to use.</param>
        /// <param name="configuration"></param>
        public static ILoggerBuilder AddConsole(this ILoggerBuilder builder, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            builder.AddConsole();
            builder.Services.Configure<ConsoleLoggerOptions>(configuration);

            return builder;
        }

        /// <summary>
        /// <para>
        /// This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.
        /// </para>
        /// Adds a console logger that is enabled for <see cref="LogLevel"/>.Information or higher.
        /// </summary>
        /// <param name="factory">The <see cref="ILoggerFactory"/> to use.</param>
        [Obsolete("This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.")]
        public static ILoggerFactory AddConsole(this ILoggerFactory factory)
        {
            return factory.AddConsole(includeScopes: false);
        }

        /// <summary>
        /// <para>
        /// This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.
        /// </para>
        /// Adds a console logger that is enabled for <see cref="LogLevel"/>.Information or higher.
        /// </summary>
        /// <param name="factory">The <see cref="ILoggerFactory"/> to use.</param>
        /// <param name="includeScopes">A value which indicates whether log scope information should be displayed
        /// in the output.</param>
        [Obsolete("This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.")]
        public static ILoggerFactory AddConsole(this ILoggerFactory factory, bool includeScopes)
        {
            factory.AddConsole((n, l) => l >= LogLevel.Information, includeScopes);
            return factory;
        }

        /// <summary>
        /// <para>
        /// This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.
        /// </para>
        /// Adds a console logger that is enabled for <see cref="LogLevel"/>s of minLevel or higher.
        /// </summary>
        /// <param name="factory">The <see cref="ILoggerFactory"/> to use.</param>
        /// <param name="minLevel">The minimum <see cref="LogLevel"/> to be logged</param>
        [Obsolete("This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.")]
        public static ILoggerFactory AddConsole(this ILoggerFactory factory, LogLevel minLevel)
        {
            factory.AddConsole(minLevel, includeScopes: false);
            return factory;
        }

        /// <summary>
        /// <para>
        /// This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.
        /// </para>
        /// Adds a console logger that is enabled for <see cref="LogLevel"/>s of minLevel or higher.
        /// </summary>
        /// <param name="factory">The <see cref="ILoggerFactory"/> to use.</param>
        /// <param name="minLevel">The minimum <see cref="LogLevel"/> to be logged</param>
        /// <param name="includeScopes">A value which indicates whether log scope information should be displayed
        /// in the output.</param>
        [Obsolete("This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.")]
        public static ILoggerFactory AddConsole(
            this ILoggerFactory factory,
            LogLevel minLevel,
            bool includeScopes)
        {
            factory.AddConsole((category, logLevel) => logLevel >= minLevel, includeScopes);
            return factory;
        }

        /// <summary>
        /// <para>
        /// This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.
        /// </para>
        /// Adds a console logger that is enabled as defined by the filter function.
        /// </summary>
        /// <param name="factory">The <see cref="ILoggerFactory"/> to use.</param>
        /// <param name="filter">The category filter to apply to logs.</param>
        [Obsolete("This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.")]
        public static ILoggerFactory AddConsole(
            this ILoggerFactory factory,
            Func<string, LogLevel, bool> filter)
        {
            factory.AddConsole(filter, includeScopes: false);
            return factory;
        }

        /// <summary>
        /// <para>
        /// This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.
        /// </para>
        /// Adds a console logger that is enabled as defined by the filter function.
        /// </summary>
        /// <param name="factory">The <see cref="ILoggerFactory"/> to use.</param>
        /// <param name="filter">The category filter to apply to logs.</param>
        /// <param name="includeScopes">A value which indicates whether log scope information should be displayed
        /// in the output.</param>
        [Obsolete("This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.")]
        public static ILoggerFactory AddConsole(
            this ILoggerFactory factory,
            Func<string, LogLevel, bool> filter,
            bool includeScopes)
        {
            factory.AddProvider(new ConsoleLoggerProvider(filter, includeScopes));
            return factory;
        }


        /// <summary>
        /// <para>
        /// This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.
        /// </para>
        /// </summary>
        /// <param name="factory">The <see cref="ILoggerFactory"/> to use.</param>
        /// <param name="settings">The settings to apply to created <see cref="ConsoleLogger"/>'s.</param>
        /// <returns></returns>
        [Obsolete("This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.")]
        public static ILoggerFactory AddConsole(
            this ILoggerFactory factory,
            IConsoleLoggerSettings settings)
        {
            factory.AddProvider(new ConsoleLoggerProvider(settings));
            return factory;
        }

        /// <summary>
        /// <para>
        /// This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.
        /// </para>
        /// </summary>
        /// <param name="factory">The <see cref="ILoggerFactory"/> to use.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> to use for <see cref="IConsoleLoggerSettings"/>.</param>
        /// <returns></returns>
        [Obsolete("This method is obsolete and will be removed in a future version. The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.")]
        public static ILoggerFactory AddConsole(this ILoggerFactory factory, IConfiguration configuration)
        {
            var settings = new ConfigurationConsoleLoggerSettings(configuration);
            return factory.AddConsole(settings);
        }
    }
}