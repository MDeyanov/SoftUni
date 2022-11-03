function solve() {
  let obj = {
    extend(template) {
      let methods = {};
      let props = {};
      for (const key in template) {
        if (typeof template[key] === "function") {
          methods[key] = template[key];
        } else {
          props[key] = template[key];
        }
      }

      Object.assign(this, props);
      Object.assign(Object.getPrototypeOf(this), methods);
    },
  };

  return obj;
}
