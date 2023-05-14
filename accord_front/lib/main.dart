import 'package:accord_front/src/pages/room.dart';
import 'package:fluent_ui/fluent_ui.dart';
import 'package:get_it/get_it.dart';

// This is our global ServiceLocator
GetIt getIt = GetIt.instance;

void main() {
  runApp(LFG());
}

class LFG extends StatefulWidget {
  @override
  State<LFG> createState() => _LFGState();
}

class _LFGState extends State<LFG> {
  @override
  Widget build(BuildContext context) {
    return FluentApp(
      title: 'Accord',
      theme: FluentThemeData(
          scaffoldBackgroundColor: Colors.white,
          accentColor: Colors.blue,
          iconTheme: const IconThemeData(size: 24)),
          debugShowCheckedModeBanner: false,
      home: RoomsPage(),
    );
  }
}
