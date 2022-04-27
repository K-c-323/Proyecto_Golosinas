using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.Productos;

partial class EditarProducto
{
    [Inject] private IProductoServicio _productoServicio { get; set; }


    [Inject] NavigationManager _navigationManager { get; set; }


    [Inject] SweetAlertService Swal { get; set; }

    [Parameter] public string Codigo { get; set; }

    Producto user = new Producto();



    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(Codigo))
        {
            user = await _productoServicio.GetPorCodigo(Codigo);
        }

    }


    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(user.Codigo) || string.IsNullOrEmpty(user.Descripcion)  )
        {
            return;
        }

        bool edito = await _productoServicio.Actualizar(user);
        if (edito)
        {
            await Swal.FireAsync("Felicidades", "Producto Actualizado con éxito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Producto NO actualizado", SweetAlertIcon.Error);
        }
        _navigationManager.NavigateTo("/Productos");

    }

    protected async Task Cancelar()
    {
        _navigationManager.NavigateTo("/Productos");
    }

    protected async Task Eliminar()
    {
        bool elimino = false;

        SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = "¿Seguro que desea eliminar?",
            Icon = SweetAlertIcon.Question,
            ShowCancelButton = true,
            ConfirmButtonText = "Aceptar",
            CancelButtonText = "Cancelar"
        });

        if (!string.IsNullOrEmpty(result.Value))
        {
            elimino = await _productoServicio.Eliminar(user);

            if (elimino)
            {
                await Swal.FireAsync("Felicidades", "Producto eliminado con éxito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Productos");
            }
            else
            {
                await Swal.FireAsync("Error", "Producto NO eliminado", SweetAlertIcon.Error);
            }

        }
    }


}






