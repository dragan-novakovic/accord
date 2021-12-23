import 'package:accord_front/src/models/RoomModel.dart';
import 'package:accord_front/src/models/UserModel.dart';
import 'package:accord_front/src/repositories/UserRepository.dart';
import 'package:accord_front/src/services/UserService.dart';
import 'package:rxdart/rxdart.dart';

class UserBloc {
  final _service = UserService(userRepository: UserRepository());
  final _userFetcher = PublishSubject<LoginUser>();

  Stream<LoginUser> get user => _userFetcher.stream;

  fetchUser() async {
    LoginUser user = await _service.loginUser();
    _userFetcher.sink.add(user);
  }

  dispose() {
    _userFetcher.close();
  }
}

final userBloc = UserBloc();
