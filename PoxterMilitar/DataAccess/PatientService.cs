using System;
using System.Collections.Generic;
using System.Linq;
using PoxterMilitar.classe;
using PoxterMilitar.Models; // Asegúrate de que este namespace es correcto
using System.Windows;
using System.Text;
using System.Collections.ObjectModel;


namespace PoxterMilitar.DataAccess
{
    public class PatientService
    {
        // Implementación Singleton para compartir una única instancia
        private static PatientService _instance;
        public static PatientService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PatientService();
                return _instance;
            }
        }

        private readonly dbpoxterContext _context;
        public ObservableCollection<dato_paciente> ListaPacientes { get; set; }

        private PatientService()
        {
            _context = new dbpoxterContext();
            ListaPacientes = new ObservableCollection<dato_paciente>(GetAllPatients());
        }

        private List<dato_paciente> GetAllPatients()
        {
            return _context.patients_poxter.ToList().Select(p => new dato_paciente
            {
                Id = p.id_p,
                Altura = p.height_p,
                Peso = p.weight_p,
                Nombre = p.name_p,
                Apellido = p.lastname_p,
                Genero = p.gender_p,
                PrimerAmp = p.amp_first,
                SegundoAmp = p.amp_sec
            }).ToList();
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
                    id_p = newPatient.Id, // Cédula proporcionada por el usuario
                    name_p = newPatient.Nombre,
                    lastname_p = newPatient.Apellido,
                    gender_p = newPatient.Genero,
                    weight_p = newPatient.Peso,
                    height_p = newPatient.Altura,
                    amp_first = newPatient.PrimerAmp,
                    amp_sec = string.IsNullOrEmpty(newPatient.SegundoAmp) ? null : newPatient.SegundoAmp
                };

                _context.patients_poxter.Add(paciente);
                _context.SaveChanges();

                // Agregar al ObservableCollection para actualizar la UI automáticamente
                ListaPacientes.Add(newPatient);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar el paciente: {ex.Message}");
            }
        }

        // Métodos para actualizar y eliminar pacientes también deben actualizar la ObservableCollection
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
                paciente.amp_first = updatedPatient.PrimerAmp;
                paciente.amp_sec = updatedPatient.SegundoAmp;

                _context.SaveChanges();

                // Actualizar en la ObservableCollection
                var pacienteEnLista = ListaPacientes.FirstOrDefault(p => p.Id == updatedPatient.Id);
                if (pacienteEnLista != null)
                {
                    pacienteEnLista.Nombre = updatedPatient.Nombre;
                    pacienteEnLista.Apellido = updatedPatient.Apellido;
                    pacienteEnLista.Genero = updatedPatient.Genero;
                    pacienteEnLista.Peso = updatedPatient.Peso;
                    pacienteEnLista.Altura = updatedPatient.Altura;
                    pacienteEnLista.PrimerAmp = updatedPatient.PrimerAmp;
                    pacienteEnLista.SegundoAmp = updatedPatient.SegundoAmp;
                }
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

                    // Eliminar de la ObservableCollection
                    var pacienteEnLista = ListaPacientes.FirstOrDefault(p => p.Id == patientId);
                    if (pacienteEnLista != null)
                    {
                        ListaPacientes.Remove(pacienteEnLista);
                    }
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
