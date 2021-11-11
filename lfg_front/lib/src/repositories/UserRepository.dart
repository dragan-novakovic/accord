import 'package:lfg_front/src/models/UserModel.dart';

class UserRepository {
  Future<LoginUser> loginUser() async {
    // return API().get('/rooms');
    return Future.delayed(
        const Duration(seconds: 2), () => LoginUser("123", "admin", "jwt"));
  }
}
