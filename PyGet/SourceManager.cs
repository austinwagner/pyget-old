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
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    /// <summary>
    ///     Maintains <see cref="Source" /> in a configuration file.
    /// </summary>
    public class SourceManager : ICollection<Source>
    {
        #region Fields

        /// <summary>
        ///     Path to the XML configuration.
        /// </summary>
        private readonly string xmlFile;

        /// <summary>
        ///     The XML configuration as LINQ-to-SQL.
        /// </summary>
        private XElement sources;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SourceManager" /> class.
        /// </summary>
        public SourceManager()
        {
            string pygetDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                "PyGet");
            this.xmlFile = Path.Combine(pygetDir, "pyget.config");
            if (!File.Exists(this.xmlFile))
            {
                Directory.CreateDirectory(pygetDir);
                string defaultConfig = Path.Combine(
                    Assembly.GetAssembly(typeof(SourceManager)).Location, 
                    "pyget.config");
                File.Copy(defaultConfig, this.xmlFile);
            }

            using (var fs = new FileStream(this.xmlFile, FileMode.Open, FileAccess.Read))
            {
                this.sources = XElement.Load(fs).Element("sources");
            }
        }

        #endregion

        #region Public Properties

        /// <inheritdoc />
        public int Count
        {
            get
            {
                return this.Elements.Count();
            }
        }

        /// <inheritdoc />
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the source elements.
        /// </summary>
        private IEnumerable<XElement> Elements
        {
            get
            {
                return this.sources.Elements("source");
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds a source to the configuration.
        /// </summary>
        /// <param name="source">
        /// The <see cref="Source"/> to add.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if a source with the same name already exists.
        /// </exception>
        public void Add(Source source)
        {
            if (
                this.Elements.Any(
                    x => source.Name.Equals(x.Attribute("name").Value, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ArgumentException("A source with the name " + source.Name + " already exists.");
            }

            this.sources.Add(source.ToXElement());
            this.Save();
        }

        /// <inheritdoc />
        public void Clear()
        {
            this.sources.RemoveAll();
            this.Save();
        }

        /// <inheritdoc />
        public bool Contains(Source item)
        {
            return this.Elements.Any(x => item.Name == x.Attribute("name").Value);
        }

        /// <inheritdoc />
        public void CopyTo(Source[] array, int arrayIndex)
        {
            int i = arrayIndex;
            foreach (var source in this)
            {
                array[i] = source;
                i++;
            }
        }

        /// <summary>
        ///     Gets the sources in the order they are defined.
        /// </summary>
        /// <returns>The configured sources.</returns>
        public IEnumerator<Source> GetEnumerator()
        {
            return this.Elements.Select(x => new Source(x)).GetEnumerator();
        }

        /// <inheritdoc />
        public bool Remove(Source item)
        {
            return this.Remove(item.Name);
        }

        /// <summary>
        /// Removes a source from the configuration.
        /// </summary>
        /// <param name="name">
        /// The name of the source.
        /// </param>
        /// <returns>
        /// True if the value was removed, otherwise false.
        /// </returns>
        public bool Remove(string name)
        {
            XElement match = this.Elements.FirstOrDefault(x => name == x.Attribute("name").Value);
            if (match == null)
            {
                return false;
            }

            match.Remove();
            this.Save();
            return true;
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>
        ///     Gets the sources in the order they are defined.
        /// </summary>
        /// <returns>The configured sources.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Save the sources to a file.
        /// </summary>
        private void Save()
        {
            this.sources.Save(this.xmlFile);
        }

        #endregion
    }
}