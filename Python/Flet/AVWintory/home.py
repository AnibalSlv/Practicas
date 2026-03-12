import flet as ft

def home_view(page: ft.Page) -> ft.View:
    def styleContainer(value: str, link: str):
        return ft.Container(
            content= ft.Text(value, color= ft.Colors.BLACK),
            width= 250,
            height= 250,
            border= ft.border.all(2, ft.Colors.BLACK),
            border_radius= 20,
            padding= 50,
            margin= 50,
            alignment= ft.alignment.center,
            on_click= lambda e: page.go(link),
        )
        
    header = ft.Row(
        alignment= ft.MainAxisAlignment.CENTER, # Centrar los elementos dentro de la fila / Center elements in the row
        controls=[
            ft.Container(
                content= ft.Text(
                    "AVWintory", 
                    width=250, 
                    size=32, 
                    text_align= ft.TextAlign.CENTER, 
                    color= ft.Colors.BLUE_ACCENT_700),
                padding= 5,
                width=300,
                margin= 10,
                border= ft.border.only(bottom= ft.border.BorderSide (2, ft.Colors.BLUE_ACCENT_700)),
            )
        ]
    )

    
    content = ft.Container(
        width= 10000,
        content=ft.Column(
            controls=[
                ft.Row(
                    controls=[
                        styleContainer("Inventario", "/inventory"),
                        styleContainer("Opcion 2 / adorno", "/home"),
                        styleContainer("Opcion 3 / adorno", "/home"),
                    ],
                    alignment=ft.MainAxisAlignment.CENTER #? Centra la fila / Center the row
                ),
                ft.Row(
                    controls=[
                        styleContainer("Opcion 4 / adorno", "/home"),
                        styleContainer("Opcion 5 / adorno", "/home"),
                        styleContainer("Finanzas", "/finance"),
                    ],
                    alignment=ft.MainAxisAlignment.CENTER
                )
            ]
        )
    )
    
    return ft.View(
        "/",
        controls=[ 
            header,
            content
        ]
    )
    page.update()  #? Esto es para que la pagina aplique los cambios