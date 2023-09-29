namespace VaccOps
{
    using Models;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VaccDb : IVaccOps
    {

        private Dictionary<string, Doctor> doctorsByName=new Dictionary<string, Doctor>();
        private Dictionary<string,Patient>patiensByName=new Dictionary<string, Patient>();
        
        public void AddDoctor(Doctor doctor)
        {
            if (this.doctorsByName.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }
            this.doctorsByName.Add(doctor.Name, doctor);
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            if (!this.doctorsByName.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();

            }
            this.patiensByName.Add(patient.Name, patient);
            this.doctorsByName[doctor.Name].Patients.Add(patient);
            patient.Doctor = doctor;

           
        }

        public void ChangeDoctor(Doctor oldDoctor, Doctor newDoctor, Patient patient)
        {
            if (!(this.doctorsByName.ContainsKey(oldDoctor.Name)) 
                ||!(this.doctorsByName.ContainsKey(newDoctor.Name)) || 
                !this.patiensByName.ContainsKey(patient.Name))
            {
                throw new ArgumentException();
            }
            oldDoctor.Patients.Remove(patient);
            newDoctor.Patients.Add(patient);
            patient.Doctor = newDoctor;
        }

        public bool Exist(Doctor doctor)
        {
            if (this.doctorsByName.ContainsKey(doctor.Name))
            {
                return true;
            }
            return false;
        }

        public bool Exist(Patient patient)
        {
            if (this.patiensByName.ContainsKey(patient.Name))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Doctor> GetDoctors()=>this.doctorsByName.Values;
        

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
            =>this.doctorsByName.Values.Where(d=>d.Popularity==populariry);

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
            => this.doctorsByName.Values.OrderByDescending(d => d.Patients.Count())
            .ThenBy(d => d.Name);
        
            

        public IEnumerable<Patient> GetPatients() => this.patiensByName.Values;
        

        public IEnumerable<Patient> GetPatientsByTown(string town)
            =>this.patiensByName.Values.Where(p=>p.Town==town);

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
            => this.patiensByName.Values.Where(p => p.Age >= lo && p.Age <= hi);


        public IEnumerable<Patient>
            GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
            => this.patiensByName.Values
            .OrderBy(d => d.Doctor.Popularity).ThenByDescending(pat => pat.Height)
            .ThenBy(pat => pat.Age);
        
       

        public Doctor RemoveDoctor(string name)
        {
            if (!this.doctorsByName.ContainsKey(name))
            {
                throw new ArgumentException();
            }
            Doctor removedDoctor = this.doctorsByName[name];
            this.doctorsByName.Remove(name);
            foreach (var patient in removedDoctor.Patients)
            {
                this.patiensByName.Remove(patient.Name);

            }
            return removedDoctor;
        }
    }
}
