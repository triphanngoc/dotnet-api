using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace BooksApi.Core.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string UsersCollectionName   { get; set; }
    }
}
