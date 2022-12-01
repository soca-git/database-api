using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Core.Tables
{
    [Table("Log")]
    public class Log
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public string Action { get; set; }

        public string Url { get; set; }

        public string Request { get; set; }

        public int StatusCode { get; set; }

        public string Response { get; set; }

        public string Controller { get; set; }

        public string CallId { get; set; }
    }
}
