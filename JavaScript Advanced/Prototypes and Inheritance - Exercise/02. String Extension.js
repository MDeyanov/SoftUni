(function () {
  String.prototype.ensureStart = function (str) {
    return this.toString().startsWith(str)
      ? this.toString()
      : str + this.toString();
  };
  String.prototype.ensureEnd = function (str) {
    return this.toString().endsWith(str)
      ? this.toString()
      : this.toString() + str;
  };
  String.prototype.isEmpty = function () {
    return this.length === 0 ? true : false;
  };
  String.prototype.truncate = function (n) {
    let str = this.toString();

    if (str.length < 4) {
      return ".".repeat(n);
    }
    if (str.length <= n) {
      return str;
    }

    if (str.length > n) {
      str = str.substring(0, n);
    }

    str = str.substring(0, n - 2);

    if (!str.includes(" ")) {
      return str + "...";
    } else {
      return str.substring(0, str.lastIndexOf(" ")) + "...";
    }
  };
  String.format = function (str, ...params) {
    str = str.toString();
    params.map((el, loc) => {
      loc = "{" + loc;
      let reg = new RegExp(loc);
      // let reg = /\{`${loc}`\}/
      str = str.replace(reg, el);
      let fix = new RegExp("}");
      str = str.replace(fix, "");
    });
    return str;
  };
})();