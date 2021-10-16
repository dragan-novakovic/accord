import 'package:lfg_front/src/models/RoomModel.dart';
import 'package:lfg_front/src/repositories/RoomRepository.dart';
import 'package:lfg_front/src/services/RoomService.dart';
import 'package:rxdart/rxdart.dart';

class RoomBloc {
  final _repository = RoomRepository(roomService: RoomService());
  final _roomsFetcher = PublishSubject<List<Room>>();

  Stream<List<Room>> get allRooms => _roomsFetcher.stream;

  fetchAllRooms() async {
    List<Room> rooms = await _repository.getRooms();
    _roomsFetcher.sink.add(rooms);
  }

  dispose() {
    _roomsFetcher.close();
  }
}

final bloc = RoomBloc();
