using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.Productos;

partial class NuevoProducto
{
    [Inject] private IProductoServicio productoServicio { get; set; }
    [Inject] private NavigationManager navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }


    private Producto user = new Producto();


    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(user.Codigo) || string.IsNullOrEmpty(user.Descripcion))
        {
            return;
        }

        bool inserto = await productoServicio.Nuevo(user);
        if (inserto)
        {
            await Swal.FireAsync("Felicidades", "Producto creado con éxito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Producto NO creado", SweetAlertIcon.Error);
        }
        navigationManager.NavigateTo("/Productos");


    }

    protected async Task Cancelar()
    {
        navigationManager.NavigateTo("/Productos");
    }
}
