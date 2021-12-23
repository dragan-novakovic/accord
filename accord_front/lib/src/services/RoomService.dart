import 'package:accord_front/src/models/ChannelModel.dart';
import 'package:accord_front/src/models/RoomModel.dart';
// import 'package:accord_front/src/utils/ApiService.dart';

class RoomService {
  Future<List<Room>> getRooms() async {
    // return API().get('/rooms');
    return Future.delayed(
        const Duration(seconds: 2),
        () => [
              Room("A room", [Channel("Ch: 01")]),
              Room("B room", [Channel("Ch: 02")]),
              Room("C room", [Channel("Ch: 03")])
            ]);
  }
}
