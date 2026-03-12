import 'package:flutter/material.dart';
import 'database_helper.dart';

class DetailsClient extends StatefulWidget {
  final int mascotId;
  const DetailsClient({super.key, required this.mascotId});

  @override
  State<DetailsClient> createState() => _DetailsClientState();
}

class _DetailsClientState extends State<DetailsClient> {
  TextEditingController _clientControllerName = TextEditingController();
  TextEditingController _clientControllerTelephone = TextEditingController();
  TextEditingController _clientControllerAddress = TextEditingController();

  Future<Map<String, dynamic>> obtenerMascotaPorId(int id) async {
    final db = await DatabaseHelper.instance.database;
    final result = await db.query(
      'clients',
      where: 'Id_clients = ?',
      whereArgs: [id],
    );
    return result.isNotEmpty ? result.first : {};
  }

  @override
  void initState() {
    super.initState();
    _loadClient(); // tu método para obtener datos del cliente
  }

  Future<void> _loadClient() async {
    final cliente = await obtenerMascotaPorId(widget.mascotId);
    if (cliente.isNotEmpty) {
      setState(() {
        _clientControllerName.text = cliente['clients'] ?? '';
        _clientControllerTelephone.text = cliente['telephone'] ?? '';
        _clientControllerAddress.text = cliente['address'] ?? '';
      });
    }
  }

  _showWriteDetail() {
    showDialog(
      context: context,
      builder: (_) => AlertDialog(
        title: Text('Nuevo Paciente'),
        content: Column(
          children: [
            Expanded(
              child: ListView(
                children: [
                  TextField(
                    controller: _clientControllerName,
                    decoration: InputDecoration(labelText: 'Nombre'),
                  ),
                  TextField(
                    controller: _clientControllerTelephone,
                    decoration: InputDecoration(labelText: 'Numero Telefonico'),
                  ),
                  TextField(
                    controller: _clientControllerAddress,
                    decoration: InputDecoration(labelText: 'Dirrecion'),
                  ),
                ],
              ),
            ),
          ],
        ),
        actions: [
          Row(
            children: [
              TextButton(
                onPressed: () async {
                  final textClientName = _clientControllerName.text.trim();
                  final textClientTelephone = _clientControllerTelephone.text
                      .trim();
                  final textClientAddres = _clientControllerAddress.text.trim();
                  if (textClientName.isNotEmpty) {
                    await DatabaseHelper.instance.updateClient(
                      widget.mascotId,
                      textClientName,
                      textClientTelephone,
                      textClientAddres,
                    );

                    setState(() {
                      _clientControllerName.clear();
                      _clientControllerTelephone.clear();
                      _clientControllerAddress.clear();
                    });
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
  Widget build(BuildContext context) {
    return SafeArea(
      top: false,
      child: Scaffold(
        appBar: AppBar(title: Text("Detalles del Cliente")),
        body: FutureBuilder<Map<String, dynamic>>(
          future: obtenerMascotaPorId(widget.mascotId),
          builder: (context, snapshot) {
            if (snapshot.connectionState == ConnectionState.waiting) {
              return Center(child: CircularProgressIndicator());
            } else if (snapshot.hasError ||
                snapshot.data == null ||
                snapshot.data!.isEmpty) {
              return Center(child: Text('Cliente no encontrado'));
            }
            final cliente = snapshot.data!;

            _clientControllerName = TextEditingController(
              text: '${cliente['clients'] ?? ''}',
            );
            _clientControllerTelephone = TextEditingController(
              text: '${cliente['telephone'] ?? ''}',
            );
            _clientControllerAddress = TextEditingController(
              text: '${cliente['address'] ?? ''}',
            );

            return Column(
              mainAxisAlignment: MainAxisAlignment.start,
              children: [
                Padding(
                  padding: EdgeInsets.all(10),
                  child: Container(
                    decoration: BoxDecoration(
                      border: Border(
                        bottom: BorderSide(color: Colors.grey, width: 1),
                      ),
                    ),
                    child: Column(
                      children: [
                        Padding(
                          padding: EdgeInsets.only(bottom: 8),
                          child: Row(
                            children: [
                              Text(
                                "Nombre: ",
                                style: TextStyle(fontWeight: FontWeight.bold),
                              ),
                              Text('${cliente['clients']}'),
                            ],
                          ),
                        ),
                        Padding(
                          padding: EdgeInsets.only(bottom: 8),
                          child: Row(
                            children: [
                              Text(
                                "N. telefonico: ",
                                style: TextStyle(fontWeight: FontWeight.bold),
                              ),
                              Text("${cliente['telephone']}"),
                            ],
                          ),
                        ),
                        Padding(
                          padding: EdgeInsets.only(bottom: 8),
                          child: Row(
                            children: [
                              Text(
                                "Direccion: ",
                                style: TextStyle(fontWeight: FontWeight.bold),
                              ),
                              Text("${cliente['address']}"),
                            ],
                          ),
                        ),
                        Padding(
                          padding: EdgeInsets.only(bottom: 8),
                          child: Row(
                            children: [
                              Text(
                                "Mascotas: ",
                                style: TextStyle(fontWeight: FontWeight.bold),
                              ),
                              Text(""),
                            ],
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
              ],
            );
          },
        ),
        floatingActionButton: FloatingActionButton(
          backgroundColor: const Color.fromARGB(255, 107, 134, 255),
          tooltip: 'Agregar un nuevo cliente',
          onPressed: _showWriteDetail,
          child: Icon(Icons.add),
        ),
      ),
    );
  }
}
