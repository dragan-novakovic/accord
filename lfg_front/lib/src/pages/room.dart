import 'package:flutter/material.dart';
import 'package:lfg_front/src/bloc/RoomBloc.dart';

class RoomsPage extends StatefulWidget {
  const RoomsPage({Key key}) : super(key: key);

  @override
  _RoomsPageState createState() => _RoomsPageState();
}

class _RoomsPageState extends State<RoomsPage> {
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
    bloc.fetchAllRooms();

    return getRooms();
  }
}

Widget getRooms() {
  return Column(children: [
    Container(child: Text('Room A')),
    Container(child: Text('Room B')),
    Container(child: Text('Room C'))
  ]);
}
