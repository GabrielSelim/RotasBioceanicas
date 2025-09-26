namespace WebApp.Application.Converter.Contrato
{
    public interface IParser<O, D>
    {
        D Parse(O origem);
        List<D> ParseList(List<O> origem);
    }
}