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
    /// <para>Membership Report Result. Each of the items in the storage report is an array of
    /// values, one value per day. If there is no data for a day, then the value will be
    /// None.</para>
    /// </summary>
    /// <seealso cref="Dropbox.Api.Team.BaseDfbReport" />
    public class GetMembershipReport : BaseDfbReport
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<GetMembershipReport> Encoder = new GetMembershipReportEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<GetMembershipReport> Decoder = new GetMembershipReportDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="GetMembershipReport" />
        /// class.</para>
        /// </summary>
        /// <param name="startDate">First date present in the results as 'YYYY-MM-DD' or
        /// None.</param>
        /// <param name="teamSize">Team size, for each day.</param>
        /// <param name="pendingInvites">The number of pending invites to the team, for each
        /// day.</param>
        /// <param name="membersJoined">The number of members that joined the team, for each
        /// day.</param>
        /// <param name="suspendedMembers">The number of suspended team members, for each
        /// day.</param>
        /// <param name="licenses">The total number of licenses the team has, for each
        /// day.</param>
        public GetMembershipReport(string startDate,
                                   col.IEnumerable<ulong?> teamSize,
                                   col.IEnumerable<ulong?> pendingInvites,
                                   col.IEnumerable<ulong?> membersJoined,
                                   col.IEnumerable<ulong?> suspendedMembers,
                                   col.IEnumerable<ulong?> licenses)
            : base(startDate)
        {
            var teamSizeList = enc.Util.ToList(teamSize);

            if (teamSize == null)
            {
                throw new sys.ArgumentNullException("teamSize");
            }

            var pendingInvitesList = enc.Util.ToList(pendingInvites);

            if (pendingInvites == null)
            {
                throw new sys.ArgumentNullException("pendingInvites");
            }

            var membersJoinedList = enc.Util.ToList(membersJoined);

            if (membersJoined == null)
            {
                throw new sys.ArgumentNullException("membersJoined");
            }

            var suspendedMembersList = enc.Util.ToList(suspendedMembers);

            if (suspendedMembers == null)
            {
                throw new sys.ArgumentNullException("suspendedMembers");
            }

            var licensesList = enc.Util.ToList(licenses);

            if (licenses == null)
            {
                throw new sys.ArgumentNullException("licenses");
            }

            this.TeamSize = teamSizeList;
            this.PendingInvites = pendingInvitesList;
            this.MembersJoined = membersJoinedList;
            this.SuspendedMembers = suspendedMembersList;
            this.Licenses = licensesList;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="GetMembershipReport" />
        /// class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public GetMembershipReport()
        {
        }

        /// <summary>
        /// <para>Team size, for each day.</para>
        /// </summary>
        public col.IList<ulong?> TeamSize { get; protected set; }

        /// <summary>
        /// <para>The number of pending invites to the team, for each day.</para>
        /// </summary>
        public col.IList<ulong?> PendingInvites { get; protected set; }

        /// <summary>
        /// <para>The number of members that joined the team, for each day.</para>
        /// </summary>
        public col.IList<ulong?> MembersJoined { get; protected set; }

        /// <summary>
        /// <para>The number of suspended team members, for each day.</para>
        /// </summary>
        public col.IList<ulong?> SuspendedMembers { get; protected set; }

        /// <summary>
        /// <para>The total number of licenses the team has, for each day.</para>
        /// </summary>
        public col.IList<ulong?> Licenses { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="GetMembershipReport" />.</para>
        /// </summary>
        private class GetMembershipReportEncoder : enc.StructEncoder<GetMembershipReport>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(GetMembershipReport value, enc.IJsonWriter writer)
            {
                WriteProperty("start_date", value.StartDate, writer, enc.StringEncoder.Instance);
                WriteListProperty("team_size", value.TeamSize, writer, enc.UInt64Encoder.NullableInstance);
                WriteListProperty("pending_invites", value.PendingInvites, writer, enc.UInt64Encoder.NullableInstance);
                WriteListProperty("members_joined", value.MembersJoined, writer, enc.UInt64Encoder.NullableInstance);
                WriteListProperty("suspended_members", value.SuspendedMembers, writer, enc.UInt64Encoder.NullableInstance);
                WriteListProperty("licenses", value.Licenses, writer, enc.UInt64Encoder.NullableInstance);
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="GetMembershipReport" />.</para>
        /// </summary>
        private class GetMembershipReportDecoder : enc.StructDecoder<GetMembershipReport>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="GetMembershipReport" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override GetMembershipReport Create()
            {
                return new GetMembershipReport();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(GetMembershipReport value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "start_date":
                        value.StartDate = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "team_size":
                        value.TeamSize = ReadList<ulong?>(reader, enc.UInt64Decoder.NullableInstance);
                        break;
                    case "pending_invites":
                        value.PendingInvites = ReadList<ulong?>(reader, enc.UInt64Decoder.NullableInstance);
                        break;
                    case "members_joined":
                        value.MembersJoined = ReadList<ulong?>(reader, enc.UInt64Decoder.NullableInstance);
                        break;
                    case "suspended_members":
                        value.SuspendedMembers = ReadList<ulong?>(reader, enc.UInt64Decoder.NullableInstance);
                        break;
                    case "licenses":
                        value.Licenses = ReadList<ulong?>(reader, enc.UInt64Decoder.NullableInstance);
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
