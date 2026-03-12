import flet as ft

def inventory_view(page: ft.Page) -> ft.View:
        return ft.View( 
                "/inventory", 
                controls=[ 
                        ft.Text("Inventario") 
                ] 
        )