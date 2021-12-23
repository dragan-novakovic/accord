import 'ChannelModel.dart';
import 'RoomModel.dart';

class User {
  User(this.username, this.email, this.roomList, this.channelList);
  final String username;
  final String email;
  final List<Room> roomList;
  final List<Channel> channelList;
}

class LoginUser {
  LoginUser(this.id, this.username, this.token);
  final String id;
  final String username;
  final String token;
}
