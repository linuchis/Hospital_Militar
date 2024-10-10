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

        
        public PatientService()
        {
            _context = new dbpoxterContext();
        }

     
        public List<dato_paciente> GetAllPatients()
        {
            var patients= _context.patients_poxter.ToList();

            var listaPacientes = patients.Select(p =>new dato_paciente
            {               
                Id = p.id_p,
                Altura = p.height_p,
                Peso = p.weight_p,
                Nombre = p.name_p,
                Apellido = p.lastname_p,
                Genero = p.gender_p,
                
            }).ToList();

            return listaPacientes;
        }

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
                };
            }
            else
            {
                return null;
            }
        }

        public void AddPatient(dato_paciente newPatient)
        {
            try
            {
                // Verificar si el ID ya existe para evitar duplicados
                var existingPatient = _context.patients_poxter.FirstOrDefault(p => p.id_p == newPatient.Id);
                if (existingPatient != null)
                {
                    throw new Exception("Ya existe un paciente con este ID.");
                }

                var paciente = new patients_poxter
                {
                    id_p = newPatient.Id,
                    name_p = newPatient.Nombre,
                    lastname_p = newPatient.Apellido,
                    gender_p = newPatient.Genero,
                    weight_p = newPatient.Peso,
                    height_p = newPatient.Altura
                    // Añade otras propiedades si las tienes
                };

                _context.patients_poxter.Add(paciente);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar el paciente: {ex.Message}");
            }
        }

        //este metodo care picha es el que sube los datos a la base de datos
        public void UpdatePatient(dato_paciente updatedPatient)
        {
            var paciente = _context.patients_poxter.FirstOrDefault(p => p.id_p == updatedPatient.Id);
            if (paciente != null)
            {
                paciente.name_p = updatedPatient.Nombre;
                paciente.lastname_p = updatedPatient.Apellido;
                paciente.gender_p = updatedPatient.Genero;
                paciente.weight_p = updatedPatient.Peso;
                paciente.height_p = updatedPatient.Altura;
                // Actualiza otras propiedades según sea necesario

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Paciente no encontrado.");
            }
        }



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
