class List {
  constructor() {
    this.list = [];
    this.size = this.list.length;
  }

  add(num) {
    this.list.push(num);
    this.list.sort((a, b) => a - b);
    this.size = this.list.length;
  }

  remove(index) {
    if (index >= 0 && index < this.list.length) {
      this.list.splice(index, 1);
      this.list.sort((a, b) => a - b);
      this.size = this.list.length;
    } else {
      throw new Error("Invalid Index");
    }
  }

  get(index) {
    if (index >= 0 && index < this.list.length) {
      return this.list[index];
    } else {
      throw new Error("Invalid Index");
    }
  }
}