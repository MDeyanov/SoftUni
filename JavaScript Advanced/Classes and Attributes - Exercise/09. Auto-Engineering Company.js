function solve(input) {
  let list = input.reduce((acc, el) => {
    let [manufacturer, model, producedCount] = el.split(" | ");

    if (!acc.hasOwnProperty(manufacturer)) {
      acc[manufacturer] = {};
    }

    if (!acc[manufacturer].hasOwnProperty(model)) {
      acc[manufacturer][model] = 0;
    }

    acc[manufacturer][model] += Number(producedCount);

    return acc;
  }, {});

  return Object.entries(list)
    .reduce((acc, el) => {
      let [make, rest] = el;
      acc += `${make}\n`;
      acc += Object.entries(rest).reduce((a, e) => {
        a += `###${e[0]} -> ${e[1]}\n`;
        return a;
      }, "");
      return acc;
    }, "")
    .trim();
}