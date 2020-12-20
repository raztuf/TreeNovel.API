using LocalModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalModel.Services.Interface
{
    public interface IReportService
    {
        Report GetOne(int Id);
        IEnumerable<Report> GetAll();
        void Insert(Report r);
        void Delete(int Id);
    }
}
