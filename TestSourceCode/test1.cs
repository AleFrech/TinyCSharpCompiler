using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Ajax.Utilities;
using VinculacionBackend.Data.Entities;
using VinculacionBackend.Data.Enums;
using VinculacionBackend.Data.Exceptions;
using VinculacionBackend.Data.Interfaces;
using VinculacionBackend.Interfaces;
using VinculacionBackend.Models;
using VinculacionBackend.Reports;

namespace VinculacionBackend.Services
{
    public class StudentReportModel
    {
        public string StudentNumber;
        public int FirstPeriod ;
        public int SecondPeriod ;
        public int FourthPeriod ;
        public int FifthPeriod ;
    }
    public class StudentsServices : IStudentsServices
    {


        public void AddMany(StudentAddManyEntryModel entries)
        {
            entries.Select( new User
            {
                Name = entry.Name,
                AccountId = entry.AccountId,
                Major = _majorServices.Find(entry.Major),
                Email = entry.Email, Password = _encryption.Encrypt("12345"),
                Campus = "SPS",
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                Finiquiteado = false,
                Status = Status.Inactive
            }).ToList().Forach(add);
        }

    
    }
}