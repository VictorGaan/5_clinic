using Microsoft.AspNetCore.Mvc;
using TRPOFirst.Contracts.Hospital;
using TRPOFirst.Contracts.Hospital.Requests;
using TRPOFirst.Contracts.Hospital.Responses;
using TRPOFirst.Domian;
using TRPOFirst.Settings;
using System.Collections.Generic;

namespace TRPOFirst.Services;

public class PacientService : IPacientService
{
    private readonly List<Pacients> _pacients; // Сущность представляющая доктора

    public PacientService()
    {
        _pacients = new List<Pacients>();
        for (int i = 0; i < DataApi.QuantityRequest; i++)
        {
            _pacients.Add(new Pacients
            {
                IdPacient = Guid.NewGuid(),
                FirstName = "Имя",
                LastName = "Фамилия",
                MiddleName = "Отчество",
                Age = 20,
                Polis = Convert.ToString((12345678912 + i))
            });
        }
    }

    public List<Pacients> GetPacient()
    {
        return _pacients;
    }

    public Pacients GetPacientById(Guid idPacient)
    {
        var result = _pacients.SingleOrDefault(x => x.IdPacient == idPacient);
        return result;
    }

    public bool UpdatePacient(Pacients updateToPacient)
    {
        var exist = GetPacientById(updateToPacient.IdPacient) != null;

        if (!exist)
            return false;

        var index = _pacients.FindIndex(x => x.IdPacient == updateToPacient.IdPacient);
        _pacients[index] = updateToPacient;
        return true;
    }
}