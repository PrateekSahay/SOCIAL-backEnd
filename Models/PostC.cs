using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizartsocial_backend.Models
{
    public class Post
    {
        [Key]
        public int postId{get; set;}
        public string post{get; set;}
        public List<Comment> comments{get; set;}
        public int topicId { get; set; }
        public string userId { get; set; }
<<<<<<< HEAD
        public string userName { get; set; }
=======
        public string userName { get; set;}
>>>>>>> a161ba57f39dd8ab4f1d9ae160dd0a4253d72d4f
    }
}
