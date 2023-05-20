using Telefon_Rehberi.Business.Abstract;
using Telefon_Rehberi.Business.Constants;
using Telefon_Rehberi.Core.Utilities.Results;
using Telefon_Rehberi.DataAccess.Abstract;
using Telefon_Rehberi.Entities.Concrete;
using Telefon_Rehberi.Entities.DTOs;

namespace Telefon_Rehberi.Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonDal _personDal;
        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }
        public IResult Add(Person person)
        {
            if (person == null)
                return new ErrorResult(Messages.PersonEmpty);

            _personDal.Add(person);
            return new SuccessResult(Messages.PersonAdd);
        }

        public IResult Delete(int personId)
        {
            var person = _personDal.Get(x => x.UUID == personId);
            if (person == null)
                return new ErrorResult(Messages.PersonNull);

            _personDal.Delete(person);
            return new SuccessResult(Messages.PersonDelete);
        }

        public IDataResult<IList<Person>> GetAll()
        {
            var personList = _personDal.GetList();
            if (personList == null)
                return new ErrorDataResult<IList<Person>>(Messages.PersonNull);

            return new SuccessDataResult<IList<Person>>(personList, Messages.PersonList);
        }

        public IList<ReportByLocationDto> GetLocationAllReports()
        {
            var report = _personDal.LocationReport();

            return report;
        }
    }
}
