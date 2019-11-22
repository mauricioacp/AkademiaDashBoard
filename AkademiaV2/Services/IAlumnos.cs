﻿using AkademiaV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiaV2.Services
{
    public interface IAlumnos
    {
        public Task<List<Alumnos>> GetAlumnos();
        public Task<Alumnos> GetAlumnoByIdAsync(int? id);
        public Task CreateAlumnoAsync(Alumnos alumnos);
        public Task UpdateAlumnoAsync(Alumnos alumnos);
        public Task DeleteAlumnoAsync(Alumnos alumnos);
        public bool AlumnoExist(int id);
    }
}
