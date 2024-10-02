using System;
using System.Collections.Generic;
using System.Linq;
using PoxterMilitar.classe;
using PoxterMilitar.Models; // Asegúrate de que este namespace es correcto
using System.Windows;

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
        /*public List<dato_paciente> GetAllPatients()
        {
            try
            {
                var pacientes = _context.patients_poxter.ToList();

                var listaPacientes = pacientes.Select(p => new dato_paciente
                {
                    Id_p = p.id_p,
                    Nombre = p.name_p,
                    Apellido = p.lastname_p,
                    Genero = p.gender_p,
                    Altura = p.height_p,
                    Peso = p.weight_p
                    // Asigna otros campos si existen
                }).ToList();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                // Manejar el error, por ejemplo, loguearlo
                MessageBox.Show($"Error al obtener pacientes: {ex.Message}");
                return new List<dato_paciente>();
            }
        }

        // Método para obtener un paciente por su ID
        public patients_poxter GetPatientById(long patientId)
        {
            try
            {
                return _context.patients_poxter.FirstOrDefault(p => p.id_p == patientId);
            }
            catch (Exception ex)
            {
                // Manejar el error
                MessageBox.Show($"Error al obtener el paciente: {ex.Message}");
                return null;
            }
        }

        // Método para agregar un nuevo paciente
        public void AddPatient(dato_paciente nuevoPaciente)
        {
            try 
            {
                var pacienteEntity = new patients_poxter
                {
                    name_p = nuevoPaciente.Nombre,
                    lastname_p = nuevoPaciente.Apellido,
                    gender_p = nuevoPaciente.Genero,
                    height_p = nuevoPaciente.Altura,
                    weight_p = nuevoPaciente.Peso
                    // Asigna otros campos si existen
                };

                _context.patients_poxter.Add(pacienteEntity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el paciente: {ex.Message}");
            }
        }

        // Método para actualizar un paciente existente
        public void UpdatePatient(long patientId, dato_paciente updatedPatient)
        {
            try
            {
                var paciente = _context.patients_poxter.FirstOrDefault(p => p.id_p == patientId);
                if (paciente != null)
                {
                    paciente.name_p = updatedPatient.Nombre;
                    paciente.lastname_p = updatedPatient.Apellido;
                    paciente.gender_p = updatedPatient.Genero;
                    paciente.height_p = updatedPatient.Altura;
                    paciente.weight_p = updatedPatient.Peso;
                    // Actualiza otros campos si existen

                    _context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Paciente no encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el paciente: {ex.Message}");
            }
        }*/

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
