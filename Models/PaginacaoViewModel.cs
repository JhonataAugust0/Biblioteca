using System.Collections.Generic;

public class PaginacaoViewModel<T>
{
    public List<T> Itens { get; set; }
    public int PaginaAtual { get; set; }
    public int TotalPaginas { get; set; }
    public int ItensPorPagina { get; set; }
}
