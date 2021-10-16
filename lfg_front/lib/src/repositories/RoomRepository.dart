import 'dart:async';
import 'package:lfg_front/src/services/RoomService.dart';
import 'package:meta/meta.dart';

import '../models/RoomModel.dart';

class RoomRepository {
  final RoomService roomService;

  RoomRepository({@required this.roomService}) : assert(roomService != null);

  Future<List<Room>> getRooms() async {
    return roomService.getRooms();
  }
}
