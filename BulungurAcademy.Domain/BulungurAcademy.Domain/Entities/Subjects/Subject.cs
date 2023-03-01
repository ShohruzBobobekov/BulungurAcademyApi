using BulungurAcademy.Domain.Entities.Common;
using BulungurAcademy.Domain.Entities.Exams;
using Newtonsoft.Json;

namespace BulungurAcademy.Domain.Entities.Subjects
{
    public class Subject : Auditable
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Exam> Exams { get; set; }
    }
}
