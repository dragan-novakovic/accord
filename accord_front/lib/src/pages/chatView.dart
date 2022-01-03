import 'package:fluent_ui/fluent_ui.dart';

class ChatView extends StatefulWidget {
  const ChatView({Key key}) : super(key: key);

  @override
  _ChatViewState createState() => _ChatViewState();
}

class _ChatViewState extends State<ChatView> {
//  final _textController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Column(
        children: [Text("NavBar"), Text("Boubless"), renderInputBox()],
      ),
    );
  }
}

// fix this
Widget renderInputBox() {
  return Expanded(
    child: TextBox(
      header: 'Message',
      placeholder: 'Type your message here',
    ),
  );
}
