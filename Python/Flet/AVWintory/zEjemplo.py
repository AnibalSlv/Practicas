import flet as ft

def zEjemplo_view(page: ft.Page) -> ft.View:
    # 1. Definimos el gráfico primero como una variable
    grafico_barras = ft.BarChart(
        bar_groups=[
            ft.BarChartGroup(
                x=0,
                bar_rods=[ft.BarChartRod(from_y=0, to_y=40, width=40, color=ft.Colors.GREEN, border_radius=0)],
            ),
            ft.BarChartGroup(
                x=1,
                bar_rods=[ft.BarChartRod(from_y=0, to_y=100, width=40, color=ft.Colors.BLUE, border_radius=0)],
            ),
            ft.BarChartGroup(
                x=2,
                bar_rods=[ft.BarChartRod(from_y=0, to_y=30, width=40, color=ft.Colors.RED, border_radius=0)],
            ),
            ft.BarChartGroup(
                x=3,
                bar_rods=[ft.BarChartRod(from_y=0, to_y=60, width=40, color=ft.Colors.ORANGE, border_radius=0)],
            ),
        ],
        border=ft.border.all(1, ft.Colors.GREY_400),
        left_axis=ft.ChartAxis(
            labels_size=40, title=ft.Text("Suministro de Frutas"), title_size=40
        ),
        bottom_axis=ft.ChartAxis(
            labels=[
                ft.ChartAxisLabel(value=0, label=ft.Container(ft.Text("Manzana"), padding=10)),
                ft.ChartAxisLabel(value=1, label=ft.Container(ft.Text("Arándano"), padding=10)),
                ft.ChartAxisLabel(value=2, label=ft.Container(ft.Text("Cereza"), padding=10)),
                ft.ChartAxisLabel(value=3, label=ft.Container(ft.Text("Naranja"), padding=10)),
            ],
            labels_size=40,
        ),
        horizontal_grid_lines=ft.ChartGridLines(
            color=ft.Colors.GREY_300, width=1, dash_pattern=[3, 3]
        ),
        tooltip_bgcolor=ft.Colors.with_opacity(0.5, ft.Colors.GREY_300),
        max_y=110,
        interactive=True,
        expand=True,
    )

    # 2. Retornamos la Vista (ft.View)
    return ft.View(
        route="/test",
        controls=[
            # Aquí van los componentes visuales uno tras otro
            ft.Text("Mi Gráfico de Frutas", size=30, weight=ft.FontWeight.BOLD),
            grafico_barras 
        ]
    )   