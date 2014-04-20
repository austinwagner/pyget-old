﻿#region License
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

namespace PyGet.Rpc
{
    using System.Threading;

    using CookComputing.XmlRpc;

    /// <summary>
    ///     A thread-safe wrapper around <see cref="IPyPiXmlRpc" />.
    /// </summary>
    public class PyPi
    {
        #region Fields

        /// <summary>
        ///     Thread-local instances of <see cref="IPyPiXmlRpc" />
        /// </summary>
        private readonly ThreadLocal<IPyPiXmlRpc> proxy;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PyPi" /> class.
        /// </summary>
        public PyPi()
        {
            this.proxy = new ThreadLocal<IPyPiXmlRpc>(XmlRpcProxyGen.Create<IPyPiXmlRpc>);
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the released package versions.
        /// </summary>
        /// <param name="url">
        /// The URL of the package index.
        /// </param>
        /// <param name="packageName">
        /// The package name.
        /// </param>
        /// <param name="showHidden">
        /// Whether to show hidden (usually older) versions.
        /// </param>
        /// <returns>
        /// An array of versions.
        /// </returns>
        public string[] GetPackageReleases(string url, string packageName, bool showHidden)
        {
            this.proxy.Value.Url = url;
            return this.proxy.Value.GetPackageReleases(packageName, showHidden);
        }

        /// <summary>
        /// Searches for a package using the given parameters.
        /// </summary>
        /// <param name="url">
        /// The URL of the package index.
        /// </param>
        /// <param name="filter">
        /// The search parameters.
        /// </param>
        /// <returns>
        /// An array of matching packages.
        /// </returns>
        public SearchResult[] Search(string url, SearchParams filter)
        {
            this.proxy.Value.Url = url;
            return this.proxy.Value.Search(filter);
        }

        #endregion
    }
}