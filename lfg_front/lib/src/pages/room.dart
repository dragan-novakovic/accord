import 'package:fluent_ui/fluent_ui.dart';
import 'package:accord_front/src/bloc/RoomBloc.dart';
import 'package:accord_front/src/models/RoomModel.dart';
// import 'package:accord_front/src/pages/channel.dart';

class RoomsPage extends StatefulWidget {
  const RoomsPage({Key key}) : super(key: key);

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
      content: Container(
        child: Row(children: [RoomList()]),
      ),
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
            return RoomItems(rooms: snapshot.data);
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

  const RoomItems({Key key, @required this.rooms}) : super(key: key);

  @override
  State<RoomItems> createState() => _RoomItemsState();
}

class _RoomItemsState extends State<RoomItems> {
  int index = 0;

  @override
  Widget build(BuildContext build) {
    return NavigationView(
      appBar: NavigationAppBar(
        title: Text('Nice App Title :)'),
        actions: Row(children: []),
        automaticallyImplyLeading: true,
      ),
      pane: NavigationPane(
        selected: index,
        items: this.widget.rooms.map((room) {
          return PaneItem(
            icon: Icon(FluentIcons.inbox),
            title: Text(room.name),
            infoBadge: InfoBadge(
              source: Text('9'),
            ),
          );
        }).toList(),
        onChanged: (i) => setState(() => index = i),
        displayMode: PaneDisplayMode.auto,
      ),
    );
  }
}
