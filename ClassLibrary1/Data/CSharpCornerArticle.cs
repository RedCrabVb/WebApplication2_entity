using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClassLibrary1.Data
{
    [Table("example_table_entity")]
    public class CSharpCornerArticle
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("createdat")]
        public DateTime CreatedAt { get; set; }
    }
}