using Microsoft.EntityFrameworkCore;
using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Models
{
    //[Keyless]
   
    public class Comment
    {
        [Key]
        public int CommentsId { get; set; }
        public Animal? Animal { get; set; }
        public string? CommentMessage { get; set; }
    }
}
