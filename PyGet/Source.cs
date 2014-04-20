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
    using System.Xml.Linq;

    /// <summary>
    ///     Represents a Pip source.
    /// </summary>
    public class Source
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Source"/> class.
        /// </summary>
        /// <param name="x">
        /// The <see cref="XElement"/> representing a <see cref="Source"/>.
        /// </param>
        public Source(XElement x)
            : this(
                x.Attribute("name").Value, 
                x.Attribute("location").Value, 
                bool.Parse(x.Attribute("trusted").Value), 
                (SourceType)Enum.Parse(typeof(SourceType), x.Attribute("type").Value, true))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Source"/> class.
        /// </summary>
        /// <param name="name">
        /// The name of the source.
        /// </param>
        /// <param name="location">
        /// URL of the source.
        /// </param>
        /// <param name="trusted">
        /// Whether the source is considered trusted.
        /// </param>
        /// <param name="type">
        /// The type of source.
        /// </param>
        public Source(string name, string location, bool trusted, SourceType type)
        {
            this.Name = name;
            this.Location = location;
            this.Trusted = trusted;
            this.Type = type;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the URL of the source.
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        ///     Gets the name of the source.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether the source is considered trusted.
        /// </summary>
        public bool Trusted { get; private set; }

        /// <summary>
        ///     Gets the type of source.
        /// </summary>
        public SourceType Type { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Compares two <see cref="Source" />.
        /// </summary>
        /// <param name="a">The first <see cref="Source" />.</param>
        /// <param name="b">The second <see cref="Source" />.</param>
        /// <returns>True if the <see cref="Source" /> are equal, otherwise false.</returns>
        public static bool operator ==(Source a, Source b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.Name == b.Name;
        }

        /// <summary>
        ///     Compares two <see cref="Source" />.
        /// </summary>
        /// <param name="a">The first <see cref="Source" />.</param>
        /// <param name="b">The second <see cref="Source" />.</param>
        /// <returns>False if the <see cref="Source" /> are equal, otherwise true.</returns>
        public static bool operator !=(Source a, Source b)
        {
            return !(a == b);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            var other = obj as Source;
            if (other == null)
            {
                return false;
            }

            return this.Name == other.Name;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        /// <summary>
        ///     Converts this object to <see cref="XElement" />.
        /// </summary>
        /// <returns>An <see cref="XElement" /> representing the <see cref="Source" />.</returns>
        public XElement ToXElement()
        {
            return new XElement(
                "source", 
                new XAttribute("name", this.Name), 
                new XAttribute("location", this.Location), 
                new XAttribute("trusted", this.Trusted), 
                new XAttribute("type", this.Type.ToString()));
        }

        #endregion
    }
}