#region License
/*
 * Copyright (c) 2014, Austin Wagner
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 * 
 * 1. Redistributions of source code must retain the above copyright notice, this
 *    list of conditions and the following disclaimer. 
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 * The views and conclusions contained in the software and documentation are those
 * of the authors and should not be interpreted as representing official policies, 
 * either expressed or implied, of the FreeBSD Project.
 */
#endregion

namespace PyGet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     Provides helper methods for working with the PowerShell callback.
    /// </summary>
    internal static class CallbackHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// Casts one delegate to another.
        /// </summary>
        /// <param name="src">
        /// The delegate to cast.
        /// </param>
        /// <typeparam name="TDelegate">
        /// The type of delegate to return.
        /// </typeparam>
        /// <returns>
        /// The delegate cast to <see cref="TDelegate"/>.
        /// </returns>
        public static TDelegate CastDelegate<TDelegate>(this Delegate src) where TDelegate : class
        {
            return Delegate.CreateDelegate(typeof(TDelegate), src.Target, src.Method, true) as TDelegate;
        }

        /// <summary>
        /// Resolve a delegate from the PowerShell callback.
        /// </summary>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <typeparam name="TDelegate">
        /// The callback to resolve.
        /// </typeparam>
        /// <returns>
        /// The PowerShell callback of type <see cref="TDelegate"/>.
        /// </returns>
        public static TDelegate GetCallback<TDelegate>(this Func<string, IEnumerable<object>, object> c)
            where TDelegate : class
        {
            Type type = typeof(TDelegate);
            if (type.BaseType != typeof(MulticastDelegate))
            {
                throw new Exception("Generic Type Incorrect");
            }

            var src = (Delegate)c(type.Name, null);
            if (src != null)
            {
                return src.CastDelegate<TDelegate>();
            }

            return default(TDelegate);
        }

        /// <summary>
        /// Gets the value of a switch from the PowerShell command.
        /// </summary>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <param name="key">
        /// The name of the switch.
        /// </param>
        /// <returns>
        /// The value of the switch.
        /// </returns>
        /// <exception cref="KeyNotFoundException">
        /// Thrown if the switch is not set.
        /// </exception>
        public static string GetSwitch(this Func<string, IEnumerable<object>, object> c, string key)
        {
            string value;
            if (!TryGetSwitch(c, key, out value))
            {
                throw new KeyNotFoundException(string.Format("Unable to find switch '{0}'", key));
            }

            return value;
        }

        /// <summary>
        /// Checks if a switch is set (if the value is "True") in the PowerShell command.
        /// </summary>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <param name="key">
        /// The name of the switch.
        /// </param>
        /// <returns>
        /// True if the switch is set, otherwise false.
        /// </returns>
        public static bool IsSwitchSet(Func<string, IEnumerable<object>, object> c, string key)
        {
            string value;
            if (!TryGetSwitch(c, key, out value))
            {
                return false;
            }

            return value == "True";
        }

        /// <summary>
        /// Attempts to get the value of a switch from the PowerShell command.
        /// </summary>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <param name="key">
        /// The name of the switch.
        /// </param>
        /// <param name="value">
        /// The value of the switch.
        /// </param>
        /// <returns>
        /// True if the switch exists, otherwise false.
        /// </returns>
        public static bool TryGetSwitch(this Func<string, IEnumerable<object>, object> c, string key, out string value)
        {
            var getKeys = GetCallback<Delegates.GetMetadataKeys>(c);
            var getValues = GetCallback<Delegates.GetMetadataValues>(c);

            value =
                getValues(
                    getKeys().FirstOrDefault(k => k.Equals(key, StringComparison.InvariantCultureIgnoreCase)) ?? key)
                    .FirstOrDefault();
            return value != null;
        }

        #endregion
    }
}