import 'package:lfg_front/src/models/ChannelModel.dart';

class Room {
  Room(this.name, this.channelList);

  final String name;
  final List<Channel> channelList;
}
