function solve(input) {
  let validMethod = ["GET", "POST", "DELETE", "CONNECT"];
  let validVersion = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];


  if (validMethod.includes(input.method) == false) {
    throw new Error("Invalid request header: Invalid Method");
  }

  let uriTest = /[^a-z0-9.]/gi;
  if (
    input.uri == "" ||
    uriTest.exec(input.uri) != null ||
    input.uri == undefined
  ) {
    if (input.uri != "*") {
      throw new Error("Invalid request header: Invalid URI");
    }
  }

  
  if (validVersion.includes(input.version) == false) {
    throw new Error("Invalid request header: Invalid Version");
  }

  let msgTest = /[\<\>\\\&\'\"]/g;
  if (msgTest.exec(input.message) != null || input.message == undefined) {
    if (input.message != "") {
      throw new Error("Invalid request header: Invalid Message");
    }
  }
  return input;
}