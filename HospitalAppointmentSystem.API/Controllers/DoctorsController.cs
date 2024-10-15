using HospitalAppointmentSystem.Models.Dtos.Doctors.Requests;
using HospitalAppointmentSystem.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;
namespace HospitalAppointmentSystem.API.Controllers;
public class DoctorsController(IDoctorService doctorService) : CustomBaseController
{
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll() => 
        CreateActionResult(await doctorService.GetAllDoctorsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => 
        CreateActionResult(await doctorService.GetByIdAsync(id));

    [HttpPost("add")]
    public async Task<IActionResult> Add(CreateDoctorRequest request) => 
        CreateActionResult(await doctorService.AddAsync(request));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => 
        CreateActionResult(await doctorService.DeleteAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateDoctorRequest request) => 
        CreateActionResult(await doctorService.UpdateAsync(id, request));

}