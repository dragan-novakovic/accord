import 'package:http/http.dart' as http;

class API {
  String _base = "http://localhost";
  Future<dynamic> get(String endpoint) async {
    try {
      var url = Uri.parse(_base + endpoint);
      http.Response response = await http.get(url);

      if (response.statusCode < 400) {
        return response.body;
      }
    } catch (e) {
      return print("Err" + e.toString());
    }
  }
}
