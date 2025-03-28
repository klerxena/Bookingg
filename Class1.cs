using System;
using System.Collections.Generic;

namespace booking
{
    public class BookingService
    {
        private List<string> appointments = new List<string>();

        public string AddAppointment(string name, string birthday, string date)
        {
            if (string.IsNullOrWhiteSpace(date) || !ValidateDateInput(date))
            {
                return "Invalid Date. Please try again.";
            }

            string appointment = $"Name: {name}, Birthday: {birthday}, Date: {date}";
            appointments.Add(appointment);
            return "Appointment Added!";
        }

        public List<string> GetAppointments()
        {
            return new List<string>(appointments);
        }

        public string SearchAppointment(string name)
        {
            foreach (var appt in appointments)
            {
                if (appt.Contains($"Name: {name}"))
                {
                    return appt;
                }
            }
            return "Appointment not found.";
        }

        public string DeleteAppointment(string name)
        {
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].Contains($"Name: {name}"))
                {
                    appointments.RemoveAt(i);
                    return "Appointment Deleted.";
                }
            }
            return "Appointment not found.";
        }

        public string UpdateAppointment(string name, string newDate)
        {
            if (string.IsNullOrWhiteSpace(newDate) || !ValidateDateInput(newDate))
            {
                return "Invalid Date. Please try again.";
            }

            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].Contains($"Name: {name}"))
                {
                    var parts = appointments[i].Split(", ");
                    parts[2] = $"Date: {newDate}";
                    appointments[i] = string.Join(", ", parts);
                    return "Appointment Updated.";
                }
            }

            return "Appointment not found.";
        }

        private bool ValidateDateInput(string date)
        {
            return DateTime.TryParse(date, out _);
        }
    }
}
