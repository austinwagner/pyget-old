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

    // TODO: Add doc comments
    /// <summary>
    /// PowerShell delegates taken from the Chocolatey package.
    /// </summary>
    internal static class Delegates
    {
        #region Delegates

        public delegate void AbortTransaction();

        public delegate void AddExplorerMenuItem();

        public delegate void AddFileAssociation();

        public delegate void AddFolderToPath();

        public delegate void AddPinnedItemToTaskbar(string item);

        public delegate bool AskPermission(string permission);

        public delegate void BeginTransaction();

        public delegate bool CopyFile(string sourcePath, string destinationPath);

        public delegate void CopyFolder();

        public delegate void CreateFolder(string folder);

        public delegate bool CreateShortcutLink(
            string linkPath, 
            string targetPath, 
            string description, 
            string workingDirectory, 
            string arguments);

        public delegate bool Debug(string messageCode, string message, IEnumerable<object> args = null);

        public delegate void Delete(string path);

        public delegate void DeleteFile(string filename);

        public delegate void DeleteFolder(string foler);

        public delegate void DownloadFile(string remoteLocation, string localLocation);

        public delegate void EndTransaction();

        public delegate bool Error(string messageCode, string message, IEnumerable<object> args = null);

        public delegate bool ExceptionThrown(string exceptionType, string message, string stacktrace);

        public delegate void GenerateUninstallScript();

        public delegate IEnumerable<string> GetConfiguration(string path);

        public delegate Func<string, IEnumerable<object>, object> GetHostDelegate();

        public delegate IEnumerable<string> GetInstallationOptionKeys();

        public delegate IEnumerable<string> GetInstallationOptionValues(string key);

        public delegate string GetKnownFolder(string knownFolder);

        public delegate IEnumerable<string> GetMetadataKeys();

        public delegate IEnumerable<string> GetMetadataValues(string key);

        public delegate string GetNuGetDllPath();

        public delegate string GetNuGetExePath();

        public delegate void GetSystemBinFolder();

        public delegate void GetUserBinFolder();

        public delegate void InstallMSI();

        public delegate void InstallPowershellScript();

        public delegate void InstallVSIX();

        public delegate bool IsCancelled();

        public delegate bool IsElevated();

        public delegate IEnumerable<string> LookupEnumerable(string name);

        public delegate string LookupString(string name);

        public delegate bool Message(string messageCode, string message, IEnumerable<object> args = null);

        public delegate bool OkToContinue();

        public delegate IEnumerable<string> PackageSources();

        public delegate bool Progress(
            int activityId, 
            string activity, 
            int progress, 
            string message, 
            IEnumerable<object> args = null);

        public delegate bool ProgressComplete(
            int activityId, 
            string activity, 
            string message, 
            IEnumerable<object> args = null);

        public delegate bool RemoveEnvironmentVariable(string variable, string context);

        public delegate void RemoveExplorerMenuItem();

        public delegate void RemoveFileAssociation();

        public delegate void RemoveFolderFromPath();

        public delegate void RemoveMSI();

        public delegate void RemovePinnedItemFromTaskbar(string item);

        public delegate void SearchForExecutable();

        public delegate void SetEnvironmentVariable(string variable, string value, string context);

        public delegate void ShouldContinueAfterPackageInstallFaliure(string packageName, string version, string source);

        public delegate void ShouldContinueAfterPackageUninstallFaliure(
            string packageName, 
            string version, 
            string source);

        public delegate bool ShouldContinueRunningInstallScript(
            string packageName, 
            string version, 
            string source, 
            string scriptLocation);

        public delegate bool ShouldContinueRunningUninstallScript(
            string packageName, 
            string version, 
            string source, 
            string scriptLocation);

        public delegate bool ShouldContinueWithUntrustedPackageSource(string package, string packageSource);

        public delegate bool ShouldProcessPackageInstall(string packageName, string version, string source);

        public delegate bool ShouldProcessPackageUninstall(string packageName, string version);

        public delegate void StartProcess();

        public delegate void UninstallPowershellScript();

        public delegate void UninstallVSIX();

        public delegate IEnumerable<string> UnzipFile(string zipFile, string folder);

        public delegate IEnumerable<string> UnzipFileIncremental(string zipFile, string folder);

        public delegate bool Verbose(string messageCode, string message, IEnumerable<object> args = null);

        public delegate bool Warning(string messageCode, string message, IEnumerable<object> args = null);

        public delegate bool WhatIf();

        public delegate bool YieldInstallationOptionsDefinition(
            string name, 
            string expectedType, 
            bool required, 
            IEnumerable<string> permittedValues);

        public delegate bool YieldMetadataDefinition(
            string name, 
            string expectedType, 
            IEnumerable<string> permittedValues);

        public delegate bool YieldPackage(
            string fastPath, 
            string name, 
            string version, 
            string versionScheme, 
            string summary, 
            string source);

        public delegate bool YieldSource(string name, string location, bool isTrusted);

        #endregion
    }
}