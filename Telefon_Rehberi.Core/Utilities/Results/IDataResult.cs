namespace Telefon_Rehberi.Core.Utilities.Results
{
    //out parametresi, obje ve IList olarak dönüş yapmamızı sağlar.
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
