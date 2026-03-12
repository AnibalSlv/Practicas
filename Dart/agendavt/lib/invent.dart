import 'package:flutter/material.dart';
import 'database_helper.dart';

class InventoryPage extends StatefulWidget {
  const InventoryPage({super.key});

  @override
  State<InventoryPage> createState() => _InventoryPageState();
}

class _InventoryPageState extends State<InventoryPage> {
  final _nameController = TextEditingController();
  final _quantityController = TextEditingController();
  final _descriptionController = TextEditingController();

  List<Map<String, dynamic>> _products = [];

  @override
  void initState() {
    super.initState();
    _loadProducts();
  }

  Future<void> _loadProducts() async {
    final data = await DatabaseHelper.instance.getAllProducts();
    setState(() {
      _products = data;
    });
  }

  void _showAddProductDialog() {
    _nameController.clear();
    _quantityController.clear();
    _descriptionController.clear();

    showDialog(
      context: context,
      builder: (_) => AlertDialog(
        title: const Text('Agregar Producto'),
        content: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            TextField(
              controller: _nameController,
              decoration: const InputDecoration(labelText: 'Nombre'),
            ),
            TextField(
              controller: _quantityController,
              decoration: const InputDecoration(labelText: 'Cantidad'),
              keyboardType: TextInputType.number,
            ),
            TextField(
              controller: _descriptionController,
              decoration: const InputDecoration(labelText: 'Descripción'),
            ),
          ],
        ),
        actions: [
          TextButton(
            onPressed: () async {
              final name = _nameController.text.trim();
              final quantity =
                  int.tryParse(_quantityController.text.trim()) ?? 0;
              final description = _descriptionController.text.trim();

              if (name.isNotEmpty && quantity > 0) {
                await DatabaseHelper.instance.addProduct(
                  name,
                  quantity,
                  description,
                );
                Navigator.pop(context);
                await _loadProducts();
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

  Future<void> _changeQuantity(int id, int current, int delta) async {
    final newQuantity = current + delta;
    if (newQuantity >= 0) {
      await DatabaseHelper.instance.updateQuantity(id, newQuantity);
      await _loadProducts();
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Inventario')),
      body: ListView.builder(
        itemCount: _products.length,
        itemBuilder: (context, index) {
          final item = _products[index];
          return Dismissible(
            key: Key(item['id'].toString()),
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
                builder: (context) => AlertDialog(
                  title: const Text('¿Eliminar producto?'),
                  content: Text(
                    '¿Deseas eliminar "${item['name']}" del inventario?',
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
                await DatabaseHelper.instance.deleteProduct(item['id']);
                await _loadProducts();
                ScaffoldMessenger.of(context).showSnackBar(
                  SnackBar(
                    content: Text('Producto "${item['name']}" eliminado'),
                  ),
                );
                return true; // ✅ permite el dismiss
              }

              return false; // ❌ cancela el dismiss
            },
            child: ListTile(
              title: Text(item['name']),
              subtitle: Text(
                '${item['description'] ?? ''}\nCantidad: ${item['quantity']}',
              ),
              isThreeLine: true,
              trailing: Row(
                mainAxisSize: MainAxisSize.min,
                children: [
                  IconButton(
                    icon: const Icon(Icons.remove),
                    onPressed: () =>
                        _changeQuantity(item['id'], item['quantity'], -1),
                  ),
                  IconButton(
                    icon: const Icon(Icons.add),
                    onPressed: () =>
                        _changeQuantity(item['id'], item['quantity'], 1),
                  ),
                ],
              ),
            ),
          );
        },
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: _showAddProductDialog,
        tooltip: 'Agregar producto',
        child: const Icon(Icons.add),
      ),
    );
  }
}
