$(document).ready(function () {
    TablaJQDT('tbLibro', 0, "asc");
});

function TablaJQDT(idtabla, idcolumOrden, tipoOrden) {
    var table = $("#" + idtabla).DataTable({
        orderCellsTop: true,
        autoWidth: true,
        "columns": [
            { "width": "100px" },
            { "width": "100px" },
            { "width": "200px" },
            { "width": "100px" },
            { "width": "400px" }
        ],
        "lengthMenu": [[5, 10, 25, 50, 100, -1], [5, 10, 25, 50, 100, "Todo"]],
        "pageLength": -1,
        "order": [[idcolumOrden, tipoOrden]],
        scrollX: true,
        language: {
            "selectAll": "Procesando...",
            "processing": "Procesando...",
            "lengthMenu": "Mostrar _MENU_",
            "zeroRecords": "No se encontraron resultados",
            "emptyTable": "Ningún dato disponible en esta tabla",
            "info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
            "infoPostFix": "",
            "search": "Buscar: ",
            "Url": "",
            "infoThousands": ",",
            "loadingRecords": "Cargando...",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            },
            "buttons": {
                "selectAll": 'Seleccionar todos',
                "selectNone": 'Deseleccionar',
                'pageLength': "Mostrar por página"
            },
            "aria": {
                "sortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }
    });
    return table;
}
