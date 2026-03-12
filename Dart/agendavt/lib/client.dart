import 'package:flutter/material.dart';
import 'database_helper.dart';

class ClientsPage extends StatefulWidget {
  const ClientsPage({super.key});

  @override
  State<ClientsPage> createState() => _ClientsPageState();
}

class _ClientsPageState extends State<ClientsPage> {
  final _nameController = TextEditingController();
  final _phoneController = TextEditingController();
  final _addressController = TextEditingController();
  final _mascotasController = TextEditingController(); // 🐾 nuevo

  List<Map<String, dynamic>> _clients = [];
  int? _editingId;

  @override
  void initState() {
    super.initState();
    _loadClients();
  }

  Future<void> _loadClients() async {
    final db = await DatabaseHelper.instance.database;
    final result = await db.query('clients', orderBy: 'clients ASC');
    setState(() {
      _clients = result;
    });
  }

  void _showClientDialog({Map<String, dynamic>? existing}) {
    if (existing != null) {
      _editingId = existing['Id_clients'];
      _nameController.text = existing['clients'] ?? '';
      _phoneController.text = existing['telephone'] ?? '';
      _addressController.text = existing['address'] ?? '';
      _mascotasController.text = existing['mascotas'] ?? '';
    } else {
      _editingId = null;
      _nameController.clear();
      _phoneController.clear();
      _addressController.clear();
      _mascotasController.clear();
    }

    showDialog(
      context: context,
      builder: (_) => AlertDialog(
        title: Text(_editingId == null ? 'Agregar Cliente' : 'Editar Cliente'),
        content: SingleChildScrollView(
          child: Column(
            children: [
              TextField(
                controller: _nameController,
                decoration: const InputDecoration(labelText: 'Nombre'),
              ),
              TextField(
                controller: _phoneController,
                decoration: const InputDecoration(labelText: 'Teléfono'),
                keyboardType: TextInputType.phone,
              ),
              TextField(
                controller: _addressController,
                decoration: const InputDecoration(labelText: 'Dirección'),
              ),
              TextField(
                controller: _mascotasController,
                decoration: const InputDecoration(
                  labelText: 'Mascotas (texto libre)',
                ),
              ), // 🐾
            ],
          ),
        ),
        actions: [
          TextButton(
            onPressed: () async {
              final name = _nameController.text.trim();
              final phone = _phoneController.text.trim();
              final address = _addressController.text.trim();
              final mascotas = _mascotasController.text.trim();

              if (name.isNotEmpty) {
                if (_editingId == null) {
                  await DatabaseHelper.instance.addClient(
                    name,
                    phone,
                    address,
                    mascotas,
                  );
                } else {
                  await DatabaseHelper.instance.updateClient(
                    _editingId!,
                    name,
                    phone,
                    address,
                    mascotas,
                  );
                }
                Navigator.pop(context);
                await _loadClients();
              }
            },
            child: const Text('Guardar'),
          ),
          TextButton(
            onPressed: () => Navigator.pop(context),
            child: const Text('Cancelar'),
          ),
        ],
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Clientes')),
      body: _clients.isEmpty
          ? const Center(child: Text('No hay clientes registrados'))
          : ListView.builder(
              itemCount: _clients.length,
              itemBuilder: (context, index) {
                final client = _clients[index];
                return Dismissible(
                  key: Key(client['Id_clients'].toString()),
                  direction: DismissDirection.endToStart,
                  background: Container(
                    color: Colors.red,
                    alignment: Alignment.centerRight,
                    padding: const EdgeInsets.symmetric(horizontal: 20),
                    child: const Icon(Icons.delete, color: Colors.white),
                  ),
                  confirmDismiss: (_) async {
                    final confirm = await showDialog<bool>(
                      context: context,
                      builder: (_) => AlertDialog(
                        title: const Text('¿Eliminar cliente?'),
                        content: Text(
                          '¿Deseas eliminar a "${client['clients']}"?',
                        ),
                        actions: [
                          TextButton(
                            onPressed: () => Navigator.pop(context, false),
                            child: const Text('Cancelar'),
                          ),
                          TextButton(
                            onPressed: () => Navigator.pop(context, true),
                            child: const Text(
                              'Eliminar',
                              style: TextStyle(color: Colors.red),
                            ),
                          ),
                        ],
                      ),
                    );

                    if (confirm == true) {
                      await DatabaseHelper.instance.deleteClient(
                        client['Id_clients'],
                      );
                      await _loadClients();
                      ScaffoldMessenger.of(context).showSnackBar(
                        SnackBar(
                          content: Text(
                            'Cliente "${client['clients']}" eliminado',
                          ),
                        ),
                      );
                      return true;
                    }

                    return false;
                  },
                  child: ListTile(
                    title: Text(client['clients']),
                    subtitle: Text(
                      'Tel: ${client['telephone'] ?? '—'}\nDir: ${client['address'] ?? '—'}\nMascotas: ${client['mascotas'] ?? '—'}',
                    ),
                    isThreeLine: true,
                    trailing: IconButton(
                      icon: const Icon(Icons.edit, color: Colors.blue),
                      onPressed: () => _showClientDialog(existing: client),
                    ),
                  ),
                );
              },
            ),
      floatingActionButton: FloatingActionButton(
        onPressed: () => _showClientDialog(),
        tooltip: 'Agregar cliente',
        child: const Icon(Icons.person_add),
      ),
    );
  }
}
