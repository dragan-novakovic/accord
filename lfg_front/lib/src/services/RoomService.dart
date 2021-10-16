import 'package:lfg_front/src/models/RoomModel.dart';
import 'package:lfg_front/src/utils/ApiService.dart';

class RoomService {
  Future<List<Room>> getRooms() async {
    return API().get('/rooms');
  }
}
