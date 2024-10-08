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
        public List<classe.dato_paciente> GetAllPatients()
        {
            var patients = _context.patients_poxter.ToList();

            var listaPacientes = patients.Select(p => new dato_paciente
            {
                // Mapea las propiedades de patients_poxter a dato_usuario
                Id = p.id_p,
                Altura = p.height_p,
                Peso = p.weight_p,
                Nombre = p.name_p,
                Apellido = p.lastname_p,
                Genero = p.gender_p,
            }).ToList();

            return listaPacientes;
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
