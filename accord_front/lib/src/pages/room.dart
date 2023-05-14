import 'package:fluent_ui/fluent_ui.dart';
import 'package:accord_front/src/bloc/RoomBloc.dart';
import 'package:accord_front/src/models/RoomModel.dart';
import 'package:accord_front/src/pages/channel.dart';

class RoomsPage extends StatefulWidget {
  const RoomsPage({Key? key}) : super(key: key);

  @override
  _RoomsPageState createState() => _RoomsPageState();
}

class _RoomsPageState extends State<RoomsPage> {
  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return ScaffoldPage(
      content: RoomList(),
    );
  }
}

class RoomList extends StatefulWidget {
  @override
  State<RoomList> createState() => _RoomListState();
}

class _RoomListState extends State<RoomList> {
  @override
  Widget build(BuildContext context) {
    roomBloc.fetchAllRooms();

    return StreamBuilder(
        stream: roomBloc.allRooms,
        builder: (context, AsyncSnapshot<List<Room>> snapshot) {
          if (snapshot.hasData) {
            return RoomItems(rooms: snapshot.data as List<Room>);
          }

          if (snapshot.hasError) {
            return Text(snapshot.error.toString());
          }
          return Center(child: ProgressRing());
        });
  }
}

class RoomItems extends StatefulWidget {
  final List<Room> rooms;

  const RoomItems({Key? key, required this.rooms}) : super(key: key);

  @override
  State<RoomItems> createState() => _RoomItemsState();
}

class _RoomItemsState extends State<RoomItems> {
  int index = 0;

  @override
  Widget build(BuildContext build) {
    return NavigationView(
      appBar: NavigationAppBar(
        title: Text('ACCORD'),
        actions: Row(mainAxisAlignment: MainAxisAlignment.end, children: [
          Icon(FluentIcons.account_browser),
          Icon(FluentIcons.add_bookmark),
          Icon(FluentIcons.settings),
        ]),
        automaticallyImplyLeading: true,
      ),
      pane: NavigationPane(
        size: NavigationPaneSize(openWidth: 180),
        selected: index,
        items: getPaneItems(this.widget.rooms),
        onChanged: (i) => setState(() => index = i),
        displayMode: PaneDisplayMode.auto,
      ),
      // content: ScaffoldPage(
      //  // content: ChannelView(),
      // ),
    );
  }
}

List<NavigationPaneItem> getPaneItems(List<Room> rooms) {
  return rooms
      .map((room) => PaneItem(
            body: Container(child: Text("XX"),),
            icon: Icon(FluentIcons.caret_right),
            title: Text(room.name),
            infoBadge: const InfoBadge(
              source: Text('9'),
            ),
          ))
      .toList()
      .cast<NavigationPaneItem>();
}
