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
        child: Row(children: [RoomList(), Center(child: Text('Select Room'))]),
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
  return Column(
      children:
          rooms.map((room) => Container(child: Text(room.name))).toList());
}
