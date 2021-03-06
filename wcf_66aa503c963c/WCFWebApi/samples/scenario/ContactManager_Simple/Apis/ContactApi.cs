﻿// <copyright>
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>

namespace ContactManager_Simple
{
    using System;
    using Microsoft.ApplicationServer.Http.Dispatcher;
    using System.Net;
    using System.Net.Http;
    using System.ServiceModel.Web;

    public class ContactApi
    {
        private readonly IContactRepository repository;

        public ContactApi() : this(new ContactRepository())
        {
        }

        public ContactApi(IContactRepository repository)
        {
            this.repository = repository;
        }

        [WebGet(UriTemplate = "{id}")]
        public HttpResponseMessage<Contact> Get(int id)
        {
            var contact = this.repository.Get(id);
            if (contact == null)
            {
                var response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.NotFound;
                response.Content = new StringContent("Contact not found");
                throw new HttpResponseException(response);
            }
            var contactResponse = new HttpResponseMessage<Contact>(contact);

            //set it to expire in 5 minutes
            contactResponse.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(30));
            return contactResponse;
        }

        [WebInvoke(UriTemplate = "{id}")]
        public Contact Put(int id, Contact contact)
        {
            this.repository.Get(id);
            this.repository.Update(contact);
            return contact;
        }

        [WebInvoke(UriTemplate = "{id}")]
        public Contact Delete(int id)
        {
            var deleted = this.repository.Get(id);
            this.repository.Delete(id);
            return deleted;
        }
    }
}
