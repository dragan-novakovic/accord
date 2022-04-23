import 'package:fluent_ui/fluent_ui.dart';

class ChatView extends StatefulWidget {
  const ChatView({Key key}) : super(key: key);

  @override
  _ChatViewState createState() => _ChatViewState();
}

class _ChatViewState extends State<ChatView> {
//  final _textController = TextEditingController();

  List<Map<String, String>> fakeData = [
    {
      "username": "Tester1",
      "msg":
          "Dobar dan, ovo je dugacak text koji se pise da bih popunio i testirao sirinu balon"
    },
    {
      "username": "Tester1",
      "msg":
          "Dobar dan, ovo je dugacak text koji se pise da bih popunio i testirao sirinu balon"
    },
    {
      "username": "Tester1",
      "msg":
          "Dobar dan, ovo je dugacak text koji se pise da bih popunio i testirao sirinu balon"
    },
    {
      "username": "Tester2",
      "msg":
          "Dobar dan, ovo je dugacak text koji se pise da bih popunio i testirao sirinu balon"
    },
    {
      "username": "Tester2",
      "msg":
          "Dobar dan, ovo je dugacak text koji se pise da bih popunio i testirao sirinu balon"
    },
    {
      "username": "Tester2",
      "msg":
          "Dobar dan, ovo je dugacak text koji se pise da bih popunio i testirao sirinu balon"
    },
    {
      "username": "Tester1",
      "msg":
          "Dobar dan, ovo je dugacak text koji se pise da bih popunio i testirao sirinu balon"
    },
    {
      "username": "Tester2",
      "msg":
          "Dobar dan, ovo je dugacak text koji se pise da bih popunio i testirao sirinu balon"
    },
  ];

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(color: Colors.green),
      child: Column(
        mainAxisSize: MainAxisSize.max,
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text("NavBar"),
          renderBubbles(fakeData),
          renderInputBox(context)
        ],
      ),
    );
  }
}

Widget renderBubbles(List<Map<String, String>> data) {
  List<Widget> babbles = data.map((el) {
    return Row(
      mainAxisAlignment: el["username"][6] == "1"
          ? MainAxisAlignment.end
          : MainAxisAlignment.start,
      children: el["username"][6] == "2"
          ? [
              CircleAvatar(
                  backgroundImage: NetworkImage(
                      "https://ui-avatars.com/api/?name=John+${el["username"][6]}"),
                  backgroundColor: Colors.transparent),
              Container(
                  margin: EdgeInsets.all(10.0),
                  decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(10),
                  ),
                  padding: EdgeInsets.all(20.0),
                  child: Text(el["msg"])),
            ]
          : [
              Container(
                  margin: EdgeInsets.all(10.0),
                  decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(10),
                  ),
                  padding: EdgeInsets.all(20.0),
                  child: Text(el["msg"])),
              CircleAvatar(
                  backgroundImage: NetworkImage(
                      "https://ui-avatars.com/api/?name=John+${el["username"][6]}"),
                  backgroundColor: Colors.transparent),
            ],
    );
  }).toList();

  return Container(
    child: Column(
      children: babbles,
    ),
  );
}

Widget renderInputBox(context) {
  return Container(
    margin: EdgeInsets.symmetric(horizontal: 18.0, vertical: 10.0),
    height: 60.0,
    child: TextBox(
      textAlign: TextAlign.start,
      suffix: Button(
        child: Icon(FluentIcons.send),
        onPressed: () {},
      ),
      prefix: Button(
        child: Icon(FluentIcons.add_to),
        onPressed: () {},
      ),
      header: "Send Message",
      placeholder: 'Type your message here...',
    ),
  );
}
