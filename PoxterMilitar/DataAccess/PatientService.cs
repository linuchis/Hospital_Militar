using System;
using System.Collections.Generic;
using System.Linq;
using PoxterMilitar.classe;
using PoxterMilitar.Models; // Asegúrate de que este namespace es correcto
using System.Windows;
using System.Text;


namespace PoxterMilitar.DataAccess
{
    public class PatientService
    {
        private readonly dbpoxterContext _context;

        // Constructor que inicializa el contexto de la base de datos
        public PatientService()
        {
            _context = new dbpoxterContext();
        }

        // Método para obtener todos los pacientes y mapearlos a dato_paciente
        public List<dato_paciente> GetAllPatients()
        {
            var patients = _context.patients_poxter.ToList();

            var listaPacientes = patients.Select(p => new dato_paciente
            {
                // Mapea las propiedades de patients_poxter a dato_paciente
                Id = p.id_p,
                Altura = p.height_p,
                Peso = p.weight_p,
                Nombre = p.name_p,
                Apellido = p.lastname_p,
                Genero = p.gender_p,
                // Añade otras propiedades si las tienes
            }).ToList();

            return listaPacientes;
        }

        // **Nuevo Método: Obtener un Paciente por ID**
        public dato_paciente GetPatientById(long patientId)
        {
            var paciente = _context.patients_poxter.FirstOrDefault(p => p.id_p == patientId);
            if (paciente != null)
            {
                return new dato_paciente
                {
                    Id = paciente.id_p,
                    Altura = paciente.height_p,
                    Peso = paciente.weight_p,
                    Nombre = paciente.name_p,
                    Apellido = paciente.lastname_p,
                    Genero = paciente.gender_p,
                    // Añade otras propiedades si las tienes
                };
            }
            else
            {
                return null;
            }
        }

        // Método para eliminar un paciente
        public void DeletePatient(long patientId)
        {
            try
            {
                var paciente = _context.patients_poxter.FirstOrDefault(p => p.id_p == patientId);
                if (paciente != null)
                {
                    _context.patients_poxter.Remove(paciente);
                    _context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Paciente no encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el paciente: {ex.Message}");
            }
        }
    }
}
