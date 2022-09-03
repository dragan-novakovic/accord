import 'package:accord_front/src/pages/FriendsView.dart';
import 'package:fluent_ui/fluent_ui.dart';
import 'package:accord_front/src/pages/chatView.dart';

class ChannelView extends StatefulWidget {
  const ChannelView({Key key}) : super(key: key);

  @override
  _ChannelViewState createState() => _ChannelViewState();
}

class _ChannelViewState extends State<ChannelView> {
  @override
  Widget build(BuildContext context) {
    return ScaffoldPage(
      header: PageHeader(
        title: Text("Room A"),
        // leading: Text("IDK"),
        // commandBar:
      ),
      content: Row(
        mainAxisSize: MainAxisSize.max,
        children: [
          renderChannels(),
          Flexible(
            child: ChatView(),
            fit: FlexFit.tight,
          ),
          FriendsView()
        ],
      ),
    );
  }
}

renderChannels() {
  return Container(
    decoration: BoxDecoration(
      color: Colors.grey[30],
    ),
    child: Column(
      children: [
        renderChannel("Kanal 1"),
        renderChannel("Kanal 2"),
        renderChannel("Kanal 3"),
        renderChannel("Kanal 4"),
      ],
    ),
  );
}

Widget renderChannel(String text) {
  return Container(
    child: Row(
      children: [
        Padding(
          padding: const EdgeInsets.all(8.0),
          child: Icon(
            FluentIcons.message,
            size: 10,
          ),
        ),
        Padding(
          padding: const EdgeInsets.all(12.0),
          child: Text(text),
        )
      ],
    ),
  );
}
