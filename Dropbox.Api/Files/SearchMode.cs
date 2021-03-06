// <auto-generated>
// Auto-generated by BabelAPI, do not modify.
// </auto-generated>

namespace Dropbox.Api.Files
{
    using sys = System;
    using col = System.Collections.Generic;
    using re = System.Text.RegularExpressions;

    using enc = Dropbox.Api.Babel;

    /// <summary>
    /// <para>The search mode object</para>
    /// </summary>
    public class SearchMode
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<SearchMode> Encoder = new SearchModeEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<SearchMode> Decoder = new SearchModeDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="SearchMode" /> class.</para>
        /// </summary>
        public SearchMode()
        {
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is Filename</para>
        /// </summary>
        public bool IsFilename
        {
            get
            {
                return this is Filename;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a Filename, or <c>null</c>.</para>
        /// </summary>
        public Filename AsFilename
        {
            get
            {
                return this as Filename;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is FilenameAndContent</para>
        /// </summary>
        public bool IsFilenameAndContent
        {
            get
            {
                return this is FilenameAndContent;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a FilenameAndContent, or <c>null</c>.</para>
        /// </summary>
        public FilenameAndContent AsFilenameAndContent
        {
            get
            {
                return this as FilenameAndContent;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is DeletedFilename</para>
        /// </summary>
        public bool IsDeletedFilename
        {
            get
            {
                return this is DeletedFilename;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a DeletedFilename, or <c>null</c>.</para>
        /// </summary>
        public DeletedFilename AsDeletedFilename
        {
            get
            {
                return this as DeletedFilename;
            }
        }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="SearchMode" />.</para>
        /// </summary>
        private class SearchModeEncoder : enc.StructEncoder<SearchMode>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(SearchMode value, enc.IJsonWriter writer)
            {
                if (value is Filename)
                {
                    WriteProperty(".tag", "filename", writer, enc.StringEncoder.Instance);
                    Filename.Encoder.EncodeFields((Filename)value, writer);
                    return;
                }
                if (value is FilenameAndContent)
                {
                    WriteProperty(".tag", "filename_and_content", writer, enc.StringEncoder.Instance);
                    FilenameAndContent.Encoder.EncodeFields((FilenameAndContent)value, writer);
                    return;
                }
                if (value is DeletedFilename)
                {
                    WriteProperty(".tag", "deleted_filename", writer, enc.StringEncoder.Instance);
                    DeletedFilename.Encoder.EncodeFields((DeletedFilename)value, writer);
                    return;
                }
                throw new sys.InvalidOperationException();
            }
        }

        #endregion

        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="SearchMode" />.</para>
        /// </summary>
        private class SearchModeDecoder : enc.UnionDecoder<SearchMode>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="SearchMode" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override SearchMode Create()
            {
                return new SearchMode();
            }

            /// <summary>
            /// <para>Decode based on given tag.</para>
            /// </summary>
            /// <param name="tag">The tag.</param>
            /// <param name="reader">The json reader.</param>
            /// <returns>The decoded object.</returns>
            protected override SearchMode Decode(string tag, enc.IJsonReader reader)
            {
                switch (tag)
                {
                    case "filename":
                        return Filename.Decoder.DecodeFields(reader);
                    case "filename_and_content":
                        return FilenameAndContent.Decoder.DecodeFields(reader);
                    case "deleted_filename":
                        return DeletedFilename.Decoder.DecodeFields(reader);
                    default:
                        throw new sys.InvalidOperationException();
                }
            }
        }

        #endregion

        /// <summary>
        /// <para>Search file and folder names.</para>
        /// </summary>
        public sealed class Filename : SearchMode
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<Filename> Encoder = new FilenameEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<Filename> Decoder = new FilenameDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Filename" /> class.</para>
            /// </summary>
            private Filename()
            {
            }

            /// <summary>
            /// <para>A singleton instance of Filename</para>
            /// </summary>
            public static readonly Filename Instance = new Filename();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="Filename" />.</para>
            /// </summary>
            private class FilenameEncoder : enc.StructEncoder<Filename>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(Filename value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="Filename" />.</para>
            /// </summary>
            private class FilenameDecoder : enc.StructDecoder<Filename>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="Filename" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override Filename Create()
                {
                    return new Filename();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override Filename DecodeFields(enc.IJsonReader reader)
                {
                    return Filename.Instance;
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>Search file and folder names as well as file contents.</para>
        /// </summary>
        public sealed class FilenameAndContent : SearchMode
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<FilenameAndContent> Encoder = new FilenameAndContentEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<FilenameAndContent> Decoder = new FilenameAndContentDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="FilenameAndContent" />
            /// class.</para>
            /// </summary>
            private FilenameAndContent()
            {
            }

            /// <summary>
            /// <para>A singleton instance of FilenameAndContent</para>
            /// </summary>
            public static readonly FilenameAndContent Instance = new FilenameAndContent();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="FilenameAndContent" />.</para>
            /// </summary>
            private class FilenameAndContentEncoder : enc.StructEncoder<FilenameAndContent>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(FilenameAndContent value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="FilenameAndContent" />.</para>
            /// </summary>
            private class FilenameAndContentDecoder : enc.StructDecoder<FilenameAndContent>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="FilenameAndContent"
                /// />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override FilenameAndContent Create()
                {
                    return new FilenameAndContent();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override FilenameAndContent DecodeFields(enc.IJsonReader reader)
                {
                    return FilenameAndContent.Instance;
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>Search for deleted file and folder names.</para>
        /// </summary>
        public sealed class DeletedFilename : SearchMode
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<DeletedFilename> Encoder = new DeletedFilenameEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<DeletedFilename> Decoder = new DeletedFilenameDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="DeletedFilename" />
            /// class.</para>
            /// </summary>
            private DeletedFilename()
            {
            }

            /// <summary>
            /// <para>A singleton instance of DeletedFilename</para>
            /// </summary>
            public static readonly DeletedFilename Instance = new DeletedFilename();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="DeletedFilename" />.</para>
            /// </summary>
            private class DeletedFilenameEncoder : enc.StructEncoder<DeletedFilename>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(DeletedFilename value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="DeletedFilename" />.</para>
            /// </summary>
            private class DeletedFilenameDecoder : enc.StructDecoder<DeletedFilename>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="DeletedFilename" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override DeletedFilename Create()
                {
                    return new DeletedFilename();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override DeletedFilename DecodeFields(enc.IJsonReader reader)
                {
                    return DeletedFilename.Instance;
                }
            }

            #endregion
        }
    }
}
