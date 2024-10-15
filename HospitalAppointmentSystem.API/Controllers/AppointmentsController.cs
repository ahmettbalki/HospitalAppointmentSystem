using HospitalAppointmentSystem.Models.Dtos.Appointments.Requests;
using HospitalAppointmentSystem.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;
namespace HospitalAppointmentSystem.API.Controllers;
public class AppointmentsController(IAppointmentService appointmentService) : CustomBaseController
{
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll() =>
    CreateActionResult(await appointmentService.GetAllAppointmentAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id) =>
        CreateActionResult(await appointmentService.GetByIdAsync(id));

    [HttpPost("add")]
    public async Task<IActionResult> Add(CreateAppointmentRequest request) =>
        CreateActionResult(await appointmentService.AddAsync(request));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id) =>
        CreateActionResult(await appointmentService.DeleteAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateAppointmentRequest request) =>
        CreateActionResult(await appointmentService.UpdateAsync(id, request));
}