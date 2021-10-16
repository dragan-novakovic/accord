import 'package:flutter/material.dart';

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
        child: Row(children: [
          Column(
            children: getRooms(),
          ),
          Center(child: Text('Select Room'))
        ]),
      ),
    );
  }
}

List<Widget> getRooms() {
  return [
    Container(child: Text('Room A')),
    Container(child: Text('Room B')),
    Container(child: Text('Room C'))
  ];
}
