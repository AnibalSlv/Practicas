from django.db import models

class Cliente(models.Model):
    id_cliente = models.AutoField(db_column='Id_cliente', primary_key=True)
    nombre = models.TextField()
    cedula = models.IntegerField()
    ntelefonico = models.IntegerField(db_column='Ntelefonico', blank=True, null=True)
    abogado = models.ForeignKey('Empleado', on_delete=models.SET_NULL, null=True, blank=True)
    

    class Meta:
        db_table = 'cliente'

class Empleado(models.Model):
    id_empleado = models.AutoField(db_column='Id_empleado', primary_key=True)
    nombre = models.TextField()
    cedula = models.IntegerField(unique=True)
    edad = models.IntegerField()
    profesion = models.TextField()  # Si profesion == "Abogado", es abogado
    ntelefonico = models.IntegerField(db_column='Ntelefonico', blank=True, null=True)
    activo = models.BooleanField(default=True)
    carpeta = models.TextField()
    user = models.TextField()
    password = models.TextField()

    class Meta:
        db_table = 'empleado'
        
class Caso(models.Model):
    id_caso = models.AutoField(db_column='Id_caso', primary_key=True)
    fecha = models.CharField(max_length=20)
    informacion = models.TextField()
    n_de_caso = models.IntegerField(db_column='N_de_caso')
    documentacion = models.TextField(blank=True, null=True)
    documentacion_url = models.URLField(blank=True, null=True)  # Nuevo campo para links
    pk_cliente = models.ForeignKey(Cliente, models.DO_NOTHING, db_column='Pk_cliente', blank=True, null=True)
    abogados = models.ManyToManyField(Empleado, blank=True)  # Relación con empleados

    class Meta:
        db_table = 'caso'

class Pago(models.Model):
    id_pago = models.AutoField(db_column='Id_pago', primary_key=True)
    pk_cliente = models.ForeignKey(Cliente, models.DO_NOTHING, db_column='PK_cliente')
    pk_caso = models.ForeignKey(Caso, models.DO_NOTHING, db_column='PK_caso')
    pago = models.IntegerField()

    class Meta:
        db_table = 'pago'