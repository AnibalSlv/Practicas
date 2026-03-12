from django.urls import path
from app import views

urlpatterns = [
    path('', views.login_view, name='index'),
    path('administrador.html/', views.administrador, name='administrador'),
    path('asistente.html/', views.asistente, name='asistente'),
    path('abogado.html/', views.abogado, name='abogado'),
    path('agregar_cliente/', views.agregar_cliente, name='agregar_cliente'),
    path('agregar_empleado/', views.agregar_empleado, name='agregar_empleado'),
    path('agregar_caso/', views.agregar_caso, name='agregar_caso'),
    path('agregar_pago/', views.agregar_pago, name='agregar_pago'),
    path('eliminar_empleado/', views.eliminar_empleado, name='eliminar_empleado'),
    path('editar_empleado/', views.editar_empleado, name='editar_empleado'),
    path('editar_cliente/', views.editar_cliente, name='editar_cliente'),
    path('eliminar_cliente/', views.eliminar_cliente, name='eliminar_cliente'),
    path('editar_caso/', views.editar_caso, name='editar_caso'),
    path('eliminar_caso/', views.eliminar_caso, name='eliminar_caso'),
    path('editar_pago/', views.editar_pago, name='editar_pago'),
    path('eliminar_pago/', views.eliminar_pago, name='eliminar_pago'),
    path('tabla/', views.tabla, name='tabla'),
]