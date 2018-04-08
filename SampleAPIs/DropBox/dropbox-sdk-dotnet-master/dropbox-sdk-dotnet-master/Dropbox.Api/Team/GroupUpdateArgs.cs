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
    /// <para>The group update args object</para>
    /// </summary>
    public class GroupUpdateArgs
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<GroupUpdateArgs> Encoder = new GroupUpdateArgsEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<GroupUpdateArgs> Decoder = new GroupUpdateArgsDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="GroupUpdateArgs" />
        /// class.</para>
        /// </summary>
        /// <param name="group">Specify a group.</param>
        /// <param name="newGroupName">Optional argument. Set group name to this if
        /// provided.</param>
        /// <param name="newGroupExternalId">Optional argument. New group external ID. If the
        /// argument is None, the group's external_id won't be updated. If the argument is
        /// empty string, the group's external id will be cleared.</param>
        public GroupUpdateArgs(GroupSelector @group,
                               string newGroupName = null,
                               string newGroupExternalId = null)
        {
            if (@group == null)
            {
                throw new sys.ArgumentNullException("@group");
            }

            this.Group = @group;
            this.NewGroupName = newGroupName;
            this.NewGroupExternalId = newGroupExternalId;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="GroupUpdateArgs" />
        /// class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public GroupUpdateArgs()
        {
        }

        /// <summary>
        /// <para>Specify a group.</para>
        /// </summary>
        public GroupSelector Group { get; protected set; }

        /// <summary>
        /// <para>Optional argument. Set group name to this if provided.</para>
        /// </summary>
        public string NewGroupName { get; protected set; }

        /// <summary>
        /// <para>Optional argument. New group external ID. If the argument is None, the
        /// group's external_id won't be updated. If the argument is empty string, the group's
        /// external id will be cleared.</para>
        /// </summary>
        public string NewGroupExternalId { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="GroupUpdateArgs" />.</para>
        /// </summary>
        private class GroupUpdateArgsEncoder : enc.StructEncoder<GroupUpdateArgs>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(GroupUpdateArgs value, enc.IJsonWriter writer)
            {
                WriteProperty("group", value.Group, writer, Dropbox.Api.Team.GroupSelector.Encoder);
                if (value.NewGroupName != null)
                {
                    WriteProperty("new_group_name", value.NewGroupName, writer, enc.StringEncoder.Instance);
                }
                if (value.NewGroupExternalId != null)
                {
                    WriteProperty("new_group_external_id", value.NewGroupExternalId, writer, enc.StringEncoder.Instance);
                }
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="GroupUpdateArgs" />.</para>
        /// </summary>
        private class GroupUpdateArgsDecoder : enc.StructDecoder<GroupUpdateArgs>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="GroupUpdateArgs" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override GroupUpdateArgs Create()
            {
                return new GroupUpdateArgs();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(GroupUpdateArgs value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "group":
                        value.Group = Dropbox.Api.Team.GroupSelector.Decoder.Decode(reader);
                        break;
                    case "new_group_name":
                        value.NewGroupName = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "new_group_external_id":
                        value.NewGroupExternalId = enc.StringDecoder.Instance.Decode(reader);
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
