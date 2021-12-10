import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:lfg_front/src/pages/chatView.dart';

class ChannelView extends StatefulWidget {
  const ChannelView({Key key}) : super(key: key);

  @override
  _ChannelViewState createState() => _ChannelViewState();
}

class _ChannelViewState extends State<ChannelView> {
  @override
  Widget build(BuildContext context) {
    return Container(
      color: Colors.amber,
      child: Column(
        children: [
          Text("NavBar - Icon (Name) |||||| notifications account search bar"),
          ChatView()
        ],
      ),
    );
  }
}
