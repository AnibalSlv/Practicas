import 'package:flutter/material.dart';
import 'database_helper.dart';

class Schedule extends StatefulWidget {
  const Schedule({super.key});
  @override
  State<Schedule> createState() => _ScheduleState();
}

class _ScheduleState extends State<Schedule> {
  List<Map<String, dynamic>> citas = [];
  TextEditingController scheduleTitle = TextEditingController();
  TextEditingController scheduleDate = TextEditingController();
  TextEditingController scheduleInformation = TextEditingController();
  TextEditingController descripcionController = TextEditingController();
  TextEditingController titleController = TextEditingController();

  Future<List<Map<String, dynamic>>> obtenerDatos() async {
    return await DatabaseHelper.instance.obtenerDatos('dates');
  }

  void _agregarCita(DateTime fecha, String descripcion) {
    setState(() {
      citas.add({'fecha': fecha, 'descripcion': descripcion});
    });
  }

  void _mostrarDialogoNuevaCita() async {
    DateTime? fechaSeleccionada = await showDatePicker(
      context: context,
      initialDate: DateTime.now(),
      firstDate: DateTime.now().subtract(Duration(days: 1)),
      lastDate: DateTime.now().add(Duration(days: 365)),
    );

    if (fechaSeleccionada != null) {
      // Seleccionar hora
      TimeOfDay? horaSeleccionada = await showTimePicker(
        context: context,
        initialTime: TimeOfDay.now(),
      );

      if (horaSeleccionada != null) {
        // Combinar fecha y hora
        final fechaHora = DateTime(
          fechaSeleccionada.year,
          fechaSeleccionada.month,
          fechaSeleccionada.day,
          horaSeleccionada.hour,
          horaSeleccionada.minute,
        );

        showDialog(
          context: context,
          builder: (_) => AlertDialog(
            title: Text('Nueva cita'),
            content: Column(
              children: [
                TextField(
                  controller: titleController,
                  decoration: InputDecoration(labelText: 'Titulo'),
                ),
                TextField(
                  controller: descripcionController,
                  decoration: InputDecoration(labelText: 'Descripción'),
                ),
              ],
            ),
            actions: [
              TextButton(
                onPressed: () async {
                  if (descripcionController.text.isNotEmpty) {
                    Navigator.pop(context);
                    _agregarCita(fechaHora, descripcionController.text);
                    final scheduleTitle = titleController.text;
                    final scheduleInformation = descripcionController.text;
                    final scheduleDate = fechaHora.toIso8601String();
                    await DatabaseHelper.instance.addSchedule(
                      scheduleTitle,
                      scheduleDate,
                      scheduleInformation,
                    );
                  } else {
                    showDialog(
                      context: context,
                      builder: (BuildContext context) {
                        return AlertDialog(
                          title: Text('Error'),
                          content: Text('Te falto un campo por rellenar'),
                          actions: <Widget>[
                            TextButton(
                              child: Text('Aceptar'),
                              onPressed: () {
                                // Acción al aceptar
                                Navigator.of(context).pop();
                              },
                            ),
                          ],
                        );
                      },
                    );
                  }
                },
                child: Text('Guardar'),
              ),
            ],
          ),
        );
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      top: false,
      child: Scaffold(
        appBar: AppBar(title: Text('Agenda')),
        body: FutureBuilder<List<Map<String, dynamic>>>(
          future: obtenerDatos(),
          builder: (context, snapshot) {
            if (snapshot.connectionState == ConnectionState.waiting) {
              return Center(child: CircularProgressIndicator());
            } else if (snapshot.hasError) {
              return Center(child: Text('Error: ${snapshot.error}'));
            } else if (!snapshot.hasData || snapshot.data!.isEmpty) {
              return Center(child: Text('No hay datos'));
            } else {
              final citas = snapshot.data!;
              return ListView.builder(
                itemCount: citas.length,
                itemBuilder: (context, index) {
                  final cita = citas[index];
                  return Dismissible(
                    key: Key(cita['Id_date'].toString()),
                    direction: DismissDirection.endToStart,
                    background: Container(
                      color: Colors.red,
                      alignment: Alignment.centerRight,
                      padding: EdgeInsets.symmetric(horizontal: 20),
                      child: Icon(Icons.delete, color: Colors.white),
                    ),
                    onDismissed: (direction) async {
                      await DatabaseHelper.instance.deleteSchedule(
                        cita['Id_date'],
                      );
                      setState(() {}); // 🔄 Refresca la lista
                      ScaffoldMessenger.of(
                        context,
                      ).showSnackBar(SnackBar(content: Text('Cita eliminada')));
                    },

                    child: Card(
                      margin: EdgeInsets.symmetric(horizontal: 12, vertical: 6),
                      child: ListTile(
                        title: Text(cita['title'] ?? 'Sin título'),
                        subtitle: Text(
                          cita['information'] ?? 'Sin descripción',
                        ),
                        trailing: Text(
                          cita['date'] != null
                              ? cita['date'].toString().substring(0, 16)
                              : '',
                        ),
                      ),
                    ),
                  );
                },
              );
            }
          },
        ),
        floatingActionButton: FloatingActionButton(
          backgroundColor: const Color.fromARGB(255, 107, 134, 255),
          tooltip: 'Agregar nueva cita',
          onPressed: _mostrarDialogoNuevaCita,
          child: Icon(Icons.calendar_today),
        ),
      ),
    );
  }
}
