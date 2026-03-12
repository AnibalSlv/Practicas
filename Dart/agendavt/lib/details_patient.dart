import 'dart:io';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'database_helper.dart';

class DetailsClient extends StatefulWidget {
  final int mascotId;
  const DetailsClient({super.key, required this.mascotId});

  @override
  State<DetailsClient> createState() => _DetailsClientState();
}

Future<Map<String, dynamic>> obtenerMascotaPorId(int id) async {
  final db = await DatabaseHelper.instance.database;
  final result = await db.query(
    'mascots',
    where: 'Id_mascots = ?',
    whereArgs: [id],
  );
  return result.isNotEmpty ? result.first : {};
}

class _DetailsClientState extends State<DetailsClient> {
  final dbHelper = DatabaseHelper.instance;
  String? _imagePath;
  TextEditingController _patientControllerName = TextEditingController();
  TextEditingController _patientControllerSpecies = TextEditingController();
  TextEditingController _patientControllerRace = TextEditingController();
  TextEditingController _patientControllerReproductive =
      TextEditingController();
  TextEditingController _patientControllerWeight = TextEditingController();
  TextEditingController _patientControllerAge = TextEditingController();
  TextEditingController _patientControllerFood = TextEditingController();
  TextEditingController _patientControllerHousing = TextEditingController();
  TextEditingController _patientControllerAmountFood = TextEditingController();
  TextEditingController _patientControllerBathingFrequency =
      TextEditingController();
  TextEditingController _patientControllerLastHeat = TextEditingController();
  TextEditingController _patientControllerOtherPets = TextEditingController();

  Future<void> _pickImage() async {
    final picker = ImagePicker();
    final pickedFile = await picker.pickImage(source: ImageSource.gallery);
    if (pickedFile != null) {
      setState(() {
        _imagePath = pickedFile.path;
      });
    }
  }

  _showWriteDetail(mascota) {
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
                    controller: _patientControllerName,
                    decoration: InputDecoration(labelText: 'Nombre'),
                  ),
                  TextField(
                    controller: _patientControllerSpecies,
                    decoration: InputDecoration(labelText: 'Especie'),
                  ),
                  TextField(
                    controller: _patientControllerRace,
                    decoration: InputDecoration(labelText: 'Raza'),
                  ),
                  TextField(
                    controller: _patientControllerReproductive,
                    decoration: InputDecoration(labelText: 'E. Reproductivo'),
                  ),
                  TextField(
                    controller: _patientControllerWeight,
                    decoration: InputDecoration(labelText: 'Peso'),
                  ),
                  TextField(
                    controller: _patientControllerAge,
                    decoration: InputDecoration(labelText: 'Edad'),
                  ),
                  TextField(
                    controller: _patientControllerFood,
                    decoration: InputDecoration(labelText: 'Alimento'),
                  ),
                  TextField(
                    controller: _patientControllerHousing,
                    decoration: InputDecoration(labelText: 'Vivienda'),
                  ),
                  TextField(
                    controller: _patientControllerAmountFood,
                    decoration: InputDecoration(labelText: 'Cantida de Comida'),
                  ),
                  TextField(
                    controller: _patientControllerBathingFrequency,
                    decoration: InputDecoration(
                      labelText: 'Frecuencia de Baño',
                    ),
                  ),
                  TextField(
                    controller: _patientControllerLastHeat,
                    decoration: InputDecoration(labelText: 'Ultimo Celo'),
                  ),
                  TextField(
                    controller: _patientControllerOtherPets,
                    decoration: InputDecoration(labelText: 'Otras Mascotas'),
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
                  final textPatientName = _patientControllerName.text.trim();
                  final textPatientSpecie = _patientControllerSpecies.text
                      .trim();
                  final textPatientRace = _patientControllerRace.text.trim();
                  final textPatientReproductive = _patientControllerReproductive
                      .text
                      .trim();
                  final textPatientWeight = _patientControllerWeight.text
                      .trim();
                  final textPatientAge = _patientControllerAge.text.trim();
                  final textPatientFood = _patientControllerFood.text.trim();
                  final textPatientHousing = _patientControllerHousing.text
                      .trim();
                  final textPatientAmountFood = _patientControllerAmountFood
                      .text
                      .trim();
                  final textPatientBathingFrequency =
                      _patientControllerBathingFrequency.text.trim();
                  final textPatientLastHeat = _patientControllerLastHeat.text
                      .trim();
                  final textPatientOtherPets = _patientControllerOtherPets.text
                      .trim();
                  if (textPatientName.isNotEmpty) {
                    await DatabaseHelper.instance.updateMascot(
                      widget.mascotId,
                      textPatientName,
                      textPatientSpecie,
                      textPatientRace,
                      textPatientReproductive,
                      textPatientWeight,
                      textPatientAge,
                      textPatientFood,
                      textPatientHousing,
                      textPatientAmountFood,
                      textPatientBathingFrequency,
                      textPatientLastHeat,
                      textPatientOtherPets,
                      _imagePath = mascota['img'] ?? '',
                    );

                    setState(() {
                      _patientControllerName.clear();
                      _patientControllerSpecies.clear();
                      _patientControllerRace.clear();
                      _patientControllerReproductive.clear();
                      _patientControllerWeight.clear();
                      _patientControllerAge.clear();
                      _patientControllerFood.clear();
                      _patientControllerHousing.clear();
                      _patientControllerAmountFood.clear();
                      _patientControllerBathingFrequency.clear();
                      _patientControllerLastHeat.clear();
                      _patientControllerOtherPets.clear();
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

  //void _mostrar() async {
  //  final data = await dbHelper.obtenerDatos('mascots');
  //  setState(() {
  //    _mascots = data;
  //  });
  //}

  // Aquí va la función
  //void _insert() async {
  //  await dbHelper.addData();
  //}

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      top: false,
      child: Scaffold(
        appBar: AppBar(title: Text("Detalles del Paciente")),
        body: FutureBuilder<Map<String, dynamic>>(
          future: obtenerMascotaPorId(widget.mascotId),
          builder: (context, snapshot) {
            if (snapshot.connectionState == ConnectionState.waiting) {
              return Center(child: CircularProgressIndicator());
            } else if (snapshot.hasError ||
                snapshot.data == null ||
                snapshot.data!.isEmpty) {
              return Center(child: Text('Mascota no encontrada'));
            }

            final mascota = snapshot.data!;
            _patientControllerName = TextEditingController(
              text: '${mascota['name']}',
            );
            _patientControllerSpecies = TextEditingController(
              text: '${mascota['species'] ?? ''}',
            );
            _patientControllerRace = TextEditingController(
              text: '${mascota['race'] ?? ''}',
            );
            _patientControllerReproductive = TextEditingController(
              text: '${mascota['reproductive'] ?? ''}',
            );
            _patientControllerWeight = TextEditingController(
              text: '${mascota['weight'] ?? ''}',
            );
            _patientControllerAge = TextEditingController(
              text: '${mascota['age'] ?? ''}',
            );
            _patientControllerFood = TextEditingController(
              text: '${mascota['food'] ?? ''}',
            );
            _patientControllerHousing = TextEditingController(
              text: '${mascota['housing'] ?? ''}',
            );
            _patientControllerAmountFood = TextEditingController(
              text: '${mascota['amount_of_food'] ?? ''}',
            );
            _patientControllerBathingFrequency = TextEditingController(
              text: '${mascota['bathing_frequency'] ?? ''}',
            );
            _patientControllerLastHeat = TextEditingController(
              text: '${mascota['last_heat'] ?? ''}',
            );
            _patientControllerOtherPets = TextEditingController(
              text: '${mascota['other_pets'] ?? ''}',
            );
            _imagePath ??= mascota['img'];
            return Column(
              mainAxisAlignment: MainAxisAlignment.start,
              children: [
                Expanded(
                  child: ListView(
                    children: [
                      Padding(
                        padding: EdgeInsets.all(10),
                        child: Row(
                          children: [
                            Container(
                              height: 100,
                              width: 100,
                              decoration: BoxDecoration(
                                border: Border.all(
                                  color: const Color.fromARGB(
                                    255,
                                    107,
                                    134,
                                    255,
                                  ),
                                  width: 2.5,
                                ),
                                image: _imagePath != null
                                    ? DecorationImage(
                                        image: FileImage(File(_imagePath!)),
                                        fit: BoxFit.cover,
                                      )
                                    : null,
                                borderRadius: BorderRadius.circular(10000),
                              ),
                            ),
                            Padding(
                              padding: EdgeInsets.all(10),
                              child: Text('${mascota['name']}'),
                            ),
                            Spacer(),
                            ElevatedButton.icon(
                              icon: Icon(Icons.image),
                              onPressed: () async {
                                await _pickImage(); // 👈 espera a que el usuario seleccione la imagen
                                print(
                                  'Ruta de imagen a guardar: $_imagePath',
                                ); // ahora sí tendrá valor
                              },
                              style: ElevatedButton.styleFrom(
                                minimumSize: Size(0, 0),
                              ),
                              label: Text('Foto'),
                            ),
                          ],
                        ),
                      ),
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
                                      "Especie: ${mascota['species'] ?? ''} ",
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.only(bottom: 8),
                                child: Row(
                                  children: [
                                    Text(
                                      "Raza: ${mascota['race']}",
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.only(bottom: 8),
                                child: Row(
                                  children: [
                                    Text(
                                      "E. Reproductivo: ${mascota['reproductive'] ?? ''}",
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.only(bottom: 8),
                                child: Row(
                                  children: [
                                    Text(
                                      "Peso: ${mascota['weight'] ?? ''}",
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.only(bottom: 8),
                                child: Row(
                                  children: [
                                    Text(
                                      "Edad: ${mascota['age'] ?? ''}",
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.only(bottom: 8),
                                child: Row(
                                  children: [
                                    Text(
                                      "Alimento: ${mascota['food'] ?? ''}",
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.only(bottom: 8),
                                child: Row(
                                  children: [
                                    Text(
                                      "Vivienda: ${mascota['housing'] ?? ''}",
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.only(bottom: 8),
                                child: Row(
                                  children: [
                                    Text(
                                      "Cantidad de Alimento: ${mascota['amount_of_food'] ?? ''}",
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.only(bottom: 8),
                                child: Row(
                                  children: [
                                    Text(
                                      "Frecuencia de Baño: ${mascota['bathing_frequency'] ?? ''}",
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.only(bottom: 8),
                                child: Row(
                                  children: [
                                    Text(
                                      "Ultimo Celo: ${mascota['last_heat'] ?? ''}",
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.only(bottom: 8),
                                child: Row(
                                  children: [
                                    Text(
                                      "Otras Mascotas: ${mascota['other_pets'] ?? ''}",
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                            ],
                          ),
                        ),
                      ),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.end,
                        children: [
                          ElevatedButton(
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Colors.red,
                              padding: EdgeInsets.all(12),
                            ),
                            onPressed: () {
                              showDialog(
                                context: context,
                                builder: (BuildContext context) {
                                  return AlertDialog(
                                    title: Text('¿Borrar Paciente?'),
                                    content: Text('El paciente se eliminará.'),
                                    actions: [
                                      TextButton(
                                        onPressed: () => Navigator.pop(context),
                                        child: Text('Cancelar'),
                                      ),
                                      TextButton(
                                        onPressed: () async {
                                          await DatabaseHelper.instance
                                              .deleteMascot(widget.mascotId);
                                          Navigator.pop(
                                            context,
                                          ); // Cierra el diálogo
                                          Navigator.pop(
                                            context,
                                          ); // Vuelve atrás en la navegación
                                        },
                                        child: Text('Aceptar'),
                                      ),
                                    ],
                                  );
                                },
                              );
                            },
                            child: Icon(Icons.delete),
                          ),
                          SizedBox(width: 10),
                          ElevatedButton(
                            onPressed: () => _showWriteDetail(mascota),
                            style: ElevatedButton.styleFrom(
                              padding: EdgeInsets.all(12),
                            ),
                            child: Icon(Icons.edit_document),
                          ),
                          SizedBox(width: 10),
                          ElevatedButton(
                            onPressed: () async {
                              final textPatientName = _patientControllerName
                                  .text
                                  .trim();
                              final textPatientSpecie =
                                  _patientControllerSpecies.text.trim();
                              final textPatientRace = _patientControllerRace
                                  .text
                                  .trim();
                              final textPatientReproductive =
                                  _patientControllerReproductive.text.trim();
                              final textPatientWeight = _patientControllerWeight
                                  .text
                                  .trim();
                              final textPatientAge = _patientControllerAge.text
                                  .trim();
                              final textPatientFood = _patientControllerFood
                                  .text
                                  .trim();
                              final textPatientHousing =
                                  _patientControllerHousing.text.trim();
                              final textPatientAmountFood =
                                  _patientControllerAmountFood.text.trim();
                              final textPatientBathingFrequency =
                                  _patientControllerBathingFrequency.text
                                      .trim();
                              final textPatientLastHeat =
                                  _patientControllerLastHeat.text.trim();
                              final textPatientOtherPets =
                                  _patientControllerOtherPets.text.trim();

                              // ✅ Asegúrate de que _imagePath tenga valor, o usa el que ya estaba guardado
                              final imagePathToSave =
                                  _imagePath ?? mascota['img'] ?? '';

                              if (textPatientName.isNotEmpty) {
                                await DatabaseHelper.instance.updateMascot(
                                  widget.mascotId,
                                  textPatientName,
                                  textPatientSpecie,
                                  textPatientRace,
                                  textPatientReproductive,
                                  textPatientWeight,
                                  textPatientAge,
                                  textPatientFood,
                                  textPatientHousing,
                                  textPatientAmountFood,
                                  textPatientBathingFrequency,
                                  textPatientLastHeat,
                                  textPatientOtherPets,
                                  imagePathToSave,
                                );
                              }
                            },
                            child: Icon(Icons.save),
                          ),
                          SizedBox(width: 10),
                        ],
                      ),
                    ],
                  ),
                ),
              ],
            );
          },
        ),
      ),
    );
  }
}
