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

    /// <summary>
    /// A OneGet plugin for PyPi
    /// </summary>
    public class PyGetPlugin
    {
        #region Public Properties

        /// <summary>
        ///     Gets the provider name.
        /// </summary>
        public IEnumerable<string> PackageProviderNames
        {
            get
            {
                yield return PyPiProvider.ProviderName;
            }
        }

        /// <summary>
        ///     Gets the name of this plugin.
        /// </summary>
        public string PluginName
        {
            get
            {
                return "PyGet";
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates the package provider.
        /// </summary>
        /// <param name="name">
        /// Ignored. There is only one package provider.
        /// </param>
        /// <returns>
        /// The provider object.
        /// </returns>
        public object CreatePackageProvider(string name)
        {
            return new PyPiProvider();
        }

        /// <summary>
        ///     Cleans up the plugin.
        /// </summary>
        public void DisposePlugin()
        {
        }

        /// <summary>
        /// Initializes the plugin.
        /// </summary>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        public void InitPlugin(Func<string, IEnumerable<object>, object> c)
        {
        }

        #endregion
    }
}
