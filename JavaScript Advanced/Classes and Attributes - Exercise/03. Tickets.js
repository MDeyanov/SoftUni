function solve(info, sortOrder) {
  class Ticket {
    constructor(dest, price, status) {
      (this.destination = dest),
        (this.price = Number(price)),
        (this.status = status);
    }
  }
  let result = [];

  info.map((item) => {
    result.push(new Ticket(...item.split("|")));
  });

  if (sortOrder === "price") {
    result.sort((a, b) => a[sortOrder] - b[sortOrder]);
  } else {
    result.sort((a, b) => a[sortOrder].localeCompare(b[sortOrder]));
  }
  return result;
}