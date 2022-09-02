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
      decoration: BoxDecoration(color: Colors.grey[30]),
      child: Column(
          //mainAxisSize: MainAxisSize.max,
          children: [
            Text(
              "Online - 2",
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
            Padding(
              padding: const EdgeInsets.fromLTRB(20.0, 10, 20, 20),
              child: Row(children: [
                CircleAvatar(
                    backgroundImage:
                        NetworkImage("https://ui-avatars.com/api/?name=John"),
                    backgroundColor: Colors.transparent),
                Text("John Doe")
              ]),
            ),
            Padding(
              padding: const EdgeInsets.fromLTRB(20.0, 10, 20, 20),
              child: Row(children: [
                CircleAvatar(
                    backgroundImage:
                        NetworkImage("https://ui-avatars.com/api/?name=John"),
                    backgroundColor: Colors.transparent),
                Text("John Doe")
              ]),
            ),
            Text(
              "Offline",
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
            Padding(
              padding: const EdgeInsets.fromLTRB(20.0, 10, 20, 20),
              child: Row(children: [
                CircleAvatar(
                    backgroundImage:
                        NetworkImage("https://ui-avatars.com/api/?name=John"),
                    backgroundColor: Colors.transparent),
                Text("John Doe")
              ]),
            ),
            Row(children: [
              CircleAvatar(
                  backgroundImage:
                      NetworkImage("https://ui-avatars.com/api/?name=John"),
                  backgroundColor: Colors.transparent),
              Text("John Doe")
            ])
          ]),
    );
  }
}
