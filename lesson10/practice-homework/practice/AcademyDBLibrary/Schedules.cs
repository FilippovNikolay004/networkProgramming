using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDBLibrary {
    class Schedules {
        public int Id { get; set; }
        public string Class { get; set; }
        public int DayOfWeek { get; set; }
        public int Week { get; set; }

        [ForeignKey("LectureRoomId")]
        public LectureRooms LectureRooms { get; set; }

        [ForeignKey("LectureId")]
        public Lectures Lectures { get; set; }
    }
}
