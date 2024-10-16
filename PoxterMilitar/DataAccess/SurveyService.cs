using PoxterMilitar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PoxterMilitar.DataAccess
{
    public class SurveyService
    {
        private readonly dbpoxterContext _context;

        public SurveyService()
        {
            _context = new dbpoxterContext();
        }

        public void AddSurvey(surveys_patients survey)
        {
            _context.surveys_patients.Add(survey);
            _context.SaveChanges();
        }

        public List<surveys_patients> GetSurveysByPatient(long patientId)
        {
            return _context.surveys_patients
                .Where(s => s.id_p == patientId)
                .ToList();
        }


        // Opcional: Obtener todas las encuestas
        public List<surveys_patients> GetAllSurveys()
        {
            return _context.surveys_patients.ToList();
        }

    }
}
