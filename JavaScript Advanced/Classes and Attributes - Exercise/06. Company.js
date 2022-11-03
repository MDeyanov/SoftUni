class Company {
  constructor() {
    this.departmentsList = {};
  }

  addEmployee(username, salary, position, department) {
    if (!username || !position || !department || !salary || salary < 0) {
      throw new Error("Invalid input!");
    }

    if (!this.departmentsList[department]) {
      this.departmentsList[department] = [];
    }
    this.departmentsList[department].push({
      username,
      salary: Number(salary),
      position,
    });
    return `New employee is hired. Name: ${username}. Position: ${position}`;
  }

  bestDepartment() {
    let bestDep = "";
    let bestSum = 0;

    Object.entries(this.departmentsList).forEach(([dep, eList]) => {
      let sum = eList.reduce((acc, el) => {
        acc += el.salary;
        return acc;
      }, 0);
      sum = sum / eList.length;
      if (sum > bestSum) {
        bestSum = sum;
        bestDep = dep;
      }
    });

    if (bestDep != "") {
      let row = `Best Department is: ${bestDep}\nAverage salary: ${bestSum.toFixed(
        2
      )}\n`;
      this.departmentsList[bestDep]
        .sort(
          (a, b) => b.salary - a.salary || a.username.localeCompare(b.username)
        )
        .forEach(
          (emp) => (row += `${emp.username} ${emp.salary} ${emp.position}\n`)
        );
      return row.trim();
    }
  }
}