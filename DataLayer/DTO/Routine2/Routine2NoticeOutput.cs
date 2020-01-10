using DataLayer.DTO.UserDTO;
using DataLayer.Entities.ExireRoutine;

using System.Collections.Generic; 
namespace DataLayer.DTO.Routine2
{
    public class Routine2NoticeOutput
    {
        public Routine2Notice Routine2Notice { get; set; }

        public List<int> UserIds { get; set; } = new List<int>();


        public List<Routine2NoticeSpecificUser> Notices { get; set; } = new List<Routine2NoticeSpecificUser>();

        

    }

    public class Routine2NoticeSpecificUser
    {
        public int UserId { get; set; }
        public Dictionary<string, object> Model { get; set; } = new Dictionary<string, object>();
        public string BodyCompiled { get; set; }
        public string BodySmsCompiled { get; set; }
        public string BodyEmailCompiled { get; set; }


        //TODO ***
        public UserSummaryDTO User { get; set; }

    }
}