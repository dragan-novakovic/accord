import 'package:lfg_front/src/models/ChannelModel.dart';
import 'package:lfg_front/src/models/RoomModel.dart';
import 'package:lfg_front/src/utils/ApiService.dart';

class RoomService {
  Future<List<Room>> getRooms() async {
    // return API().get('/rooms');
    return [
      Room("A", [Channel("Ch: 01")]),
      Room("B", [Channel("Ch: 02")]),
      Room("C", [Channel("Ch: 03")])
    ];
  }
}
