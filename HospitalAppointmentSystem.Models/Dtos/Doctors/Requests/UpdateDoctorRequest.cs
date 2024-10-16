﻿using HospitalAppointmentSystem.Models.Entities;
using HospitalAppointmentSystem.Models.Enums;
namespace HospitalAppointmentSystem.Models.Dtos.Doctors.Requests;
public sealed record UpdateDoctorRequest(
    int Id,
    string Name,
    Branch Branch,
    List<Appointment> Appointments);