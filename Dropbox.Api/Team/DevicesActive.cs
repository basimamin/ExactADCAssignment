// <auto-generated>
// Auto-generated by BabelAPI, do not modify.
// </auto-generated>

namespace Dropbox.Api.Team
{
    using sys = System;
    using col = System.Collections.Generic;
    using re = System.Text.RegularExpressions;

    using enc = Dropbox.Api.Babel;

    /// <summary>
    /// <para>Each of the items is an array of values, one value per day. The value is the
    /// number of devices active within a time window, ending with that day.</para>
    /// <para>If there is no data for a day, then the value will be None.</para>
    /// </summary>
    /// <seealso cref="GetDevicesReport" />
    public class DevicesActive
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<DevicesActive> Encoder = new DevicesActiveEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<DevicesActive> Decoder = new DevicesActiveDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="DevicesActive" /> class.</para>
        /// </summary>
        /// <param name="windows">Array of number of linked windows (desktop) clients with
        /// activity.</param>
        /// <param name="macos">Array of number of linked mac (desktop) clients with
        /// activity.</param>
        /// <param name="linux">Array of number of linked linus (desktop) clients with
        /// activity.</param>
        /// <param name="ios">Array of number of linked ios devices with activity.</param>
        /// <param name="android">Array of number of linked android devices with
        /// activity.</param>
        /// <param name="other">Array of number of other linked devices (blackberry, windows
        /// phone, etc)  with activity.</param>
        /// <param name="total">Array of total number of linked clients with activity.</param>
        public DevicesActive(col.IEnumerable<ulong?> windows,
                             col.IEnumerable<ulong?> macos,
                             col.IEnumerable<ulong?> linux,
                             col.IEnumerable<ulong?> ios,
                             col.IEnumerable<ulong?> android,
                             col.IEnumerable<ulong?> other,
                             col.IEnumerable<ulong?> total)
        {
            var windowsList = enc.Util.ToList(windows);

            if (windows == null)
            {
                throw new sys.ArgumentNullException("windows");
            }

            var macosList = enc.Util.ToList(macos);

            if (macos == null)
            {
                throw new sys.ArgumentNullException("macos");
            }

            var linuxList = enc.Util.ToList(linux);

            if (linux == null)
            {
                throw new sys.ArgumentNullException("linux");
            }

            var iosList = enc.Util.ToList(ios);

            if (ios == null)
            {
                throw new sys.ArgumentNullException("ios");
            }

            var androidList = enc.Util.ToList(android);

            if (android == null)
            {
                throw new sys.ArgumentNullException("android");
            }

            var otherList = enc.Util.ToList(other);

            if (other == null)
            {
                throw new sys.ArgumentNullException("other");
            }

            var totalList = enc.Util.ToList(total);

            if (total == null)
            {
                throw new sys.ArgumentNullException("total");
            }

            this.Windows = windowsList;
            this.Macos = macosList;
            this.Linux = linuxList;
            this.Ios = iosList;
            this.Android = androidList;
            this.Other = otherList;
            this.Total = totalList;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="DevicesActive" /> class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public DevicesActive()
        {
        }

        /// <summary>
        /// <para>Array of number of linked windows (desktop) clients with activity.</para>
        /// </summary>
        public col.IList<ulong?> Windows { get; protected set; }

        /// <summary>
        /// <para>Array of number of linked mac (desktop) clients with activity.</para>
        /// </summary>
        public col.IList<ulong?> Macos { get; protected set; }

        /// <summary>
        /// <para>Array of number of linked linus (desktop) clients with activity.</para>
        /// </summary>
        public col.IList<ulong?> Linux { get; protected set; }

        /// <summary>
        /// <para>Array of number of linked ios devices with activity.</para>
        /// </summary>
        public col.IList<ulong?> Ios { get; protected set; }

        /// <summary>
        /// <para>Array of number of linked android devices with activity.</para>
        /// </summary>
        public col.IList<ulong?> Android { get; protected set; }

        /// <summary>
        /// <para>Array of number of other linked devices (blackberry, windows phone, etc)
        /// with activity.</para>
        /// </summary>
        public col.IList<ulong?> Other { get; protected set; }

        /// <summary>
        /// <para>Array of total number of linked clients with activity.</para>
        /// </summary>
        public col.IList<ulong?> Total { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="DevicesActive" />.</para>
        /// </summary>
        private class DevicesActiveEncoder : enc.StructEncoder<DevicesActive>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(DevicesActive value, enc.IJsonWriter writer)
            {
                WriteListProperty("windows", value.Windows, writer, enc.UInt64Encoder.NullableInstance);
                WriteListProperty("macos", value.Macos, writer, enc.UInt64Encoder.NullableInstance);
                WriteListProperty("linux", value.Linux, writer, enc.UInt64Encoder.NullableInstance);
                WriteListProperty("ios", value.Ios, writer, enc.UInt64Encoder.NullableInstance);
                WriteListProperty("android", value.Android, writer, enc.UInt64Encoder.NullableInstance);
                WriteListProperty("other", value.Other, writer, enc.UInt64Encoder.NullableInstance);
                WriteListProperty("total", value.Total, writer, enc.UInt64Encoder.NullableInstance);
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="DevicesActive" />.</para>
        /// </summary>
        private class DevicesActiveDecoder : enc.StructDecoder<DevicesActive>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="DevicesActive" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override DevicesActive Create()
            {
                return new DevicesActive();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(DevicesActive value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "windows":
                        value.Windows = ReadList<ulong?>(reader, enc.UInt64Decoder.NullableInstance);
                        break;
                    case "macos":
                        value.Macos = ReadList<ulong?>(reader, enc.UInt64Decoder.NullableInstance);
                        break;
                    case "linux":
                        value.Linux = ReadList<ulong?>(reader, enc.UInt64Decoder.NullableInstance);
                        break;
                    case "ios":
                        value.Ios = ReadList<ulong?>(reader, enc.UInt64Decoder.NullableInstance);
                        break;
                    case "android":
                        value.Android = ReadList<ulong?>(reader, enc.UInt64Decoder.NullableInstance);
                        break;
                    case "other":
                        value.Other = ReadList<ulong?>(reader, enc.UInt64Decoder.NullableInstance);
                        break;
                    case "total":
                        value.Total = ReadList<ulong?>(reader, enc.UInt64Decoder.NullableInstance);
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
