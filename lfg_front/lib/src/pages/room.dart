import 'package:flutter/material.dart';
import 'package:lfg_front/src/bloc/RoomBloc.dart';
import 'package:lfg_front/src/models/RoomModel.dart';

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
    return Scaffold(
      body: Container(
        child: Row(children: [RoomList(), showRoom(null)]),
      ),
    );
  }
}

class RoomList extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    roomBloc.fetchAllRooms();

    return StreamBuilder(
        stream: roomBloc.allRooms,
        builder: (context, AsyncSnapshot<List<Room>> snapshot) {
          if (snapshot.hasData) {
            return getRooms(snapshot.data);
          }

          if (snapshot.hasError) {
            return Text(snapshot.error.toString());
          }

          return Center(child: CircularProgressIndicator());
        });
  }
}

Widget getRooms(List<Room> rooms) {
  return Container(
    child: Column(
        children: rooms
            .map((room) => Container(
                padding: EdgeInsets.only(left: 10.0, top: 20.0),
                child: Row(
                  children: [
                    CircleAvatar(
                      backgroundColor: Colors.grey,
                    ),
                    Text(room.name),
                  ],
                )))
            .toList()),
  );
}

Widget showRoom(String selected) {
  if (selected != null) {
    return Text(selected);
  }

  return Text("Select Room");
}
