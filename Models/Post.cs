using System;

namespace Models
{
    public class Post
    {
        public int id;
        public string title;
        public string author;

        public override bool Equals(object obj)
        {
            if (obj is not Post obj2) return false;
            return title == obj2.title && author == obj2.author;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, title, author);
        }
    }
}