class Stringer {
  constructor(str, length) {
    this.innerString = str;
    this.innerLength = length;
  }

  decrease(num) {
    this.innerLength -= num;
    if (this.innerLength < 0) {
      this.innerLength = 0;
    }
  }

  increase(num) {
    this.innerLength += num;
  }

  toString() {
    if (this.innerString.length <= this.innerLength) {
      return this.innerString;
    } else {
      let result = this.innerString.slice(0, this.innerLength);
      return result + "...";
    }
  }
}