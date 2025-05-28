using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AiWebGymTracker.Models
{
    public class Training
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        //public ApplicationUser? Coach { get; set; }
        public ApplicationUser Trainee { get; set; }

        [Column("start_training")]
        public DateTime TimeStartTraining { get; set; }

        [Column("end_training")]
        public DateTime TimeEndTraining { get; set; }

        [Column("status")]
        public TrainingType TrainingType { get; set; }
    }
}
