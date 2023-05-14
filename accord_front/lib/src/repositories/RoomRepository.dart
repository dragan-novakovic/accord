import 'dart:async';
import 'package:accord_front/src/services/RoomService.dart';

import '../models/RoomModel.dart';

class RoomRepository {
  final RoomService roomService;

  RoomRepository({required this.roomService});

  Future<List<Room>> getRooms() async {
    return roomService.getRooms();
  }
}
