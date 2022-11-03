function validate() {
  let mail = document.querySelector("#email");
  mail.addEventListener("change", (e) => {
    let infoStr = e.target.value;
    let test = /[a-z]+@[a-z]+\.[a-z]+/g;

    if (test.exec(infoStr) === null) {
      e.target.classList.add("error");
    } else {
      e.target.classList.remove("error");
    }
  });
}