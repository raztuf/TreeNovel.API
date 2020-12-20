using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IReportRepo<Report>
    {
        Report GetOne(int Id);
        IEnumerable<Report> GetAll();
        void Insert(Report r);
        bool Delete(int Id);
    }
}
