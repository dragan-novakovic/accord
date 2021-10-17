import 'package:flutter/material.dart';
import 'package:lfg_front/src/pages/room.dart';
import 'package:get_it/get_it.dart';

// This is our global ServiceLocator
GetIt getIt = GetIt.instance;

void main() {
  // getIt.registerSingleton<AppModel>(AppModelImplementation(),
  //     signalsReady: true);
  runApp(LFG());
}

class LFG extends StatelessWidget {
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
