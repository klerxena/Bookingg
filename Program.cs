using System;
using System.Collections.Generic;

namespace booking
{
    internal class Program
    {
        static string[] actions = new string[]
        {
            "[1] Add Appointment",
            "[2] View Appointments",
            "[3] Search Appointment",
            "[4] Delete Appointment",
            "[5] Update Appointment",
            "[6] Exit"
        };

        static List<string> appointments = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO LASH & NAILS BOOKING SYSTEM");

            DisplayMenu();
            int userInput = GetUserInput();

            while (userInput != 6)
            {
                switch (userInput)
                {
                    case 1:
                        AddAppointment();
                        break;
                    case 2:
                        ViewAppointments();
                        break;
                    case 3:
                        SearchAppointment();
                        break;
                    case 4:
                        DeleteAppointment();
                        break;
                    case 5:
                        UpdateAppointment();
                        break;
                    case 6:
                        Console.WriteLine("Thank you for booking with us! Have a great day!");
                        break;
                    default:
                        Console.WriteLine("INVALID OPTION. Please select between 1-6.");
                        break;
                }
                DisplayMenu();
                userInput = GetUserInput();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("BOOKING MENU");

            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }
        }

        static int GetUserInput()
        {
            Console.Write("[User Input]: ");
            return Convert.ToInt16(Console.ReadLine());
        }

        static void AddAppointment()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("ADD APPOINTMENT");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Birthday (MM-DD-YYYY): ");
            string birthday = Console.ReadLine();

            Console.Write("Enter Appointment Date (MM-DD-YYYY): ");
            string date = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(date))
            {
                Console.WriteLine("Invalid Date. Please try again.");
                return;
            }

            ValidateDateInput(date);

            string appointment = $"Name: {name}, Birthday: {birthday}, Date: {date}";
            appointments.Add(appointment);
            Console.WriteLine("Appointment Added!");
        }

        static void ViewAppointments()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("YOUR APPOINTMENTS");
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
            }
            else
            {
                foreach (var appt in appointments)
                {
                    Console.WriteLine("- " + appt);
                }
            }
        }

        static void SearchAppointment()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("SEARCH APPOINTMENT");
            Console.Write("Enter Name to Search: ");
            string searchName = Console.ReadLine();

            bool found = false;
            foreach (var appt in appointments)
            {
                if (appt.Contains($"Name: {searchName}"))
                {
                    Console.WriteLine(appt);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Appointment not found.");
            }
        }

        static void DeleteAppointment()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("DELETE APPOINTMENT");
            Console.Write("Enter Name of Appointment to Delete: ");
            string nameToDelete = Console.ReadLine();

            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].Contains($"Name: {nameToDelete}"))
                {
                    appointments.RemoveAt(i);
                    Console.WriteLine("Appointment Deleted.");
                    return;
                }
            }

            Console.WriteLine("Appointment not found.");
        }

        static void UpdateAppointment()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("UPDATE APPOINTMENT");
            Console.Write("Enter Name of Appointment to Update: ");
            string nameToUpdate = Console.ReadLine();

            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].Contains($"Name: {nameToUpdate}"))
                {
                    Console.Write("Enter New Appointment Date (MM-DD-YYYY): ");
                    string newDate = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(newDate))
                    {
                        Console.WriteLine("Invalid Date. Please try again.");
                        return;
                    }

                    ValidateDateInput(newDate);

                    appointments[i] = appointments[i].Replace(appointments[i].Split(", ")[2], $"Date: {newDate}");
                    Console.WriteLine("Appointment Updated.");
                    return;
                }
            }

            Console.WriteLine("Appointment not found.");
        }

        static void ValidateDateInput(string date)
        {
            if (DateTime.TryParse(date, out _))
            {
                Console.WriteLine("Valid Date.");
            }
            else
            {
                Console.WriteLine("Invalid Date Format. Use MM-DD-YYYY.");
            }
        }
    }
}
