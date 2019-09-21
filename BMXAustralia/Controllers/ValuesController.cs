using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BMXAustralia.Controllers
{
    public class ValuesController : ApiController
    {
        // Lists 
        [HttpGet]
        public List<Participant> ListParticipantBirth()
        {
            EventManagerEntities myDB = new EventManagerEntities();
            List<Participant> listBirth = myDB.Participants.Where(s => s.ParticipantId > 0).ToList<Participant>();
            return listBirth;
        }

        [HttpGet]
        public List<Participant> ListParticipantGender()
        {
            EventManagerEntities myDB = new EventManagerEntities();
            List<Participant> listGender = myDB.Participants.Where(s => s.ParticipantId > 0).ToList<Participant>();
            return listGender;
        }

        // Search

        [HttpGet]
        public List<Participant> SearchLastName(string lastName)

        {
            EventManagerEntities myDB = new EventManagerEntities();
            List<Participant> listLastName = myDB.Participants.Where(s => s.LastName == lastName).ToList<Participant>();
            return listLastName;
        }

        [HttpGet]
        public List<Participant> SearchEmailAddress(string email)

        {
            EventManagerEntities myDB = new EventManagerEntities();
            List<Participant> listEmail = myDB.Participants.Where(s => s.EmailAddress == email).ToList<Participant>();
            return listEmail;
        }

        [HttpGet]
        public List<Participant> SearchBirthDate(DateTime date)

        {
            EventManagerEntities myDB = new EventManagerEntities();
            List<Participant> listBirthDate = myDB.Participants.Where(s => s.BirthDate == date).ToList<Participant>();
            return listBirthDate;
        }


        public string Get(int id)
        {
            return "GET WITH ID value";
        }

        // POST api/values
        [HttpGet]
        public string PostNewParticipant(string FirstName, string LastName, string Gender, DateTime BirthDate, string EmailAddress)
        {
            EventManagerEntities myDB = new EventManagerEntities();
            Participant newParticipant = new Participant();


            newParticipant.FirstName = FirstName;
            newParticipant.LastName = LastName;
            newParticipant.Gender = Gender;
            newParticipant.BirthDate = BirthDate;
            newParticipant.EmailAddress = EmailAddress;

            myDB.Participants.Add(newParticipant);

            myDB.SaveChanges();

            return "POST Success!";
        }

        // PUT api/values/5
        [HttpGet]
        public string PutParticipants(int ParticipantId, string FirstName, string LastName, string Gender, DateTime BirthDate, string EmailAddress)
        {
            EventManagerEntities myDB = new EventManagerEntities();
            Participant newParticipant = myDB.Participants.Where(s => s.ParticipantId == ParticipantId).FirstOrDefault();

            newParticipant.FirstName = FirstName;
            newParticipant.LastName = LastName;
            newParticipant.EmailAddress = EmailAddress;
            newParticipant.BirthDate = BirthDate;
            newParticipant.Gender = Gender;

            myDB.SaveChanges();

            return "PUT Success!";
        }

        // DELETE api/values/5
        [HttpGet]
        public string RemoveParticipant(int id)
        {
            EventManagerEntities myDB = new EventManagerEntities();
            Participant newParticipant = myDB.Participants.Where(s => s.ParticipantId == id).FirstOrDefault();

            myDB.Participants.Remove(newParticipant);
            myDB.SaveChanges();

            return "DELETE Success!";
        }
    }
}