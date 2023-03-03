using Microsoft.AspNetCore.Mvc;
using TRPOFirst.Contracts.Hospital;
using TRPOFirst.Contracts.Hospital.Requests;
using TRPOFirst.Contracts.Hospital.Responses;
using TRPOFirst.Domian;
using TRPOFirst.Settings;
using System.Collections.Generic;

namespace TRPOFirst.Services;

public class DoctorService : IDoctorService
{
    private readonly List<Doctors> _doctors; // Сущность представляющая доктора

    public DoctorService()
    {
        _doctors = new List<Doctors>();
        for (var i = 0; i < DataApi.QuantityRequest; i++)
        {
            _doctors.Add(new Doctors
            {
                IdDoctor = Guid.NewGuid(),
                FirstName = "Человек" + i,
                LastName = "Фамилия",
                MiddleName = "Отчество",
                post = null,
                receptionSchedule = null,
                DoctorInfo = null
            }); // Нулл будет до тех пор пока не свяяжу с АПИ с БД
        }
    }

    public List<Doctors> GetDoctors()
    {
        return _doctors;
    }

    public Doctors GetDoctorById(Guid idDoctor)
    {
        var result = _doctors.SingleOrDefault(x => x.IdDoctor == idDoctor);
        return result;
    }

    public bool UpdateDoctor(Doctors updateToDoctors)
    {
        var exist = GetDoctorById(updateToDoctors.IdDoctor) != null;

        if (!exist)
            return false;

        var index = _doctors.FindIndex(x => x.IdDoctor == updateToDoctors.IdDoctor);
        _doctors[index] = updateToDoctors;
        return true;
    }
}