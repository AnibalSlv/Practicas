import flet as ft
from home import home_view
from finance import finance_view
from inventory import inventory_view
from zEjemplo import zEjemplo_view

def main(page: ft.Page):
    page.title = "Buenas noches mundo"
    page.window.height = 700
    page.window.width = 1020
    page.theme_mode = ft.ThemeMode.LIGHT
    
    #? Recibe un parametro (e) y el evento routeChange cambia de ruta y se dispara /
    #? It receives a parameter (e) and the routeChangeEvent is execute 
    def on_route(e: ft.RouteChangeEvent): 
        
        #? Es la ruta que tiene el evento, si la ruta esta vacia usa la ruta de la pagina /
        #? Is route that have has the event, if the route is empty use the route of page
        route = e.route or page.route
        
        #? Limpia la lista de vistas para que no se acumulen / clear list of view does not accumulate
        page.views.clear()
        
        if route == "/":
            #? Va a la vista home_view / Goes to the view home_view
            page.views.append(home_view(page))
            
        elif route == "/finance":
            page.views.append(finance_view(page))
        elif route == "/inventory":
            page.views.append(inventory_view(page))
        elif route == "/test":
            page.views.append(zEjemplo_view(page))
        else:
            page.views.append(ft.View(route, controls=[
                ft.Text("Error 404 (No existe checa eso)")
                ]))
            
        page.update()
    
    page.on_route_change = on_route 
    page.go(page.route)

#ft.app(target=main)
#TODO Para trabajar mas comodo pon esta linea

ft.app(target=main, view=ft.WEB_BROWSER) 
#? Esto abre el navegador y se ven los links

#TODO y elimina el anterior ft.app o comentala 