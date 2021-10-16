import 'package:flutter/material.dart';
import 'package:lfg_front/src/pages/login.dart';
import 'package:lfg_front/src/pages/room.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'LFG',
      theme: ThemeData(
        primarySwatch: Colors.grey,
        visualDensity: VisualDensity.adaptivePlatformDensity,
      ),
      home: RoomsPage(),
    );
  }
}
