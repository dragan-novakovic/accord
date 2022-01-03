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
        leading: Text("The Icon"),
        // commandBar:
      ),
      content: Row(
        children: [renderChannels(), ChatView()],
      ),
    );
  }
}

renderChannels() {
  return Container(
    decoration: BoxDecoration(
      color: Color(0xff7c94b6),
    ),
    child: Column(
      children: [
        Text("Channel 1"),
        Text("Channel 2"),
        Text("Channel 3"),
        Text("Channel 4"),
        Text("Channel 5"),
        Text("Channel 6"),
        Text("Channel 7")
      ],
    ),
  );
}
