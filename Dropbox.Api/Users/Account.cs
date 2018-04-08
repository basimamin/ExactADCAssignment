// <auto-generated>
// Auto-generated by BabelAPI, do not modify.
// </auto-generated>

namespace Dropbox.Api.Users
{
    using sys = System;
    using col = System.Collections.Generic;
    using re = System.Text.RegularExpressions;

    using enc = Dropbox.Api.Babel;

    /// <summary>
    /// <para>The amount of detail revealed about an account depends on the user being queried
    /// and the user making the query.</para>
    /// </summary>
    /// <seealso cref="BasicAccount" />
    /// <seealso cref="FullAccount" />
    public class Account
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<Account> Encoder = new AccountEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<Account> Decoder = new AccountDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Account" /> class.</para>
        /// </summary>
        /// <param name="accountId">The user's unique Dropbox ID.</param>
        /// <param name="name">Details of a user's name.</param>
        /// <param name="email">The user's e-mail address. Do not rely on this without checking
        /// the <paramref name="emailVerified" /> field. Even then, it's possible that the user
        /// has since lost access to their e-mail.</param>
        /// <param name="emailVerified">Whether the user has verified their e-mail
        /// address.</param>
        /// <param name="profilePhotoUrl">URL for the photo representing the user, if one is
        /// set.</param>
        public Account(string accountId,
                       Name name,
                       string email,
                       bool emailVerified,
                       string profilePhotoUrl = null)
        {
            if (accountId == null)
            {
                throw new sys.ArgumentNullException("accountId");
            }
            if (accountId.Length < 40)
            {
                throw new sys.ArgumentOutOfRangeException("accountId", "Length should be at least 40");
            }
            if (accountId.Length > 40)
            {
                throw new sys.ArgumentOutOfRangeException("accountId", "Length should be at most 40");
            }

            if (name == null)
            {
                throw new sys.ArgumentNullException("name");
            }

            if (email == null)
            {
                throw new sys.ArgumentNullException("email");
            }

            this.AccountId = accountId;
            this.Name = name;
            this.Email = email;
            this.EmailVerified = emailVerified;
            this.ProfilePhotoUrl = profilePhotoUrl;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Account" /> class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public Account()
        {
        }

        /// <summary>
        /// <para>The user's unique Dropbox ID.</para>
        /// </summary>
        public string AccountId { get; protected set; }

        /// <summary>
        /// <para>Details of a user's name.</para>
        /// </summary>
        public Name Name { get; protected set; }

        /// <summary>
        /// <para>The user's e-mail address. Do not rely on this without checking the <see
        /// cref="EmailVerified" /> field. Even then, it's possible that the user has since
        /// lost access to their e-mail.</para>
        /// </summary>
        public string Email { get; protected set; }

        /// <summary>
        /// <para>Whether the user has verified their e-mail address.</para>
        /// </summary>
        public bool EmailVerified { get; protected set; }

        /// <summary>
        /// <para>URL for the photo representing the user, if one is set.</para>
        /// </summary>
        public string ProfilePhotoUrl { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="Account" />.</para>
        /// </summary>
        private class AccountEncoder : enc.StructEncoder<Account>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(Account value, enc.IJsonWriter writer)
            {
                WriteProperty("account_id", value.AccountId, writer, enc.StringEncoder.Instance);
                WriteProperty("name", value.Name, writer, Dropbox.Api.Users.Name.Encoder);
                WriteProperty("email", value.Email, writer, enc.StringEncoder.Instance);
                WriteProperty("email_verified", value.EmailVerified, writer, enc.BooleanEncoder.Instance);
                if (value.ProfilePhotoUrl != null)
                {
                    WriteProperty("profile_photo_url", value.ProfilePhotoUrl, writer, enc.StringEncoder.Instance);
                }
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="Account" />.</para>
        /// </summary>
        private class AccountDecoder : enc.StructDecoder<Account>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="Account" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override Account Create()
            {
                return new Account();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(Account value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "account_id":
                        value.AccountId = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "name":
                        value.Name = Dropbox.Api.Users.Name.Decoder.Decode(reader);
                        break;
                    case "email":
                        value.Email = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "email_verified":
                        value.EmailVerified = enc.BooleanDecoder.Instance.Decode(reader);
                        break;
                    case "profile_photo_url":
                        value.ProfilePhotoUrl = enc.StringDecoder.Instance.Decode(reader);
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
