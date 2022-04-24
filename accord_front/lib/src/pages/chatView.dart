import 'package:fluent_ui/fluent_ui.dart';
import 'package:signalr_netcore/signalr_client.dart';

class ChatView extends StatefulWidget {
  const ChatView({Key key}) : super(key: key);

  @override
  _ChatViewState createState() => _ChatViewState();
}

class _ChatViewState extends State<ChatView> {
  TextEditingController _textController = TextEditingController();
  final String serverURL = "http://localhost:5207/chat";
  HubConnection hubConnection;
  List<Map<String, String>> serverData = [
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
      "username": "Tester1",
      "msg":
          "Dobar dan, ovo je dugacak text koji se pise da bih popunio i testirao sirinu balon"
    }
  ];

  @override
  void initState() {
    super.initState();
    initSignalR();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(color: Colors.green),
      child: Column(
        mainAxisSize: MainAxisSize.max,
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text("NavBar"),
          SingleChildScrollView(
            child: ConstrainedBox(
              child: renderBubbles(serverData),
              constraints: BoxConstraints(maxHeight: 200.0),
            ),
          ),
          renderInputBox(context)
        ],
      ),
    );
  }

  void initSignalR() async {
    hubConnection = HubConnectionBuilder()
        .withUrl(serverURL,
            options: new HttpConnectionOptions(
                skipNegotiation: true, transport: HttpTransportType.WebSockets))
        .build();
    print(hubConnection.state);
    hubConnection.onclose(({error}) {
      print('Connection close ${error.toString()}');
    });
    hubConnection.on("receive", (arguments) {
      arguments.forEach((element) {
        serverData.add({"username": "Tester1", "msg": element});
      });
    });
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
        controller: _textController,
        textAlign: TextAlign.start,
        suffix: Button(
          child: Icon(FluentIcons.send),
          onPressed: () async {
            await hubConnection.start();
            if (hubConnection.state == HubConnectionState.Connected) {
              await hubConnection
                  .invoke('send', args: <String>[_textController.text]);
            }
          },
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
}
