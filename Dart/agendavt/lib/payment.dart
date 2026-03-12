import 'package:flutter/material.dart';
import 'database_helper.dart';

class Payment extends StatefulWidget {
  const Payment({super.key});

  @override
  State<Payment> createState() => _PaymentState();
}

class _PaymentState extends State<Payment> {
  final _paymentControllerDate = TextEditingController();
  final _paymentControllerClient = TextEditingController();
  final _paymentControllerActivity = TextEditingController();
  final _paymentControllerPayment = TextEditingController();
  final _paymentControllerPaymentTotal = TextEditingController();
  final _paymentControllerMethod = TextEditingController();
  final _paymentControllerInformation = TextEditingController();

  List<Map<String, dynamic>> _payments = [];
  int? _editingId;

  @override
  void initState() {
    super.initState();
    _loadPayments();
  }

  Future<void> _loadPayments() async {
    final data = await DatabaseHelper.instance.getAllPayments();
    setState(() {
      _payments = data;
    });
  }

  void _showAddOrEditPayment({Map<String, dynamic>? existing}) {
    if (existing != null) {
      _editingId = existing['Id_payments'];
      _paymentControllerDate.text = existing['date'] ?? '';
      _paymentControllerClient.text = existing['clients'] ?? '';
      _paymentControllerActivity.text = existing['activity'] ?? '';
      _paymentControllerPayment.text = existing['payment'] ?? '';
      _paymentControllerPaymentTotal.text = existing['total_payment'] ?? '';
      _paymentControllerMethod.text = existing['method'] ?? '';
      _paymentControllerInformation.text = existing['information'] ?? '';
    } else {
      _editingId = null;
      _paymentControllerDate.clear();
      _paymentControllerClient.clear();
      _paymentControllerActivity.clear();
      _paymentControllerPayment.clear();
      _paymentControllerPaymentTotal.clear();
      _paymentControllerMethod.clear();
      _paymentControllerInformation.clear();
    }

    showDialog(
      context: context,
      builder: (_) => AlertDialog(
        title: Text(_editingId == null ? 'Registrar Pago' : 'Editar Pago'),
        content: SizedBox(
          height: 350,
          child: SingleChildScrollView(
            child: Column(
              children: [
                TextField(
                  controller: _paymentControllerDate,
                  decoration: InputDecoration(labelText: 'Fecha'),
                ),
                TextField(
                  controller: _paymentControllerClient,
                  decoration: InputDecoration(labelText: 'Cliente'),
                ),
                TextField(
                  controller: _paymentControllerActivity,
                  decoration: InputDecoration(labelText: 'Actividad'),
                ),
                TextField(
                  controller: _paymentControllerPayment,
                  decoration: InputDecoration(labelText: 'Pago'),
                ),
                TextField(
                  controller: _paymentControllerPaymentTotal,
                  decoration: InputDecoration(labelText: 'Pago Total'),
                ),
                TextField(
                  controller: _paymentControllerMethod,
                  decoration: InputDecoration(labelText: 'Método de Pago'),
                ),
                TextField(
                  controller: _paymentControllerInformation,
                  decoration: InputDecoration(labelText: 'Información'),
                ),
              ],
            ),
          ),
        ),
        actions: [
          TextButton(
            onPressed: () async {
              final date = _paymentControllerDate.text.trim();
              final client = _paymentControllerClient.text.trim();
              final activity = _paymentControllerActivity.text.trim();
              final payment = _paymentControllerPayment.text.trim();
              final total = _paymentControllerPaymentTotal.text.trim();
              final method = _paymentControllerMethod.text.trim();
              final info = _paymentControllerInformation.text.trim();

              if ([
                date,
                client,
                activity,
                payment,
                total,
                method,
              ].every((e) => e.isNotEmpty)) {
                if (_editingId == null) {
                  await DatabaseHelper.instance.addPayment(
                    date,
                    client,
                    activity,
                    payment,
                    total,
                    method,
                    info,
                  );
                } else {
                  await DatabaseHelper.instance.updatePayment(
                    _editingId!,
                    date,
                    client,
                    activity,
                    payment,
                    total,
                    method,
                    info,
                  );
                }
                Navigator.pop(context);
                await _loadPayments();
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

  Future<void> _deletePayment(int id) async {
    final confirm = await showDialog<bool>(
      context: context,
      builder: (context) => AlertDialog(
        title: const Text('¿Eliminar pago?'),
        content: const Text(
          '¿Estás seguro de que deseas eliminar este pago? Esta acción no se puede deshacer.',
        ),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context, false),
            child: const Text('Cancelar'),
          ),
          TextButton(
            onPressed: () => Navigator.pop(context, true),
            child: const Text('Eliminar', style: TextStyle(color: Colors.red)),
          ),
        ],
      ),
    );

    if (confirm == true) {
      await DatabaseHelper.instance.deletePayment(id);
      await _loadPayments();
      ScaffoldMessenger.of(
        context,
      ).showSnackBar(const SnackBar(content: Text('Pago eliminado')));
    }
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      top: false,
      child: Scaffold(
        appBar: AppBar(title: const Text("Pagos")),
        body: SingleChildScrollView(
          scrollDirection: Axis.horizontal,
          child: SingleChildScrollView(
            scrollDirection: Axis.vertical,
            child: DataTable(
              columns: const [
                DataColumn(label: Text('Fecha')),
                DataColumn(label: Text('Cliente')),
                DataColumn(label: Text('Actividad')),
                DataColumn(label: Text('Pago')),
                DataColumn(label: Text('Total')),
                DataColumn(label: Text('Método')),
                DataColumn(label: Text('Info')),
                DataColumn(label: Text('Acciones')),
              ],
              rows: _payments.map((pago) {
                return DataRow(
                  cells: [
                    DataCell(Text(pago['date'] ?? '')),
                    DataCell(Text(pago['clients'] ?? '')),
                    DataCell(Text(pago['activity'] ?? '')),
                    DataCell(Text(pago['payment'] ?? '')),
                    DataCell(Text(pago['total_payment'] ?? '')),
                    DataCell(Text(pago['method'] ?? '')),
                    DataCell(Text(pago['information'] ?? '')),
                    DataCell(
                      Row(
                        children: [
                          IconButton(
                            icon: const Icon(Icons.edit, color: Colors.blue),
                            onPressed: () =>
                                _showAddOrEditPayment(existing: pago),
                          ),
                          IconButton(
                            icon: const Icon(Icons.delete, color: Colors.red),
                            onPressed: () =>
                                _deletePayment(pago['Id_payments']),
                          ),
                        ],
                      ),
                    ),
                  ],
                );
              }).toList(),
            ),
          ),
        ),
        floatingActionButton: FloatingActionButton(
          backgroundColor: const Color.fromARGB(255, 107, 134, 255),
          tooltip: 'Agregar nuevo pago',
          onPressed: () => _showAddOrEditPayment(),
          child: const Icon(Icons.attach_money),
        ),
      ),
    );
  }
}
