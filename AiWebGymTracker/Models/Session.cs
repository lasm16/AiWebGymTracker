using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AiWebGymTracker.Models
{
    public class Session
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        //[Column("workout_id")]
        //public Workout WorkoutID { get; set; }

        [Column("coach_id")]
        public Coach coach { get; set; }        

        [Column("start_session")]
        public DateTime StartSession { get; set; }

        [Column("end_session")]
        public DateTime EndSession { get; set; }

        [Column("status")]
        public SessionType  SessionType { get; set; }
    }
}
