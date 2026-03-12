from django.http import JsonResponse
from django.views.decorators.csrf import csrf_exempt
from django.shortcuts import render, redirect
from .models import Empleado, Caso, Cliente, Pago
import json

def index(request):
    return render(request, 'index.html')

def administrador(request):
    empleados = Empleado.objects.all()
    clientes = Cliente.objects.all()
    casos = Caso.objects.all()
    pagos = Pago.objects.select_related('pk_cliente', 'pk_caso')
    return render(request, 'administrador.html', {
        'empleados': empleados,
        'clientes': clientes,
        'casos': casos,
        'pagos': pagos,
    })
    
def asistente(request):
    empleados = Empleado.objects.all()
    clientes = Cliente.objects.all()
    casos = Caso.objects.all()
    pagos = Pago.objects.select_related('pk_cliente', 'pk_caso')
    return render(request, 'asistente.html', {
        'empleados': empleados,
        'clientes': clientes,
        'casos': casos,
        'pagos': pagos,
    })
    
def abogado(request):
    empleados = Empleado.objects.all()
    clientes = Cliente.objects.all()
    casos = Caso.objects.all()
    pagos = Pago.objects.select_related('pk_cliente', 'pk_caso')
    return render(request, 'abogado.html', {
        'empleados': empleados,
        'clientes': clientes,
        'casos': casos,
        'pagos': pagos,
    })
    
def agregar_empleado(request):
    if request.method == 'POST':
        user = request.POST.get('user')
        password = request.POST.get('password')
        nombre = request.POST.get('nombre')
        cedula = request.POST.get('cedula')
        edad = request.POST.get('edad')
        profesion = request.POST.get('profesion')
        ntelefonico = request.POST.get('ntelefonico')
        carpeta = request.POST.get('carpeta')

        # Validación básica
        if not all([user, password, nombre, cedula, edad, profesion]):
            return JsonResponse({'ok': False, 'error': 'Campos incompletos'})

        # Validar que el usuario no exista
        if Empleado.objects.filter(user__iexact=user).exists():
            return JsonResponse({'ok': False, 'error': 'Usuario ya registrado'})

        # Crear nuevo empleado
        empleado = Empleado.objects.create(
            user=user,
            password=password,
            nombre=nombre,
            cedula=cedula,
            edad=edad,
            profesion=profesion,
            ntelefonico=ntelefonico,
            carpeta=carpeta
        )

        return JsonResponse({'ok': True, 'id': empleado.id_empleado})

    return render(request, "index.html")

@csrf_exempt
def agregar_cliente(request):
    if request.method == 'POST':
        nombre = request.POST.get('nombre')
        cedula = request.POST.get('cedula')
        ntelefonico = request.POST.get('ntelefonico')
        abogado_id = request.session.get('usuario_id')
        print("ID abogado en sesión:", abogado_id)
        abogado = Empleado.objects.filter(id_empleado=abogado_id).first()  
        cliente = Cliente.objects.create(
            nombre=nombre,
            cedula=cedula,
            ntelefonico=ntelefonico,
            abogado=abogado 
        )
        return JsonResponse({'ok': True, 'id': cliente.id_cliente})
    return JsonResponse({'ok': False})

@csrf_exempt
def agregar_caso(request):
    if request.method == 'POST':
        fecha = request.POST.get('fecha')
        informacion = request.POST.get('informacion')
        n_de_caso = request.POST.get('n_de_caso')
        documentacion = request.POST.get('documentacion')
        documentacion_url = request.POST.get('documentacion_url')
        cliente_nombre = request.POST.get('cliente_nombre')
        abogados = request.POST.getlist('abogados')
        try:
            cliente = Cliente.objects.filter(nombre=cliente_nombre).first()
            if not cliente:
                return JsonResponse({'ok': False, 'error': 'Cliente no existe'})
            caso = Caso.objects.create(
                fecha=fecha,
                informacion=informacion,
                n_de_caso=n_de_caso,
                documentacion=documentacion,
                documentacion_url=documentacion_url,
                pk_cliente=cliente
            )
            if abogados:
                caso.abogados.set(abogados)
            return JsonResponse({'ok': True, 'id': caso.id_caso})
        except Exception as e:
            return JsonResponse({'ok': False, 'error': str(e)})
    return JsonResponse({'ok': False})
# views.py
@csrf_exempt
def agregar_pago(request):
    if request.method == 'POST':
        cliente_nombre = request.POST.get('cliente_nombre')
        caso_nombre = request.POST.get('caso_nombre')
        pago = request.POST.get('pago')
        try:
            cliente = Cliente.objects.filter(nombre=cliente_nombre).first()
            if not cliente:
                return JsonResponse({'ok': False, 'error': 'Cliente no existe'})
            if not caso_nombre:
                return JsonResponse({'ok': False, 'error': 'Debes seleccionar un caso'})
            try:
                caso = Caso.objects.get(n_de_caso=int(caso_nombre))
            except (ValueError, Caso.DoesNotExist):
                return JsonResponse({'ok': False, 'error': 'Caso no existe'})
            pago_obj = Pago.objects.create(
                pk_cliente=cliente,
                pk_caso=caso,
                pago=pago
            )
            return JsonResponse({'ok': True, 'id': pago_obj.id_pago})
        except Exception as e:
            return JsonResponse({'ok': False, 'error': str(e)})
    return JsonResponse({'ok': False})

@csrf_exempt
def eliminar_empleado(request):
    if request.method == 'POST':
        import json
        data = json.loads(request.body)
        id_empleado = data.get('id')
        try:
            Empleado.objects.get(id_empleado=id_empleado).delete()
            return JsonResponse({'ok': True})
        except:
            return JsonResponse({'ok': False})
    return JsonResponse({'ok': False})

@csrf_exempt
def editar_empleado(request):
    if request.method == 'POST':
        import json
        data = json.loads(request.body)
        id_empleado = data.get('id')
        # Recibe los campos a modificar y actualiza el empleado
        try:
            empleado = Empleado.objects.get(id_empleado=id_empleado)
            empleado.nombre = data.get('nombre', empleado.nombre)
            empleado.cedula = data.get('cedula', empleado.cedula)
            empleado.edad = data.get('edad', empleado.edad)
            empleado.profesion = data.get('profesion', empleado.profesion)
            empleado.ntelefonico = data.get('ntelefonico', empleado.ntelefonico)
            empleado.activo = data.get('activo', empleado.activo)
            empleado.carpeta = data.get('carpeta', empleado.carpeta)
            empleado.user = data.get('user', empleado.user)
            empleado.password = data.get('password', empleado.password)
            empleado.save()
            return JsonResponse({'ok': True})
        except:
            return JsonResponse({'ok': False})
    return JsonResponse({'ok': False})

from django.views.decorators.csrf import csrf_exempt
from django.http import JsonResponse
import json
from .models import Caso, Cliente

@csrf_exempt
def editar_caso(request):
    if request.method == "POST":
        data = json.loads(request.body)
        try:
            caso = Caso.objects.get(pk=data['id'])
            caso.fecha = data['fecha']
            caso.informacion = data['informacion']
            caso.n_de_caso = data['n_de_caso']
            caso.documentacion = data['documentacion']
            # Actualiza cliente si se envía
            if data.get('cliente_nombre'):
                cliente = Cliente.objects.filter(nombre=data['cliente_nombre']).first()
                if cliente:
                    caso.pk_cliente = cliente
            caso.save()
            # Actualiza abogados (ManyToMany)
            if 'abogados' in data:
                caso.abogados.set(data['abogados'])
            return JsonResponse({'ok': True})
        except Exception as e:
            return JsonResponse({'ok': False, 'error': str(e)})
    return JsonResponse({'ok': False, 'error': 'Método no permitido'})

@csrf_exempt
def eliminar_caso(request):
    if request.method == 'POST':
        data = json.loads(request.body)
        id_caso = data.get('id')
        try:
            Caso.objects.get(id_caso=id_caso).delete()
            return JsonResponse({'ok': True})
        except:
            return JsonResponse({'ok': False})
    return JsonResponse({'ok': False})

@csrf_exempt
def editar_cliente(request):
    if request.method == "POST":
        data = json.loads(request.body)
        try:
            cliente = Cliente.objects.get(pk=data['id'])
            cliente.nombre = data.get('nombre', cliente.nombre)
            cliente.cedula = data.get('cedula', cliente.cedula)
            cliente.ntelefonico = data.get('ntelefonico', cliente.ntelefonico)
            cliente.save()
            return JsonResponse({'ok': True})
        except Exception as e:
            return JsonResponse({'ok': False, 'error': str(e)})
    return JsonResponse({'ok': False, 'error': 'Método no permitido'})

@csrf_exempt
def eliminar_cliente(request):
    if request.method == 'POST':
        data = json.loads(request.body)
        id_cliente = data.get('id')
        try:
            Cliente.objects.get(id_cliente=id_cliente).delete()
            return JsonResponse({'ok': True})
        except:
            return JsonResponse({'ok': False})
    return JsonResponse({'ok': False})

@csrf_exempt
def editar_pago(request):
    if request.method == "POST":
        data = json.loads(request.body)
        try:
            pago = Pago.objects.get(pk=data['id'])
            # Actualiza cliente si se envía el nombre
            if data.get('cliente_nombre'):
                cliente = Cliente.objects.filter(nombre=data['cliente_nombre']).first()
                if cliente:
                    pago.pk_cliente = cliente
            # Actualiza caso si se envía el nombre o número
            if data.get('caso_nombre'):
                caso = Caso.objects.filter(n_de_caso=data['caso_nombre']).first()
                if caso:
                    pago.pk_caso = caso
            pago.pago = data.get('monto', pago.pago)
            pago.save()
            return JsonResponse({'ok': True})
        except Exception as e:
            return JsonResponse({'ok': False, 'error': str(e)})
    return JsonResponse({'ok': False, 'error': 'Método no permitido'})

@csrf_exempt
def eliminar_pago(request):
    if request.method == 'POST':
        data = json.loads(request.body)
        id_pago = data.get('id')
        try:
            Pago.objects.get(id_pago=id_pago).delete()
            return JsonResponse({'ok': True})
        except:
            return JsonResponse({'ok': False})
    return JsonResponse({'ok': False})



def login_view(request):
    if request.method == 'POST':
        user = request.POST.get('login_user')
        password = request.POST.get('login_pass')


        print("📥 Datos recibidos del form:")
        print("👤 user:", repr(user))
        print("🔐 password:", repr(password))

        
        empleado = Empleado.objects.filter(user=user, password=password).first()
        if not empleado:
            return render(request, 'index.html', {'error': 'Credenciales inválidas'})
        
        request.session.flush()  # Limpia la sesión anterior
        # Guardar datos en sesión
        request.session['usuario_id'] = empleado.id_empleado
        request.session['rango'] = empleado.profesion.lower().strip()

        print("🧾 Usuario que inicia:", empleado.user)
        print("🔐 Profesión que se guarda:", empleado.profesion.lower().strip())

        # Redirigir según profesión
        return redirect('tabla')

    return render(request, 'index.html')



from django.http import JsonResponse
from django.views.decorators.csrf import csrf_exempt
from django.shortcuts import render, redirect
from .models import Empleado, Caso, Cliente, Pago
import json

# ... (otras vistas como index, administrador, asistente, abogado, agregar_empleado, etc. sin cambios) ...

def tabla(request):
    usuario_id = request.session.get('usuario_id')
    rango = request.session.get('rango')

    print("🔍 usuario_id en sesión:", usuario_id)
    print("🔍 rango en sesión:", repr(rango))

    if not usuario_id or not rango:
        print("⛔ Sesión incompleta. Redirigiendo...")
        return redirect('index')

    rango = rango.lower().strip()  # Asegura formato correcto

    empleados = Empleado.objects.all()
    
    # Inicializamos casos y clientes para evitar errores si el rango no es "abogado"
    casos = Caso.objects.all() 
    clientes = Cliente.objects.all()
    pagos = Pago.objects.select_related('pk_cliente', 'pk_caso')

    if rango == "abogado":
        print("✅ Rango es 'abogado'. Aplicando filtros específicos.")
        
        # 1. Filtrar los casos que están asociados a este abogado
        # 'abogados__id_empleado' es correcto para acceder al ID del empleado a través de la relación ManyToMany
        casos_del_abogado = Caso.objects.filter(abogados__id_empleado=usuario_id).distinct()
        print(f"   Casos del abogado (IDs): {[c.id_caso for c in casos_del_abogado]}")

        # 2. Obtener los IDs de los clientes asociados a esos casos
        # 'pk_cliente_id' es el nombre del campo de la clave foránea en el modelo Caso
        clientes_ids_de_casos = casos_del_abogado.values_list('pk_cliente_id', flat=True)
        print(f"   IDs de clientes de los casos del abogado: {list(clientes_ids_de_casos)}")

        # 3. Filtrar el modelo Cliente usando los IDs obtenidos
        # 'id_cliente' es la clave primaria del modelo Cliente
        clientes = Cliente.objects.filter(id_cliente__in=clientes_ids_de_casos).distinct()
        print(f"   Clientes filtrados para el abogado: {clientes}")

        # 4. Filtrar los pagos relacionados con los casos del abogado
        # 'pk_caso__in=casos_del_abogado' es correcto para filtrar pagos por los casos del abogado
        pagos = pagos.filter(pk_caso__in=casos_del_abogado).distinct()
        print(f"   Pagos filtrados para el abogado: {pagos}")
        
        # Asignar los casos filtrados para que se muestren solo los del abogado
        casos = casos_del_abogado

    elif rango in ["administrador", "asistente"]:
        print("✅ Rango es 'administrador' o 'asistente'. Mostrando todos los datos.")
        # Para estos rangos, ya se inicializaron con .all()
        pass # No se necesita filtro adicional, ya se obtienen todos los datos
    else:
        print("🚫 Rango inválido:", rango)
        clientes = Cliente.objects.none()
        casos = Caso.objects.none()
        pagos = Pago.objects.none() # También vaciar pagos si el rango es inválido

    return render(request, 'tabla.html', {
        'empleados': empleados,
        'clientes': clientes,
        'casos': casos,
        'pagos': pagos,
        'rango': rango,
    })

# ... (resto de tus vistas sin cambios) ...
