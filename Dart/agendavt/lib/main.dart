import 'package:flutter/material.dart';
import 'patient_page.dart';
import 'schedule.dart';
import 'client.dart';
import 'payment.dart';
import 'invent.dart';

void main() {
  runApp(
    MaterialApp(
      title: "ni idea bro",
      home: SafeArea(top: false, bottom: true, child: MyApp()),
      routes: {
        '/patient_page': (context) => ClientsPages(),
        '/schedule': (context) => Schedule(),
        '/client': (context) => ClientsPage(),
        '/payment': (context) => Payment(),
        '/invent': (context) => InventoryPage(),
      },
    ),
  );
}

double vh(BuildContext context, double porcentaje) =>
    MediaQuery.of(context).size.height * porcentaje;

double vw(BuildContext context, double porcentaje) =>
    MediaQuery.of(context).size.width * porcentaje;

class StyleContainer extends StatelessWidget {
  final Widget child;

  const StyleContainer({super.key, required this.child});

  @override
  Widget build(BuildContext context) {
    return Container(
      height: vh(context, 0.2),
      width: vw(context, 0.4),
      padding: EdgeInsets.all(16),
      decoration: BoxDecoration(
        border: Border.all(
          color: const Color.fromARGB(255, 107, 134, 255),
          width: 2.5,
        ),
        boxShadow: [
          BoxShadow(
            color: Colors.black.withValues(alpha: 0.3),
            spreadRadius: 2,
            blurRadius: 10,
            offset: Offset(4, 4),
          ),
        ],
        borderRadius: BorderRadius.circular(15),
        color: Colors.white,
      ),
      child: child,
    );
  }
}

class MyApp extends StatefulWidget {
  const MyApp({super.key});

  @override
  State<MyApp> createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Color.fromARGB(255, 107, 134, 255),
        title: Center(
          child: Text("AgendaVT", style: TextStyle(color: Colors.white)),
        ),
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            SizedBox(height: vh(context, 0.05)),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                InkWell(
                  onTap: () {
                    Navigator.pushNamed(context, '/patient_page');
                  },
                  child: StyleContainer(
                    child: Center(child: Text("Pacientes")),
                  ),
                ),
                SizedBox(width: vw(context, 0.1)),
                InkWell(
                  onTap: () {
                    Navigator.pushNamed(context, '/schedule');
                  },
                  child: StyleContainer(
                    child: Center(child: Text("Agenda y Citas")),
                  ),
                ),
              ],
            ),
            SizedBox(height: vh(context, 0.03)),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                InkWell(
                  onTap: () {
                    Navigator.pushNamed(context, '/client');
                  },
                  child: StyleContainer(child: Center(child: Text("Clientes"))),
                ),
                SizedBox(width: vw(context, 0.1)),
                InkWell(
                  onTap: () {
                    Navigator.pushNamed(context, '/payment');
                  },
                  child: StyleContainer(child: Center(child: Text("Pagos"))),
                ),
              ],
            ),
            SizedBox(height: 20),
            InkWell(
              child: Container(
                height: vh(context, 0.20),
                width: vw(context, 0.90),
                padding: EdgeInsets.all(16),
                decoration: BoxDecoration(
                  border: Border.all(
                    color: const Color.fromARGB(255, 107, 134, 255),
                    width: 2.5,
                  ),
                  boxShadow: [
                    BoxShadow(
                      color: Colors.black.withValues(alpha: 0.3),
                      spreadRadius: 2,
                      blurRadius: 10,
                      offset: Offset(4, 4),
                    ),
                  ],
                  color: Colors.white,
                  borderRadius: BorderRadius.circular(15),
                ),
                child: Center(child: Text("Inventario")),
              ),
              onTap: () {
                Navigator.pushNamed(context, '/invent');
              },
            ),
          ],
        ),
      ),
    );
  }
}
