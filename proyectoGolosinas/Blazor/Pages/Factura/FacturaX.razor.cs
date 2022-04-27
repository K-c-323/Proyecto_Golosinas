using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.Factura;

partial class FacturaX
{
    [Inject] private IProductoServicio _productoServicio { get; set; }

    private IEnumerable<Producto> productoLista { get; set; }

    protected override async Task OnInitializedAsync()
    {
        productoLista = await _productoServicio.GetLista();
    }






}
