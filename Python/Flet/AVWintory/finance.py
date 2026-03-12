import flet as ft

def finance_view(page: ft.Page) -> ft.View:
    """
        Mapa / Map
        
        ft.View (Scrollable)
            Container (MAX_WIDTH)
                Row
                    Column
                        Row (3 tarjetas / 3 Cards)
                            Container (Grafica de ventas / Graph of sell)
                        Row (2 Graficas secundarias / 2 Graph secundary)
                            Container (Grafica secundaria 1 / Graph secundary 1)
                            Container (Grafica secundaria 2 / Graph secundary 2)
                        Column
                            Container (Ventas / Sell)
                                Column
                            Container (Fecha / Date)
                            Column (Advertencias / Warning)
        
    """
    
    
    
    MAX_WIDTH = 1000 # Tamaño maximo del contenedor / Size max of container 
    SEC_WIDTH = 200 # Tamaño para los cotenedores de la derecha / Size for contianer of the right
    
    def StyleContainer(text:str, colorText:str, colorContainer:str, colorBg:str):
        return ft.Container(
            content= ft.Text(
                text,
                color= colorText,
                size=18,
                text_align= ft.TextAlign.CENTER,
            ),
            width= 250,
            height= 150,
            alignment=ft.alignment.center,
            padding= ft.padding.symmetric (10, 20),
            border= ft.border.all(1, colorContainer),
            border_radius= 20,
            bgcolor= colorBg,
        )
        
    return ft.View(
        "/finance",
        scroll=ft.ScrollMode.ALWAYS,
        controls=[   
            ft.Container(
                width = MAX_WIDTH,
                padding= 20,
                content= ft.Row(
                    vertical_alignment=ft.CrossAxisAlignment.START,    
                    alignment=ft.MainAxisAlignment.CENTER,
                    controls=[
                        ft.Column(
                            controls=[
                                ft.Row(
                                    alignment=ft.MainAxisAlignment.SPACE_BETWEEN,
                                    width= MAX_WIDTH,
                                    controls=[
                                        StyleContainer("0$", "#00FF00", "#00FF00", "#086E08"),
                                        StyleContainer("0 ventas", "#D5FF02","#D5FF02", "#6A7E07"),
                                        StyleContainer("0 Bs.", "#C8A559", "#C8A559", "#6C4D0B"),
                                    ]
                                ),
                                
                                ft.Container(
                                    content= ft.Text("(Grafica)"),
                                    width= MAX_WIDTH,
                                    height= MAX_WIDTH / 2,
                                    bgcolor= "#464646",
                                    border= ft.border.all(1, "#5C5C5C"),
                                    border_radius= 20,
                                ),
                                
                                ft.Row(
                                    alignment= ft.MainAxisAlignment.SPACE_BETWEEN,
                                    width= MAX_WIDTH,
                                    controls=[
                                        ft.Container(
                                            content=ft.Text("(Grafica 2)"),
                                            width= (MAX_WIDTH / 2) - 90,
                                            height= 250,
                                            border= ft.border.all(1, "#5C5C5C"),
                                            border_radius= 20,
                                        ),
                                        ft.Container(
                                            content=ft.Text("(Grafica 3)"),
                                            width= (MAX_WIDTH / 2) - 90,
                                            height= 250,
                                            border= ft.border.all(1, "#5C5C5C"),
                                            border_radius= 20,
                                        )
                                    ]
                                )
                            ]
                        ),
                        ft.Column(
                            width=SEC_WIDTH,
                            controls=[
                                ft.Container(                                    
                                    content= ft.Column(
                                        controls=[
                                            ft.Text("Ganancias del mes"),
                                            ft.Text("Bs. 0"),
                                            ft.Text("Usd. 0"),
                                        ]
                                    ),
                                    width= SEC_WIDTH,
                                    height= 200,
                                    border= ft.border.all(1, '#00FF00'),
                                    border_radius=20,
                                    bgcolor= "#086E08"
                                ),
                                ft.Container(
                                    content= ft.Text("01/01/0001"),
                                    border= ft.border.only(bottom= ft.BorderSide (2, "#000000")),
                                    width= SEC_WIDTH,
                                ),
                                #! Ocurre si hay una advertencia
                                ft.Column(
                                    controls=[
                                        ft.Text("Stock casi vacio", color= ft.Colors.RED),
                                        ft.Text("Facturas pendientes", color= ft.Colors.RED),
                                        ft.Text("Ganancias bajas", color= ft.Colors.RED),
                                    ]
                                )
                            ]    
                        )
                    ]
                )          
            )
        ]
    ) 