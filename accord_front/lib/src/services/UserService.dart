import 'dart:async';
import 'package:accord_front/src/models/UserModel.dart';
import 'package:accord_front/src/repositories/UserRepository.dart';

class UserService {
  final UserRepository userRepository;

  UserService({required this.userRepository});

  Future<LoginUser> loginUser() async => userRepository.loginUser();
}
