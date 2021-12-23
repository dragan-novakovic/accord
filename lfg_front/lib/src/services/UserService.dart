import 'dart:async';
import 'package:accord_front/src/models/UserModel.dart';
import 'package:accord_front/src/repositories/UserRepository.dart';
import 'package:meta/meta.dart';

class UserService {
  final UserRepository userRepository;

  UserService({@required this.userRepository}) : assert(userRepository != null);

  Future<LoginUser> loginUser() async {
    return userRepository.loginUser();
  }
}
