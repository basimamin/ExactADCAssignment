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
    /// <para>Error occurred while performing an asynchronous job from <see
    /// cref="Dropbox.Api.Sharing.Routes.SharingRoutes.UnshareFolderAsync" /> or <see
    /// cref="Dropbox.Api.Sharing.Routes.SharingRoutes.RemoveFolderMemberAsync" />.</para>
    /// </summary>
    public class JobError
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<JobError> Encoder = new JobErrorEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<JobError> Decoder = new JobErrorDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="JobError" /> class.</para>
        /// </summary>
        public JobError()
        {
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is UnshareFolderError</para>
        /// </summary>
        public bool IsUnshareFolderError
        {
            get
            {
                return this is UnshareFolderError;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a UnshareFolderError, or <c>null</c>.</para>
        /// </summary>
        public UnshareFolderError AsUnshareFolderError
        {
            get
            {
                return this as UnshareFolderError;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is
        /// RemoveFolderMemberError</para>
        /// </summary>
        public bool IsRemoveFolderMemberError
        {
            get
            {
                return this is RemoveFolderMemberError;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a RemoveFolderMemberError, or <c>null</c>.</para>
        /// </summary>
        public RemoveFolderMemberError AsRemoveFolderMemberError
        {
            get
            {
                return this as RemoveFolderMemberError;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is Other</para>
        /// </summary>
        public bool IsOther
        {
            get
            {
                return this is Other;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a Other, or <c>null</c>.</para>
        /// </summary>
        public Other AsOther
        {
            get
            {
                return this as Other;
            }
        }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="JobError" />.</para>
        /// </summary>
        private class JobErrorEncoder : enc.StructEncoder<JobError>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(JobError value, enc.IJsonWriter writer)
            {
                if (value is UnshareFolderError)
                {
                    WriteProperty(".tag", "unshare_folder_error", writer, enc.StringEncoder.Instance);
                    UnshareFolderError.Encoder.EncodeFields((UnshareFolderError)value, writer);
                    return;
                }
                if (value is RemoveFolderMemberError)
                {
                    WriteProperty(".tag", "remove_folder_member_error", writer, enc.StringEncoder.Instance);
                    RemoveFolderMemberError.Encoder.EncodeFields((RemoveFolderMemberError)value, writer);
                    return;
                }
                if (value is Other)
                {
                    WriteProperty(".tag", "other", writer, enc.StringEncoder.Instance);
                    Other.Encoder.EncodeFields((Other)value, writer);
                    return;
                }
                throw new sys.InvalidOperationException();
            }
        }

        #endregion

        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="JobError" />.</para>
        /// </summary>
        private class JobErrorDecoder : enc.UnionDecoder<JobError>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="JobError" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override JobError Create()
            {
                return new JobError();
            }

            /// <summary>
            /// <para>Decode based on given tag.</para>
            /// </summary>
            /// <param name="tag">The tag.</param>
            /// <param name="reader">The json reader.</param>
            /// <returns>The decoded object.</returns>
            protected override JobError Decode(string tag, enc.IJsonReader reader)
            {
                switch (tag)
                {
                    case "unshare_folder_error":
                        return UnshareFolderError.Decoder.DecodeFields(reader);
                    case "remove_folder_member_error":
                        return RemoveFolderMemberError.Decoder.DecodeFields(reader);
                    default:
                        return Other.Decoder.DecodeFields(reader);
                }
            }
        }

        #endregion

        /// <summary>
        /// <para>Error occurred while performing <see
        /// cref="Dropbox.Api.Sharing.Routes.SharingRoutes.UnshareFolderAsync" />
        /// action.</para>
        /// </summary>
        public sealed class UnshareFolderError : JobError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<UnshareFolderError> Encoder = new UnshareFolderErrorEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<UnshareFolderError> Decoder = new UnshareFolderErrorDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="UnshareFolderError" />
            /// class.</para>
            /// </summary>
            /// <param name="value">The value</param>
            public UnshareFolderError(Dropbox.Api.Sharing.UnshareFolderError value)
            {
                this.Value = value;
            }
            /// <summary>
            /// <para>Initializes a new instance of the <see cref="UnshareFolderError" />
            /// class.</para>
            /// </summary>
            private UnshareFolderError()
            {
            }

            /// <summary>
            /// <para>Gets the value of this instance.</para>
            /// </summary>
            public Dropbox.Api.Sharing.UnshareFolderError Value { get; private set; }

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="UnshareFolderError" />.</para>
            /// </summary>
            private class UnshareFolderErrorEncoder : enc.StructEncoder<UnshareFolderError>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(UnshareFolderError value, enc.IJsonWriter writer)
                {
                    Dropbox.Api.Sharing.UnshareFolderError.Encoder.EncodeFields(value.Value, writer);
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="UnshareFolderError" />.</para>
            /// </summary>
            private class UnshareFolderErrorDecoder : enc.StructDecoder<UnshareFolderError>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="UnshareFolderError"
                /// />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override UnshareFolderError Create()
                {
                    return new UnshareFolderError();
                }

                /// <summary>
                /// <para>Set given field.</para>
                /// </summary>
                /// <param name="value">The field value.</param>
                /// <param name="fieldName">The field name.</param>
                /// <param name="reader">The json reader.</param>
                protected override void SetField(UnshareFolderError value, string fieldName, enc.IJsonReader reader)
                {
                    switch (fieldName)
                    {
                        case "unshare_folder_error":
                            value.Value = Dropbox.Api.Sharing.UnshareFolderError.Decoder.Decode(reader);
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>Error occurred while performing <see
        /// cref="Dropbox.Api.Sharing.Routes.SharingRoutes.RemoveFolderMemberAsync" />
        /// action.</para>
        /// </summary>
        public sealed class RemoveFolderMemberError : JobError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<RemoveFolderMemberError> Encoder = new RemoveFolderMemberErrorEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<RemoveFolderMemberError> Decoder = new RemoveFolderMemberErrorDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="RemoveFolderMemberError" />
            /// class.</para>
            /// </summary>
            /// <param name="value">The value</param>
            public RemoveFolderMemberError(Dropbox.Api.Sharing.RemoveFolderMemberError value)
            {
                this.Value = value;
            }
            /// <summary>
            /// <para>Initializes a new instance of the <see cref="RemoveFolderMemberError" />
            /// class.</para>
            /// </summary>
            private RemoveFolderMemberError()
            {
            }

            /// <summary>
            /// <para>Gets the value of this instance.</para>
            /// </summary>
            public Dropbox.Api.Sharing.RemoveFolderMemberError Value { get; private set; }

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="RemoveFolderMemberError" />.</para>
            /// </summary>
            private class RemoveFolderMemberErrorEncoder : enc.StructEncoder<RemoveFolderMemberError>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(RemoveFolderMemberError value, enc.IJsonWriter writer)
                {
                    Dropbox.Api.Sharing.RemoveFolderMemberError.Encoder.EncodeFields(value.Value, writer);
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="RemoveFolderMemberError" />.</para>
            /// </summary>
            private class RemoveFolderMemberErrorDecoder : enc.StructDecoder<RemoveFolderMemberError>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="RemoveFolderMemberError"
                /// />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override RemoveFolderMemberError Create()
                {
                    return new RemoveFolderMemberError();
                }

                /// <summary>
                /// <para>Set given field.</para>
                /// </summary>
                /// <param name="value">The field value.</param>
                /// <param name="fieldName">The field name.</param>
                /// <param name="reader">The json reader.</param>
                protected override void SetField(RemoveFolderMemberError value, string fieldName, enc.IJsonReader reader)
                {
                    switch (fieldName)
                    {
                        case "remove_folder_member_error":
                            value.Value = Dropbox.Api.Sharing.RemoveFolderMemberError.Decoder.Decode(reader);
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>The other object</para>
        /// </summary>
        public sealed class Other : JobError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<Other> Encoder = new OtherEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<Other> Decoder = new OtherDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Other" /> class.</para>
            /// </summary>
            private Other()
            {
            }

            /// <summary>
            /// <para>A singleton instance of Other</para>
            /// </summary>
            public static readonly Other Instance = new Other();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="Other" />.</para>
            /// </summary>
            private class OtherEncoder : enc.StructEncoder<Other>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(Other value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="Other" />.</para>
            /// </summary>
            private class OtherDecoder : enc.StructDecoder<Other>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="Other" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override Other Create()
                {
                    return new Other();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override Other DecodeFields(enc.IJsonReader reader)
                {
                    return Other.Instance;
                }
            }

            #endregion
        }
    }
}
