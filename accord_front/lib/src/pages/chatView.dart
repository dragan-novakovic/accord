import 'package:flutter/widgets.dart';

class ChatView extends StatefulWidget {
  const ChatView({Key key}) : super(key: key);

  @override
  _ChatViewState createState() => _ChatViewState();
}

class _ChatViewState extends State<ChatView> {
  @override
  Widget build(BuildContext context) {
    return Container(
      child: Column(
        children: [
          Text("Avatar ||| Text Box"),
          Text("MessageBar ( input  + enter")
        ],
      ),
    );
  }
}
