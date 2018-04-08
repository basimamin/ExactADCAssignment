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
    /// <para>The unshare folder arg object</para>
    /// </summary>
    public class UnshareFolderArg
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<UnshareFolderArg> Encoder = new UnshareFolderArgEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<UnshareFolderArg> Decoder = new UnshareFolderArgDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="UnshareFolderArg" />
        /// class.</para>
        /// </summary>
        /// <param name="sharedFolderId">The ID for the shared folder.</param>
        /// <param name="leaveACopy">If true, members of this shared folder will get a copy of
        /// this folder after it's unshared. Otherwise, it will be removed from their Dropbox.
        /// The current user, who is an owner, will always retain their copy.</param>
        public UnshareFolderArg(string sharedFolderId,
                                bool leaveACopy = false)
        {
            if (sharedFolderId == null)
            {
                throw new sys.ArgumentNullException("sharedFolderId");
            }
            if (!re.Regex.IsMatch(sharedFolderId, @"\A(?:[-_0-9a-zA-Z:]+)\z"))
            {
                throw new sys.ArgumentOutOfRangeException("sharedFolderId", @"Value should match pattern '\A(?:[-_0-9a-zA-Z:]+)\z'");
            }

            this.SharedFolderId = sharedFolderId;
            this.LeaveACopy = leaveACopy;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="UnshareFolderArg" />
        /// class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public UnshareFolderArg()
        {
            this.LeaveACopy = false;
        }

        /// <summary>
        /// <para>The ID for the shared folder.</para>
        /// </summary>
        public string SharedFolderId { get; protected set; }

        /// <summary>
        /// <para>If true, members of this shared folder will get a copy of this folder after
        /// it's unshared. Otherwise, it will be removed from their Dropbox. The current user,
        /// who is an owner, will always retain their copy.</para>
        /// </summary>
        public bool LeaveACopy { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="UnshareFolderArg" />.</para>
        /// </summary>
        private class UnshareFolderArgEncoder : enc.StructEncoder<UnshareFolderArg>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(UnshareFolderArg value, enc.IJsonWriter writer)
            {
                WriteProperty("shared_folder_id", value.SharedFolderId, writer, enc.StringEncoder.Instance);
                WriteProperty("leave_a_copy", value.LeaveACopy, writer, enc.BooleanEncoder.Instance);
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="UnshareFolderArg" />.</para>
        /// </summary>
        private class UnshareFolderArgDecoder : enc.StructDecoder<UnshareFolderArg>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="UnshareFolderArg" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override UnshareFolderArg Create()
            {
                return new UnshareFolderArg();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(UnshareFolderArg value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "shared_folder_id":
                        value.SharedFolderId = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "leave_a_copy":
                        value.LeaveACopy = enc.BooleanDecoder.Instance.Decode(reader);
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
