import 'package:fluent_ui/fluent_ui.dart';

class FriendsView extends StatefulWidget {
  const FriendsView({Key key}) : super(key: key);

  @override
  _FriendsViewState createState() => _FriendsViewState();
}

class _FriendsViewState extends State<FriendsView> {
//  final _textController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(color: Colors.blue),
      child: Column(
        //mainAxisSize: MainAxisSize.max,
        children: [Text("NavBar"), Text("Boubless")],
      ),
    );
  }
}
