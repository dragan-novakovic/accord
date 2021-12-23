import 'package:fluent_ui/fluent_ui.dart';
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
    return FluentApp(
      title: 'Accord',
      theme: ThemeData(
          scaffoldBackgroundColor: Colors.white,
          accentColor: Colors.blue,
          iconTheme: const IconThemeData(size: 24)),
      darkTheme: ThemeData(
          scaffoldBackgroundColor: Colors.black,
          accentColor: Colors.blue,
          iconTheme: const IconThemeData(size: 24)),
      home: RoomsPage(),
    );
  }
}
