import 'package:flutter/material.dart';
import 'details_patient.dart';
import 'database_helper.dart';

class ClientsPages extends StatefulWidget {
  const ClientsPages({super.key});

  @override
  State<ClientsPages> createState() => _ClientsPagesState();
}

class _ClientsPagesState extends State<ClientsPages> {
  final TextEditingController _patientController = TextEditingController();
  final List<Map<String, dynamic>> _mascots = [];
  final List<String> _petNames = [];

  Future<void> _cargarMascotas() async {
    final data = await DatabaseHelper.instance.obtenerDatos('mascots');
    final mascotas = List<Map<String, dynamic>>.from(data);

    mascotas.sort(
      (a, b) => (a['name'] ?? '').toString().toLowerCase().compareTo(
        (b['name'] ?? '').toString().toLowerCase(),
      ),
    );

    setState(() {
      _mascots.clear();
      _mascots.addAll(mascotas); // ✅ ahora sí, ordenado

      _petNames.clear();
      _petNames.addAll(
        mascotas.map((m) => m['name']?.toString() ?? '').toList(),
      );
    });
  }

  void _showAddClients() {
    showDialog(
      context: context,
      builder: (_) => AlertDialog(
        title: Text('Nuevo Paciente'),
        content: TextField(
          controller: _patientController,
          decoration: InputDecoration(labelText: 'Paciente'),
        ),
        actions: [
          Row(
            children: [
              TextButton(
                onPressed: () async {
                  final textPatient = _patientController.text.trim();
                  if (textPatient.isNotEmpty) {
                    await DatabaseHelper.instance.addData(
                      textPatient,
                      '',
                      '',
                      '',
                      '',
                      '',
                      '',
                      '',
                      '',
                      '',
                      '',
                      '',
                      '',
                    );

                    setState(() {
                      _patientController.clear();
                    });
                    await _cargarMascotas();
                  }
                  Navigator.pop(context);
                },
                child: Text('Guardar'),
              ),
              Spacer(),
              TextButton(
                onPressed: () {
                  Navigator.pop(context);
                },
                child: Text("Cancelar"),
              ),
            ],
          ),
        ],
      ),
    );
  }

  @override
  void initState() {
    super.initState();
    _cargarMascotas();
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      top: false,
      child: Scaffold(
        appBar: AppBar(title: Text('Pacientes')),
        body: Column(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            Expanded(
              child: ListView.builder(
                itemCount: _mascots.length,
                itemBuilder: (context, index) {
                  return ListTile(
                    title: Padding(
                      padding: EdgeInsets.all(10),
                      child: InkWell(
                        child: Container(
                          padding: EdgeInsets.all(10),
                          decoration: BoxDecoration(
                            border: Border.all(
                              color: const Color.fromARGB(255, 107, 134, 255),
                              width: 2.5,
                            ),
                            borderRadius: BorderRadius.circular(5),
                          ),
                          child: Text(_petNames[index]),
                        ),
                        onTap: () {
                          final id = _mascots[index]['Id_mascots'];
                          Navigator.push(
                            context,
                            MaterialPageRoute(
                              builder: (context) => DetailsClient(mascotId: id),
                            ),
                          );
                        },
                      ),
                    ),
                  );
                },
              ),
            ),
          ],
        ),
        floatingActionButton: FloatingActionButton(
          backgroundColor: const Color.fromARGB(255, 107, 134, 255),
          tooltip: 'Agregar un nuevo cliente',
          onPressed: _showAddClients,
          child: Icon(Icons.add),
        ),
      ),
    );
  }
}
