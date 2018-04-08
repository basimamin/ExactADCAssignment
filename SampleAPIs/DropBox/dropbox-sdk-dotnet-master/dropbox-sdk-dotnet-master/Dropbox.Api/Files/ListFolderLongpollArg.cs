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
    /// <para>The list folder longpoll arg object</para>
    /// </summary>
    public class ListFolderLongpollArg
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<ListFolderLongpollArg> Encoder = new ListFolderLongpollArgEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<ListFolderLongpollArg> Decoder = new ListFolderLongpollArgDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ListFolderLongpollArg" />
        /// class.</para>
        /// </summary>
        /// <param name="cursor">A cursor as returned by <see
        /// cref="Dropbox.Api.Files.Routes.FilesRoutes.ListFolderAsync" /> or <see
        /// cref="Dropbox.Api.Files.Routes.FilesRoutes.ListFolderContinueAsync" />. Cursors
        /// retrieved by setting <see cref="Dropbox.Api.Files.ListFolderArg.IncludeMediaInfo"
        /// /> to <c>true</c> are not supported.</param>
        /// <param name="timeout">A timeout in seconds. The request will block for at most this
        /// length of time, plus up to 90 seconds of random jitter added to avoid the
        /// thundering herd problem. Care should be taken when using this parameter, as some
        /// network infrastructure does not support long timeouts.</param>
        public ListFolderLongpollArg(string cursor,
                                     ulong timeout = 30)
        {
            if (cursor == null)
            {
                throw new sys.ArgumentNullException("cursor");
            }
            if (cursor.Length < 1)
            {
                throw new sys.ArgumentOutOfRangeException("cursor", "Length should be at least 1");
            }

            if (timeout < 30UL)
            {
                throw new sys.ArgumentOutOfRangeException("timeout", "Value should be greater or equal than 30");
            }
            if (timeout > 480UL)
            {
                throw new sys.ArgumentOutOfRangeException("timeout", "Value should be less of equal than 480");
            }

            this.Cursor = cursor;
            this.Timeout = timeout;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ListFolderLongpollArg" />
        /// class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public ListFolderLongpollArg()
        {
            this.Timeout = 30;
        }

        /// <summary>
        /// <para>A cursor as returned by <see
        /// cref="Dropbox.Api.Files.Routes.FilesRoutes.ListFolderAsync" /> or <see
        /// cref="Dropbox.Api.Files.Routes.FilesRoutes.ListFolderContinueAsync" />. Cursors
        /// retrieved by setting <see cref="Dropbox.Api.Files.ListFolderArg.IncludeMediaInfo"
        /// /> to <c>true</c> are not supported.</para>
        /// </summary>
        public string Cursor { get; protected set; }

        /// <summary>
        /// <para>A timeout in seconds. The request will block for at most this length of time,
        /// plus up to 90 seconds of random jitter added to avoid the thundering herd problem.
        /// Care should be taken when using this parameter, as some network infrastructure does
        /// not support long timeouts.</para>
        /// </summary>
        public ulong Timeout { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="ListFolderLongpollArg" />.</para>
        /// </summary>
        private class ListFolderLongpollArgEncoder : enc.StructEncoder<ListFolderLongpollArg>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(ListFolderLongpollArg value, enc.IJsonWriter writer)
            {
                WriteProperty("cursor", value.Cursor, writer, enc.StringEncoder.Instance);
                WriteProperty("timeout", value.Timeout, writer, enc.UInt64Encoder.Instance);
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="ListFolderLongpollArg" />.</para>
        /// </summary>
        private class ListFolderLongpollArgDecoder : enc.StructDecoder<ListFolderLongpollArg>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="ListFolderLongpollArg"
            /// />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override ListFolderLongpollArg Create()
            {
                return new ListFolderLongpollArg();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(ListFolderLongpollArg value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "cursor":
                        value.Cursor = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "timeout":
                        value.Timeout = enc.UInt64Decoder.Instance.Decode(reader);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }
        }

        #endregion
    }
}
