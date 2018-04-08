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
    /// <para>The write error object</para>
    /// </summary>
    public class WriteError
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<WriteError> Encoder = new WriteErrorEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<WriteError> Decoder = new WriteErrorDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="WriteError" /> class.</para>
        /// </summary>
        public WriteError()
        {
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is MalformedPath</para>
        /// </summary>
        public bool IsMalformedPath
        {
            get
            {
                return this is MalformedPath;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a MalformedPath, or <c>null</c>.</para>
        /// </summary>
        public MalformedPath AsMalformedPath
        {
            get
            {
                return this as MalformedPath;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is Conflict</para>
        /// </summary>
        public bool IsConflict
        {
            get
            {
                return this is Conflict;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a Conflict, or <c>null</c>.</para>
        /// </summary>
        public Conflict AsConflict
        {
            get
            {
                return this as Conflict;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is NoWritePermission</para>
        /// </summary>
        public bool IsNoWritePermission
        {
            get
            {
                return this is NoWritePermission;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a NoWritePermission, or <c>null</c>.</para>
        /// </summary>
        public NoWritePermission AsNoWritePermission
        {
            get
            {
                return this as NoWritePermission;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is InsufficientSpace</para>
        /// </summary>
        public bool IsInsufficientSpace
        {
            get
            {
                return this is InsufficientSpace;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a InsufficientSpace, or <c>null</c>.</para>
        /// </summary>
        public InsufficientSpace AsInsufficientSpace
        {
            get
            {
                return this as InsufficientSpace;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is DisallowedName</para>
        /// </summary>
        public bool IsDisallowedName
        {
            get
            {
                return this is DisallowedName;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a DisallowedName, or <c>null</c>.</para>
        /// </summary>
        public DisallowedName AsDisallowedName
        {
            get
            {
                return this as DisallowedName;
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
        /// <para>Encoder for  <see cref="WriteError" />.</para>
        /// </summary>
        private class WriteErrorEncoder : enc.StructEncoder<WriteError>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(WriteError value, enc.IJsonWriter writer)
            {
                if (value is MalformedPath)
                {
                    WriteProperty(".tag", "malformed_path", writer, enc.StringEncoder.Instance);
                    MalformedPath.Encoder.EncodeFields((MalformedPath)value, writer);
                    return;
                }
                if (value is Conflict)
                {
                    WriteProperty(".tag", "conflict", writer, enc.StringEncoder.Instance);
                    Conflict.Encoder.EncodeFields((Conflict)value, writer);
                    return;
                }
                if (value is NoWritePermission)
                {
                    WriteProperty(".tag", "no_write_permission", writer, enc.StringEncoder.Instance);
                    NoWritePermission.Encoder.EncodeFields((NoWritePermission)value, writer);
                    return;
                }
                if (value is InsufficientSpace)
                {
                    WriteProperty(".tag", "insufficient_space", writer, enc.StringEncoder.Instance);
                    InsufficientSpace.Encoder.EncodeFields((InsufficientSpace)value, writer);
                    return;
                }
                if (value is DisallowedName)
                {
                    WriteProperty(".tag", "disallowed_name", writer, enc.StringEncoder.Instance);
                    DisallowedName.Encoder.EncodeFields((DisallowedName)value, writer);
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
        /// <para>Decoder for  <see cref="WriteError" />.</para>
        /// </summary>
        private class WriteErrorDecoder : enc.UnionDecoder<WriteError>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="WriteError" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override WriteError Create()
            {
                return new WriteError();
            }

            /// <summary>
            /// <para>Decode based on given tag.</para>
            /// </summary>
            /// <param name="tag">The tag.</param>
            /// <param name="reader">The json reader.</param>
            /// <returns>The decoded object.</returns>
            protected override WriteError Decode(string tag, enc.IJsonReader reader)
            {
                switch (tag)
                {
                    case "malformed_path":
                        return MalformedPath.Decoder.DecodeFields(reader);
                    case "conflict":
                        return Conflict.Decoder.DecodeFields(reader);
                    case "no_write_permission":
                        return NoWritePermission.Decoder.DecodeFields(reader);
                    case "insufficient_space":
                        return InsufficientSpace.Decoder.DecodeFields(reader);
                    case "disallowed_name":
                        return DisallowedName.Decoder.DecodeFields(reader);
                    default:
                        return Other.Decoder.DecodeFields(reader);
                }
            }
        }

        #endregion

        /// <summary>
        /// <para>The malformed path object</para>
        /// </summary>
        public sealed class MalformedPath : WriteError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<MalformedPath> Encoder = new MalformedPathEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<MalformedPath> Decoder = new MalformedPathDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="MalformedPath" />
            /// class.</para>
            /// </summary>
            /// <param name="value">The value</param>
            public MalformedPath(string value)
            {
                this.Value = value;
            }
            /// <summary>
            /// <para>Initializes a new instance of the <see cref="MalformedPath" />
            /// class.</para>
            /// </summary>
            private MalformedPath()
            {
            }

            /// <summary>
            /// <para>Gets the value of this instance.</para>
            /// </summary>
            public string Value { get; private set; }

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="MalformedPath" />.</para>
            /// </summary>
            private class MalformedPathEncoder : enc.StructEncoder<MalformedPath>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(MalformedPath value, enc.IJsonWriter writer)
                {
                    if (value.Value != null)
                    {
                        WriteProperty("malformed_path", value.Value, writer, enc.StringEncoder.Instance);
                    }
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="MalformedPath" />.</para>
            /// </summary>
            private class MalformedPathDecoder : enc.StructDecoder<MalformedPath>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="MalformedPath" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override MalformedPath Create()
                {
                    return new MalformedPath();
                }

                /// <summary>
                /// <para>Set given field.</para>
                /// </summary>
                /// <param name="value">The field value.</param>
                /// <param name="fieldName">The field name.</param>
                /// <param name="reader">The json reader.</param>
                protected override void SetField(MalformedPath value, string fieldName, enc.IJsonReader reader)
                {
                    switch (fieldName)
                    {
                        case "malformed_path":
                            value.Value = enc.StringDecoder.Instance.Decode(reader);
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
        /// <para>Couldn't write to the target path because there was something in the
        /// way.</para>
        /// </summary>
        public sealed class Conflict : WriteError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<Conflict> Encoder = new ConflictEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<Conflict> Decoder = new ConflictDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Conflict" /> class.</para>
            /// </summary>
            /// <param name="value">The value</param>
            public Conflict(WriteConflictError value)
            {
                this.Value = value;
            }
            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Conflict" /> class.</para>
            /// </summary>
            private Conflict()
            {
            }

            /// <summary>
            /// <para>Gets the value of this instance.</para>
            /// </summary>
            public WriteConflictError Value { get; private set; }

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="Conflict" />.</para>
            /// </summary>
            private class ConflictEncoder : enc.StructEncoder<Conflict>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(Conflict value, enc.IJsonWriter writer)
                {
                    Dropbox.Api.Files.WriteConflictError.Encoder.EncodeFields(value.Value, writer);
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="Conflict" />.</para>
            /// </summary>
            private class ConflictDecoder : enc.StructDecoder<Conflict>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="Conflict" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override Conflict Create()
                {
                    return new Conflict();
                }

                /// <summary>
                /// <para>Set given field.</para>
                /// </summary>
                /// <param name="value">The field value.</param>
                /// <param name="fieldName">The field name.</param>
                /// <param name="reader">The json reader.</param>
                protected override void SetField(Conflict value, string fieldName, enc.IJsonReader reader)
                {
                    switch (fieldName)
                    {
                        case "conflict":
                            value.Value = Dropbox.Api.Files.WriteConflictError.Decoder.Decode(reader);
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
        /// <para>The user doesn't have permissions to write to the target location.</para>
        /// </summary>
        public sealed class NoWritePermission : WriteError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<NoWritePermission> Encoder = new NoWritePermissionEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<NoWritePermission> Decoder = new NoWritePermissionDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="NoWritePermission" />
            /// class.</para>
            /// </summary>
            private NoWritePermission()
            {
            }

            /// <summary>
            /// <para>A singleton instance of NoWritePermission</para>
            /// </summary>
            public static readonly NoWritePermission Instance = new NoWritePermission();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="NoWritePermission" />.</para>
            /// </summary>
            private class NoWritePermissionEncoder : enc.StructEncoder<NoWritePermission>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(NoWritePermission value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="NoWritePermission" />.</para>
            /// </summary>
            private class NoWritePermissionDecoder : enc.StructDecoder<NoWritePermission>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="NoWritePermission"
                /// />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override NoWritePermission Create()
                {
                    return new NoWritePermission();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override NoWritePermission DecodeFields(enc.IJsonReader reader)
                {
                    return NoWritePermission.Instance;
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>The user doesn't have enough available space (bytes) to write more
        /// data.</para>
        /// </summary>
        public sealed class InsufficientSpace : WriteError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<InsufficientSpace> Encoder = new InsufficientSpaceEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<InsufficientSpace> Decoder = new InsufficientSpaceDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="InsufficientSpace" />
            /// class.</para>
            /// </summary>
            private InsufficientSpace()
            {
            }

            /// <summary>
            /// <para>A singleton instance of InsufficientSpace</para>
            /// </summary>
            public static readonly InsufficientSpace Instance = new InsufficientSpace();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="InsufficientSpace" />.</para>
            /// </summary>
            private class InsufficientSpaceEncoder : enc.StructEncoder<InsufficientSpace>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(InsufficientSpace value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="InsufficientSpace" />.</para>
            /// </summary>
            private class InsufficientSpaceDecoder : enc.StructDecoder<InsufficientSpace>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="InsufficientSpace"
                /// />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override InsufficientSpace Create()
                {
                    return new InsufficientSpace();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override InsufficientSpace DecodeFields(enc.IJsonReader reader)
                {
                    return InsufficientSpace.Instance;
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>Dropbox will not save the file or folder because of its name.</para>
        /// </summary>
        public sealed class DisallowedName : WriteError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<DisallowedName> Encoder = new DisallowedNameEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<DisallowedName> Decoder = new DisallowedNameDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="DisallowedName" />
            /// class.</para>
            /// </summary>
            private DisallowedName()
            {
            }

            /// <summary>
            /// <para>A singleton instance of DisallowedName</para>
            /// </summary>
            public static readonly DisallowedName Instance = new DisallowedName();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="DisallowedName" />.</para>
            /// </summary>
            private class DisallowedNameEncoder : enc.StructEncoder<DisallowedName>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(DisallowedName value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="DisallowedName" />.</para>
            /// </summary>
            private class DisallowedNameDecoder : enc.StructDecoder<DisallowedName>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="DisallowedName" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override DisallowedName Create()
                {
                    return new DisallowedName();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override DisallowedName DecodeFields(enc.IJsonReader reader)
                {
                    return DisallowedName.Instance;
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>The other object</para>
        /// </summary>
        public sealed class Other : WriteError
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
