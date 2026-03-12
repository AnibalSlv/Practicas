import 'dart:io';
import 'package:flutter/services.dart';
import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart';

// ignore: avoid_init_to_null
var path = null;

class DatabaseHelper {
  static final DatabaseHelper instance = DatabaseHelper._internal();
  static Database? _database;

  DatabaseHelper._internal();

  Future<Database> get database async {
    if (_database != null) return _database!;
    _database = await _initDB();
    return _database!;
  }

  Future<Database> _initDB() async {
    final dbPath = await getDatabasesPath();
    final path = join(dbPath, 'agendavt.db');

    final exists = await databaseExists(path);

    if (!exists) {
      ByteData data = await rootBundle.load('assets/db/agendavt.db');
      List<int> bytes = data.buffer.asUint8List(
        data.offsetInBytes,
        data.lengthInBytes,
      );
      await File(path).writeAsBytes(bytes, flush: true);
    }

    return await openDatabase(path);
  }

  Future<List<Map<String, dynamic>>> obtenerDatos(String tabla) async {
    final db = await database;
    return await db.query(tabla);
  }

  Future<void> addData(
    //? Esto es para pacientes solo que se me olvido cambiar la variable
    String name,
    String species,
    String race,
    String reproductive,
    String weight,
    String age,
    String food,
    String housing,
    String amountOfFood,
    String bathingFrequency,
    String lastHeat,
    String otherPets,
    String imagePath,
  ) async {
    final db = await database;
    await db.insert('mascots', {
      'name': name,
      'species': species,
      'race': race,
      'reproductive': reproductive,
      'weight': weight,
      'age': age,
      'food': food,
      'housing': housing,
      'amount_of_food': amountOfFood,
      'bathing_frequency': bathingFrequency,
      'last_heat': lastHeat,
      'other_pets': otherPets,
      'img': imagePath,
    }, conflictAlgorithm: ConflictAlgorithm.replace);
    print("agregado");
  }

  Future<void> mostrar() async {
    final db = await database;
    final data = await db.query('mascots');
    print(data);
  }

  Future<void> updateMascot(
    int id,
    String name,
    String species,
    String race,
    String reproductive,
    String weight,
    String age,
    String food,
    String housing,
    String amountOfFood,
    String bathingFrequency,
    String lastHeat,
    String otherPets,
    String imagePath,
  ) async {
    final db = await database;
    await db.update(
      'mascots',
      {
        'name': name,
        'species': species,
        'race': race,
        'reproductive': reproductive,
        'weight': weight,
        'age': age,
        'food': food,
        'housing': housing,
        'amount_of_food': amountOfFood,
        'bathing_frequency': bathingFrequency,
        'last_heat': lastHeat,
        'other_pets': otherPets,
        'img': imagePath,
      },
      where: 'Id_mascots = ?',
      whereArgs: [id],
    );
  }

  Future<void> deleteMascot(int id) async {
    final db = await database;
    await db.delete('mascots', where: 'Id_mascots = ?', whereArgs: [id]);
  }

  Future<void> addSchedule(
    String title,
    String date,
    String information,
  ) async {
    final db = await database;
    await db.insert('dates', {
      'title': title,
      'date': date,
      'information': information,
    }, conflictAlgorithm: ConflictAlgorithm.replace);
    print("agregado");
  }

  Future<void> showSchedule() async {
    final db = await database;
    final data = await db.query('dates');
    print(data);
  }

  Future<void> updateSchedule(
    int id,
    String title,
    String date,
    String information,
  ) async {
    final db = await database;
    await db.update(
      'mascots',
      {'title': title, 'date': date, 'information': information},
      where: 'Id_date = ?',
      whereArgs: [id],
    );
  }

  Future<void> deleteSchedule(int id) async {
    final db = await database;
    await db.delete('dates', where: 'Id_date = ?', whereArgs: [id]);
  }

  Future<void> addClient(
    String clients,
    String telephone,
    String address,
    String mascotas,
  ) async {
    final db = await database;
    await db.insert('clients', {
      'clients': clients,
      'telephone': telephone,
      'address': address,
      'mascotas': mascotas,
    }, conflictAlgorithm: ConflictAlgorithm.replace);
  }

  Future<void> showClient() async {
    final db = await database;
    final data = await db.query('clients');
    print(data); // Puedes quitar esto en producción
  }

  Future<void> updateClient(
    int id,
    String clients,
    String telephone,
    String address,
    String mascotas,
  ) async {
    final db = await database;
    await db.update(
      'clients',
      {
        'clients': clients,
        'telephone': telephone,
        'address': address,
        'mascotas': mascotas,
      },
      where: 'Id_clients = ?',
      whereArgs: [id],
    );
  }

  Future<void> deleteClient(int id) async {
    final db = await database;
    await db.delete(
      'clients', // ✅ tabla corregida
      where: 'Id_clients = ?',
      whereArgs: [id],
    );
  }

  Future<void> addPayment(
    String date,
    String clients,
    String activity,
    String payment,
    String totalPayment,
    String method,
    String information,
  ) async {
    final db = await database;
    await db.insert('payments', {
      'date': date,
      'clients': clients,
      'activity': activity,
      'payment': payment,
      'total_payment': totalPayment,
      'method': method,
      'information': information,
    }, conflictAlgorithm: ConflictAlgorithm.replace);
    print("agregado");
  }

  Future<void> showPayment() async {
    final db = await database;
    final data = await db.query('payments');
    print(data);
  }

  Future<void> updatePayment(
    int id,
    String date,
    String clients,
    String activity,
    String payment,
    String totalPayment,
    String method,
    String information,
  ) async {
    final db = await database;
    await db.update(
      'payments',
      {
        'date': date,
        'clients': clients,
        'activity': activity,
        'payment': payment,
        'total_payment': totalPayment,
        'method': method,
        'information': information,
      },
      where: 'Id_payments = ?',
      whereArgs: [id],
    );
  }

  Future<void> deletePayment(int id) async {
    final db = await database;
    await db.delete('payments', where: 'Id_payments = ?', whereArgs: [id]);
  }

  Future<List<Map<String, dynamic>>> getAllPayments() async {
    final db = await database;
    return await db.query('payments', orderBy: 'date DESC');
  }

  Future<void> addProduct(String name, int quantity, String description) async {
    final db = await database;
    await db.insert('inventory', {
      'name': name,
      'quantity': quantity,
      'description': description,
    });
  }

  Future<List<Map<String, dynamic>>> getAllProducts() async {
    final db = await database;
    return await db.query('inventory', orderBy: 'name ASC');
  }

  Future<void> updateQuantity(int id, int newQuantity) async {
    final db = await database;
    await db.update(
      'inventory',
      {'quantity': newQuantity},
      where: 'id = ?',
      whereArgs: [id],
    );
  }

  Future<void> deleteProduct(int id) async {
    final db = await database;
    await db.delete('inventory', where: 'id = ?', whereArgs: [id]);
  }
}
