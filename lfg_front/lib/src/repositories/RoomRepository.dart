import 'dart:async';
import 'package:lfg_front/src/services/RoomService.dart';
import 'package:meta/meta.dart';

import '../models/RoomModel.dart';

class RoomRepository {
  final RoomService weatherApiClient;

  RoomRepository({@required this.weatherApiClient})
      : assert(weatherApiClient != null);

  Future<Room> getWeather(String city) async {}
}
