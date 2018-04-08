// <auto-generated>
// Auto-generated by BabelAPI, do not modify.
// </auto-generated>

namespace Dropbox.Api.Sharing
{
    using sys = System;
    using col = System.Collections.Generic;
    using re = System.Text.RegularExpressions;

    using enc = Dropbox.Api.Babel;

    /// <summary>
    /// <para>The list folders continue arg object</para>
    /// </summary>
    public class ListFoldersContinueArg
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<ListFoldersContinueArg> Encoder = new ListFoldersContinueArgEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<ListFoldersContinueArg> Decoder = new ListFoldersContinueArgDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ListFoldersContinueArg" />
        /// class.</para>
        /// </summary>
        /// <param name="cursor">The cursor returned by the previous API call specified in the
        /// endpoint description.</param>
        public ListFoldersContinueArg(string cursor)
        {
            if (cursor == null)
            {
                throw new sys.ArgumentNullException("cursor");
            }

            this.Cursor = cursor;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ListFoldersContinueArg" />
        /// class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public ListFoldersContinueArg()
        {
        }

        /// <summary>
        /// <para>The cursor returned by the previous API call specified in the endpoint
        /// description.</para>
        /// </summary>
        public string Cursor { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="ListFoldersContinueArg" />.</para>
        /// </summary>
        private class ListFoldersContinueArgEncoder : enc.StructEncoder<ListFoldersContinueArg>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(ListFoldersContinueArg value, enc.IJsonWriter writer)
            {
                WriteProperty("cursor", value.Cursor, writer, enc.StringEncoder.Instance);
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="ListFoldersContinueArg" />.</para>
        /// </summary>
        private class ListFoldersContinueArgDecoder : enc.StructDecoder<ListFoldersContinueArg>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="ListFoldersContinueArg"
            /// />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override ListFoldersContinueArg Create()
            {
                return new ListFoldersContinueArg();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(ListFoldersContinueArg value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "cursor":
                        value.Cursor = enc.StringDecoder.Instance.Decode(reader);
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
