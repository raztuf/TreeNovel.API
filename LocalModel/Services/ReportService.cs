using DAL.Interface;
using LocalModel.Models;
using LocalModel.Services.Interface;
using LocalModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dal = DAL.Models;

namespace LocalModel.Services
{
    public class ReportService : IReportService
    {
        IReportRepo<dal.Report> _repo;

        public ReportService(IReportRepo<dal.Report> ReportRepo)
        {
            _repo = ReportRepo;
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public IEnumerable<Report> GetAll()
        {
            return _repo.GetAll().Select(x => x.toLocal());
        }

        public Report GetOne(int Id)
        {
            return _repo.GetOne(Id).toLocal();
        }

        public void Insert(Report r)
        {
            _repo.Insert(r.toDal());
        }
    }
}
