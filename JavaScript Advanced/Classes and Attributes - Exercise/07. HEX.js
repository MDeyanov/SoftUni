class Hex {
  constructor(num) {
    this.value = Number(num);
  }

  valueOf() {
    return this.value;
  }

  plus(num) {
    let temp = 0;
    if (typeof num === "number") {
      temp = this.value + num;
    } else {
      temp = this.value + num.value;
    }
    return new Hex(temp);
  }

  minus(num) {
    let temp = 0;
    if (typeof num === "number") {
      temp = this.value - num;
    } else {
      temp = this.value - num.value;
    }
    return new Hex(temp);
  }

  parse(str) {
    return parseInt(str, 16);
  }

  toString() {
    return `0x${this.value.toString(16).toUpperCase()}`;
  }
}