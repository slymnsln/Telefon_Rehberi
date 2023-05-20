using Telefon_Rehberi.Business.Abstract;
using Telefon_Rehberi.Business.Constants;
using Telefon_Rehberi.Core.Utilities.Results;
using Telefon_Rehberi.DataAccess.Abstract;
using Telefon_Rehberi.Entities.Concrete;

namespace Telefon_Rehberi.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IReportDal _reportDal;
        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }

        public Report Add(Report report)
        {
            return _reportDal.CustomAdd(report);
        }

        public IDataResult<IList<Report>> GetAll()
        {
            var reportList = _reportDal.GetList();
            if (reportList == null)
                return new ErrorDataResult<IList<Report>>(Messages.ReportNull);

            return new SuccessDataResult<IList<Report>>(reportList);
        }

        public IDataResult<Report> GetById(int reportId)
        {
            var report = _reportDal.Get(x => x.UUID == reportId);
            if (report == null)
                return new ErrorDataResult<Report>(Messages.ReportNull);

            return new SuccessDataResult<Report>(report, Messages.ReportList);
        }

        public IResult Update(Report report)
        {
            var reportResult = _reportDal.Get(x => x.UUID == report.UUID);
            if (reportResult == null)
                return new ErrorResult(Messages.ReportNull);

            _reportDal.Update(report);

            return new SuccessResult(Messages.ReportUpdated);
        }
    }
}
