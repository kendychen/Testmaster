using System.ComponentModel.DataAnnotations;

namespace ViraCare.Models
{
    public class Input
    {
        [Key]
        public int UID { get; set; }
        public string Name { get; set; }

        public string Friend { get; set; }
        public string Group { get; set; }
        public string Sex { get; set; }

        public string Folder { get; set; }
        public string Last_interaction { get; set; }
        public string Condition { get; set; }
        public string Status { get; set; }

    }
}
