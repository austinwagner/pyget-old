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
    ///     A OneGet provider that manages Python packages. Wraps Pip.
    /// </summary>
    public class PyPiProvider
    {
        #region Constants

        /// <summary>
        ///     The provider name for use by OneGet.
        /// </summary>
        public const string ProviderName = "PyPi";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds a package source.
        /// </summary>
        /// <param name="name">
        /// The name of the package source.
        /// </param>
        /// <param name="location">
        /// The URL of the package index.
        /// </param>
        /// <param name="trusted">
        /// If the package source should be considered as trusted.
        /// </param>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        public void AddPackageSource(
            string name, 
            string location, 
            bool trusted, 
            Func<string, IEnumerable<object>, object> c)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches all of the package sources for a package meeting the optional version requirements. Calls
        ///     <see cref="Delegates.YieldPackage"/> for each match.
        /// </summary>
        /// <param name="name">
        /// The string to search for.
        /// </param>
        /// <param name="requiredVersion">
        /// Optional. The explicit version requirement.
        /// </param>
        /// <param name="minimumVersion">
        /// Optional. The minimum version requirement.
        /// </param>
        /// <param name="maximumVersion">
        /// Optional. The maximum version requirement.
        /// </param>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <returns>
        /// True if a matching package was found, otherwise false.
        /// </returns>
        public bool FindPackage(
            string name, 
            string requiredVersion, 
            string minimumVersion, 
            string maximumVersion, 
            Func<string, IEnumerable<object>, object> c)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds a package at a file path.
        /// </summary>
        /// <param name="filePath">
        /// The path to the package.
        /// </param>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <returns>
        /// True if the package exists, otherwise false.
        /// </returns>
        public bool FindPackageByFile(string filePath, Func<string, IEnumerable<object>, object> c)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the installation option definitions. Calls <see cref="Delegates.YieldInstallationOptionsDefinition"/>
        ///     for each definition.
        /// </summary>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        public void GetInstallationOptionDefinitions(Func<string, IEnumerable<object>, object> c)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the installed packages. Calls <see cref="Delegates.YieldPackage"/> for each installed package.
        /// </summary>
        /// <param name="name">
        /// Optional. The name of a package.
        /// </param>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <returns>
        /// True if package listing succeeded, otherwise false.
        /// </returns>
        public bool GetInstalledPackages(string name, Func<string, IEnumerable<object>, object> c)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the metadata definitions. Calls <see cref="Delegates.YieldMetadataDefinition"/> for each definition.
        /// </summary>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        public void GetMetadataDefinitions(Func<string, IEnumerable<object>, object> c)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the registered package sources. Calls <see cref="Delegates.YieldSource"/> for each source.
        /// </summary>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <returns>
        /// True if there are sources, otherwise false.
        /// </returns>
        public bool GetPackageSources(Func<string, IEnumerable<object>, object> c)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the name of this provider.
        /// </summary>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <returns>
        /// The name of this provider.
        /// </returns>
        public string GetProviderName(Func<string, IEnumerable<object>, object> c)
        {
            return ProviderName;
        }

        /// <summary>
        /// Installs a package based on a fast path. Fast path is formatted as source/package/version. Slashes (/)
        ///     and backslashes (\) are escaped with a backslash.
        /// </summary>
        /// <param name="fastPath">
        /// The package fast path to install.
        /// </param>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <returns>
        /// True if the package installed successfully, otherwise false.
        /// </returns>
        public bool InstallPackageByFastpath(string fastPath, Func<string, IEnumerable<object>, object> c)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Installs a package directly from a file.
        /// </summary>
        /// <param name="filePath">
        /// The path to the file to install.
        /// </param>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <returns>
        /// True if the package installed successfully, otherwise false.
        /// </returns>
        public bool InstallPackageByFile(string filePath, Func<string, IEnumerable<object>, object> c)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if a package source is marked as trusted.
        /// </summary>
        /// <param name="packageSource">
        /// The name of the package source.
        /// </param>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <returns>
        /// True if the source is trusted, otherwise false.
        /// </returns>
        public bool IsTrustedPackageSource(string packageSource, Func<string, IEnumerable<object>, object> c)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if a package source is valid.
        /// </summary>
        /// <param name="packageSource">
        /// The name of the package source.
        /// </param>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <returns>
        /// True if the source is valid, otherwise false.
        /// </returns>
        public bool IsValidPackageSource(string packageSource, Func<string, IEnumerable<object>, object> c)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a package source.
        /// </summary>
        /// <param name="packageSource">
        /// The name of the package source to remove.
        /// </param>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        public void RemovePackageSource(string packageSource, Func<string, IEnumerable<object>, object> c)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Uninstalls a package.
        /// </summary>
        /// <param name="fastPath">
        /// The fast path of the package.
        /// <seealso cref="InstallPackageByFastpath"/>
        /// </param>
        /// <param name="c">
        /// The PowerShell callback.
        /// </param>
        /// <returns>
        /// True if the package uninstalled successfully, otherwise false.
        /// </returns>
        public bool UninstallPackage(string fastPath, Func<string, IEnumerable<object>, object> c)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
